using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public class NhanVien
    {
        //public NhanVien()
        //{
        //    ChiTietMuonIdNhanVienNhanNavigations = new HashSet<ChiTietMuon>();
        //    ChiTietMuonIdNhanVienTraNavigations = new HashSet<ChiTietMuon>();
        //    MuonIdNhanVienChoNavigations = new HashSet<Muon>();
        //    MuonIdNhanVienMuonNavigations = new HashSet<Muon>();
        //}

        public int IdNhanVien { get; set; }
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SoDt { get; set; }
        public int? IdPhongBan { get; set; }
        public int? IdDonVi { get; set; }
        public int? IdChucDanh { get; set; }

        [Display(Name = "Chức danh")]
        public virtual ChucDanh IdChucDanhNavigation { get; set; }
        [Display(Name = "Đơn vị")]
        public virtual DonVi IdDonViNavigation { get; set; }
        [Display(Name = "Phòng ban")]
        public virtual PhongBan IdPhongBanNavigation { get; set; }
        //public virtual ICollection<ChiTietMuon> ChiTietMuonIdNhanVienNhanNavigations { get; set; }
        //public virtual ICollection<ChiTietMuon> ChiTietMuonIdNhanVienTraNavigations { get; set; }
        //public virtual ICollection<Muon> MuonIdNhanVienChoNavigations { get; set; }
        //public virtual ICollection<Muon> MuonIdNhanVienMuonNavigations { get; set; }
    }
}
