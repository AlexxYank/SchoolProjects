namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public abstract class Procedure : IProcedure
    {
        private IList<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public IList<IAnimal> ProcedureHistory { get => this.procedureHistory; set => this.procedureHistory = value; }


        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            string[] ordered = procedureHistory
                .OrderBy(p => p.Name)
                .Select(a => a.ToString())
                .ToArray();

            string result = sb.ToString().Trim();

            return result;
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            procedureHistory.Add(animal);
        }

    }
}
