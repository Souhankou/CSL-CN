using HanJie.CSLCN.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanJie.CSLCN.Models.Dtos
{
    public class WikiPassageDto : BaseDtoModel<WikiPassageDto, WikiPassage>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
