using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Dtos
{
    public class StockActivitiesListDto
    {
        public string Barcode { get; set; }
        public int StockAmount { get; set; }
        public int StockTakeOutAmount { get; set; }
        public int StockEntryAmount { get; set; }
        public decimal Gain { get; set; }
        public decimal EntryPrice { get; set; }
    }
}
