using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ModelsUI.Base;

namespace Client.Controllers
{
    interface IBaseController<T> where T : EntityBaseUI<int>
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<bool> Edit(T Entity);
        Task<bool> Delete(int id);
        Task<bool> Add(T Entity);
    }
}