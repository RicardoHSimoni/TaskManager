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

        //Coleta de dados base
        Console.WriteLine("Informe o nome da tarefa: ");
        string title = Console.ReadLine();
        Console.WriteLine("Informe uma descrição(opcional): ");
        string description = Console.ReadLine();
        Console.WriteLine("Informe a data(formato DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine()).Date;
        Priority priority = GetPriority();
        Category category = GetCategory().Result;
        Console.WriteLine("Categoria escolhida: " + category);

        if (aux.IsSimple())
        {
            var simpleLabor = new SimpleLabor(title, description, date, priority, category);
            register.RegisterSimpleLabor(simpleLabor);
        }
        else
        {
            Recurence recurence = GetRecurence();
            var recurringLabor = new RecurringLabor(title, description, date, priority, category, recurence);
            register.RegisterRecurringLabor(recurringLabor);

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

    public async Task<Category> GetCategory(){
        var service = new CategoryService();
        await service.ShowCategories();
        Console.WriteLine("Digite o Id da Categoria para incluir a tarefa: ");
        int iD = int.Parse(Console.ReadLine());

        var category = new Category();
        var context = new TaskManagerEFContext();
        var categoryRepository = new GenericRepository<Category>(context);
        category = await categoryRepository.GetByIdAsync(iD);
        return category;
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
