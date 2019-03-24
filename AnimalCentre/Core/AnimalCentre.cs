namespace AnimalCentre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using global::AnimalCentre.Models;
    using global::AnimalCentre.Models.Animals.Factory;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Procedures;

    public class AnimalCentre
    {
        AnimalFactory animalFactory;
        IHotel hotel;
        Dictionary<string, IProcedure> services;
        public Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();
            this.hotel = new Hotel();
            this.services = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();

            InitializeServices();
        }

        private void InitializeServices()
        {
            services.Add("Chip", new Chip());
            services.Add("DentalCare", new DentalCare());
            services.Add("Fitness", new Fitness());
            services.Add("NailTrim", new NailTrim());
            services.Add("Play", new Play());
            services.Add("Vaccinate", new Vaccinate());
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            //if (hotel.Animals.ContainsKey(name))
            //{
            //    throw new ArgumentException($"Animal {name} already exist");
            //}

            hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["Chip"].DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["Vaccinate"].DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["Fitness"].DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["Play"].DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["DentalCare"].DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = FindAnimal(name);

            services["NailTrim"].DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = FindAnimal(animalName);

            hotel.Adopt(animalName, owner);

            if (!adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals.Add(owner, new List<string>());
                adoptedAnimals[owner].Add(animalName);
            }
            else
            {
                adoptedAnimals[owner].Add(animalName);
            }

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"{type}"));

            var procedure = services[type];

            foreach (var item in procedure.ProcedureHistory)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        private IAnimal FindAnimal(string animalName)
        {
            var animals = hotel.Animals.FirstOrDefault(x => x.Key == animalName);

            IAnimal animal = animals.Value;

            if (animal == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            return animal;
        }


    }
}
