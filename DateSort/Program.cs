namespace DateSort
{
    public class DateSort
    {
        private readonly Dictionary<string, DateTime> listPeople = new Dictionary<string, DateTime>()

        public void ReadFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                while (!file.EndOfStream)
                {
                    var fileLine = file.ReadLine();
                    var fragments = fileLine.Split('#', 2);
                    string key = fragments[0];
                    DateTime value = fragments[1];
                    listPeople[key] = value;
                }

            }
        } 
    } 
}
