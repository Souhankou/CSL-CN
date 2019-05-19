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
        /// 存储主要的维基文章所使用的数据库表。
        /// </summary>
        public DbSet<WikiPassage> WikiPassages { get; set; }

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
            string connStr = "User ID=root;Password=admin;Host=localhost;Port=3306;Database=CSLCN;Min Pool Size=0;Max Pool Size=100;";
            optionsBuilder.UseMySql(connStr);
        }

    }
}
