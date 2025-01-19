using System;
using System.Threading.Tasks;
using TaskManager.Business;

namespace TaskManager.UI.ConsoleApp.Menus;

public class PrincipalMenu
{
      public async Task ShowPrincipalMenu(){
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
                    var aux =  new CategoryService();

                    await aux.GetCategories();
                    

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

    public bool SimpleOrRecurring(){
        bool continuar = true;
        string option = "";
        while(continuar){
            Console.WriteLine("\nA tarefa será simples ou recorrente? Digite 1 para adicionar recorrência ou 0 para tarefa simples: ");
            option = Console.ReadLine();

            if(option == "1" || option == "0")
                continuar = false;
        }
        if(option == "1")
            return true;
        return false;
    }
}