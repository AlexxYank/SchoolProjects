namespace WildFarm.Animals.Birds
{
    using System;
    using WildFarm.Contracts;

    public class Owl : Bird
    {
        private const double weightGain = 0.25;

        public Owl(string name, double weight, double wingSize) 
           : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            string allowedFood = "meat";

            if (food.GetType().Name.ToLower() == allowedFood)
            {
                this.Weight = weightGain * food.Quantity + this.Weight;
                this.FoodEaten = food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
