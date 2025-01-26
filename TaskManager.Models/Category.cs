using System;
using System.Reflection;

namespace TaskManager.Models;

public class Category
{
    //Atributos:
    public int CategoryId {get; set;}
    public string? Name {get; set;}

    public List<Labor>? Labors {get; set;} = [];

    //Métodos:
    public Category(){}

    public Category(string name){
        Name = name;
    }

    
    //public override bool Equals(object? obj)
    //{
    //    if(obj == null || obj.GetType() != GetType()){
    //        return false;
    //    }
    //    var other = (Category)obj;

    //    return base.Equals(
    //        CategoryId.HasValue && other.CategoryId.HasValue && 
    //            CategoryId==other.CategoryId
    //    );
    //}

    //public override int GetHashCode()
    //{
    //    return CategoryId.HasValue ? CategoryId.GetHashCode() : 0;
    //}

    public bool Validate() {
        var isValid =  !string.IsNullOrWhiteSpace(Name);
        if (!isValid) {
            throw new Exception("Dados Inválidos");
        }
        return true;
    }

    public override string ToString()
    {
        return $"[{CategoryId},{Name}]";
    }

}
