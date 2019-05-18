using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HanJie.CSLCN.Models.DataModels
{
    public class DataModelBase
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime LastModifyDate { get; set; }
    }
}
