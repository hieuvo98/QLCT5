using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int IdPhongBan { get; set; }
        [Display(Name = "Phòng ban")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenPhongBan { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
