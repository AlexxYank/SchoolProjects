using System;
using WildFarm.Contracts;
namespace WildFarm.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        private const double weightGain = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
         : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
