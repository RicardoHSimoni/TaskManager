using System;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new TaskManagerEFContext();

        //var category = new Category(
          //  "Estudo"
        //);

        var category2 = new Category(
            "Trabalho"
        );

        //var simpleLabor = new SimpleLabor(
        //    "Estudo", "Estudando EFCore", DateTime.Now.Date, DateTime.Parse("15/12/2024"), Priority.Alta, category, false
        //);

        var recurringLabor = new RecurringLabor(
            "Chorar", "Chorar no banho", DateTime.Now.Date, DateTime.Parse("14/12/2024"), Priority.Alta, category2, false, Recurence.Diaria, DateTime.Parse("15/12/2024")
        );

        /*var simpleLabor = new SimpleLabor(
            "Teste","Testando EFCore",DateTime.Now.Date, DateTime.Parse("12/12/2024"),Priority.Alta,category, false
        );

        simpleLabor.RegistryCategoryToLabor(category);*/


        //context.Categories!.Add(category);
        //context.Categories!.Add(category2);
       // context.SimpleLabors!.Add(simpleLabor);
       context.RecurringLabors!.Add(recurringLabor);
       
        context.SaveChanges();
    }
}