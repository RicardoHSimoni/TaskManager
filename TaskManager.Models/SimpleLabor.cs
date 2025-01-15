using System;

namespace TaskManager.Models;

public class SimpleLabor: Labor
{
    //Não possui propriedades adicionais, é uma tarefa simples

    //Métodos
    public SimpleLabor(){}

    public SimpleLabor(string title, string description, DateTime dateCreation, DateTime dateExpiration, 
                       Priority priority, Category category, bool status)
                       : base(title, description,dateExpiration,priority,category){}

    public override string ToString()
    {
        return base.ToString();
    }

    public bool Validate() {
        var isValid =  !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Category.Name)
            && DateExpiration != null;
        if (!isValid) {
            throw new Exception("Dados Inválidos");
        }
        return true;
    }
}
