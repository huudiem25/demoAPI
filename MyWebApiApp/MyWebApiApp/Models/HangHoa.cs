using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Models
{
    public class HangHoaVM
    {
        public string TenSach { get; set; }
        public double DonGia { get; set; }
    }
    public class HangHoa : HangHoaVM
    {
        public Guid MaSach { get; set; }
    }
    public class HangHoaModel
    {
        public Guid MaSach { get; set; }
        public string TenSach { get; set; }
        public string Mota { get; set; }
        public byte GiamGia { get; set; }
        public double DonGia { get; set; }
        public string TheLoai { get; set; }
    }
}
