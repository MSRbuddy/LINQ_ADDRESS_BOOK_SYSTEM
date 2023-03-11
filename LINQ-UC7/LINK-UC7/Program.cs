using System;

namespace LINQ_AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LINQ AddressBookSystem!");
            //Create Object for DataTable
            ContactDataManager contactDataManager = new ContactDataManager();
            ContactDataManager contactDataManagers = new ContactDataManager();
            DataTableManager dataTableManger = new DataTableManager();
            dataTableManger.CreateDataTable();

            //Insert Values into Table
            contactDataManager.FirstName = "Meghana";
            contactDataManager.LastName = "Dasari";
            contactDataManager.PhoneNumber = 9876504321;
            contactDataManager.Email = "meghana@gmail.com";
            contactDataManager.Address = "Dharpally";
            contactDataManager.City = "Nizamabad";
            contactDataManager.State = "TS";
            contactDataManager.zip = 503165;
            dataTableManger.InsertintoDataTable(contactDataManager);

            //Insert Values into Table
            contactDataManagers.FirstName = "Rushitha";
            contactDataManagers.LastName = "Kottala";
            contactDataManagers.PhoneNumber = 9876543201;
            contactDataManagers.Email = "rushitha@gmail.com";
            contactDataManagers.Address = "Hyderabad";
            contactDataManagers.City = "Hyderabad";
            contactDataManagers.State = "TS";
            contactDataManagers.zip = 503001;
            dataTableManger.InsertintoDataTable(contactDataManagers);
            dataTableManger.Display();
            //Modify
            int varl = dataTableManger.EditDataTable("lalita", "Lastname");
            Console.WriteLine("Success" + varl);
            //Delete
            int var2 = dataTableManger.DeleteRowInDataTable("lalita");
            Console.WriteLine("Success" + varl);
            //Retrieve based on city or state
            string var3 = dataTableManger.RetrieveBasedOnCityorState("Hyderabad", "TS");
            Console.WriteLine("Success" + varl);
            //count based on city or state
            string var4 = dataTableManger.RetrieveCountBasedOnCityorState();
            Console.WriteLine("Success" + varl);
        }
    }
}