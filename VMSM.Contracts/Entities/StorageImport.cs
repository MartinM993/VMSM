namespace VMSM.Contracts.Entities
{
    public class StorageImport : Entity
    {
        public virtual User StorageWorker { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}
