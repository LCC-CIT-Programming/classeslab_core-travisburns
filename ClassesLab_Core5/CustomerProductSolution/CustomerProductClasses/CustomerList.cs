using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CustomerProductClasses
{
    public class CustomerList
    {
        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<Customer>();
        }

        public int Count
        {
            get { return customers.Count; }
        }

        public Customer this[int index]
        {
            get { return customers[index]; }
            set { customers[index] = value; }
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customers.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Add(int id, string firstName, string lastName, string email, string phoneNumber)
        {
            Customer customer = new Customer(id, firstName, lastName, email, phoneNumber);
            customers.Add(customer);
        }

        public static CustomerList operator +(CustomerList list, Customer customer)
        {
            list.Add(customer);
            return list;
        }

        public void Save()
        {
            CustomerDB.SaveCustomers(customers);
        }

        public void Fill()
        {
            customers = CustomerDB.GetCustomers();
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        public static CustomerList operator -(CustomerList list, Customer customer)
        {
            list.Remove(customer);
            return list;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Customer c in customers)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }
    }
}