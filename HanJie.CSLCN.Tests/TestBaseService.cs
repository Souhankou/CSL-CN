using HanJie.CSLCN.Datas;
using HanJie.CSLCN.Models.DataModels;
using HanJie.CSLCN.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HanJie.CSLCN.Tests
{
    public class TestBaseService
    {
        [Fact]
        public async Task TestBaseServiceDbWrite_ShouldCreateAsync()
        {
            var options = new DbContextOptionsBuilder<CSLDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Writes_to_database")
                .Options;

            using (var context = new CSLDbContext(options))
            {
                var service = new WikiPassageService();

                WikiPassage passageToCreate = new WikiPassage();
                passageToCreate.Title = "功能介绍";
                passageToCreate.Content = "这是第一篇维基内容";
                passageToCreate.CreateDate = DateTime.Now;
                passageToCreate.LastModifyDate = DateTime.Now;

                await service.CreateAsync(passageToCreate);

                WikiPassage passage = service.GetById(1);

                Assert.NotNull(passage);

            }
        }
    }
}
