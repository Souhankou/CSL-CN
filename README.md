# CSL-CN

## 概述

城市天际线中文站点，虎牙汉界，开源项目。

## 常见构建命令

1.修改数据模型后执行以下操作，更新数据库模型。

```cmd
Add-Migration InitialCreate //修改 "InitialCreate" 为本次调整的详细说明
Update-Database

//备注，如果执行以上命令出现异常:
An item with the same key has already been added. Key: Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal.MySqlOptionsExtension
则注释 CSLDbContext 下的 OnConfiguring 方法，仅保留 base. 一行。

```
