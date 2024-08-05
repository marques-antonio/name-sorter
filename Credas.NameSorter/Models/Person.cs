namespace Credas.NameSorter.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }

        public Person(string fullName)
        {
            var nameParts = fullName.Split(' ');
            LastName = nameParts[^1];
            FirstName = nameParts[0];
            MiddleNames = nameParts.Length > 2 ? string.Join(' ', nameParts.Skip(1).Take(nameParts.Length - 2)) : string.Empty;
        }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(MiddleNames) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleNames} {LastName}";
        }
    }
}