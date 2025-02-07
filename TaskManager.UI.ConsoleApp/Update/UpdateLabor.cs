using System;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;
using TaskManager.UI.ConsoleApp.GenericMethods;

namespace TaskManager.UI.ConsoleApp.Update;

public class UpdateLabor
{
    public async Task Update(TaskManagerEFContext context, Labor labor)
    {
        var utils = new Utils();
        var repository = new GenericRepository<Labor>(context);
        string opcao;

        Console.WriteLine("Atualizar tarefa");
        //atualiza o título se desejado
        while(true){
            Console.WriteLine("Deseja atualizar o título? [1]-sim [0]-não...");
            opcao = Console.ReadLine();
            if(opcao == "1"){
                labor.Title = GetTitle();
                break;
            }
            else if(opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida");
        }
        
        //atualiza a descrição se desejado
        while(true){
            Console.WriteLine("Deseja atualizar a descrição? [1]-sim [0]-não...");
            opcao = Console.ReadLine();
            if(opcao == "1"){
                labor.Description = GetDescription();
                break;
            } 
            else if(opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida");
        }

        //atualiza a data
        while(true){
            Console.WriteLine("Deseja atualizar a data? [1]-sim [0]-não...");
            opcao = Console.ReadLine();
            if(opcao == "1"){
                labor.DateExpiration = GetDateTime();
                break;
            } 
            else if(opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida");
        }

        //atualiza a prioridade
         while(true){
            Console.WriteLine("Deseja atualizar a prioridade da tarefa? [1]-sim [0]-não...");
            opcao = Console.ReadLine();
            if(opcao == "1"){
                labor.Priority = utils.GetPriority();
                break;
            }
            else if(opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida");
        }

        //atualiza a categoria
        var category = new Category();
        while(true){
            Console.WriteLine("Deseja atualizar a categoria? [1]-sim [0]-não...");
            opcao = Console.ReadLine();
            if(opcao == "1")
            {
                category = utils.GetCategoryAsync(context).Result;
                labor.RegistryCategoryToLabor(category);
                break;
            }
            else if(opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida");
        }

        if(labor is SimpleLabor)
        {
            //labor.Update(name, description, date, priority, category);
            await repository.UpdateAsync(labor);
            
        }
        else
        {
            RecurringLabor recurringLabor = (RecurringLabor)labor;
            while(true){
                Console.WriteLine("Deseja atualizar a recorrencia? [1]-sim [0]-não...");
                opcao = Console.ReadLine();
                if(opcao == "1")
                {
                    recurringLabor.Recurence = utils.GetRecurence();
                    break;
                }
                else if(opcao == "0")
                    break;
                else
                    Console.WriteLine("Opção inválida");
            }
            await repository.UpdateAsync(labor);
        }

        Console.WriteLine("Tarefa atualizada com sucesso!");
       
    }

    private string GetTitle(){
        Console.WriteLine("Digite o novo nome da tarefa: ");
        string title = Console.ReadLine();
        if(string.IsNullOrEmpty(title))
            return GetTitle();
        return title;
    }

    private string GetDescription(){
        Console.WriteLine("Digite a nova descrição da tarefa: ");
        string description = Console.ReadLine();
        if(string.IsNullOrEmpty(description))
            return GetDescription();
        return description;
    }

    private DateTime GetDateTime(){
        Console.WriteLine("Digite a nova data da tarefa(formato DD/MM/YYYY): ");
        string input = Console.ReadLine();
        if(string.IsNullOrEmpty(input))
            return GetDateTime();
        DateTime date = DateTime.Parse(input).Date;
        return date;
    }
}


