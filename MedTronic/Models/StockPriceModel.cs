using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTronic.Models
{
    [Table("TBLSTOCKSPRICE")]
    public class StockPriceModel
    {
        [Key]
        [Column("TICKER")]
        public string Ticker { get; set; }
        [Column("PRICE")]
        public decimal Price { get; set; }
    }
}
