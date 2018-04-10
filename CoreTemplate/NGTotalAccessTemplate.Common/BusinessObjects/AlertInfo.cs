using Template.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Common.BusinessObjects
{
    public class AlertInfo : BaseEntity
    {
        public int Id { get; set; }
        public int EventCode { get; set; }
        public int ClientId { get; set; }
    }
}
