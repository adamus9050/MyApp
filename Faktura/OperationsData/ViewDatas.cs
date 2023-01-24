using Faktura.Data;
using Faktura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.OperationsData
{
    public class ViewDatas
    {
        public static void VievCustomers(FactureDbContext contextBase)
        {
            var customers = from customer in contextBase.Customers select customer;
            var adress = from adrress in contextBase.Adress select adrress;
            //customers = (IQueryable<Customer>)adress;

            int idCust;
            int idAdress;

            foreach (Customer custom in customers)
            {
                idCust = custom.Id;
                AddData.PrintMessage(ConsoleColor.Green, ConsoleColor.Black, $"Id:{custom.Id}");
                AddData.PrintMessage(ConsoleColor.Green, ConsoleColor.Black, $"Name:{custom.Name}");
                AddData.PrintMessage(ConsoleColor.Green, ConsoleColor.Black, $"Surname:{custom.Surname}");
                AddData.PrintMessage(ConsoleColor.Green, ConsoleColor.Black, $"PhoneNumber:{custom.PhoneNumber}");

                foreach (AdressesCustomers adrescust in adress)
                {
                    
                    AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"Id:{adrescust.Id}");
                    AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"Street:{adrescust.Street}");
                    AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"City:{adrescust.City}");
                    AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"PostCode:{adrescust.PostCode}");
                }
            }

        }
        //public static void VievAdress(FactureDbContext contextBase, int Idcust)
        //{
        //    //var adress = from adrress in contextBase.Adress select adrress;
        //    var adress = contextBase.Adress.Where(e => e.Id == Idcust).FirstOrDefault();

        //    foreach (AdressesCustomers adrescust in adress)
        //    {

        //        AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"Id:{adrescust.Id}");
        //        AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"Street:{adrescust.Street}");
        //        AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"City:{adrescust.City}");
        //        AddData.PrintMessage(ConsoleColor.White, ConsoleColor.Black, $"PostCode:{adrescust.PostCode}");
        //    }

        //}
    }
        

}
