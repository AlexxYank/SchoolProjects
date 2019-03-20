namespace WildFarm.Animals.Mammals
{
    using System;
    using WildFarm.Contracts;

    public class Dog : Mammal
    {
        private const double weightGain = 0.40;

        public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
