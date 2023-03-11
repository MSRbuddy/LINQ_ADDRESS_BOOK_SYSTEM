using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace LINQ_AddressBook
{
    public class DataTableManager
    {
        DataTable custTable;
        //Create Column in Datatable
        public void CreateDataTable()
        {
            custTable = new DataTable("AddressBookSystem");
            DataColumn dtColumn;

            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Contactid";
            dtColumn.Caption = "Contact ID";
            dtColumn.AutoIncrement = true;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.Caption = "First Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "Last Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.Caption = "Address";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "City";
            dtColumn.Caption = "City";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "State";
            dtColumn.Caption = "State";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Email";
            dtColumn.Caption = "Email";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "PhoneNumber";
            dtColumn.Caption = "PhoneNumber";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "Zip";
            dtColumn.Caption = "Zip";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

        }
        //Insert Values in Datatable
        public int AddValues()
        {
            CreateDataTable();
            //Create Object for DataTable
            ContactDataManager contactDataManager = new ContactDataManager();
            ContactDataManager contactDataManagers = new ContactDataManager();
            //Insert Values into Table
            contactDataManager.FirstName = "Shalini";
            contactDataManager.LastName = "Venkatesh";
            contactDataManager.PhoneNumber = 9842905050;
            contactDataManager.Email = "shalini@gmail.com";
            contactDataManager.Address = "4,B Block,Avadi";
            contactDataManager.City = "chennai";
            contactDataManager.State = "TN";
            contactDataManager.zip = 600072;
            InsertintoDataTable(contactDataManager);

            //Insert Values into Table
            contactDataManagers.FirstName = "Raksha";
            contactDataManagers.LastName = "Parthiban";
            contactDataManagers.PhoneNumber = 7742905050;
            contactDataManagers.Email = "raksha@gmail.com";
            contactDataManagers.Address = "Sasthri street,ambattur";
            contactDataManagers.City = "chennai";
            contactDataManagers.State = "TN";
            contactDataManagers.zip = 123001;
            InsertintoDataTable(contactDataManagers);

            return custTable.Rows.Count;
        }

        //Insert values in Data Table
        public void InsertintoDataTable(ContactDataManager contactDataManager)
        {
            DataRow dtRow = custTable.NewRow();
            dtRow["FirstName"] = contactDataManager.FirstName;
            dtRow["LastName"] = contactDataManager.LastName;
            dtRow["Address"] = contactDataManager.Address;
            dtRow["City"] = contactDataManager.City;
            dtRow["State"] = contactDataManager.State;
            dtRow["Zip"] = contactDataManager.zip;
            dtRow["PhoneNumber"] = contactDataManager.PhoneNumber;
            dtRow["Email"] = contactDataManager.Email;
            custTable.Rows.Add(dtRow);

        }
        public int EditDataTable(string FirstName, string ColumnName)
        {
            AddValues();
            var modifiedList = (from ContactList in custTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList[ColumnName] = "Sing";
                Display();
                return 1;
            }
            else return 0;
        }
        //Delete a row from DataTable based on Name
        public int DeleteRowInDataTable(string FirstName)
        {
            AddValues();
            var modifiedList = (from ContactList in custTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("--- After Deletion ---");
                Display();
                return 1;
            }
            else return 0;
        }
        //Display all Values in DataRow
        public void Display()
        {
            foreach (DataRow dtRows in custTable.Rows)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
    }
}