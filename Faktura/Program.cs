using Faktura.Data;
using Faktura.Models;
using Faktura.OperationsData;
using System;
using System.Numerics;


using FactureDbContext context= new FactureDbContext();

Console.WriteLine("Chcesz Wprowadzić dane? Wpisz 1");
Console.WriteLine("Chcesz Usunąć dane? Wpisz 2");
string operation = Console.ReadLine();

int operationInt;
    if(operation == "1" || operation == "2")
    {
        operationInt = int.Parse(operation);
    
        ChooseOptions(operationInt);
    } 
    else
    {
        Console.WriteLine("Podałeś złe informacje do komputera.");
        Console.WriteLine("PODAJ JESZCZE RAZ");
        operation = Console.ReadLine();
        operationInt = int.Parse(operation);
        ChooseOptions(operationInt);
    }



void ChooseOptions(int operationint)
{
   
    switch(operationint)
    {
        case 1:
            Console.WriteLine("Wpisz tabele, do której chcesz wprowadzidz dane");
            Console.WriteLine("1-Customers || 2-Matrials || 3-Kolnierz");
            int choice = int.Parse(Console.ReadLine());

            AddData.InsertAll( context,choice);
            break;


        case 2:
            Console.WriteLine("Wpisz tabele, z której chcesz usunąć dane");
            Console.WriteLine("1-Customers || 2-Matrials || 3-Kolnierz");
            int choices= int.Parse(Console.ReadLine());

            RemoveData.RemoveAllData(context, choices);

            break;
    }
}


    



