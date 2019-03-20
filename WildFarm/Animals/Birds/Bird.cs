namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) 
        : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get => this.wingSize; set => this.wingSize = value; }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} [{this.Name}, {this.wingSize}, {this.Weight}, {this.FoodEaten}]";

            return result;
        }
    }
}
