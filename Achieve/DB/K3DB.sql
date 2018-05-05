USE SYAIS
GO
/****** Object:  StoredProcedure [dbo].[sp_Pager]    Script Date: 2016/6/28 16:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Pager]
@tableName varchar(64),  --分页表名
@columns varchar(512),  --查询的字段
@order varchar(256),    --排序方式
@pageSize int,  --每页大小
@pageIndex int,  --当前页
@where varchar(8000) = '1=1',  --查询条件
@totalCount int output  --总记录数
as
declare @beginIndex int,@endIndex int,@sqlresult nvarchar(2000),@sqlGetCount nvarchar(2000)
set @beginIndex = (@pageIndex - 1) * @pageSize + 1  --开始
set @endIndex = (@pageIndex) * @pageSize  --结束
set @sqlresult = 'select '+@columns+' from (
select row_number() over(order by '+ @order +')
as Rownum,'+@columns+'
from '+@tableName+' where '+ @where +') as T
where T.Rownum between ' + CONVERT(varchar(max),@beginIndex) + ' and ' + CONVERT(varchar(max),@endIndex);
set @sqlGetCount = 'select @totalCount = count(*) from '+@tableName+' where ' + @where  --总数
--print @sqlresult
exec(@sqlresult)
exec sp_executesql @sqlGetCount,N'@totalCount int output',@totalCount output