﻿using HanJie.CSLCN.Datas;
using HanJie.CSLCN.Models.DataModels;
using HanJie.CSLCN.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HanJie.CSLCN.Services
{
    public class BaseService<TDtoType, TDataModelType>
        where TDtoType : BaseDtoModel<TDtoType, TDataModelType>, new()
        where TDataModelType : BaseDataModel<TDataModelType, TDtoType>, new()     //约束继承此基类的子类必须拥有传输模型和数据模型，且数据模型和传输模型必须继承自 BaseDtoModel 和 BaseDataModel
    {
        public CSLDbContext CSLDbContext { get; set; }

        public BaseService()
        {
            this.CSLDbContext = new CSLDbContext();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dto"></param>
        public async Task AddAsync(TDataModelType data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            data.CreateDate = DateTime.Now;
            data.LastModifyDate = DateTime.Now;
            await CSLDbContext.Set<TDataModelType>().AddAsync(data);
            await CSLDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据 ID 删除实数据
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteByIdAsync(int id)
        {
            TDataModelType data = CSLDbContext.Set<TDataModelType>().Find(id);
            if (data == null)
                throw new ArgumentException($"指定删除的数据(id:{id})不存在");

            CSLDbContext.Set<TDataModelType>().Remove(data);
            await CSLDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="dto"></param>
        public async Task UpdateAsync(TDataModelType data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            data.LastModifyDate = DateTime.Now;
            CSLDbContext.Set<TDataModelType>().Update(data);
            await CSLDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据 ID 查询数据。
        /// </summary>
        /// <param name="id"></param>
        /// <returns>查找到的数据，或是 null</returns>
        public TDataModelType GetById(int id)
        {
            TDataModelType data = CSLDbContext.Set<TDataModelType>().Find(id);

            return data;
        }
    }
}