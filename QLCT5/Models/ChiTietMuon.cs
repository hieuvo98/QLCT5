using System;
using System.Collections.Generic;

#nullable disable

namespace QLCT5.Models
{
    public partial class ChiTietMuon
    {
        public int IdMuon { get; set; }
        public int? IdNhanVienTra { get; set; }
        public int? IdNhanVienNhan { get; set; }
        public int IdChungTu { get; set; }
        public DateTime? NgayTra { get; set; }

        public virtual ChungTu IdChungTuNavigation { get; set; }
        public virtual Muon IdMuonNavigation { get; set; }
        public virtual NhanVien IdNhanVienNhanNavigation { get; set; }
        public virtual NhanVien IdNhanVienTraNavigation { get; set; }
    }
}
