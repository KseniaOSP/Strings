// See https://aka.ms/new-console-template for more information

using SmallTask;


    var people = new List<Person>
{
    new Person ("Tom", 23, new List<string> {"english", "german"}),
    new Person ("Bob", 27, new List<string> {"english", "french" }),
    new Person ("Sam", 29, new List<string>  { "english", "spanish" }),
    new Person ("Alice", 24, new List<string> {"spanish", "german" })
};

    //var selectedPeople = from p in people
    //                     where p.Age > 25
    //                     select p;

var selectedPeople = from person in people
                    where person.Age > 23
                    where person.Name.Length > 3
                    select person;

foreach (Person person in selectedPeople)
        Console.WriteLine($"{person.Name} - {person.Age}");
