using System;
using System.Reflection;

namespace TaskManager.Models;

public class Category
{
    public Category(){}

    public Category(string name, Labor labor){
        Name = name;
        if(Labors is not null)
            Labors.Add(labor);
    }
    public int? CategoryId {get; set;}
    public string? Name {get; set;}

    public ICollection<Labor>? Labors;

    public override bool Equals(object? obj)
    {
        if(obj == null || obj.GetType() != GetType()){
            return false;
        }
        var other = (Category)obj;

        return base.Equals(
            CategoryId.HasValue && other.CategoryId.HasValue && 
                CategoryId==other.CategoryId
        );
    }

    public override int GetHashCode()
    {
        return CategoryId.HasValue ? CategoryId.GetHashCode() : 0;
    }

}
