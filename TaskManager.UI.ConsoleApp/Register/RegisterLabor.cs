using System;
using System.Reflection;
using TaskManager.Business;
using TaskManager.Models;
using TaskManager.UI.ConsoleApp.Menus;
using TaskManager.Persistence;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;
using System.Threading.Tasks;
using TaskManager.UI.ConsoleApp.GenericMethods;

namespace TaskManager.UI.ConsoleApp.Register;

public class RegisterLabor
{
    public void NewLabor()
    {
        var register = new LaborService();
        var context = new TaskManagerEFContext();
        var utils = new Utils();

        //Coleta de dados base
        Console.WriteLine("Informe o nome da tarefa: ");
        string title = Console.ReadLine();
        Console.WriteLine("Informe uma descrição(opcional): ");
        string description = Console.ReadLine();
        Console.WriteLine("Informe a data(formato DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine()).Date;
        Priority priority = utils.GetPriority();
        Category category = GetCategoryAsync(context).Result;
        Console.WriteLine("Categoria escolhida: " + category);

        if (utils.IsSimple())
        {
            var simpleLabor = new SimpleLabor(title, description, date, priority, category);
            register.RegisterSimpleLabor(context, simpleLabor);
        }
        else
        {
            Recurence recurence = utils.GetRecurence();
            var recurringLabor = new RecurringLabor(title, description, date, priority, category, recurence);
            register.RegisterRecurringLabor(context, recurringLabor);

        }
    }

    public async Task<Category> GetCategoryAsync(TaskManagerEFContext context){
        var service = new CategoryService();
        var repository = new GenericRepository<Category>(context);
        int id;
        while(true){
            await service.ShowCategories();
            Console.WriteLine("Digite o Id da Categoria para incluir a tarefa ou digite 0 para cadastrar uma nova: ");
            string input = Console.ReadLine();
            if(input == "0"){
                var registerCategory =  new RegisterCategory();
                registerCategory.NewCategory();
            }
            else if(!string.IsNullOrWhiteSpace(input)){
                id = int.Parse(input);
                var category = await repository.GetByIdAsync(id);
                if(category != null)
                    return category;
                else
                    Console.WriteLine("Categoria inválida. Tente novamente");
            }
            else
                Console.WriteLine("Entrada inválida");
        }
    }
   

   


  
}
