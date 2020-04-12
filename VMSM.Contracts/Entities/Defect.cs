using System;

namespace VMSM.Contracts.Entities
{
    public class Defect : Entity
    {
        public virtual VendingMachine VendingMachine { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
