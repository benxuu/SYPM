/******************************************************************
* 表名：Article
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([ID])+1 FROM [Article]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_Exists
@ID int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [Article] WHERE ID=@ID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_ADD
@ID int output,
@Title varchar(200),
@Content varchar(8000),
@FilePath nvarchar(200)

 AS 
	INSERT INTO [Article](
	[Title],[Content],[FilePath]
	)VALUES(
	@Title,@Content,@FilePath
	)
	SET @ID = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_Update
@ID int,
@Title varchar(200),
@Content varchar(8000),
@FilePath nvarchar(200)
 AS 
	UPDATE [Article] SET 
	[Title] = @Title,[Content] = @Content,[FilePath] = @FilePath
	WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_Delete
@ID int
 AS 
	DELETE [Article]
	 WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_GetModel
@ID int
 AS 
	SELECT 
	ID,Title,Content,FilePath
	 FROM [Article]
	 WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Article_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE Article_GetList
 AS 
	SELECT 
	ID,Title,Content,FilePath
	 FROM [Article]

GO


/******************************************************************
* 表名：tb_Test
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tb_Test]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tb_Test] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_ADD
@Id int output,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@FName nvarchar(50),
@FSex nvarchar(50),
@FAge int

 AS 
	INSERT INTO [tb_Test](
	[CreateTime],[CreateBy],[UpdateTime],[UpdateBy],[FName],[FSex],[FAge]
	)VALUES(
	@CreateTime,@CreateBy,@UpdateTime,@UpdateBy,@FName,@FSex,@FAge
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_Update
@Id int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@FName nvarchar(50),
@FSex nvarchar(50),
@FAge int
 AS 
	UPDATE [tb_Test] SET 
	[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy,[FName] = @FName,[FSex] = @FSex,[FAge] = @FAge
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_Delete
@Id int
 AS 
	DELETE [tb_Test]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_GetModel
@Id int
 AS 
	SELECT 
	Id,CreateTime,CreateBy,UpdateTime,UpdateBy,FName,FSex,FAge
	 FROM [tb_Test]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test_GetList
 AS 
	SELECT 
	Id,CreateTime,CreateBy,UpdateTime,UpdateBy,FName,FSex,FAge
	 FROM [tb_Test]

GO


/******************************************************************
* 表名：tb_Test1
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tb_Test1]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tb_Test1] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_ADD
@Id int output,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tb_Test1](
	[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_Update
@Id int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tb_Test1] SET 
	[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_Delete
@Id int
 AS 
	DELETE [tb_Test1]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_GetModel
@Id int
 AS 
	SELECT 
	Id,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tb_Test1]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tb_Test1_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tb_Test1_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tb_Test1_GetList
 AS 
	SELECT 
	Id,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tb_Test1]

GO


/******************************************************************
* 表名：tbAppendInfo
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_Exists
@AppendID nvarchar(50)
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbAppendInfo] WHERE AppendID=@AppendID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_ADD
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@AppendName nvarchar(50),
@AppendPath nvarchar(255),
@AppendImage image,
@Remark nvarchar(255)

 AS 
	INSERT INTO [tbAppendInfo](
	[AppendID],[AppendListID],[AppendName],[AppendPath],[AppendImage],[Remark]
	)VALUES(
	@AppendID,@AppendListID,@AppendName,@AppendPath,@AppendImage,@Remark
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_Update
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@AppendName nvarchar(50),
@AppendPath nvarchar(255),
@AppendImage image,
@Remark nvarchar(255)
 AS 
	UPDATE [tbAppendInfo] SET 
	[AppendListID] = @AppendListID,[AppendName] = @AppendName,[AppendPath] = @AppendPath,[AppendImage] = @AppendImage,[Remark] = @Remark
	WHERE AppendID=@AppendID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_Delete
@AppendID nvarchar(50)
 AS 
	DELETE [tbAppendInfo]
	 WHERE AppendID=@AppendID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_GetModel
@AppendID nvarchar(50)
 AS 
	SELECT 
	AppendID,AppendListID,AppendName,AppendPath,AppendImage,Remark
	 FROM [tbAppendInfo]
	 WHERE AppendID=@AppendID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbAppendInfo_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbAppendInfo_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbAppendInfo_GetList
 AS 
	SELECT 
	AppendID,AppendListID,AppendName,AppendPath,AppendImage,Remark
	 FROM [tbAppendInfo]

GO


/******************************************************************
* 表名：tbBasicInfo
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([InfoID])+1 FROM [tbBasicInfo]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_Exists
@InfoID int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbBasicInfo] WHERE InfoID=@InfoID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_ADD
@InfoID int,
@InfoName nvarchar(50),
@ParentID int,
@IsAble bit,
@Remark nvarchar(50)

 AS 
	INSERT INTO [tbBasicInfo](
	[InfoID],[InfoName],[ParentID],[IsAble],[Remark]
	)VALUES(
	@InfoID,@InfoName,@ParentID,@IsAble,@Remark
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_Update
@InfoID int,
@InfoName nvarchar(50),
@ParentID int,
@IsAble bit,
@Remark nvarchar(50)
 AS 
	UPDATE [tbBasicInfo] SET 
	[InfoName] = @InfoName,[ParentID] = @ParentID,[IsAble] = @IsAble,[Remark] = @Remark
	WHERE InfoID=@InfoID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_Delete
@InfoID int
 AS 
	DELETE [tbBasicInfo]
	 WHERE InfoID=@InfoID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_GetModel
@InfoID int
 AS 
	SELECT 
	InfoID,InfoName,ParentID,IsAble,Remark
	 FROM [tbBasicInfo]
	 WHERE InfoID=@InfoID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBasicInfo_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbBasicInfo_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbBasicInfo_GetList
 AS 
	SELECT 
	InfoID,InfoName,ParentID,IsAble,Remark
	 FROM [tbBasicInfo]

GO


/******************************************************************
* 表名：tbButton
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbButton]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbButton] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_ADD
@Id int output,
@Name varchar(50),
@Code varchar(50),
@Icon varchar(50),
@Sort int,
@Description varchar(100),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbButton](
	[Name],[Code],[Icon],[Sort],[Description],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@Name,@Code,@Icon,@Sort,@Description,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_Update
@Id int,
@Name varchar(50),
@Code varchar(50),
@Icon varchar(50),
@Sort int,
@Description varchar(100),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbButton] SET 
	[Name] = @Name,[Code] = @Code,[Icon] = @Icon,[Sort] = @Sort,[Description] = @Description,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_Delete
@Id int
 AS 
	DELETE [tbButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_GetModel
@Id int
 AS 
	SELECT 
	Id,Name,Code,Icon,Sort,Description,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbButton_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbButton_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbButton_GetList
 AS 
	SELECT 
	Id,Name,Code,Icon,Sort,Description,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbButton]

GO


/******************************************************************
* 表名：tbDataType
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbDataType]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbDataType] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_ADD
@Id int output,
@DataType nvarchar(50),
@DataTypeName nvarchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbDataType](
	[DataType],[DataTypeName],[Sort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@DataType,@DataTypeName,@Sort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_Update
@Id int,
@DataType nvarchar(50),
@DataTypeName nvarchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbDataType] SET 
	[DataType] = @DataType,[DataTypeName] = @DataTypeName,[Sort] = @Sort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_Delete
@Id int
 AS 
	DELETE [tbDataType]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_GetModel
@Id int
 AS 
	SELECT 
	Id,DataType,DataTypeName,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbDataType]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDataType_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDataType_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDataType_GetList
 AS 
	SELECT 
	Id,DataType,DataTypeName,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbDataType]

GO


/******************************************************************
* 表名：tbDepartment
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbDepartment]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbDepartment] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_ADD
@Id int output,
@DepartmentName varchar(50),
@ParentId int,
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbDepartment](
	[DepartmentName],[ParentId],[Sort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@DepartmentName,@ParentId,@Sort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_Update
@Id int,
@DepartmentName varchar(50),
@ParentId int,
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbDepartment] SET 
	[DepartmentName] = @DepartmentName,[ParentId] = @ParentId,[Sort] = @Sort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_Delete
@Id int
 AS 
	DELETE [tbDepartment]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_GetModel
@Id int
 AS 
	SELECT 
	Id,DepartmentName,ParentId,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbDepartment]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbDepartment_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbDepartment_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbDepartment_GetList
 AS 
	SELECT 
	Id,DepartmentName,ParentId,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbDepartment]

GO


/******************************************************************
* 表名：tbFields
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbFields]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbFields] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_ADD
@Id int output,
@TabId int,
@FieldName nvarchar(50),
@FieldViewName nvarchar(50),
@FieldDataTypeId int,
@IsActive bit,
@IsSearch bit,
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbFields](
	[TabId],[FieldName],[FieldViewName],[FieldDataTypeId],[IsActive],[IsSearch],[Sort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@TabId,@FieldName,@FieldViewName,@FieldDataTypeId,@IsActive,@IsSearch,@Sort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_Update
@Id int,
@TabId int,
@FieldName nvarchar(50),
@FieldViewName nvarchar(50),
@FieldDataTypeId int,
@IsActive bit,
@IsSearch bit,
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbFields] SET 
	[TabId] = @TabId,[FieldName] = @FieldName,[FieldViewName] = @FieldViewName,[FieldDataTypeId] = @FieldDataTypeId,[IsActive] = @IsActive,[IsSearch] = @IsSearch,[Sort] = @Sort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_Delete
@Id int
 AS 
	DELETE [tbFields]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_GetModel
@Id int
 AS 
	SELECT 
	Id,TabId,FieldName,FieldViewName,FieldDataTypeId,IsActive,IsSearch,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbFields]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbFields_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbFields_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbFields_GetList
 AS 
	SELECT 
	Id,TabId,FieldName,FieldViewName,FieldDataTypeId,IsActive,IsSearch,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbFields]

GO


/******************************************************************
* 表名：tbHtmlType
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbHtmlType]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbHtmlType] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_ADD
@Id int output,
@HtmlTypeName nvarchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbHtmlType](
	[HtmlTypeName],[Sort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@HtmlTypeName,@Sort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_Update
@Id int,
@HtmlTypeName nvarchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbHtmlType] SET 
	[HtmlTypeName] = @HtmlTypeName,[Sort] = @Sort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_Delete
@Id int
 AS 
	DELETE [tbHtmlType]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_GetModel
@Id int
 AS 
	SELECT 
	Id,HtmlTypeName,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbHtmlType]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbHtmlType_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbHtmlType_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbHtmlType_GetList
 AS 
	SELECT 
	Id,HtmlTypeName,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbHtmlType]

GO


/******************************************************************
* 表名：tbIcons
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbIcons]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbIcons] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_ADD
@Id int output,
@IconName nvarchar(100),
@IconCssInfo nvarchar(2000),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbIcons](
	[IconName],[IconCssInfo],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@IconName,@IconCssInfo,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_Update
@Id int,
@IconName nvarchar(100),
@IconCssInfo nvarchar(2000),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbIcons] SET 
	[IconName] = @IconName,[IconCssInfo] = @IconCssInfo,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_Delete
@Id int
 AS 
	DELETE [tbIcons]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_GetModel
@Id int
 AS 
	SELECT 
	Id,IconName,IconCssInfo,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbIcons]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbIcons_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbIcons_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbIcons_GetList
 AS 
	SELECT 
	Id,IconName,IconCssInfo,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbIcons]

GO


/******************************************************************
* 表名：tbLoginIpLog
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbLoginIpLog]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbLoginIpLog] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_ADD
@Id int output,
@IpAddress nvarchar(50),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbLoginIpLog](
	[IpAddress],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@IpAddress,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_Update
@Id int,
@IpAddress nvarchar(50),
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbLoginIpLog] SET 
	[IpAddress] = @IpAddress,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_Delete
@Id int
 AS 
	DELETE [tbLoginIpLog]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_GetModel
@Id int
 AS 
	SELECT 
	Id,IpAddress,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbLoginIpLog]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbLoginIpLog_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbLoginIpLog_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbLoginIpLog_GetList
 AS 
	SELECT 
	Id,IpAddress,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbLoginIpLog]

GO


/******************************************************************
* 表名：tbMenu
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbMenu]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbMenu] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_ADD
@Id int output,
@Name varchar(50),
@ParentId int,
@Code varchar(50),
@LinkAddress varchar(100),
@Icon varchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbMenu](
	[Name],[ParentId],[Code],[LinkAddress],[Icon],[Sort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@Name,@ParentId,@Code,@LinkAddress,@Icon,@Sort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_Update
@Id int,
@Name varchar(50),
@ParentId int,
@Code varchar(50),
@LinkAddress varchar(100),
@Icon varchar(50),
@Sort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbMenu] SET 
	[Name] = @Name,[ParentId] = @ParentId,[Code] = @Code,[LinkAddress] = @LinkAddress,[Icon] = @Icon,[Sort] = @Sort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_Delete
@Id int
 AS 
	DELETE [tbMenu]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_GetModel
@Id int
 AS 
	SELECT 
	Id,Name,ParentId,Code,LinkAddress,Icon,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbMenu]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenu_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenu_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenu_GetList
 AS 
	SELECT 
	Id,Name,ParentId,Code,LinkAddress,Icon,Sort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbMenu]

GO


/******************************************************************
* 表名：tbMenuButton
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbMenuButton]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbMenuButton] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_ADD
@Id int output,
@MenuId int,
@ButtonId int

 AS 
	INSERT INTO [tbMenuButton](
	[MenuId],[ButtonId]
	)VALUES(
	@MenuId,@ButtonId
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_Update
@Id int,
@MenuId int,
@ButtonId int
 AS 
	UPDATE [tbMenuButton] SET 
	[MenuId] = @MenuId,[ButtonId] = @ButtonId
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_Delete
@Id int
 AS 
	DELETE [tbMenuButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_GetModel
@Id int
 AS 
	SELECT 
	Id,MenuId,ButtonId
	 FROM [tbMenuButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMenuButton_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMenuButton_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMenuButton_GetList
 AS 
	SELECT 
	Id,MenuId,ButtonId
	 FROM [tbMenuButton]

GO


/******************************************************************
* 表名：tbMgrNodeInfo
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_Exists

AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbMgrNodeInfo] WHERE 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_ADD
@InfoID nvarchar(50),
@NodeID nvarchar(50),
@NodeName nvarchar(50),
@PSTime datetime,
@PETime datetime,
@RSTime datetime,
@RETime datetime,
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@Remark nvarchar(255),
@ProjectID nvarchar(50)

 AS 
	INSERT INTO [tbMgrNodeInfo](
	[InfoID],[NodeID],[NodeName],[PSTime],[PETime],[RSTime],[RETime],[AppendID],[AppendListID],[UpdateTime],[UpdateBy],[Remark],[ProjectID]
	)VALUES(
	@InfoID,@NodeID,@NodeName,@PSTime,@PETime,@RSTime,@RETime,@AppendID,@AppendListID,@UpdateTime,@UpdateBy,@Remark,@ProjectID
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_Update
@InfoID nvarchar(50),
@NodeID nvarchar(50),
@NodeName nvarchar(50),
@PSTime datetime,
@PETime datetime,
@RSTime datetime,
@RETime datetime,
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@Remark nvarchar(255),
@ProjectID nvarchar(50)
 AS 
	UPDATE [tbMgrNodeInfo] SET 
	[InfoID] = @InfoID,[NodeID] = @NodeID,[NodeName] = @NodeName,[PSTime] = @PSTime,[PETime] = @PETime,[RSTime] = @RSTime,[RETime] = @RETime,[AppendID] = @AppendID,[AppendListID] = @AppendListID,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy,[Remark] = @Remark,[ProjectID] = @ProjectID
	WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_Delete

 AS 
	DELETE [tbMgrNodeInfo]
	 WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_GetModel

 AS 
	SELECT 
	InfoID,NodeID,NodeName,PSTime,PETime,RSTime,RETime,AppendID,AppendListID,UpdateTime,UpdateBy,Remark,ProjectID
	 FROM [tbMgrNodeInfo]
	 WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbMgrNodeInfo_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbMgrNodeInfo_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbMgrNodeInfo_GetList
 AS 
	SELECT 
	InfoID,NodeID,NodeName,PSTime,PETime,RSTime,RETime,AppendID,AppendListID,UpdateTime,UpdateBy,Remark,ProjectID
	 FROM [tbMgrNodeInfo]

GO


/******************************************************************
* 表名：tbNews
* 时间：2018/5/24 星期四 0:00:43
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([id])+1 FROM [tbNews]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_Exists
@id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbNews] WHERE id=@id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_ADD
@id int output,
@ftypeid int,
@ftitle nvarchar(50),
@fcontent text,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbNews](
	[ftypeid],[ftitle],[fcontent],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@ftypeid,@ftitle,@fcontent,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_Update
@id int,
@ftypeid int,
@ftitle nvarchar(50),
@fcontent text,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbNews] SET 
	[ftypeid] = @ftypeid,[ftitle] = @ftitle,[fcontent] = @fcontent,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_Delete
@id int
 AS 
	DELETE [tbNews]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_GetModel
@id int
 AS 
	SELECT 
	id,ftypeid,ftitle,fcontent,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbNews]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNews_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNews_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:43
------------------------------------
CREATE PROCEDURE tbNews_GetList
 AS 
	SELECT 
	id,ftypeid,ftitle,fcontent,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbNews]

GO


/******************************************************************
* 表名：tbNewsType
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([id])+1 FROM [tbNewsType]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_Exists
@id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbNewsType] WHERE id=@id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_ADD
@id int output,
@ftypename nvarchar(50),
@fsort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbNewsType](
	[ftypename],[fsort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@ftypename,@fsort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_Update
@id int,
@ftypename nvarchar(50),
@fsort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbNewsType] SET 
	[ftypename] = @ftypename,[fsort] = @fsort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_Delete
@id int
 AS 
	DELETE [tbNewsType]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_GetModel
@id int
 AS 
	SELECT 
	id,ftypename,fsort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbNewsType]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbNewsType_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbNewsType_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbNewsType_GetList
 AS 
	SELECT 
	id,ftypename,fsort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbNewsType]

GO


/******************************************************************
* 表名：tbOper
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([OperID])+1 FROM [tbOper]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_Exists
@OperID int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbOper] WHERE OperID=@OperID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_ADD
@OperID int,
@OperName nvarchar(50),
@OperGroupID int,
@OperNote nvarchar(50),
@DayTime decimal(13,10),
@WeekTime decimal(13,10),
@MonthTime decimal(13,10),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@IsCheck bit,
@CheckTime datetime,
@CheckBy nvarchar(50),
@Remark nvarchar(150)

 AS 
	INSERT INTO [tbOper](
	[OperID],[OperName],[OperGroupID],[OperNote],[DayTime],[WeekTime],[MonthTime],[UpdateTime],[UpdateBy],[IsCheck],[CheckTime],[CheckBy],[Remark]
	)VALUES(
	@OperID,@OperName,@OperGroupID,@OperNote,@DayTime,@WeekTime,@MonthTime,@UpdateTime,@UpdateBy,@IsCheck,@CheckTime,@CheckBy,@Remark
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_Update
@OperID int,
@OperName nvarchar(50),
@OperGroupID int,
@OperNote nvarchar(50),
@DayTime decimal(13,10),
@WeekTime decimal(13,10),
@MonthTime decimal(13,10),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@IsCheck bit,
@CheckTime datetime,
@CheckBy nvarchar(50),
@Remark nvarchar(150)
 AS 
	UPDATE [tbOper] SET 
	[OperName] = @OperName,[OperGroupID] = @OperGroupID,[OperNote] = @OperNote,[DayTime] = @DayTime,[WeekTime] = @WeekTime,[MonthTime] = @MonthTime,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy,[IsCheck] = @IsCheck,[CheckTime] = @CheckTime,[CheckBy] = @CheckBy,[Remark] = @Remark
	WHERE OperID=@OperID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_Delete
@OperID int
 AS 
	DELETE [tbOper]
	 WHERE OperID=@OperID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_GetModel
@OperID int
 AS 
	SELECT 
	OperID,OperName,OperGroupID,OperNote,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,IsCheck,CheckTime,CheckBy,Remark
	 FROM [tbOper]
	 WHERE OperID=@OperID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOper_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOper_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOper_GetList
 AS 
	SELECT 
	OperID,OperName,OperGroupID,OperNote,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,IsCheck,CheckTime,CheckBy,Remark
	 FROM [tbOper]

GO


/******************************************************************
* 表名：tbOperGroup
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([OperGroupID])+1 FROM [tbOperGroup]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_Exists
@OperGroupID int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbOperGroup] WHERE OperGroupID=@OperGroupID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_ADD
@OperGroupID int,
@OperGroupName nvarchar(50),
@DayTime decimal(13,10),
@WeekTime decimal(13,10),
@MonthTime decimal(13,10),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@IsCheck bit,
@CheckTime datetime,
@CheckBy nvarchar(50),
@Remark nvarchar(150),
@AlertValue smallint

 AS 
	INSERT INTO [tbOperGroup](
	[OperGroupID],[OperGroupName],[DayTime],[WeekTime],[MonthTime],[UpdateTime],[UpdateBy],[IsCheck],[CheckTime],[CheckBy],[Remark],[AlertValue]
	)VALUES(
	@OperGroupID,@OperGroupName,@DayTime,@WeekTime,@MonthTime,@UpdateTime,@UpdateBy,@IsCheck,@CheckTime,@CheckBy,@Remark,@AlertValue
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_Update
@OperGroupID int,
@OperGroupName nvarchar(50),
@DayTime decimal(13,10),
@WeekTime decimal(13,10),
@MonthTime decimal(13,10),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@IsCheck bit,
@CheckTime datetime,
@CheckBy nvarchar(50),
@Remark nvarchar(150),
@AlertValue smallint
 AS 
	UPDATE [tbOperGroup] SET 
	[OperGroupName] = @OperGroupName,[DayTime] = @DayTime,[WeekTime] = @WeekTime,[MonthTime] = @MonthTime,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy,[IsCheck] = @IsCheck,[CheckTime] = @CheckTime,[CheckBy] = @CheckBy,[Remark] = @Remark,[AlertValue] = @AlertValue
	WHERE OperGroupID=@OperGroupID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_Delete
@OperGroupID int
 AS 
	DELETE [tbOperGroup]
	 WHERE OperGroupID=@OperGroupID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_GetModel
@OperGroupID int
 AS 
	SELECT 
	OperGroupID,OperGroupName,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,IsCheck,CheckTime,CheckBy,Remark,AlertValue
	 FROM [tbOperGroup]
	 WHERE OperGroupID=@OperGroupID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbOperGroup_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbOperGroup_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbOperGroup_GetList
 AS 
	SELECT 
	OperGroupID,OperGroupName,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,IsCheck,CheckTime,CheckBy,Remark,AlertValue
	 FROM [tbOperGroup]

GO


/******************************************************************
* 表名：tbProject
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_Exists
@ProjectID nvarchar(50)
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbProject] WHERE ProjectID=@ProjectID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_ADD
@ProjectID nvarchar(50),
@ProjectNo nvarchar(50),
@ProjectName nvarchar(50),
@ProjectManager nvarchar(50),
@ProjectClerk nvarchar(50),
@Remark nvarchar(255),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@CreateBy nvarchar(50),
@CreateTime datetime

 AS 
	INSERT INTO [tbProject](
	[ProjectID],[ProjectNo],[ProjectName],[ProjectManager],[ProjectClerk],[Remark],[UpdateTime],[UpdateBy],[AppendID],[AppendListID],[CreateBy],[CreateTime]
	)VALUES(
	@ProjectID,@ProjectNo,@ProjectName,@ProjectManager,@ProjectClerk,@Remark,@UpdateTime,@UpdateBy,@AppendID,@AppendListID,@CreateBy,@CreateTime
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_Update
@ProjectID nvarchar(50),
@ProjectNo nvarchar(50),
@ProjectName nvarchar(50),
@ProjectManager nvarchar(50),
@ProjectClerk nvarchar(50),
@Remark nvarchar(255),
@UpdateTime datetime,
@UpdateBy nvarchar(50),
@AppendID nvarchar(50),
@AppendListID nvarchar(50),
@CreateBy nvarchar(50),
@CreateTime datetime
 AS 
	UPDATE [tbProject] SET 
	[ProjectNo] = @ProjectNo,[ProjectName] = @ProjectName,[ProjectManager] = @ProjectManager,[ProjectClerk] = @ProjectClerk,[Remark] = @Remark,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy,[AppendID] = @AppendID,[AppendListID] = @AppendListID,[CreateBy] = @CreateBy,[CreateTime] = @CreateTime
	WHERE ProjectID=@ProjectID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_Delete
@ProjectID nvarchar(50)
 AS 
	DELETE [tbProject]
	 WHERE ProjectID=@ProjectID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_GetModel
@ProjectID nvarchar(50)
 AS 
	SELECT 
	ProjectID,ProjectNo,ProjectName,ProjectManager,ProjectClerk,Remark,UpdateTime,UpdateBy,AppendID,AppendListID,CreateBy,CreateTime
	 FROM [tbProject]
	 WHERE ProjectID=@ProjectID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbProject_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbProject_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbProject_GetList
 AS 
	SELECT 
	ProjectID,ProjectNo,ProjectName,ProjectManager,ProjectClerk,Remark,UpdateTime,UpdateBy,AppendID,AppendListID,CreateBy,CreateTime
	 FROM [tbProject]

GO


/******************************************************************
* 表名：tbRequestion
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([id])+1 FROM [tbRequestion]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_Exists
@id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbRequestion] WHERE id=@id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_ADD
@id int output,
@ftypeid int,
@ftitle nvarchar(50),
@fcontent text,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbRequestion](
	[ftypeid],[ftitle],[fcontent],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@ftypeid,@ftitle,@fcontent,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_Update
@id int,
@ftypeid int,
@ftitle nvarchar(50),
@fcontent text,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbRequestion] SET 
	[ftypeid] = @ftypeid,[ftitle] = @ftitle,[fcontent] = @fcontent,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_Delete
@id int
 AS 
	DELETE [tbRequestion]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_GetModel
@id int
 AS 
	SELECT 
	id,ftypeid,ftitle,fcontent,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbRequestion]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestion_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestion_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestion_GetList
 AS 
	SELECT 
	id,ftypeid,ftitle,fcontent,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbRequestion]

GO


/******************************************************************
* 表名：tbRequestionType
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([id])+1 FROM [tbRequestionType]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_Exists
@id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbRequestionType] WHERE id=@id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_ADD
@id int output,
@ftypename nvarchar(50),
@fsort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbRequestionType](
	[ftypename],[fsort],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@ftypename,@fsort,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_Update
@id int,
@ftypename nvarchar(50),
@fsort int,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbRequestionType] SET 
	[ftypename] = @ftypename,[fsort] = @fsort,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_Delete
@id int
 AS 
	DELETE [tbRequestionType]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_GetModel
@id int
 AS 
	SELECT 
	id,ftypename,fsort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbRequestionType]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRequestionType_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRequestionType_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRequestionType_GetList
 AS 
	SELECT 
	id,ftypename,fsort,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbRequestionType]

GO


/******************************************************************
* 表名：tbRole
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbRole]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbRole] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_ADD
@Id int output,
@RoleName varchar(50),
@Description varchar(100),
@CreateBy nvarchar(50),
@CreateTime datetime,
@UpdateBy nvarchar(50),
@UpdateTime datetime

 AS 
	INSERT INTO [tbRole](
	[RoleName],[Description],[CreateBy],[CreateTime],[UpdateBy],[UpdateTime]
	)VALUES(
	@RoleName,@Description,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_Update
@Id int,
@RoleName varchar(50),
@Description varchar(100),
@CreateBy nvarchar(50),
@CreateTime datetime,
@UpdateBy nvarchar(50),
@UpdateTime datetime
 AS 
	UPDATE [tbRole] SET 
	[RoleName] = @RoleName,[Description] = @Description,[CreateBy] = @CreateBy,[CreateTime] = @CreateTime,[UpdateBy] = @UpdateBy,[UpdateTime] = @UpdateTime
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_Delete
@Id int
 AS 
	DELETE [tbRole]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_GetModel
@Id int
 AS 
	SELECT 
	Id,RoleName,Description,CreateBy,CreateTime,UpdateBy,UpdateTime
	 FROM [tbRole]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRole_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRole_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRole_GetList
 AS 
	SELECT 
	Id,RoleName,Description,CreateBy,CreateTime,UpdateBy,UpdateTime
	 FROM [tbRole]

GO


/******************************************************************
* 表名：tbRoleMenu
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbRoleMenu]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbRoleMenu] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_ADD
@Id int output,
@RoleId int,
@MenuId int

 AS 
	INSERT INTO [tbRoleMenu](
	[RoleId],[MenuId]
	)VALUES(
	@RoleId,@MenuId
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_Update
@Id int,
@RoleId int,
@MenuId int
 AS 
	UPDATE [tbRoleMenu] SET 
	[RoleId] = @RoleId,[MenuId] = @MenuId
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_Delete
@Id int
 AS 
	DELETE [tbRoleMenu]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_GetModel
@Id int
 AS 
	SELECT 
	Id,RoleId,MenuId
	 FROM [tbRoleMenu]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenu_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenu_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenu_GetList
 AS 
	SELECT 
	Id,RoleId,MenuId
	 FROM [tbRoleMenu]

GO


/******************************************************************
* 表名：tbRoleMenuButton
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbRoleMenuButton]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbRoleMenuButton] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_ADD
@Id int output,
@RoleId int,
@MenuId int,
@ButtonId int

 AS 
	INSERT INTO [tbRoleMenuButton](
	[RoleId],[MenuId],[ButtonId]
	)VALUES(
	@RoleId,@MenuId,@ButtonId
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_Update
@Id int,
@RoleId int,
@MenuId int,
@ButtonId int
 AS 
	UPDATE [tbRoleMenuButton] SET 
	[RoleId] = @RoleId,[MenuId] = @MenuId,[ButtonId] = @ButtonId
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_Delete
@Id int
 AS 
	DELETE [tbRoleMenuButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_GetModel
@Id int
 AS 
	SELECT 
	Id,RoleId,MenuId,ButtonId
	 FROM [tbRoleMenuButton]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbRoleMenuButton_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbRoleMenuButton_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbRoleMenuButton_GetList
 AS 
	SELECT 
	Id,RoleId,MenuId,ButtonId
	 FROM [tbRoleMenuButton]

GO


/******************************************************************
* 表名：tbTable
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbTable]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbTable] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_ADD
@Id int output,
@TabName nvarchar(50),
@TabViewName nvarchar(50),
@IsActive bit,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)

 AS 
	INSERT INTO [tbTable](
	[TabName],[TabViewName],[IsActive],[CreateTime],[CreateBy],[UpdateTime],[UpdateBy]
	)VALUES(
	@TabName,@TabViewName,@IsActive,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_Update
@Id int,
@TabName nvarchar(50),
@TabViewName nvarchar(50),
@IsActive bit,
@CreateTime datetime,
@CreateBy nvarchar(50),
@UpdateTime datetime,
@UpdateBy nvarchar(50)
 AS 
	UPDATE [tbTable] SET 
	[TabName] = @TabName,[TabViewName] = @TabViewName,[IsActive] = @IsActive,[CreateTime] = @CreateTime,[CreateBy] = @CreateBy,[UpdateTime] = @UpdateTime,[UpdateBy] = @UpdateBy
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_Delete
@Id int
 AS 
	DELETE [tbTable]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_GetModel
@Id int
 AS 
	SELECT 
	Id,TabName,TabViewName,IsActive,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbTable]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbTable_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbTable_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbTable_GetList
 AS 
	SELECT 
	Id,TabName,TabViewName,IsActive,CreateTime,CreateBy,UpdateTime,UpdateBy
	 FROM [tbTable]

GO


/******************************************************************
* 表名：tbUser
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([ID])+1 FROM [tbUser]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_Exists
@ID int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbUser] WHERE ID=@ID 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_ADD
@ID int output,
@AccountName nvarchar(50),
@Password nvarchar(50),
@RealName nvarchar(50),
@MobilePhone nvarchar(50),
@Email nvarchar(50),
@IsAble bit,
@IfChangePwd bit,
@Description nvarchar(MAX),
@CreateBy nvarchar(50),
@CreateTime datetime,
@UpdateBy nvarchar(50),
@UpdateTime datetime

 AS 
	INSERT INTO [tbUser](
	[AccountName],[Password],[RealName],[MobilePhone],[Email],[IsAble],[IfChangePwd],[Description],[CreateBy],[CreateTime],[UpdateBy],[UpdateTime]
	)VALUES(
	@AccountName,@Password,@RealName,@MobilePhone,@Email,@IsAble,@IfChangePwd,@Description,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime
	)
	SET @ID = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_Update
@ID int,
@AccountName nvarchar(50),
@Password nvarchar(50),
@RealName nvarchar(50),
@MobilePhone nvarchar(50),
@Email nvarchar(50),
@IsAble bit,
@IfChangePwd bit,
@Description nvarchar(MAX),
@CreateBy nvarchar(50),
@CreateTime datetime,
@UpdateBy nvarchar(50),
@UpdateTime datetime
 AS 
	UPDATE [tbUser] SET 
	[AccountName] = @AccountName,[Password] = @Password,[RealName] = @RealName,[MobilePhone] = @MobilePhone,[Email] = @Email,[IsAble] = @IsAble,[IfChangePwd] = @IfChangePwd,[Description] = @Description,[CreateBy] = @CreateBy,[CreateTime] = @CreateTime,[UpdateBy] = @UpdateBy,[UpdateTime] = @UpdateTime
	WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_Delete
@ID int
 AS 
	DELETE [tbUser]
	 WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_GetModel
@ID int
 AS 
	SELECT 
	ID,AccountName,Password,RealName,MobilePhone,Email,IsAble,IfChangePwd,Description,CreateBy,CreateTime,UpdateBy,UpdateTime
	 FROM [tbUser]
	 WHERE ID=@ID 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUser_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUser_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUser_GetList
 AS 
	SELECT 
	ID,AccountName,Password,RealName,MobilePhone,Email,IsAble,IfChangePwd,Description,CreateBy,CreateTime,UpdateBy,UpdateTime
	 FROM [tbUser]

GO


/******************************************************************
* 表名：tbUserDepartment
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_GetMaxId]
GO
------------------------------------
--用途：得到主键字段最大值 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_GetMaxId
AS
	DECLARE @TempID int
	SELECT @TempID = max([Id])+1 FROM [tbUserDepartment]
	IF @TempID IS NULL
		RETURN 1
	ELSE
		RETURN @TempID

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_Exists
@Id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbUserDepartment] WHERE Id=@Id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_ADD
@Id int output,
@UserId int,
@DepartmentId int

 AS 
	INSERT INTO [tbUserDepartment](
	[UserId],[DepartmentId]
	)VALUES(
	@UserId,@DepartmentId
	)
	SET @Id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_Update
@Id int,
@UserId int,
@DepartmentId int
 AS 
	UPDATE [tbUserDepartment] SET 
	[UserId] = @UserId,[DepartmentId] = @DepartmentId
	WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_Delete
@Id int
 AS 
	DELETE [tbUserDepartment]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_GetModel
@Id int
 AS 
	SELECT 
	Id,UserId,DepartmentId
	 FROM [tbUserDepartment]
	 WHERE Id=@Id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserDepartment_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserDepartment_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserDepartment_GetList
 AS 
	SELECT 
	Id,UserId,DepartmentId
	 FROM [tbUserDepartment]

GO


/******************************************************************
* 表名：tbUserRole
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_Exists
@id int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [tbUserRole] WHERE id=@id 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_ADD
@id int output,
@UserId int,
@RoleId int

 AS 
	INSERT INTO [tbUserRole](
	[UserId],[RoleId]
	)VALUES(
	@UserId,@RoleId
	)
	SET @id = @@IDENTITY

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_Update
@id int,
@UserId int,
@RoleId int
 AS 
	UPDATE [tbUserRole] SET 
	[UserId] = @UserId,[RoleId] = @RoleId
	WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_Delete
@id int
 AS 
	DELETE [tbUserRole]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_GetModel
@id int
 AS 
	SELECT 
	id,UserId,RoleId
	 FROM [tbUserRole]
	 WHERE id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbUserRole_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tbUserRole_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE tbUserRole_GetList
 AS 
	SELECT 
	id,UserId,RoleId
	 FROM [tbUserRole]

GO


/******************************************************************
* 表名：test
* 时间：2018/5/24 星期四 0:00:44
* Made by Codematic
******************************************************************/


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_Exists]
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_Exists

AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [test] WHERE 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_ADD]
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_ADD
@id int,
@text nvarchar(200),
@name nvarchar(50)

 AS 
	INSERT INTO [test](
	[id],[text],[name]
	)VALUES(
	@id,@text,@name
	)

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_Update]
GO
------------------------------------
--用途：修改一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_Update
@id int,
@text nvarchar(200),
@name nvarchar(50)
 AS 
	UPDATE [test] SET 
	[id] = @id,[text] = @text,[name] = @name
	WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_Delete]
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_Delete

 AS 
	DELETE [test]
	 WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_GetModel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_GetModel

 AS 
	SELECT 
	id,text,name
	 FROM [test]
	 WHERE 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test_GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[test_GetList]
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2018/5/24 星期四 0:00:44
------------------------------------
CREATE PROCEDURE test_GetList
 AS 
	SELECT 
	id,text,name
	 FROM [test]

GO


