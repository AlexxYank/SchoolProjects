namespace AnimalCentre.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;

    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get => this.name; set => this.name = value; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get => this.procedureTime; set => this.procedureTime = value; }

        public string Owner { get => this.owner; set => this.owner = value; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }
    }
}
