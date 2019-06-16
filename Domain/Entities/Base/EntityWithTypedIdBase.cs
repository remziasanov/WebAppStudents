using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Base
{
    public class EntityWithTypedIdBase<TId>
    {
        /// <summary>
        /// Индетификатор
        /// </summary>
        //[Key]
        public virtual TId Id { get; protected set; }
    }
}
