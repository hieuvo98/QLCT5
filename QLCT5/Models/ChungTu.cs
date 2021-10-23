using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class ChungTu
    {
        //public ChungTu()
        //{
        //    ChiTietMuons = new HashSet<ChiTietMuon>();
        //}

        public int IdChungTu { get; set; }
        [Display(Name = "Mã chứng từ")]
        public string MaChungTu { get; set; }
        [Required(ErrorMessage = "Phải chọn đơn vị")]
        public int? IdDonVi { get; set; }
        [Display(Name = "Tên chứng từ")]
        public string TenChungTu { get; set; }
        [Display(Name = "Ngày thêm")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayChungTu { get; set; }
        public int? IdKepChungTu { get; set; }
        [Display(Name = "Số tập")]
        public int? SoLuong { get; set; }

        [Display(Name = "Đơn vị")]
        public virtual DonVi IdDonViNavigation { get; set; }
        [Display(Name = "Kẹp Chứng Từ")]
        public virtual KepChungTu IdKepChungTuNavigation { get; set; }
        //public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; }
    }
}
