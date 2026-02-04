using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoMarketim.Entities
{
    public class ProductComment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int StarRating { get; set; } // 1 ile 5 arası
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Admin onayı (Kötü yorumları yayınlamadan önce görmek istersen)
        public bool IsApproved { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Yorumu yapan kullanıcı ID'si (User tablon Identity ise string olabilir)
        public int UserId { get; set; }
    }
}
