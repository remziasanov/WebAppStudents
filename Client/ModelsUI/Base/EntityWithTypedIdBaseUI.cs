using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI.Base
{
    public class EntityWithTypedIdBaseUI<TId>
    {
        /// <summary>
        /// Индетификатор
        /// </summary>
        public virtual TId Id { get; set; }
    }
}
