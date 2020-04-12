namespace VMSM.Contracts.Entities
{
    public class FieldWorkerProduct : Entity
    {
        public virtual User FieldWorker { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}
