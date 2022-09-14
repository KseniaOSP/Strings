using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSort
{
    public class People
    {
        public People(string name, DateTime datebirth)
        {
            Name = name;
            DateBirth = datebirth;
        }

        public string Name { get; private set; }
        public DateTime DateBirth { get; set; }
    }

}
}
