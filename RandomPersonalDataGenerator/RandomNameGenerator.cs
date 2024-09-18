using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPersonalDataGenerator
{
    public class RandomNameGenerator
    {
        private static Random random = new Random();
        private readonly List<string> _maleName = new List<string>();
        private readonly List<string> _maleSurname = new List<string>();
        private readonly List<string> _femaleName = new List<string>();
        private readonly List<string> _femaleSurname = new List<string>();

        public RandomNameGenerator()
        {
            _maleName = LoadNamesFromFile("MaleNames.csv");
            _maleSurname = LoadNamesFromFile("MaleSurnames.csv");
            _femaleName = LoadNamesFromFile("FemaleNames.csv");
            _femaleSurname = LoadNamesFromFile("FemaleSurnames.csv");
        }

        private List<string> LoadNamesFromFile(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).ToList();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {fileName} not found.");
                return new List<string>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading {fileName}: {ex.Message}");
                return new List<string>();
            }
        }

        public string GenerateRandomName(Gender gender)
        {
            return GenerateRandomNames(gender, 1).First();
        }

        public List<string> GenerateRandomNames(Gender gender, int howMany)
        {
            List<string> names = new List<string>();

            for (var i = 0; i < howMany; i++)
            {
                string name, surname;

                if (gender == Gender.Male)
                {
                    name = _maleName[random.Next(_maleName.Count)];
                    surname = _maleSurname[random.Next(_maleSurname.Count)];
                }
                else if (gender == Gender.Female)
                {
                    name = _femaleName[random.Next(_femaleName.Count)];
                    surname = _femaleSurname[random.Next(_femaleSurname.Count)];
                }
                else
                {
                    throw new ArgumentException("Invalid gender value.");
                }

                names.Add($"{CapitalizeFirstLetter(name)} {CapitalizeFirstLetter(surname)}");
            }

            return names;
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
