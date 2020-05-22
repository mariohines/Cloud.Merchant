create table if not exists merchant
(
    Id bigint not null auto_increment,
    PublicId varchar(36) not null default uuid(),
    Name varchar(100) not null,
    Description varchar(200),
    IsActive bit not null default 1,
    CreateDate datetime not null,
    ModifyDate datetime,
    constraint PK_Merchant primary key (Id),
    constraint UQ_Merchant unique (PublicId)
) auto_increment = 1;

create table if not exists merchant_setting
(
    MerchantId bigint not null,
    BaseUrl varchar(255),
    BaseImageUrl varchar(255),
    LogoUrl varchar(255),
    MastheadBackgroundUrl varchar(255),
    MastheadBackgroundColor varchar(20),
    MenuImageBaseUrl varchar(255),
    JsonCommunicationConfiguration json,
    CreateDate datetime not null,
    ModifyDate datetime,
    constraint PK_Merchant_Setting primary key (MerchantId),
    constraint FK_Merchant_Merchant_Setting foreign key (MerchantId) references merchant (Id)
) auto_increment = 1;

create table if not exists payment_gateway
(
    Id int not null auto_increment,
    Name varchar(100) not null,
    Description varchar(200),
    JsonAllowedPaymentMethods json not null,
    CreateDate datetime not null,
    ModifyDate datetime,
    constraint PK_Payment_Gateway primary key (Id)
) auto_increment = 1;

create table if not exists merchant_payment_gateway
(
    MerchantId bigint not null,
    PaymentGatewayId int not null,
    JsonApiConfiguration json not null,
    CreateDate datetime not null,
    ModifyDate datetime,
    constraint FK_Merchant_Merchant_Payment_Gateway foreign key (MerchantId) references merchant (Id),
    constraint FK_Payment_Gateway_Merchant_Payment_Gateway foreign key (PaymentGatewayId) references payment_gateway (Id),
    constraint PK_Merchant_Payment_Gateway primary key (MerchantId, PaymentGatewayId)
) auto_increment = 1;