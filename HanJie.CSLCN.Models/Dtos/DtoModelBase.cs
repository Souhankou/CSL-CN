using System;
using System.Collections.Generic;
using System.Text;

namespace HanJie.CSLCN.Models.Dtos
{
    public class DtoModelBase
    {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public string LastModifyDate { get; set; }
    }
}
