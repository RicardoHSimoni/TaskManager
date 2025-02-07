using System;
using System.Threading.Tasks;
using TaskManager.Business;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;
using TaskManager.UI.ConsoleApp.GenericMethods;
using TaskManager.UI.ConsoleApp.Register;
using TaskManager.UI.ConsoleApp.Update;

namespace TaskManager.UI.ConsoleApp.Menus;

public class ViewMenu
{
    public async Task ShowViewMenu(){
        Console.Clear();
        bool continuar = true;
        var utils = new Utils();
        var context = new TaskManagerEFContext();
        var repository = new GenericRepository<Labor>(context);
       
        //context.Entry(labor).Reference(l => l.Category).Load();
        while(continuar){
            var labors = await repository.GetAllAsync();
            Console.WriteLine("Menu de visualização");
            Console.WriteLine("1. Listar por status");
            Console.WriteLine("2. Listar por prioridade");
            Console.WriteLine("3. Listar por categoria");
            Console.WriteLine("4. Listar por tempo");
            Console.WriteLine("5. Listar todas as tarefas");
            Console.WriteLine("6. Listar categorias");
            Console.WriteLine("7. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch(opcao){
                case "1":
                    Console.WriteLine("Digite 1 para listar as tarefas concluídas e 0 para as tarefas em andamento");
                    string userOption = Console.ReadLine();
                    if(userOption == "1"){
                        foreach(var labor in labors){
                            context.Entry(labor).Reference(l => l.Category).Load();
                            if(labor.Status == true)
                                Console.WriteLine(labor);
                        }
                    }
                    else if(userOption == "0"){
                          foreach(var labor in labors){
                            context.Entry(labor).Reference(l => l.Category).Load();
                            if(labor.Status == false)
                                Console.WriteLine(labor);
                        }
                    }
                    else Console.WriteLine("Opção inválida. Operação cancelada");

                    break;
                case "2":
                var priority = utils.GetPriority();
                foreach(var labor in labors){
                    if(labor.Priority == priority){
                        context.Entry(labor).Reference(l => l.Category).Load();
                        Console.WriteLine(labor);
                    }
                }
                    break;
                case "3":
                var category = utils.GetCategoryAsync(context).Result;
                foreach(var labor in labors){
                    context.Entry(labor).Reference(l => l.Category).Load();
                    if(labor.Category == category)
                        Console.WriteLine(labor);
                }
          
                    break;
                case "4":
                Console.WriteLine("Digite a data de inicio da busca: ");
                DateTime startDate = DateTime.Parse(Console.ReadLine()).Date;
                Console.WriteLine("Digite a data de limite da busca: ");
                DateTime finalDate = DateTime.Parse(Console.ReadLine()).Date;
                foreach(var labor in labors){
                    if(labor.DateExpiration > startDate && labor.DateExpiration < finalDate){
                        context.Entry(labor).Reference(l => l.Category).Load();
                        Console.WriteLine(labor);
                    }
                        
                }
                    break;
                case "5":
                    foreach(var labor in labors){
                        context.Entry(labor).Reference(l => l.Category).Load();
                        Console.WriteLine(labor);
                    }
                    break;
                case "6":
                var categoryService = new CategoryService();
                await categoryService.ShowCategories();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                    break;
                case "7":
                continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if(opcao != "6" && opcao != "7"){ 
                Console.WriteLine("Digite o id de uma tarefa para abrir a visão detalhada ou digite 0 para sair: ");
                string id = Console.ReadLine();
                if(id != "0" && !string.IsNullOrWhiteSpace(id)){
                    await DetailedView(int.Parse(id));
                }
            }


        }
    } 

    public async Task DetailedView(int laborId){
        var context = new TaskManagerEFContext();
        var repository = new GenericRepository<Labor>(context);
        var labor = await repository.GetByIdAsync(laborId);
        context.Entry(labor).Reference(l => l.Category).Load();
        Console.WriteLine("Informações detalhadas: ");
        Console.WriteLine("Título: "+ labor.Title);
        Console.WriteLine("Descrição: "+ labor.Description);
        Console.WriteLine("Data de vencimento: "+ labor.DateExpiration);
        Console.WriteLine("Prioridade: "+ labor.Priority);
        Console.WriteLine("Categoria: "+ labor.Category);
        Console.WriteLine("Status: "+ labor.Status);
        if(labor is RecurringLabor){
            var recurringLabor = labor as RecurringLabor;
            Console.WriteLine("Recorrência: "+ recurringLabor.Recurence);
        }

        Console.WriteLine("Pressione 0 para sair...");
        Console.WriteLine("Pressione 1 para atualizar a tarefa...");
        Console.WriteLine("Pressione 2 para excluir a tarefa...");
        string opcao = Console.ReadLine();
        switch(opcao){
            case "0":
                break;
            case "1":
                var update = new UpdateLabor();
                await update.Update(context, labor);
                break;
            case "2":
                await repository.DeleteAsync(labor);
                Console.WriteLine("Tarefa excluída com sucesso.");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }



    }
}
