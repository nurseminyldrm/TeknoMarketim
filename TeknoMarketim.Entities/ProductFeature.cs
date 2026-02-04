using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoMarketim.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Key { get; set; }   // Örn: "Çalışma Voltajı" veya "Pin Sayısı"
        public string Value { get; set; } // Örn: "5V" veya "14 Digital"

        // İlişki: Hangi ürüne ait?
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
