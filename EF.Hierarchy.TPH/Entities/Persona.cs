namespace EF.Hierarchy.TPH.Entities
{
    internal abstract class Persona: EntityBase
    {
        public required string Nombre { get; set; }

        public required string Apellido { get; set; }
    }
}
