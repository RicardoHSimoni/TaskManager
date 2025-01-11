using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Persistence.Contexts;

public class TaskManagerEFContext : DbContext
{

    public DbSet<Category>? Categories { get; set; }
    public DbSet<SimpleLabor>? SimpleLabors { get; set; }

    public DbSet<RecurringLabor>? RecurringLabors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            string dbPath = "../TaskManager.Persistence/TaskManager.db";
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db");
            optionsBuilder.UseSqlite(
                $"Data Source ={dbPath}"
            );

           
        }
    }

}
