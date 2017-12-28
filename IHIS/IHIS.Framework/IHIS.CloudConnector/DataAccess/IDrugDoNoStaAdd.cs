using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugDoNoStaAdd : IDao
    {
        DataTable GetDrugDoNoStaAdd();
    }
}
