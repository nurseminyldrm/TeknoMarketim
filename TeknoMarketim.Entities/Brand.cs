using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoMarketim.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: "Arduino"
        public string LogoUrl { get; set; } // Marka logosu için

        // İlişki: Bir markanın çok ürünü olur
        public List<Product> Products { get; set; }
    }
}
