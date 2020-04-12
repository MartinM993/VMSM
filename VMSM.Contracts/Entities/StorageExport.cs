namespace VMSM.Contracts.Entities
{
    public class StorageExport : Entity
    {
        public virtual User StorageWorker { get; set; }
        public virtual User FieldWorker { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}