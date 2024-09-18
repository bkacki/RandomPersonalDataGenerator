namespace RandomPersonalDataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneNumberGenerator phoneNumberGenerator = new PhoneNumberGenerator();
            RandomNameGenerator randomNameGenerator = new RandomNameGenerator();

            var listOfNumbers = phoneNumberGenerator.GenerateRandomPhoneNumber(100);
            var listOfMaleNames = randomNameGenerator.GenerateRandomNames(Gender.Male, 100);
            var listOfFemaleNames = randomNameGenerator.GenerateRandomNames(Gender.Female, 100);

            foreach (var number in listOfNumbers)
                Console.WriteLine(number);

            foreach(var name in listOfMaleNames)
                Console.WriteLine(name);

            foreach (var name in listOfFemaleNames)
                Console.WriteLine(name);
        }
    }
}
