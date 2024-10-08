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
            RandomPeselGenerator randomPeselGenerator = new RandomPeselGenerator();

            RandomPerson[] randomPersonArray = new RandomPerson[100];

            for(int i=0; i<randomPersonArray.Length;i++)
                randomPersonArray[i] =  await RandomPerson.CreateAsync(birthDateGenerator, randomAddress, randomNameGenerator, phoneNumberGenerator);
            
            foreach(var person in randomPersonArray)
                Console.WriteLine(person.ToString());
        }

        
    }
}
