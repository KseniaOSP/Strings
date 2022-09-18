using System.Globalization;
using System.Text;

namespace DateSort
{
    public class DateSort
    {
        static private readonly List<Person> people = new List<Person>(); // создадим список List элементами которого является строковый массив

        static string inputpath = @"C:\Users\besed\Desktop\VS\People.txt";
        static string outputpath = @"C:\Users\besed\Desktop\VS\Result.txt";

        static public void ReadFile(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);// провайдер кодировок для того, чтобы была возможность подключить русскую кодировку
            
            using (StreamReader file = new StreamReader(path, Encoding.GetEncoding("windows-1251")))
            {
                while (!file.EndOfStream)
                {
                    var fileLine = file.ReadLine();
                    var fragments = fileLine.Split(':', 2);
                    string name = fragments[0];
                    string birthdate = fragments[1];
                    var person = new Person();
                    person.Name = name;
                    person.BirthDate = DateTime.ParseExact(birthdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    people.Add(person); // создать структуру / класс поле фио и поле дата рождения  
                }
            }
        }
        static public void WriteFile(string path) 
        {
            using Stream stream = new FileStream(path, FileMode.Create);
            using (StreamWriter file = new StreamWriter(stream, Encoding.GetEncoding("windows-1251")))
            {
                PersonComparer pc = new PersonComparer();
                people.Sort(pc);
                foreach(Person person in people)
                {
                    string line = person.Name + ":" + person.BirthDate.ToString("dd.MM.yyyy");
                    file.WriteLine(line);
                }
            }
        }

        static void Main(string[] args) 
        {
            ReadFile(inputpath);
            WriteFile(outputpath);
            
        }
    } 
    public class Person 
    
    { 
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

       
    
    }
}
