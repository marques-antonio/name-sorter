using Credas.NameSorter.Models;
using Credas.NameSorter.Services;

namespace NameSorter.Tests.Services
{
    public class NameSortingServiceTests
    {
        private readonly NameSortingService _service;

        public NameSortingServiceTests()
        {
            _service = new NameSortingService();
        }

        // Custom comparer for Person objects to check equality based on FirstName, MiddleNames, and LastName
        public class PersonComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.FirstName == y.FirstName &&
                       x.MiddleNames == y.MiddleNames &&
                       x.LastName == y.LastName;
            }

            public int GetHashCode(Person obj)
            {
                return HashCode.Combine(obj.FirstName, obj.MiddleNames, obj.LastName);
            }
        }

        #region SortNames
        [Fact]
        public void SortNames_ShouldSortByLastNameThenGivenNames()
        {
            // Arrange
            var unsortedNames = new List<Person>
            {
                new Person("Janet Parsons"),
                new Person("Vaughn Lewis"),
                new Person("Adonis Julius Archer"),
                new Person("Shelby Nathan Yoder"),
                new Person("Marin Alvarez"),
                new Person("London Lindsey"),
                new Person("Beau Tristan Bentley"),
                new Person("Leo Gardner"),
                new Person("Hunter Uriah Mathew Clarke"),
                new Person("Mikayla Lopez"),
                new Person("Frankie Conner Ritter")
            };

            var expectedSortedNames = new List<Person>
            {
                new Person("Marin Alvarez"),
                new Person("Adonis Julius Archer"),
                new Person("Beau Tristan Bentley"),
                new Person("Hunter Uriah Mathew Clarke"),
                new Person("Leo Gardner"),
                new Person("Vaughn Lewis"),
                new Person("London Lindsey"),
                new Person("Mikayla Lopez"),
                new Person("Janet Parsons"),
                new Person("Frankie Conner Ritter"),
                new Person("Shelby Nathan Yoder")
            };

            // Act
            var sortedNames = _service.SortNames(unsortedNames);

            // Assert
            Assert.Equal(expectedSortedNames, sortedNames, new PersonComparer());
        }
        #endregion

        #region ReadNamesFromFile
        [Fact]
        public void ReadNamesFromFile_ShouldReadNamesFromFile()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            var fileContent = new[]
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer"
            };
            File.WriteAllLines(filePath, fileContent);

            var expectedNames = new List<Person>
            {
                new Person("Janet Parsons"),
                new Person("Vaughn Lewis"),
                new Person("Adonis Julius Archer")
            };

            // Act
            var names = _service.ReadNamesFromFile(filePath);

            // Assert
            Assert.Equal(expectedNames, names, new PersonComparer());

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadNamesFromFile_ShouldHandleUnexpectedData()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            var fileContent = new[]
            {
                "Janet Parsons",
                "",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                " "
            };
            File.WriteAllLines(filePath, fileContent);

            var expectedNames = new List<Person>
            {
                new Person("Janet Parsons"),
                new Person("Vaughn Lewis"),
                new Person("Adonis Julius Archer")
            };

            // Act
            var names = _service.ReadNamesFromFile(filePath);

            // Assert
            Assert.Equal(expectedNames, names, new PersonComparer());

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadNamesFromFile_ShouldThrowException_WhenFileDoesNotExist()
        {
            // Arrange
            var filePath = "nonexistentfile.txt";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => _service.ReadNamesFromFile(filePath));
        }
        #endregion

        #region WriteNamesToFile
        [Fact]
        public void WriteNamesToFile_ShouldWriteNamesToFile()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            var namesToWrite = new List<Person>
            {
                new Person("Janet Parsons"),
                new Person("Vaughn Lewis"),
                new Person("Adonis Julius Archer")
            };

            // Act
            _service.WriteNamesToFile(filePath, namesToWrite);

            // Assert
            var writtenContent = File.ReadAllLines(filePath);
            var expectedContent = new[]
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer"
            };
            Assert.Equal(expectedContent, writtenContent);

            // Cleanup
            File.Delete(filePath);
        }
        #endregion
    }
}