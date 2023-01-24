using Faktura.Data;
using Faktura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.OperationsData
{
    class RemoveData
    {

        private static void RemoveKolnierz(FactureDbContext contextBase,string name,double price)
        {
            var kolnierzName = contextBase.Kolnierze.Where(p => p.Name==name).FirstOrDefault();
            if (kolnierzName is Kolnierz) 
            {
               contextBase.Remove(kolnierzName);
                    
            }
            else 
            {
                Console.WriteLine("nie ma takiego rekordu");
            }
            try
            {
                contextBase.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Coś poszło nie tak.Exception");
            }

        }

        private static void RemoveMaterials(FactureDbContext contextBase,string name)
        {
            var materialName = contextBase.Materialy.Where(p => p.Name==name).FirstOrDefault();
            try
            {
                if(materialName is Materials)
                {
                    contextBase.Remove(materialName);
                    contextBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("nie ma takiego rekordu.Exception");
            }
            finally
            {
                Console.WriteLine("nie ma takiego rekordu");
            }


            
        }

        private static void RemoveCustomer(FactureDbContext contextBase, string name, string surname)
        {
            var customerName = contextBase.Customers.Where(p => p.Name == name).FirstOrDefault();
            var customerSurname = contextBase.Customers.Where(s => s.Surname == surname).FirstOrDefault();

            if (customerName is Customer || customerSurname is Customer)
            {
                contextBase.Remove(customerName);

                Console.WriteLine("Dodano kolejnego, Użytkownika");
            }
            else
            {
                Console.WriteLine("Nie ma takiego rekordu");
            }
            try
            {
                contextBase.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Coś poszło nie tak.Exception");
            }
        }
        
        private static void RemoveAdress(FactureDbContext contextBase, int adressid)
        {
            var adress = contextBase.Adress.Where(e => e.Id== adressid).FirstOrDefault();

            if(adress is AdressesCustomers)
            {
                contextBase.Remove(adress);
            }
            else
            {
                Console.WriteLine("Nie ma takiego rekordu");
            }
            try
            {
                contextBase.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Coś poszło nie tak.Exception");
            }
        }

        public static void RemoveAllData(FactureDbContext contextBase, int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Podaj Imie i/lub nazwisko");
                    string name = Console.ReadLine();

                    if (name is not null)
                    {
                        
                        RemoveCustomer(contextBase, name, "");
                    }
                    else
                    {
                        string surname = Console.ReadLine();
                        RemoveCustomer(contextBase, "", surname);
                    }
                    break;

                case 2:
                    string materialName = Console.ReadLine();
                    RemoveMaterials(contextBase, materialName);
                    break;

                 case 3:
                    string NameInput = Console.ReadLine();
                    if(NameInput is not null)
                    {
                        RemoveKolnierz(contextBase, NameInput, default);
                    }
                    else
                    {
                        string priceInput = Console.ReadLine();
                        double price= double.Parse(priceInput);
                        RemoveKolnierz(contextBase, "", price);
                    }
                    break;
            }

        }
    }
}
