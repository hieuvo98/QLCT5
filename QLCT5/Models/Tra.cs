using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLCT5.Models
{
    public class Tra
    {
        [Key]
        [Display(Name = "Mã trả")]
        public int TraId { get; set; }
        public int MaNvNhan { get; set; }
        public int MaNvTra { get; set; }
        [Display(Name = "Thời điểm trả")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayTra { get; set; }
        [ForeignKey("MaNvTra")]
        [Display(Name = "Nhân viên trả")]
        public virtual NhanVien NhanVienTra { get; set; }
        [ForeignKey("MaNvNhan")]
        [Display(Name = "Nhân viên nhận trả")]
        public virtual NhanVien NhanVienNhan { get; set; }
        [Display(Name = "Mã mượn")]
        public virtual Muon Muon { get; set; }
    }
}
