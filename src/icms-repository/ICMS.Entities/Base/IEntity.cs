using System;

namespace ICMS.Entities.Base
{
    public interface IEntity
    {
        Guid id { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        T id { get; set; }
    }

    public interface IExtendedEntity<T> : IEntity
    {
        //new T Id { get; set; }
        T id { get; set; }
        DateTime createdDate { get; set; }
        DateTime? modifiedDate { get; set; }
        string createdBy { get; set; }
        string modifiedBy { get; set; }
    }

}
