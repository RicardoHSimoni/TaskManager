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
            //string dbPath = "../TaskManager.UI.ConsoleApp/TaskManager.db";
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskManager.db");
           string caminhoRelativo = "TaskManager.db";  // Caminho relativo ao diretório de trabalho da aplicação
            string dbPath = Path.GetFullPath(caminhoRelativo);
            dbPath = dbPath.Replace(Path.Combine("bin", "Debug","net8.0"), "");

            optionsBuilder.UseSqlite(
                $"Data Source ={dbPath}"
            );
        }
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        // base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Labor>().UseTpcMappingStrategy();
        //modelBuilder.Entity<SimpleLabor>() .ToTable("SimpleLabor");
        //modelBuilder.Entity<RecurringLabor>().ToTable("RecurringLabor");
        
    //}

}
