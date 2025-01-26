using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;

namespace TaskManager.Business;

public class CategoryService
{
    public async Task ShowCategories(){
        var context = new TaskManagerEFContext();
        var categoryRepository = new GenericRepository<Category>(context);
        var categories = await categoryRepository.GetAllAsync();
        foreach(var element in categories){
            Console.WriteLine(element);
        }
    }

    public async void RegisterCategory(Category category){
        var context = new TaskManagerEFContext();
        var repository = new GenericRepository<Category>(context);
        await repository.AddAsync(category);
        Console.WriteLine("Categoria cadastrada com sucesso!");
    } 


}
