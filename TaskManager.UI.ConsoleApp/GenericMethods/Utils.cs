using System;
using TaskManager.Business;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;
using TaskManager.UI.ConsoleApp.Register;

namespace TaskManager.UI.ConsoleApp.GenericMethods;

public class Utils
{
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

     public bool IsSimple(){
        bool continuar = true;
        string option = "";
        while(continuar){
            Console.WriteLine("\nA tarefa será simples ou recorrente? Digite 1 para adicionar recorrência ou 0 para tarefa simples: ");
            option = Console.ReadLine();

            if(option == "1" || option == "0")
                continuar = false;
        }
        if(option == "1")
            return false;
        return true;
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
