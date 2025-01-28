using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.VisualBasic;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.UI.ConsoleApp.Menus;

internal class Program
{
    private static async Task Main(string[] args)
    {
       PrincipalMenu menu = new();

        
        //var context = new TaskManagerEFContext();
        //var category = context.Categories!.Find(1);
        //var recurringLabor = new RecurringLabor("Teste 2","Tá dificil", DateTime.Parse("28/01/2025"),Priority.Alta,category,Recurence.Diaria);
        //context.RecurringLabors!.Add(recurringLabor);
        //context.SaveChanges();
        //Console.WriteLine("taref cadastrada com sucesso");
      
        await menu.ShowPrincipalMenu();


    }
}