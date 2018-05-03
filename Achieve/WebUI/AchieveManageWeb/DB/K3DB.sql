USE SYAIS
GO
/****** Object:  StoredProcedure [dbo].[sp_Pager]    Script Date: 2016/6/28 16:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Pager]
@tableName varchar(64),  --��ҳ����
@columns varchar(512),  --��ѯ���ֶ�
@order varchar(256),    --����ʽ
@pageSize int,  --ÿҳ��С
@pageIndex int,  --��ǰҳ
@where varchar(8000) = '1=1',  --��ѯ����
@totalCount int output  --�ܼ�¼��
as
declare @beginIndex int,@endIndex int,@sqlresult nvarchar(2000),@sqlGetCount nvarchar(2000)
set @beginIndex = (@pageIndex - 1) * @pageSize + 1  --��ʼ
set @endIndex = (@pageIndex) * @pageSize  --����
set @sqlresult = 'select '+@columns+' from (
select row_number() over(order by '+ @order +')
as Rownum,'+@columns+'
from '+@tableName+' where '+ @where +') as T
where T.Rownum between ' + CONVERT(varchar(max),@beginIndex) + ' and ' + CONVERT(varchar(max),@endIndex);
set @sqlGetCount = 'select @totalCount = count(*) from '+@tableName+' where ' + @where  --����
--print @sqlresult
exec(@sqlresult)
exec sp_executesql @sqlGetCount,N'@totalCount int output',@totalCount output