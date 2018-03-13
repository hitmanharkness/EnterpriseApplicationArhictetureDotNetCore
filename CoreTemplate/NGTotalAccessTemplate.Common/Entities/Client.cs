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
    [Description("To store Tenant information")]
    [Table("Client")]
    public class Client : BaseEntity
    {
        [Key]
        public int client_id { get; set; }

        [MaxLength(50)]
        public string last_name { get; set; }
        public string first_name { get; set; }
    }
}

