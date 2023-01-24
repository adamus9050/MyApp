using Faktura.Data;
using Faktura.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.OperationsData
{
    class AddData
    {
        public static void PrintMessage(ConsoleColor color,ConsoleColor backgroundColor, string message)
        {
            Console.ResetColor();
            Console.ForegroundColor= color;
            Console.BackgroundColor= backgroundColor;
            Console.WriteLine(message);
        }
        private static void InsertCustomers(FactureDbContext contextBase)
        {
            bool repeat = true;

            while (repeat == true)
            {
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj imię klienta");                
                string name = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj nazwisko klienta");
                string surname = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj numer telefonu klienta");
                string phone = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj ulicę klienta");
                string street = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj numer ulicy klienta");
                string streetNumb = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj kod pocztowy klienta");
                string post = Console.ReadLine();
                PrintMessage(ConsoleColor.White, ConsoleColor.Black, "Podaj miasto klienta");
                string city = Console.ReadLine();

                AdressesCustomers adresses = new AdressesCustomers(street, streetNumb, post, city);
                Customer cust = new Customer(name, surname, phone);
                cust.Adressess= adresses;
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chcesz powtórzyć operację? n/y");
                string yn = Console.ReadLine();

                if (yn == "y")
                {
                    repeat = true;
                    contextBase.Add(cust);
                    contextBase.Add(adresses); 
                    try
                    {
                        contextBase.SaveChanges();
                    }
                    catch(Exception ex) { Console.WriteLine("Error save Customer. Let's try again!"); }
                    break;
                }
                else
                {
                    contextBase.Add(cust);
                    contextBase.Add(adresses);
                    try
                    {
                        contextBase.SaveChanges();
                    }
                    catch (Exception ex) { Console.WriteLine("Error save Customer. Let's try again!"); }

                    break;
                }
                
            }
        }
        private static void InsertMaterials(FactureDbContext contextBase)
            {
                bool repeat = true;
                while (repeat == true)
                {
                    Console.WriteLine("Dodaj Nazwę materiału");
                    string name = Console.ReadLine();
                    Console.WriteLine("Podaj cenę");
                    string pricestr = Console.ReadLine();
                    double prices = double.Parse(pricestr);

                    Materials material = new Materials(name, prices);

                    Console.WriteLine("Chcesz dodac kolejną pozycję y/n");
                    string Yn = Console.ReadLine();
                if (Yn == "y")
                {
                    repeat = true;
                    contextBase.Add(material);
                    try
                    {
                        contextBase.SaveChanges();
                    }
                    catch (Exception ex) { Console.WriteLine("Error save Materials. Let's try again!"); }

                }
                else
                {
                    repeat = false;
                    contextBase.Add(material);
                    try
                    {
                        contextBase.SaveChanges();
                    }
                    catch (Exception ex) { Console.WriteLine("Error save Materials. Let's try again!"); }
                }
                }
            }
        private static void InsertKolnierz(FactureDbContext contextBase)
            {
                bool repeat = true;
                while (repeat == true)
                {
                    Console.WriteLine("Dodaj Nazwę Kołnieża");
                    string name = Console.ReadLine();
                    Console.WriteLine("Podaj cenę Kołnierza");
                    string pricestr = Console.ReadLine();
                    double price = double.Parse(pricestr);

                    Kolnierz kolnierz = new Kolnierz(name, price);

                    Console.WriteLine("Chcesz dodac kolejną pozycję");
                    string Yn = Console.ReadLine();
                    if (Yn == "y")
                    {
                            repeat = true;
                            contextBase.Add(kolnierz);
                        try
                        {
                            contextBase.SaveChanges();
                        }
                        catch (Exception ex) { Console.WriteLine("Error save Kolnierz. Let's try again!"); }

                    }
                    else
                    {
                            repeat = false;
                            contextBase.Add(kolnierz);
                        try
                        {
                            contextBase.SaveChanges();
                        }
                        catch (Exception ex) { Console.WriteLine("Error save Kolnierz. Let's try again!"); }
                    }

                }
            }

        public static void InsertAll(FactureDbContext contextBaseInsert, int ch)
        {
            switch (ch)
            {
                case 1:
                    InsertCustomers(contextBaseInsert);
                    break;
                case 2:
                    InsertMaterials(contextBaseInsert);
                    break;
                case 3:
                    InsertKolnierz(contextBaseInsert);
                    break;

            }
            
        }
           
    }
}
