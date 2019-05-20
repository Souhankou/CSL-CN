using HanJie.CSLCN.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanJie.CSLCN.Datas
{
    public class CSLDbContext : DbContext
    {
        /// <summary>
        /// 用户信息表
        /// </summary>
        public DbSet<UserInfo> UserInfoes { get; set; }

        /// <summary>
        /// 存储主要的维基文章所使用的数据库表。
        /// </summary>
        public DbSet<WikiPassage> WikiPassages { get; set; }
        /// <summary>
        /// 主菜单信息表
        /// </summary>
        public DbSet<Menu> Menus { get; set; }

        public CSLDbContext()
        {

        }

        public CSLDbContext(DbContextOptions<CSLDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI goes here.
            //优先使用 Attrbiute 标记，FluentAPI 优先级高于其他，在使用前请先仔细检查其他数据模型的标记情况。

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //执行 Add-Migration 报错时，注释一下 if -else 代码段。（但要保留 base. 一行）
            //if (AppDomain.CurrentDomain.BaseDirectory.Contains("HanJie.CSLCN.Tests"))    //如果从单元测试调用此构造函数，则采用内存中数据库
            //{
            //    var options = new DbContextOptionsBuilder<CSLDbContext>()
            //        .UseInMemoryDatabase(databaseName: "Add_Writes_to_database")
            //        .Options;
            //    optionsBuilder.UseInMemoryDatabase("test");
            //}
            //else
            //{
                string connStr = "User ID=root;Password=admin;Host=localhost;Port=3306;Database=CSLCN;Min Pool Size=0;Max Pool Size=100;";
                optionsBuilder.UseMySql(connStr);
            //}
            //base.OnConfiguring(optionsBuilder);
        }

    }
}
