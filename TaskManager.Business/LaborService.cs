using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.Repositories;

namespace TaskManager.Business;

public class LaborService
{
    public async void RegisterSimpleLabor(SimpleLabor simpleLabor){
        var context = new TaskManagerEFContext();
        var repository = new GenericRepository<SimpleLabor>(context);
        await repository.AddAsync(simpleLabor);
        //simpleLabor.Validate();
        Console.WriteLine("Tarefa Cadastrada com sucesso!");
    }

    public async void RegisterRecurringLabor(RecurringLabor recurringLabor){
        var context = new TaskManagerEFContext();
        var repository = new GenericRepository<RecurringLabor>(context);
        await repository.AddAsync(recurringLabor);
        Console.WriteLine("Tarefa Cadastrada com sucesso!");
    }
}
