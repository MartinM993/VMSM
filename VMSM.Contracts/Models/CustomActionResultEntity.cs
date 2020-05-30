using VMSM.Contracts.Interfaces;

namespace VMSM.Contracts.Models
{
    public class CustomActionResultEntity<TEntity> where TEntity : class, IEntity
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public TEntity Entity { get; set; }
    }
}
