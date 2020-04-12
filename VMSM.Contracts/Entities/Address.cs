namespace VMSM.Contracts.Entities
{
    public class Address : Entity
    {
        public virtual string Town { get; set; }
        public virtual string Street { get; set; }
        public virtual int Number { get; set; }
    }
}
