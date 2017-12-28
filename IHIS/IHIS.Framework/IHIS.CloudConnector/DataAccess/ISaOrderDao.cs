using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;

namespace IHIS.CloudConnector.DataAccess
{
    public interface ISaOrderDao : IDao
    {
        Guid Insert(SaOrder saOrder);

        Guid Insert(DbTransaction trans, SaOrder saOrder);

        int Update(SaOrder saOrder);

        int Update(DbTransaction trans, SaOrder saOrder);
    }
}
