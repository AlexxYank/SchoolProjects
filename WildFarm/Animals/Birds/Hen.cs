namespace WildFarm.Animals.Birds
{
    using WildFarm.Contracts;

    public class Hen : Bird
    {
        private const double weightGain = 0.35;

        public Hen(string name, double weight, double wingSize) 
           : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.Weight = weightGain * food.Quantity + this.Weight;
            this.FoodEaten = food.Quantity;

        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
