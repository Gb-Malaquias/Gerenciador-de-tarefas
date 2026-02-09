namespace ToDoList.Models;

public enum TaskSituation
{
    Todo,
    InProgress,
    Done
}

public class TaskItem
{
    public int Id { get; set; }
    public string Conteudo { get; set; } = string.Empty;
    public TaskSituation Status { get; set; }

    public TaskItem() {}

    public TaskItem(int id, string conteudo, TaskSituation taskSituation)
    {
        Id = id;
        Conteudo = conteudo;
        Status = taskSituation;
    }

}