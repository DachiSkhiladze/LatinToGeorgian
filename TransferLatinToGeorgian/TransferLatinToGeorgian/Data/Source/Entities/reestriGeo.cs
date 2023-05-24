using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLatinToGeorgian.Data.Source.Entities
{
    public class reestriGeo
    {
        [Key]
        public string? piradi { get; set; }
        public string? gvari { get; set; }
        public string? saxeli { get; set; }
        public string? mamisSaxeli { get; set; }
        public double? sqesi { get; set; }
        public DateTime? dabWeli { get; set; }
        public DateTime? regTariRi { get; set; }
        public string? DMONAC { get; set; }
        public string? mocmobisNomeri { get; set; }
        public string? quCa { get; set; }
        public string? REGMDAT { get; set; }
    }
}
