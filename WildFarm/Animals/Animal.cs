namespace WildFarm.Animals
{
    using WildFarm.Contracts;

    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get => this.name; set => this.name = value; }

        public double Weight { get => this.weight; set => this.weight = value; }

        public int FoodEaten { get => this.foodEaten; set => this.foodEaten = value; }

        public abstract string ProduceSound();

        public abstract void Eat(IFood food);

        public abstract override string ToString();
    }
}
