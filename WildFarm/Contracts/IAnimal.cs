namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; set; }

        double Weight { get; set; }

        int FoodEaten { get; set; }

        string ProduceSound();

        void Eat(IFood food);
    }
}
