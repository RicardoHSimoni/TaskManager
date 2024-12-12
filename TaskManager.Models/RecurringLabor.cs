using System;

namespace TaskManager.Models;

public class RecurringLabor: Labor
{
    //Propriedades:
    Recurence Recurence {get;set;}

    DateTime NextExecution{get; set;}

    //Métodos:

    public RecurringLabor(){}

    public RecurringLabor(string title, string description, DateTime dateCreation, DateTime dateExpiration, 
                       Priority priority, Category category, bool status, Recurence recurence, DateTime nextExecution)
                       : base(title, description,dateCreation,dateExpiration,priority,category,status)
    {
        Recurence = recurence;
        NextExecution = nextExecution;
    }

    public override string ToString()
    {
        return $"{base.ToString()} => {Recurence}";
    }
}
