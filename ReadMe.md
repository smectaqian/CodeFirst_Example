# 项目说明

.Net Formwork和.Net 5的CodeFirst例子，Mysql、Sqlite

<hr>

### .Net Formwork
#### ConsoleAppNet472Sqlite
##### 框架
.Net Formwork 4.7.2
##### Nuget
SQLite.CodeFirst


#### ConsoleAppNet472Mysql
##### 框架
.Net Formwork 4.7.2
##### Nuget
MySql.Data.EntityFramework

<hr>

### .Net 5
#### ConsoleAppNet5Sqlite
##### 框架
.Net 5.0
##### Nuget
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
##### 存在问题
插入的数据顺序不对，如生成的列表IP自增和序号对不上


#### ConsoleAppNet5Mysql
##### 框架
.Net 5.0
##### Nuget
Microsoft.EntityFrameworkCore
Pomelo.EntityFrameworkCore.MySql
##### 存在问题
插入的数据顺序不对，如生成的列表IP自增和序号对不上

### 总结
好像Net5的Codefist批量（超过10行的情况，如果没有超过则不会出问题）插入的时候生成的id和插入时的顺序对不上，不知道是什么原因。
如果有知道原因的同事请发我邮箱，494942792@qq.com，定会收到我的感谢信😜