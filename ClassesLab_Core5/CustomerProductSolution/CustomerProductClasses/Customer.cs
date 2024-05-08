/*Using the Visual Studio Solution provided in the starting files as a starting point and the Product class as a model, implement and test a class that represents a customer. 

A customer has the following attributes:  an integer id, first and last name, email address and phone number.  A customer must be able to report and update each of these attributes. 

A programmer must be able to create a customer without providing any of the attribute information and must be able to create a customer while providing all of the attribute information.

  A customer must be able to convert its attributes to a string for displaying on the screen as well. */

//IPO chart was not used as I draw all references of help from the files located in this project, (Product.cs and for testing the original program.cs ) - To test I was unclear on if
//I should create a additional file and test this or to modify the program.cs in CustomerProductTests. The original Progam.cs has been changed in order to test the CustomerProductClasses,
//unsure if this was the right approach or not

using System;

namespace CustomerProductClasses
{
    public class Customer
    {
      
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;

       
        public Customer()
        {
            firstName = "unknown";
        }

        public Customer(int id, string firstName, string lastName, string email, string phoneNumber)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

    
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

       
        public override string ToString()
        {
            return $"Id: {id}, Name: {firstName} {lastName}, Email: {email}, Phone: {phoneNumber}";
        }
    }
}