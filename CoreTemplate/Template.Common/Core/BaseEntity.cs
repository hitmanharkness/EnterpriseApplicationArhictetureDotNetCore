using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Common.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
            this.State = (int)EntityState.New;
            
        }
        [NotMapped]
        public string CreatedBy { get; set; }
        [NotMapped]
        public DateTime CreatedOn { get; set; }
        [NotMapped]
        public string UpdatedBy { get; set; }
        [NotMapped]
        public DateTime UpdatedOn { get; set; }

        [NotMapped]
        public int State { get; set; }

        public enum EntityState
        {
            New=1, 
            Update=2, 
            Delete =3, 
            Ignore=4
        }
    }
}
