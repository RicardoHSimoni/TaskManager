using System;
using TaskManager.Business;
using TaskManager.Models;

namespace TaskManager.UI.ConsoleApp.Register;

public class RegisterCategory
{
    public Category NewCategory(){
        var category = new Category();
        var service = new CategoryService();
        while(true){
            Console.WriteLine("Informe o nome da nova categoria: ");
            category.Name = Console.ReadLine();
            if(category.Validate()){
                service.RegisterCategory(category);
                return category;
            }
        }
    }
}
