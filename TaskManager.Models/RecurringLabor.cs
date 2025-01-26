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
                       Priority priority, Category category, Recurence recurence)
                       : base(title, description, dateExpiration,priority,category)
    {
        Recurence = recurence;
        NextExecution = CalcNextExecution(dateExpiration,recurence);
    }

    public DateTime CalcNextExecution(DateTime start, Recurence recurence){
        if(recurence == Recurence.Diaria){
            return start.AddDays(1);
        }
        else if(recurence == Recurence.Semanal){
            return start.AddDays(7);
        }
        else{
            return start.AddMonths(1);
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} => {Recurence}";
    }
}
