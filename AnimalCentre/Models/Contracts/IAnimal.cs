namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; set; }

        int Happiness { get; set; }

        bool IsChipped { get; set; }

        int ProcedureTime { get; set; }

        int Energy { get; set; }

        bool IsVaccinated { get; set; }

        string Owner { get; set; }

        bool IsAdopt { get; set; }
    }
}
