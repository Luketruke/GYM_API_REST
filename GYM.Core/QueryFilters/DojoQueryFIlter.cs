using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Core.QueryFilters
{
    public class DojoQueryFIlter
    {
        public string? name { get; set; }
        public string? instructorName { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
