using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Domain
{
    public class Customer
    {
        public string Id { get; }
        public string Name { get; set; }

        protected Customer() { }
        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
        }   

    }
}
