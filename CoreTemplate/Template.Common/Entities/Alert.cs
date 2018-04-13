using Template.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Common.Entities
{
    [Description("To store client alert information")]
    [Table("tblalerts")]
    public class Alert : BaseEntity
    {
        [Key]
        public int IAlert_ID { get; set; }
        public int event_code { get; set; }
        public int client_id { get; set; }
        
    }
}

