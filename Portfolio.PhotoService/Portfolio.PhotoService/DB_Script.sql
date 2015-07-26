
create table Products
(
	Id int identity(1,1) not null,
	CreationDate datetime not null default (GETDATE()),
	constraint PK_Products primary key(Id)
)

create Table ProductPhotoBlobs
(
	Id int identity(1,1) not null,
	GuidId uniqueidentifier rowguidcol not null default(NEWID()),
	Blob varbinary(max) filestream,
	ProductId int not null,
	CreationDate datetime not null default (GETDATE()),
	constraint PK_PhotoBlobs primary key(Id),
	constraint FK_ProductPhotoBlobs_Products foreign key(ProductId) references Products(Id),
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


