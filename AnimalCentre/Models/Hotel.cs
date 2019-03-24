namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using AnimalCentre.Models.Contracts;

    public class Hotel : IHotel
    {
        private readonly int capacity = 10;

        protected Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get => this.capacity; }

        public IReadOnlyDictionary<string, IAnimal> Animals { get => new ReadOnlyDictionary<string, IAnimal>(this.animals); }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = animals[animalName];

            animal.Owner = owner;
            animal.IsAdopt = true;

            animals.Remove(animalName);
        }

    }
}
