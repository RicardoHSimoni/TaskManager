using System;
using System.Reflection;
using TaskManager.Business;
using TaskManager.Models;
using TaskManager.UI.ConsoleApp.Menus;
using TaskManager.Persistence;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;
using System.Threading.Tasks;

namespace TaskManager.UI.ConsoleApp.Register;

public class RegisterLabor
{

    public void NewLabor(){
        var aux = new PrincipalMenu();
        Console.WriteLine("Informe o nome da tarefa: ");
        string title = Console.ReadLine();
        Console.WriteLine("Informe uma descrição(opcional): ");
        string description = Console.ReadLine();
        Console.WriteLine("Informe a data(formato DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine()).Date;
        Priority priority = GetPriority();
        Category category = GetCategory().Result;

        if(aux.IsSimple()){
            var simpleLabor = new SimpleLabor(title,description,date,priority,category);
            Console.WriteLine(simpleLabor);
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        else{

            var recurringLabor = new RecurringLabor();
        } 
        
        
    }

    public Priority GetPriority(){
        while(true){
            Console.WriteLine("\nQual a prioridade dessa tarefa: [1]- Alta [2]-Média [3]-Alta");
            string userOption = Console.ReadLine();
            switch(userOption){
                case "1":
                    return Priority.Alta;
                case "2":
                    return Priority.Média;
                case "3":
                    return Priority.Baixa;
                default:
                    Console.WriteLine("\nOpção inválida");
                break;
            }
        }
    }

    public async Task<Category> GetCategory(){
        var service = new CategoryService();
        service.ShowCategories();
        Console.WriteLine("\nDigite o Id da Categoria para incluir a tarefa: ");
        int iD = int.Parse(Console.ReadLine());

        var category = new Category();
        var context = new TaskManagerEFContext();
        var categoryRepository = new GenericRepository<Category>(context);
        category = await categoryRepository.GetByIdAsync(iD);
        return category;
        
    }
}
