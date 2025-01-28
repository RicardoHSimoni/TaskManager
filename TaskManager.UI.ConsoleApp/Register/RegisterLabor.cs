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
    public void NewLabor()
    {
        var aux = new PrincipalMenu();
        var register = new LaborService();
        var context = new TaskManagerEFContext();

        //Coleta de dados base
        Console.WriteLine("Informe o nome da tarefa: ");
        string title = Console.ReadLine();
        Console.WriteLine("Informe uma descrição(opcional): ");
        string description = Console.ReadLine();
        Console.WriteLine("Informe a data(formato DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine()).Date;
        Priority priority = GetPriority();
        Category category = GetCategoryAsync(context).Result;
        Console.WriteLine("Categoria escolhida: " + category);

        if (aux.IsSimple())
        {
            var simpleLabor = new SimpleLabor(title, description, date, priority, category);
            register.RegisterSimpleLabor(context, simpleLabor);
        }
        else
        {
            Recurence recurence = GetRecurence();
            var recurringLabor = new RecurringLabor(title, description, date, priority, category, recurence);
            register.RegisterRecurringLabor(context, recurringLabor);

        }
    }

    public Priority GetPriority(){
        while(true){
            Console.WriteLine("Qual a prioridade dessa tarefa: [1]- Alta [2]-Média [3]-Baixa");
            string userOption = Console.ReadLine();
            switch(userOption){
                case "1":
                    return Priority.Alta;
                case "2":
                    return Priority.Média;
                case "3":
                    return Priority.Baixa;
                default:
                    Console.WriteLine("Opção inválida");
                break;
            }
        }
    }

    public async Task<Category> GetCategoryAsync(TaskManagerEFContext context){
        var service = new CategoryService();
        var repository = new GenericRepository<Category>(context);
        int id;
        await service.ShowCategories();
        while(true){
            Console.WriteLine("Digite o Id da Categoria para incluir a tarefa: ");
            string input = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(input)){
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


    public Recurence GetRecurence(){
        while(true){
            Console.WriteLine("Qual a recorrência dessa tarefa: [1]- Diária [2]-Semanal [3]-Mensal");
            string userOption = Console.ReadLine();
            switch(userOption){
                case "1":
                    return Recurence.Diaria;
                case "2":
                    return Recurence.Semanal;
                case "3":
                    return Recurence.Mensal;
                default:
                    Console.WriteLine("Opção inválida");
                break;
            }
        }
    }
}
