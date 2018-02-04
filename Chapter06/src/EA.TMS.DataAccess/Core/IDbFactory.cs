using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.DataAccess.Core;

namespace EA.TMS.DataAccess.Core
{
    public interface IDbFactory
    {

        DataContext GetDataContext { get; }
    }
}
