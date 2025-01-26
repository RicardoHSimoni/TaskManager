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
            Console.WriteLine("2. Listar Categorias");
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
                    var aux =  new CategoryService();

                    await aux.ShowCategories();
                    

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

    public bool IsSimple(){
        bool continuar = true;
        string option = "";
        while(continuar){
            Console.WriteLine("\nA tarefa será simples ou recorrente? Digite 1 para adicionar recorrência ou 2 para tarefa simples: ");
            option = Console.ReadLine();

            if(option == "1" || option == "2")
                continuar = false;
        }
        if(option == "1")
            return false;
        return true;
    }
}
