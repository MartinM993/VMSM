using System;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class UserRole
    {
        public virtual Role Type { get; set; }
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? DateCreated { get; set; }
    }
}
