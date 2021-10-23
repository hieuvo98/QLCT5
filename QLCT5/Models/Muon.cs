using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace QLCT5.Models
{
    public class Muon
    {
        [Key]
        [Display(Name = "Mã mượn")]
        public int MuonId { get; set; }
        public int MaNvCho { get; set; }
        public int MaNvMuon { get; set; }
        [Display(Name = "Ngày cho mượn")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayMuon { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }

        [ForeignKey("MaNvMuon")]
        [Display(Name = "Nhân viên mượn")]
        public virtual NhanVien NhanVienMuon { get; set; }
        [ForeignKey("MaNvCho")]
        [Display(Name = "Nhân viên cho")]
        public virtual NhanVien NhanVienCho { get; set; }
        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; }
        public virtual Tra Tra { get; set; }
    }
}
