using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.DataAccess.Core;

namespace Template.DataAccess.Core
{
    public interface IDbFactory
    {

        DataContext GetDataContext { get; }
    }
}
