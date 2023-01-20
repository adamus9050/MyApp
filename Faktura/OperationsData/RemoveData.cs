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
        public static void RemoveKolnierz(FactureDbContext contextBase,string name,double price)
        {
            var kolnierzName = contextBase.Kolnierze.Where(p => p.Name==name).FirstOrDefault();

            try
            {
                if (kolnierzName is Kolnierz) 
                {
                    contextBase.Remove(kolnierzName);
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
        public static void RemoveMaterials(FactureDbContext contextBase,string name)
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
        public static void RemoveCustomer(FactureDbContext contextBase, string name,string surname)
        {
            var cusotmerName = contextBase.Customers.Where(p => p.Name == name).FirstOrDefault();
            var customerSurname = contextBase.Customers.Where(s => s.Surname == surname).FirstOrDefault();
            try
            { 
                if(cusotmerName is Customers || customerSurname is Customers)
                {
                    contextBase.Remove(cusotmerName);
                    contextBase.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("nie ma takiego rekordu.Exception");
            }
            finally
            {
                Console.WriteLine("nie ma takiego rekordu");
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
