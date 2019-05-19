using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HanJie.CSLCN.Models.Dtos
{
    public class BaseDtoModel<TDtoType, TDataModelType>
        where TDtoType : class, new() //标记继承于此方法的必须是一个类，并且具备无参的构造函数
        where TDataModelType : class, new()
    {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public string LastModifyDate { get; set; }

        /// <summary>
        /// 将数据模型转换为传输模型。
        /// </summary>
        public TDtoType ConvertFromDataModel(TDataModelType dataModel)
        {
            TDtoType result = new TDtoType();
            foreach (PropertyInfo item in dataModel.GetType().GetProperties())
            {
                string propName = item.Name;
                result.GetType().GetProperty(propName).SetValue(result, item.GetValue(dataModel));
            }

            return result;
        }
    }
}
