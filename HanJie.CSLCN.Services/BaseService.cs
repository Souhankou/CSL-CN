using HanJie.CSLCN.Datas;
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
        public CSLDbContext _cslDbContext { get; set; }

        public BaseService()
        {
            this._cslDbContext = new CSLDbContext();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dto"></param>
        public async Task CreateAsync(TDataModelType data)
        {
            await _cslDbContext.Set<TDataModelType>().AddAsync(data);
            await _cslDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据 ID 删除实数据
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteByIdAsync(int id)
        {
            TDataModelType data = _cslDbContext.Set<TDataModelType>().Find(id);
            if (data == null)
                throw new ArgumentException($"指定删除的数据(id:{id})不存在");

            _cslDbContext.Set<TDataModelType>().Remove(data);
            await _cslDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="dto"></param>
        public async Task UpdateAsync(TDataModelType data)
        {
            _cslDbContext.Set<TDataModelType>().Update(data);
            await _cslDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据 ID 查询数据。
        /// </summary>
        /// <param name="id"></param>
        /// <returns>查找到的数据，或是 null</returns>
        public TDataModelType GetById(int id)
        {
            TDataModelType data = _cslDbContext.Set<TDataModelType>().Find(id);
            return data;
        }
    }
}