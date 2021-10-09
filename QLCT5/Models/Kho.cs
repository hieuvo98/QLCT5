using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class Kho
    {
        public Kho()
        {
            TuKes = new HashSet<TuKe>();
        }

        public int IdKho { get; set; }
        [Display(Name = "Khu lưu trữ")]
        public string TenKho { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public virtual ICollection<TuKe> TuKes { get; set; }
    }
}
