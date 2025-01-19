using System;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.UI.ConsoleApp.Menus;

internal class Program
{
    private static void Main(string[] args)
    {
       PrincipalMenu menu = new();

       menu.ShowPrincipalMenu();


    }
}