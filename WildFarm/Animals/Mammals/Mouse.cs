namespace WildFarm.Animals.Mammals
{
    using System;
    using WildFarm.Contracts;

    public class Mouse : Mammal
    {
        private const double weightGain = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name.ToLower() == "vegetable" || food.GetType().Name.ToLower() == "fruit")
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
            return "Squeak";
        }
    }
}
