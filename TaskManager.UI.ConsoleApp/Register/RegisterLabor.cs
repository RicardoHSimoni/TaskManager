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
        Category category = utils.GetCategoryAsync(context).Result;
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

  
   

   


  
}
