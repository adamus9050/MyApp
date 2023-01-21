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
        public static void VievCustomers (FactureDbContext contextBase)
        {
            var customers = from customer in contextBase.Customers select customer;

            foreach (Customer custom in customers)
            {
                //Console.WriteLine($"Id: {custom.Id}");
                Console.WriteLine($"Name: {custom.Name} ");
                Console.WriteLine($"Surname: {custom.Surname}");
                Console.WriteLine($"Phone number: {custom.PhoneNumber}");
                Console.WriteLine($"Adress: {custom.Adressess}");

            }
        }
        
    }
}
