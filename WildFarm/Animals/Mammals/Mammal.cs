﻿using System;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get => this.livingRegion; set => this.livingRegion = value; }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.livingRegion}, {this.FoodEaten}]";

            return result;
        }
    }
}
