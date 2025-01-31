using System;
using System.Threading.Tasks;
using TaskManager.Business;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.UI.ConsoleApp.Register;

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
            Console.WriteLine("3. Adicionar categoria");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var register = new RegisterLabor();
                    register.NewLabor();
                    break;
                case "2":
                    var view =  new ViewMenu();

                    await view.ShowViewMenu();
                    

                    break;
                case "3":
                    var aux1 =  new RegisterCategory();

                    aux1.NewCategory();
                    
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
