namespace WildFarm.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get => this.breed; set => this.breed = value; }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} [{this.Name}, {this.breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

            return result;
        }
    }
}
