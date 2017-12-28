using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;

namespace IHIS.CloudConnector.DataAccess
{
    public interface ISaOrderDetailDao : IDao
    {
        int Insert(List<SaOrderDetail> lst, Guid refId);

        int Insert(DbTransaction trans, List<SaOrderDetail> lst, Guid refId);
    }
}
