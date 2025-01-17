# name-sorter

## Project Overview

The Name Sorter project is designed to read a list of names from a file, sort them by last name and then by first and middle names, and output the sorted list to both a file and the console. 

## Purpose

The primary purpose of this project is to showcase clean, maintainable code that is easy to understand and includes comprehensive unit tests. This is done through a simple but clear example of sorting a list of names.

## Functionality

- Reads names from a specified file.
- Sorts names by last name, then by first and middle names.
- Writes the sorted names to a new file and outputs them to the console.
- Handles errors.

## Usage

1. **Ensure the .NET environment is set up on your machine.**
2. **Clone the repository to your local machine.**
3. **Navigate to the project directory.**
4. **Run the application using the following command:**

    ```sh
    dotnet run --project Credas.NameSorter.csproj <path-to-unsorted-names-file>
    ```

    For example:

    ```sh
    dotnet run --project Credas.NameSorter.csproj ./unsorted-names-list.txt
    ```

Alternatively, after build it, navigate to the directory where the executable file is located and run it.
    For example: (C:\name-sorter\Credas.NameSorter\bin\Debug\net8.0)

    name-sorter ./unsorted-names-list.txt
    
In both cases, the **sorted-names-list.txt** file will be generated in the same directory as the project or the name-sorter.exe file.

## Project Structure

### Program.cs

- **Purpose**: Entry point of the application. Handles command-line arguments, checks for file existence, and orchestrates the reading, sorting, and writing of names.
- **Key Functions**:
  - Validates input arguments.
  - Checks if the input file exists.
  - Uses `NameSortingService` to read, sort, and write names.
  - Outputs the sorted names to the console.

### NameSortingService.cs

- **Purpose**: Service class that handles the core functionality of reading names from a file, sorting them, and writing them back to a file.
- **Key Functions**:
  - `ReadNamesFromFile(string filePath)`: Reads names from the specified file and returns a list of `Person` objects.
  - `SortNames(List<Person> unsortedNames)`: Sorts the list of `Person` objects by last name, then by first and middle names.
  - `WriteNamesToFile(string filePath, List<Person> sortedNames)`: Writes the sorted list of names to the specified file.

### Person.cs

- **Purpose**: Represents a person with a first name, middle names, and a last name.
- **Key Functions**:
  - Constructor that parses a full name string into first name, middle names, and last name.
  - Overrides `ToString()` method to return the full name in the correct format.

### NameSortingServiceTests.cs

- **Purpose**: Contains unit tests for the `NameSortingService` to ensure that it functions correctly.
- **Key Functions**:
  - Tests for sorting functionality.
  - Tests for reading from a file, including handling unexpected data.
  - Tests for writing to a file.
  - Tests for error handling, such as non-existent files.

### .travis.yml

* **Purpose**: Configuration file for Travis CI to automate the build and test process.
* **Key Functions**:
  * Specifies the language and solution file.
  * Installs necessary dependencies.
  * Defines the build and test script to run the application and tests.
