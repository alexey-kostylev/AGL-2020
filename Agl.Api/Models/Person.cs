using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agl.Api.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Pet> Pets { get; set; }

        public override string ToString()
        {
            return $"'{Name}', {Age}, {Gender}. pets: { ((Pets != null) ? Pets.Count : 0)}";
        }
    }
}
