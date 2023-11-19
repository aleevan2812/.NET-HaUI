using System;
using System.Collections.Generic;

#nullable disable

namespace DemoNET.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
