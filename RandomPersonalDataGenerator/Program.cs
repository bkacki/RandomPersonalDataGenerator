using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RandomPersonalDataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneNumberGenerator phoneNumberGenerator = new PhoneNumberGenerator();
            RandomNameGenerator randomNameGenerator = new RandomNameGenerator();
            BirthDateGenerator birthDateGenerator = new BirthDateGenerator();

            var listOfNumbers = phoneNumberGenerator.GenerateRandomPhoneNumber(100);
            var listOfMaleNames = randomNameGenerator.GenerateRandomNames(Gender.Male, 100);
            var listOfFemaleNames = randomNameGenerator.GenerateRandomNames(Gender.Female, 100);
            var listOfBirthDates = birthDateGenerator.GenerateRandomBirthDates(100);

            RandomPeselGenerator randomPeselGenerator = new RandomPeselGenerator(listOfBirthDates);
            var listOfPESEL = randomPeselGenerator.GenerateRandomPeselList(Gender.Male, 100);

            for (int i = 0; i < listOfPESEL.Count; i++)
                Console.WriteLine($"{listOfMaleNames[i],-30}{listOfNumbers[i],-20}{listOfBirthDates[i].ToString("dd-MM-yyyy"),-15}{listOfPESEL[i],-15}");
        }

        static async Task RandomAddressAsync()
        {
            string apiKey = "YOUR_API_KEY";
            Random random = new Random();
            double lat = random.NextDouble() * 180 - 90; // Losowa szerokość geograficzna
            double lng = random.NextDouble() * 360 - 180; // Losowa długość geograficzna

            string url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                string address = json["results"]?[0]?["formatted_address"]?.ToString();
                Console.WriteLine($"Losowy adres: {address}");
            }
        }
    }
}
