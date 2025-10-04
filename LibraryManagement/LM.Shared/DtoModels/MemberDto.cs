using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Shared.DtoModels
{
    internal class MemberDto
    {
        public long MemberId { get; set; }
        public string FullName {  get; set; } = string.Empty;
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }
        
    }
}
