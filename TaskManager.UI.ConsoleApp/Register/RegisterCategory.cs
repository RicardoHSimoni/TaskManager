using System;
using TaskManager.Business;
using TaskManager.Models;

namespace TaskManager.UI.ConsoleApp.Register;

public class RegisterCategory
{
    public void NewCategory(){
        var category = new Category();
        var service = new CategoryService();
        Console.WriteLine("Informe o nome da nova categoria: ");
        category.Name = Console.ReadLine();
        if(category.Validate()){
            service.RegisterCategory(category);
        }
    }
}
