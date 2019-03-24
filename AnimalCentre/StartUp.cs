namespace AnimalCentre
{
    using System;
    using System.Linq;
    using System.Text;
    using AnimalCentre.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre animalCentre = new AnimalCentre();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(animalCentre.RegisterAnimal(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            break;
                        case "Chip":
                            Console.WriteLine(animalCentre.Chip(input[1], int.Parse(input[2])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(animalCentre.Vaccinate(input[1], int.Parse(input[2])));
                            break;
                        case "Fitness":
                            Console.WriteLine(animalCentre.Fitness(input[1], int.Parse(input[2])));
                            break;
                        case "Play":
                            Console.WriteLine(animalCentre.Play(input[1], int.Parse(input[2])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(animalCentre.DentalCare(input[1], int.Parse(input[2])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(animalCentre.NailTrim(input[1], int.Parse(input[2])));
                            break;
                        case "Adopt":
                            Console.WriteLine(animalCentre.Adopt(input[1], input[2]));
                            break;
                        case "History":
                            Console.WriteLine(animalCentre.History(input[1]));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            var ordered = animalCentre.adoptedAnimals.OrderBy(x => x.Key);
            StringBuilder result = new StringBuilder();

            foreach (var owner in ordered)
            {
                result.AppendLine(string.Format($"--Owner: {owner.Key}"))
                    .Append(string.Format($"    - Adopted animals: "))
                    .AppendJoin(' ', owner.Value)
                    .AppendLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
