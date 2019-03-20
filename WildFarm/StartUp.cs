namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Animals.Birds;
    using WildFarm.Animals.Mammals;
    using WildFarm.Animals.Mammals.Feline;
    using WildFarm.Contracts;
    using WildFarm.Foods;

    public class StartUp
    {

        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            string[] animalInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                var animal = CreateAnimal(animalInput);
                animals.Add(animal);

                var food = CreateFood(foodInput);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalInput[0] == "End")
                {
                    break;
                }

                foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            animals.ForEach(Console.WriteLine);
        }

        private static IFood CreateFood(string[] foodInput)
        {
            string type = foodInput[0];
            int quantity = int.Parse(foodInput[1]);

            switch (type.ToLower())
            {
                case "fruit":
                    IFood fruit = new Fruit(quantity);
                    return fruit;
                case "meat":
                    IFood meat = new Meat(quantity);
                    return meat;
                case "seeds":
                    IFood seeds = new Seeds(quantity);
                    return seeds;
                case "vegetable":
                    IFood vegetable = new Vegetable(quantity);
                    return vegetable;
            }

            return null;
        }

        private static IAnimal CreateAnimal(string[] animalInput)
        {

            string type = animalInput[0];

            switch (type.ToLower())
            {
                case "cat":
                    IAnimal cat = new Cat(animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);
                    return cat;
                case "tiger":
                    IAnimal tiger = new Tiger(animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);
                    return tiger;
                case "dog":
                    IAnimal dog = new Dog(animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                    return dog;
                case "mouse":
                    IAnimal mouse = new Mouse(animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                    return mouse;
                case "hen":
                    IAnimal hen = new Hen(animalInput[1], double.Parse(animalInput[2]), double.Parse(animalInput[3]));
                    return hen;
                case "owl":
                    IAnimal owl = new Owl(animalInput[1], double.Parse(animalInput[2]), double.Parse(animalInput[3]));
                    return owl;
            }

            return null;

            
        }
    }
}
