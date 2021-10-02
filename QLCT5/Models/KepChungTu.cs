using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class KepChungTu
    {
        public KepChungTu()
        {
            ChungTus = new HashSet<ChungTu>();
        }

        public int IdKepChungTu { get; set; }
        [Display(Name = "Số hợp đồng")]
        public string SoHopDong { get; set; }
        [Display(Name = "Tên kẹp")]
        public string TenKepChungTu { get; set; }
        [Display(Name = "Năm")]
        public int? NamCt { get; set; }
        [Display(Name = "Tháng")]
        public int? ThangCt { get; set; }
        public int? IdTuKe { get; set; }

        [Display(Name = "Tủ/kệ")]
        public virtual TuKe IdTuKeNavigation { get; set; }
        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}
