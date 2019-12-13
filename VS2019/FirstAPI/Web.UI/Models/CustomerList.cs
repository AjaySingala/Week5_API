using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class CustomerList
    {
        public string Name { get; set; }
        public IList<string> Customers = new List<string>();
    }
}
