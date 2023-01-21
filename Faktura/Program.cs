using Faktura.Data;
using Faktura.Models;
using Faktura.OperationsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;


using FactureDbContext context= new FactureDbContext();

bool goodchoose = true;
string operation;
while(goodchoose = true)
{
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Chcesz Wprowadzić dane? Wpisz 1");
    Console.WriteLine("Chcesz Usunąć dane? Wpisz 2");
    Console.WriteLine("Chcesz wyswietlić dane Customer? Wpisz 3");
    operation = Console.ReadLine();

    if(operation == "1" || operation == "2" || operation=="3")
    {
        int operationInt = int.Parse(operation);
    
        ChooseOptions(operationInt);
        goodchoose= false;
    } 
    else
    {
        Console.WriteLine("Podałeś złe informacje do komputera.");
        Console.WriteLine("PODAJ JESZCZE RAZ");
        continue;
    }
}




void ChooseOptions(int operationint)
{
   
    switch(operationint)
    {
        case 1:
            bool inp = true;
            while(goodchoose=true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wpisz tabele, do której chcesz wprowadzidz dane");
                Console.WriteLine("1-Customers || 2-Matrials || 3-Kolnierz");
                operation= Console.ReadLine();

                if (operation == "1" || operation == "2" || operation == "3")
                {

                    int choice = int.Parse(operation);

                    AddData.InsertAll(context, choice);
                    inp= false;
                    break;
                }
                else
                {
                    Console.WriteLine("You choose incorrect tabels");
                    Console.WriteLine("Would like to choose tabels again??'y'/'n'");
                    string addagain= Console.ReadLine();
                    if (addagain=="y")
                    {
                        inp = true;
                        continue;
                    }
                    else
                    {
                        inp = false;
                        
                        break;
                    }
                }

                
            }
            break;


        case 2:
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Wpisz tabele, z której chcesz usunąć dane");
            Console.WriteLine("1-Customers || 2-Matrials || 3-Kolnierz");
            operation = Console.ReadLine();
            int choices= int.Parse(operation);

            RemoveData.RemoveAllData(context, choices);

            break;

        case 3:
            ViewDatas.VievCustomers(context);
            break;
    }
}


    



