namespace AnimalCentre.Models.Procedures
{
    using System;
    using AnimalCentre.Models.Contracts;

    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.IsChipped = true;
            animal.Happiness -= 5;
            animal.ProcedureTime -= procedureTime;
        }
    }
}
