using HanJie.CSLCN.Models.DataModels;
using HanJie.CSLCN.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanJie.CSLCN.Models.Dtos
{
    public class MenuDto : BaseDtoModel<MenuDto, Menu>
    {
        public MenuTypeEnum MenuType { get; set; }
        /// <summary>
        /// 菜单(或分类)名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级分类ID
        /// </summary>
        public int ParentId { get; set; }
    }
}
