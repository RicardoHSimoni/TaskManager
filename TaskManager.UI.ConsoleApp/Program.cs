using System;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.UI.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
       Menu menu = new();

       menu.ShowMenu();


    }
}