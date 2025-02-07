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
        await menu.ShowPrincipalMenu();
        
        /*var context = new TaskManagerEFContext();
        var category = context.Categories!.Find(2);
        var labor = context.SimpleLabors!.Find(1);
        labor.RegistryCategoryToLabor(category);
        context.SimpleLabors!.Update(labor);
        context.SaveChanges();
        Console.WriteLine("taref atualizada com sucesso");*/      
        


    }
}