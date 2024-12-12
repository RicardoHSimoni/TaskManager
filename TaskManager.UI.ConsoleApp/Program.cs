using System;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new TaskManagerEFContext();

        var category = new Category(
            "Estudo"
        );

        /*var simpleLabor = new SimpleLabor(
            "Teste","Testando EFCore",DateTime.Now.Date, DateTime.Parse("12/12/2024"),Priority.Alta,category, false
        );

        simpleLabor.RegistryCategoryToLabor(category);*/

      
        context.Categories!.Add(category);
        context.SaveChanges();
    }
}