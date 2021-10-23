using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class DonVi
    {
        public DonVi()
        {
            ChungTus = new HashSet<ChungTu>();
            NhanViens = new HashSet<NhanVien>();
        }

        public int IdDonVi { get; set; }
        [Display(Name = "Đơn vị")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenDonVi { get; set; }

        public virtual ICollection<ChungTu> ChungTus { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
