using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IMisaOrderDao : IDao
    {
        Guid GetAccountId(string code);

        Guid GetBrandId();

        MisaOrder GetMisaOrder(string code);
    }
}
