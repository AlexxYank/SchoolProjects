namespace WildFarm.Animals.Mammals.Feline
{
    using System;
    using WildFarm.Contracts;

    public class Cat : Feline
    {
        private const double weightGain = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
         : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name.ToLower() == "vegetable" || food.GetType().Name.ToLower() == "meat")
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
            return "Meow";
        }
    }
}
