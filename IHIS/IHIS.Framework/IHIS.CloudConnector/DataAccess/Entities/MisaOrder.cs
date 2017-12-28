using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class MisaOrder
    {
        private Guid inventoryItemId;
        public Guid InventoryItemId
        {
            get { return inventoryItemId; }
            set { inventoryItemId = value; }
        }

        private decimal salePrice1;
        public decimal SalePrice1
        {
            get { return salePrice1; }
            set { salePrice1 = value; }
        }

        private Guid unitId;
        public Guid UnitId
        {
            get { return unitId; }
            set { unitId = value; }
        }

        private string inventoryItemName;
        public string InventoryItemName
        {
            get { return inventoryItemName; }
            set { inventoryItemName = value; }
        }
    }
}
