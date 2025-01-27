using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.VisualBasic;
using TaskManager.Models;
using TaskManager.Persistence.Contexts;
using TaskManager.UI.ConsoleApp.Menus;

internal class Program
{
    private static async Task Main(string[] args)
    {
       PrincipalMenu menu = new();

        
        //string diretorio = Directory.GetParent(caminhoArquivo).FullName;

        //Console.WriteLine("Diretório do arquivo: " + diretorio);

        //Console.WriteLine(dbPath);
        //Console.ReadKey();
      
        await menu.ShowPrincipalMenu();


    }
}