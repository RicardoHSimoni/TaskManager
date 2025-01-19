using System;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;

namespace TaskManager.Business;

public class CategoryService
{
    public async Task GetCategories(){
        var context = new TaskManagerEFContext();
        var categoryRepository = new GenericRepository<Category>(context);
        var categories = await categoryRepository.GetAllAsync();
        foreach(var element in categories){
            Console.WriteLine(element);
        }

    }
}
