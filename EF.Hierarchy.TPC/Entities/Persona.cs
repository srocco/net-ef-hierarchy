namespace EF.Hierarchy.TPC.Entities
{
    internal abstract class Persona: EntityBase
    {
        public required string Nombre { get; set; }

        public required string Apellido { get; set; }
    }
}
