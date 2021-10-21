using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class ChucDanh
    {
        public ChucDanh()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int IdChucDanh { get; set; }
        [Display(Name = "Chức danh")]
        [Required(ErrorMessage = "Phải nhập tên {0}")]
        public string TenChucDanh { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
