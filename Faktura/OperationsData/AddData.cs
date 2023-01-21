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
        public static void InsertCustomers(FactureDbContext contextBase)
        {
            bool repeat = true;

            while (repeat == true)
            {
                Console.WriteLine("Podaj imię klienta");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko klienta");
                string surname = Console.ReadLine();
                Console.WriteLine("Podaj numer telefonu klienta");
                string phone = Console.ReadLine();
                Console.WriteLine("Podaj ulicę klienta");
                string street = Console.ReadLine();
                Console.WriteLine("Podaj numer ulicy klienta");
                string streetNumb = Console.ReadLine();
                Console.WriteLine("Podaj kod pocztowy klienta");
                string post = Console.ReadLine();
                Console.WriteLine("Podaj miasto klienta");
                string city = Console.ReadLine();

                AdressesCustomers adresses = new AdressesCustomers(street, streetNumb, post, city);
                Customer cust = new Customer(name, surname, phone);
                cust.Adressess= adresses;

                Console.WriteLine("Chcesz powtórzyć operację? n/y");
                string yn = Console.ReadLine();

                if (yn == "y")
                {
                    repeat = true;
                    contextBase.Add(cust);
                    contextBase.Add(adresses); 
                    contextBase.SaveChanges();
                    break;
                }
                else
                {
                    contextBase.Add(cust);
                    contextBase.Add(adresses);
                    contextBase.SaveChanges();
                    break;
                }
                
            }
        }
            public static void InsertMaterials(FactureDbContext contextBase)
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
                        contextBase.SaveChanges();

                    }
                    else
                    {
                        repeat = false;
                        contextBase.Add(material);
                        contextBase.SaveChanges();
                    }
                }
            }
            public static void InsertKolnierz(FactureDbContext contextBase)
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
                        contextBase.SaveChanges();

                    }
                    else
                    {
                        repeat = false;
                        contextBase.Add(kolnierz);
                        contextBase.SaveChanges();
                    }

                }
            }

        public static void InsertAll(FactureDbContext contextBaseInsert, int ch)
        {
            switch (ch)
            {
                case 1:
                    AddData.InsertCustomers(contextBaseInsert);
                    break;
                case 2:
                    AddData.InsertMaterials(contextBaseInsert);
                    break;
                case 3:
                    AddData.InsertKolnierz(contextBaseInsert);
                    break;

            }
            
        }
           
    }
}
