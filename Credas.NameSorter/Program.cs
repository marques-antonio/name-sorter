using Credas.NameSorter.Services;

namespace Credas.NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Temporary code for development testing.
            /*
            Array.Resize(ref args, args.Length + 1);
            args[args.Length - 1] = "C:\\Projects\\Processes\\Credas\\name-sorter\\Credas.NameSorter\\unsorted-names-list.txt";           
            */

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: name-sorter <path-to-unsorted-names-file>");
                return;
            }

            var filePath = args[0];
            var outputFilePath = "sorted-names-list.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: The file '{filePath}' does not exist.");
                return;
            }

            var nameSortingService = new NameSortingService();

            var people = nameSortingService.ReadNamesFromFile(filePath);
            var sortedPeople = nameSortingService.SortNames(people);
            nameSortingService.WriteNamesToFile(outputFilePath, sortedPeople);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
