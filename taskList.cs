using System.Text.Json;
using ToDoList.Models;
using System.Linq;

namespace ToDoList.Models;

class TaskList
{
    private const string FilePath = "tasks.json";
    private List<TaskItem> AllTaskList = new();

    public TaskList()
    {
        LoadFromJson();
    }

    public TaskItem AdicionarTask(string conteudo, TaskSituation TaskSituation)
    {
        int novoId = AllTaskList.Count == 0
            ? 1
            : AllTaskList.Max(t => t.Id) + 1;



        var task = new TaskItem(novoId, conteudo, TaskSituation);
        AllTaskList.Add(task);

        SaveToJson();
        return task;
    }

    public List<TaskItem> ListarTodas()
    {
        return AllTaskList;
    }

    private void LoadFromJson()
    {
        if (!File.Exists(FilePath))
        {
            AllTaskList = new List<TaskItem>();
            return;
        }

        string json = File.ReadAllText(FilePath);
        AllTaskList = JsonSerializer.Deserialize<List<TaskItem>>(json)
                      ?? new List<TaskItem>();
    }

    private void SaveToJson()
    {
        var json = JsonSerializer.Serialize(
            AllTaskList,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(FilePath, json);
    }


    public bool RemoverTask(int id)
    {
        var task = AllTaskList.Find(t => t.Id == id);
        if (task == null) return false;
        

            AllTaskList.Remove(task);
            SaveToJson();
            return true;
        }
    

    public bool AtualizarStatus(int id, TaskSituation novoStatus)
    {
        var task = AllTaskList.Find(t => t.Id == id);
        if (task == null) return false;
        else
        {
            task.Status = novoStatus;
            SaveToJson();
            return true;
        }
    }

    public List<TaskItem> ListarPorStatus(TaskSituation status)
    {
    return AllTaskList
        .Where(t => t.Status == status)
        .ToList();
    }
}


