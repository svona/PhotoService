
create Table ProductPhotoBlobs
(
	Id int identity(1,1) not null,
	GuidId uniqueidentifier rowguidcol not null default(NEWID()),
	Blob varbinary(max) filestream,
	ProductId int not null,
	CreationDate datetime not null default (GETDATE()),
	constraint PK_PhotoBlobs primary key(Id),
	constraint UQ_ProductPhotoBlobs_GuidId unique(GuidId)
)

create table ProductPhotoMetaData
(
	ProductPhotoBlobId int not null,
	CreatedBy nvarchar(50) not null,
	CreationDate datetime not null default (GETDATE()),
	LengthInBytes int not null,
	WidthInPixels int not null,
	HeightInPixels int not null,
	ContentType varchar(255) not null,
	MD5Checksum varbinary(16) not null
)

GO

create procedure GetPhoto
(
	@photoId int
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select a.Blob.PathName() as [PathName], b.ContentType,
	GET_FILESTREAM_TRANSACTION_CONTEXT() as txContext
	from ProductPhotoBlobs a
	inner join ProductPhotoMetaData b on a.Id = b.ProductPhotoBlobId
	where a.Id = @photoId
END

GO

create procedure SavePhoto
(
	@productId int,
	@createdBy nvarchar(50),
	@widthInPixels int,
	@heightInPixels int,
	@lengthInBytes int,
	@contentType varchar(255),
	@md5Checksum varbinary(16)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	insert into ProductPhotoBlobs(ProductId, Blob)
	output inserted.Blob.PathName() as [PathName], inserted.Id,
	GET_FILESTREAM_TRANSACTION_CONTEXT() as txContext
	values(@productId, null)

	insert into ProductPhotoMetaData(ProductPhotoBlobId, CreatedBy, 
	LengthInBytes, WidthInPixels, HeightInPixels, ContentType, MD5Checksum)
	values(SCOPE_IDENTITY(), @createdBy, 
	@lengthInBytes, @widthInPixels, @heightInPixels, @contentType, @md5Checksum)
END

GO