using System;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Models;

public abstract class Labor
{
    //Atributos:
    public int? LaborId { get; set; }    
    public string Title {get; set;}
   
    public string? Description { get; set; }
    
    public DateTime DateCreation { get; set; }

    public DateTime DateExpiration { get; set; }

    //Priority vai ser um enum
    public Priority Priority { get; set; }

    public Category Category {get; private set;}
    public bool Status { get; set; }

    //Métodos
    public Labor() {}
    public Labor(string title, string description, DateTime dateExpiration, Priority priority, Category category)
    {
        Title = title;
        Description = description;
        DateCreation = DateTime.Now.Date;
        DateExpiration = dateExpiration;
        Priority = priority;
        Category = category;
        RegistryCategoryToLabor(category);
        Status = false;
    }
    
    //public override bool Equals(object? obj)
    //{
        //if(obj == null || obj.GetType() != GetType()){
        //    return false;
        //}
    //    var other = (Labor)obj;

    //    return base.Equals(
    //        LaborId.HasValue && other.LaborId.HasValue && 
    //            LaborId==other.LaborId
    //    );
    //}

    public void RegistryCategoryToLabor(Category category) {
        if (!category.Labors.Contains(this)) {
            category.Labors.Add(this);
        }
    }

    //public override int GetHashCode()
    //{
    //   return LaborId.HasValue ? LaborId.GetHashCode() : 0;
    //}

    public override string ToString()
    {
        return $"[{Title}, {DateExpiration}, -> {Category.Name}]";
    }

     

}
