using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO.Base;

namespace AppServices.Interfaces.Base
{
    public interface IBaseService<TEntity, TId> where TEntity : EntityWithTypedIdBaseDto<TId>
    {
        IList<TEntity> GetAll();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Get(TId id);
        Task<bool> Delete(TId id);
    }
}
