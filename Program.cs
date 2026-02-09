using ToDoList.Models;

string option;
TaskList taskList = new TaskList();


do {


Console.WriteLine("Task Tracker Application");
Console.WriteLine("------------------------");
Console.WriteLine("Options:");
Console.WriteLine("1. Adicionar nova tarefa");
Console.WriteLine("2. Listar todas as tarefas");
Console.WriteLine("3. Listar por status");
Console.WriteLine("4. Atualizar status da tarefa");
Console.WriteLine("5. Remover uma tarefa");
Console.WriteLine("0. Sair");
Console.WriteLine("------------------------");
Console.Write("");


    option = Console.ReadLine()!;
    switch (option)
    {
        case "1":
            Console.WriteLine("Adicionando nova tarefa...");
            Console.WriteLine("digite a nova tarefa:");
            string conteudo = Console.ReadLine()!;


            Console.WriteLine("Escolha o status:");
            Console.WriteLine("0 - Todo");
            Console.WriteLine("1 - InProgress");
            Console.WriteLine("2 - Done");

             TaskSituation status;
            while (!Enum.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Status inválido, tente novamente:");
            }

            taskList.AdicionarTask(conteudo, status);
            Console.WriteLine("Tarefa adicionada!");
            break;


        case "2":
            Console.WriteLine("Listando todas as tarefas...");
            foreach (var t in taskList.ListarTodas())
            {
                Console.WriteLine($"ID: {t.Id} | Conteúdo: {t.Conteudo} | Status: {t.Status}");
                Console.WriteLine();
            }
            
            break;


        case "3":
            Console.WriteLine("Listando tarefas por status...");
            Console.WriteLine("Filtrar por status (0 Todo | 1 InProgress | 2 Done):");
            if (Enum.TryParse(Console.ReadLine(), out TaskSituation filtro))
            {
                var tarefas = taskList.ListarPorStatus(filtro);
                foreach (var t in tarefas)
                {
                    Console.WriteLine($"{t.Id} - {t.Conteudo} [{t.Status}]");
                      Console.WriteLine();
                }
            }
            break;

        case "4":
            Console.WriteLine("Atualizando status da tarefa...");
            Console.WriteLine("Digite o ID da tarefa:");

             int idUpdate = int.Parse(Console.ReadLine()!);

            Console.Write("Novo status (0 Todo | 1 InProgress | 2 Done): ");
            TaskSituation novoStatus = (TaskSituation)int.Parse(Console.ReadLine()!);

            Console.WriteLine(
                taskList.AtualizarStatus(idUpdate, novoStatus)
                ? "Status atualizado!"
                : "Tarefa não encontrada."
            );
            break;

        case "5":
            Console.WriteLine("Removendo uma tarefa...");
            Console.WriteLine("Digite o ID da tarefa a ser removida:");
            int idRemove = int.Parse(Console.ReadLine()!);


            Console.WriteLine(
                taskList.RemoverTask(idRemove)
                ? "Tarefa removida!"
                : "Tarefa não encontrada."
            );
            break;

        case "0":
            Console.WriteLine("Saindo da aplicação...");
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
while (option != "0");







