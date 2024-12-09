using System;

namespace TaskManager.Models;

public class Labor
{
    public Labor() {}
    public Labor(string title, string description, DateTime dateCreation, DateTime dateExpiration, string priority, string laborCategoryId, bool status)
    {
        Title = title;
        Description = description;
        DateCreation = dateCreation;
        DateExpiration = dateExpiration;
        Priority = priority;
        LaborCategoryName = laborCategoryId;
        Status = status;
    }

    public int? LaborId { get; set; }    
    public string? Title {get; set;}
   
    public string? Description { get; set; }
    
    public DateTime DateCreation { get; set; }

    public DateTime DateExpiration { get; set; }

    //Priority vai ser um enum
    public string? Priority { get; set; }

    public string? LaborCategoryName { get; set; }

    public bool Status { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj == null || obj.GetType() != GetType()){
            return false;
        }
        var other = (Labor)obj;

        return base.Equals(
            LaborId.HasValue && other.LaborId.HasValue && 
                LaborId==other.LaborId
        );
    }

    public override int GetHashCode()
    {
        return LaborId.HasValue ? LaborId.GetHashCode() : 0;
    }

}
