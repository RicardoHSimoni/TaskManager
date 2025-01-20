using System;

namespace TaskManager.Models;

public class RecurringLabor: Labor
{
    //Propriedades:
    Recurence Recurence {get;set;}

    DateTime NextExecution{get; set;}

    //Métodos:

    public RecurringLabor(){}

    public RecurringLabor(string title, string description, DateTime dateExpiration, 
                       Priority priority, Category category, Recurence recurence, DateTime nextExecution)
                       : base(title, description,dateExpiration,priority,category)
    {
        Recurence = recurence;
        NextExecution = nextExecution;
    }

    public override string ToString()
    {
        return $"{base.ToString()} => {Recurence}";
    }
}
