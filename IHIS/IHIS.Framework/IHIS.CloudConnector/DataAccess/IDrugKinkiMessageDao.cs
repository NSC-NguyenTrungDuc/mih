using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data;

namespace IHIS.CloudConnector.DataAccess
{
    public interface IDrugKinkiMessageDao : IDao
    {
        bool TableExists(string tableName);

        int Insert(DrugKinkiMessage drug);

        int Truncate();

        int Insert(List<DrugKinkiMessage> lst, bool isTemTable);

        int Truncate(bool isTemTable);

        int CopyData();

        DataTable CheckKinki(DataTable grdOrder, DataTable grdOutSang);
    }
}
