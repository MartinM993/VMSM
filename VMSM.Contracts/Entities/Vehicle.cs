namespace VMSM.Contracts.Entities
{
    public class Vehicle : Entity
    {
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string RegistrationPlate { get; set; }
        public virtual User AssignTo { get; set; }
    }
}