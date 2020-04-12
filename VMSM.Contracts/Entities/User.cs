using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual Role Role { get; set; }
        public virtual Address Address { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}