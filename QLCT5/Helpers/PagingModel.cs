using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCT5.Helpers
{
    public class PagingModel
    {
        public int currentPage { set; get; }
        public int countPages { set; get; }
        public Func<int?, string> generateUrl { set; get; }
    }
}
