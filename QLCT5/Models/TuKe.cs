using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLCT5.Models
{
    public partial class TuKe
    {
        public TuKe()
        {
            KepChungTus = new HashSet<KepChungTu>();
        }

        public int IdTuKe { get; set; }
        [Display(Name = "Tủ/kệ")]
        public string TenTuKe { get; set; }
        public int? IdKho { get; set; }

        [Display(Name = "Kho lưu trữ")]
        public virtual Kho IdKhoNavigation { get; set; }
        public virtual ICollection<KepChungTu> KepChungTus { get; set; }
    }
}
