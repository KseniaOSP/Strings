﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSort
{
    public class YearComparer : IComparer<DateTime>

    {

        public int Compare(DateTime birthdate1, DateTime birthdate2)
        {  

            return birthdate1.CompareTo(birthdate2);
    
        }
    }

    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person person1, Person person2)
        {
            var date1 = person1.BirthDate;
            var date2 = person2.BirthDate;
            return date2.CompareTo(date1);
        }
    }
}
