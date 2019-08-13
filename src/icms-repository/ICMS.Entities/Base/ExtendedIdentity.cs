using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICMS.Entities.Base
{
    public abstract class ExtendedEntity<T> : IExtendedEntity<T>
    {
        private DateTime? _createdDate;

        public T id { get; set; }

        public DateTime createdDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }

        public DateTime? modifiedDate { get; set; }

        public string createdBy { get; set; }

        public string modifiedBy { get; set; }

        public byte[] rowVersion { get; set; }
    }
}
