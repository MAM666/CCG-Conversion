using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.Models
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name && x.Address.Line1 == y.Address.Line1 && x.Address.Line2 == y.Address.Line2;
        }

        public int GetHashCode(Person obj)
        {
            return (obj.Name + obj.Address.Line1 + obj.Address.Line2).GetHashCode();
        }
    }
}
