using System.Collections.Generic;
using VMSM.Contracts.Interfaces;

namespace VMSM.Contracts.Models
{
    public class CustomActionResultListEntity<TEntity> where TEntity : class, IEntity
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public List<TEntity> Entities { get; set; }
    }
}
