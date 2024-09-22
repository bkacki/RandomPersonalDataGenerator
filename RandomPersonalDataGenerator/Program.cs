using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace RandomPersonalDataGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PhoneNumberGenerator phoneNumberGenerator = new PhoneNumberGenerator();
            RandomNameGenerator randomNameGenerator = new RandomNameGenerator();
            BirthDateGenerator birthDateGenerator = new BirthDateGenerator();
            RandomAddress randomAddress = new RandomAddress();

            var listOfNumbers = phoneNumberGenerator.GenerateRandomPhoneNumber(100);
            var listOfMaleNames = randomNameGenerator.GenerateRandomNames(Gender.Male, 100);
            var listOfFemaleNames = randomNameGenerator.GenerateRandomNames(Gender.Female, 100);

            var listOfBirthDates = birthDateGenerator.GenerateRandomBirthDates(100);
            RandomPeselGenerator randomPeselGenerator = new RandomPeselGenerator(listOfBirthDates);

            var listOfPESEL = randomPeselGenerator.GenerateRandomPeselList(Gender.Male, 100);

            for (int i = 0; i < listOfPESEL.Count; i++)
                Console.WriteLine($"{listOfMaleNames[i],-30}{listOfNumbers[i],-20}{listOfBirthDates[i].ToString("dd-MM-yyyy"),-15}{listOfPESEL[i],-15}{await randomAddress.RandomAddressAsync(),-15}");
        }

        
    }
}
