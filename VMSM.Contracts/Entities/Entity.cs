using System;
using VMSM.Contracts.Interfaces;

namespace VMSM.Contracts.Entities
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? DateCreated { get; set; }

        public void SetAudit(int? userId)
        {
            if(Id == 0)
            {
                CreatedBy = userId;
                DateCreated = DateTime.UtcNow;
            }

            ModifiedBy = userId;
            DateModified = DateTime.UtcNow;
        }
    }
}
