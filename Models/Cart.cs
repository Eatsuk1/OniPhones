using DoAn1.Data;
using System.Collections.Generic;

namespace DoAn1.Models
{
    public class Cart
    {
        public List<Smartphone> _Smartphone { get; set; }

        public int quantity { get; set; }

        public int totalprice { get; set; }
    }
}
