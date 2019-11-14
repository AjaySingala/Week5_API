using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Customer" in code, svc and config file together.
public class Customer : ICustomer
{
    public string GetAll()
    {
        return "Return all customers";
    }
    public CustomerEntity Get(int id)
    {
        var customer = new CustomerEntity()
        {
            Id = 101,
            Firstname = "John",
            Lastname = "Smith",
            DOB = new DateTime(1999, 10, 12)
        };

        return customer;
    }
}
