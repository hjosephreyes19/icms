using System;

namespace ICMS.Entities.Base
{
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T id { get; set; }

        //object IEntity.Id
        //{
        //    set { }
        //    get { return this.Id; }
        //}

        public byte[] rowVersion { get; set; }
    }
}
