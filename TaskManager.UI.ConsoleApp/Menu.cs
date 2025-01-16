using System;

namespace TaskManager.UI.ConsoleApp;

public class Menu
{
     public void ShowMenu(){
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Tarefas");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    //AdicionarTarefa();
                    break;
                case "2":
                    //gerenciador.ListarTarefas();
                    break;
                case "3":
                    //MarcarTarefaComoConcluida();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
