using System;
using System.Collections.Generic;

#nullable disable

namespace QLCT5.Models
{
    public partial class Muon
    {
        public Muon()
        {
            ChiTietMuons = new HashSet<ChiTietMuon>();
        }

        public int IdMuon { get; set; }
        public int? IdNhanVienMuon { get; set; }
        public int? IdNhanVienCho { get; set; }
        public DateTime? NgayMuon { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien IdNhanVienChoNavigation { get; set; }
        public virtual NhanVien IdNhanVienMuonNavigation { get; set; }
        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; }
    }
}
