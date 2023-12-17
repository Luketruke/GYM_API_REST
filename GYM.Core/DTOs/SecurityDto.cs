using GYM.Core.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int DojoId { get; set; }
        public string Role { get; set; }
        public int status { get; set; }
    }
}