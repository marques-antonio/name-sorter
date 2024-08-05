using Credas.NameSorter.Models;

namespace Credas.NameSorter.Services
{
    public class NameSortingService
    {
        public List<Person> ReadNamesFromFile(string filePath)
        {
            var names = File.ReadAllLines(filePath);
            return names
               .Where(name => !string.IsNullOrWhiteSpace(name)) // Filters out empty and whitespace-only lines
               .Select(name => new Person(name))
               .ToList();
        }

        public List<Person> SortNames(List<Person> unsortedNames)
        {
            return unsortedNames
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ThenBy(p => p.MiddleNames)
                .ToList();
        }

        public void WriteNamesToFile(string filePath, List<Person> sortedNames)
        {
            var sortedNamesStrings = sortedNames.Select(person => person.ToString()).ToArray();
            File.WriteAllLines(filePath, sortedNamesStrings);
        }
    }
}