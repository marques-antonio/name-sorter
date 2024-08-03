using Credas.NameSorter.Models;

namespace Credas.NameSorter.Services
{
    public class NameSortingService
    {
        public List<Person> ReadNamesFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var people = new List<Person>();

            foreach (var line in lines)
            {
                var names = line.Split(' ');
                var firstName = names[0];
                var lastName = names[^1];
                var middleName = names.Length > 2 ? string.Join(' ', names.Skip(1).Take(names.Length - 2)) : string.Empty;

                people.Add(new Person(firstName, middleName, lastName));
            }

            return people;
        }

        public List<Person> SortNames(List<Person> people)
        {
            return people.OrderBy(p => p.LastName)
                         .ThenBy(p => p.FirstName)
                         .ThenBy(p => p.MiddleName)
                         .ToList();
        }

        public void WriteNamesToFile(List<Person> people, string filePath)
        {
            var lines = people.Select(p => p.ToString()).ToList();
            File.WriteAllLines(filePath, lines);
        }
    }
}