create table merchant
(
    Id bigint identity(1,1) not null,
    PublicId uniqueidentifier not null default newsequentialid(),
    Name varchar(100) not null,
    Description varchar(200),
    IsActive bit not null default 1,
    CreateDate datetime2 not null,
    ModifyDate datetime2,
    constraint PK_Merchant primary key (Id),
    constraint UQ_Merchant unique (PublicId)
);

create table merchant_setting
(
    MerchantId bigint not null,
    BaseUrl varchar(255),
    BaseImageUrl varchar(255),
    LogoUrl varchar(255),
    MastheadBackgroundUrl varchar(255),
    MastheadBackgroundColor varchar(20),
    MenuImageBaseUrl varchar(255),
    JsonCommunicationConfiguration nvarchar(max),
    CreateDate datetime2 not null,
    ModifyDate datetime2,
    constraint FK_Merchant_Merchant_Setting foreign key (MerchantId) references merchant (Id),
    constraint PK_Merchant_Setting primary key (MerchantId)
    
);

create table payment_gateway
(
    Id int identity(1,1) not null,
    Name varchar(100) not null,
    Description varchar(200),
    JsonAllowedPaymentMethods nvarchar(max) not null,
    CreateDate datetime2 not null,
    ModifyDate datetime2,
    constraint PK_Payment_Gateway primary key (Id)
);

create table merchant_payment_gateway
(
    MerchantId bigint not null,
    PaymentGatewayId int not null,
    JsonApiConfiguration nvarchar(max) not null,
    CreateDate datetime2 not null,
    ModifyDate datetime2,
    constraint FK_Merchant_Merchant_Payment_Gateway foreign key (MerchantId) references merchant (Id),
    constraint FK_Payment_Gateway_Merchant_Payment_Gateway foreign key (PaymentGatewayId) references payment_gateway (Id),
    constraint PK_Merchant_Payment_Gateway primary key (MerchantId, PaymentGatewayId)
);