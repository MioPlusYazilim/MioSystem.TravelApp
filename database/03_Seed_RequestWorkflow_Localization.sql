USE [MioSystem_TravelApp];
GO

/*
    Initial seed data:
    - Languages
    - Resource keys and translations
    - Lookup groups/items for request, offer and sales workflow
*/

SET NOCOUNT ON;

IF NOT EXISTS (SELECT 1 FROM dbo.SysLanguage WHERE Code = N'tr-TR')
BEGIN
    INSERT INTO dbo.SysLanguage(Code, ShortCode, Name, CultureName, SortOrder, IsDefault, IsActive)
    VALUES (N'tr-TR', N'tr', N'Türkçe', N'Turkish - Türkiye', 1, 1, 1);
END

IF NOT EXISTS (SELECT 1 FROM dbo.SysLanguage WHERE Code = N'en-US')
BEGIN
    INSERT INTO dbo.SysLanguage(Code, ShortCode, Name, CultureName, SortOrder, IsDefault, IsActive)
    VALUES (N'en-US', N'en', N'English', N'English - United States', 2, 0, 1);
END
GO

DECLARE @Resources TABLE
(
    ResourceKey NVARCHAR(250) NOT NULL,
    ResourceType NVARCHAR(50) NOT NULL,
    TrValue NVARCHAR(MAX) NOT NULL,
    EnValue NVARCHAR(MAX) NOT NULL
);

INSERT INTO @Resources(ResourceKey, ResourceType, TrValue, EnValue)
VALUES
-- Lookup groups
(N'LookupGroup.RequestChannel', N'Lookup', N'Talep Kanalı', N'Request Channel'),
(N'LookupGroup.RequestType', N'Lookup', N'Talep Türü', N'Request Type'),
(N'LookupGroup.RequestStatus', N'Lookup', N'Talep Durumu', N'Request Status'),
(N'LookupGroup.OfferStatus', N'Lookup', N'Teklif Durumu', N'Offer Status'),
(N'LookupGroup.ServiceType', N'Lookup', N'Hizmet Türü', N'Service Type'),
(N'LookupGroup.TransactionType', N'Lookup', N'İşlem Türü', N'Transaction Type'),

-- Request channels
(N'Lookup.RequestChannel.Phone', N'Lookup', N'Telefon', N'Phone'),
(N'Lookup.RequestChannel.WhatsApp', N'Lookup', N'WhatsApp', N'WhatsApp'),
(N'Lookup.RequestChannel.Email', N'Lookup', N'E-posta', N'Email'),
(N'Lookup.RequestChannel.WebForm', N'Lookup', N'Web Form', N'Web Form'),
(N'Lookup.RequestChannel.Office', N'Lookup', N'Ofis', N'Office'),
(N'Lookup.RequestChannel.Agency', N'Lookup', N'Bayi / Acente', N'Agency'),
(N'Lookup.RequestChannel.MobileApp', N'Lookup', N'Mobil Uygulama', N'Mobile App'),

-- Request types
(N'Lookup.RequestType.Flight', N'Lookup', N'Uçak Bileti', N'Flight Ticket'),
(N'Lookup.RequestType.Hotel', N'Lookup', N'Otel', N'Hotel'),
(N'Lookup.RequestType.Transfer', N'Lookup', N'Transfer', N'Transfer'),
(N'Lookup.RequestType.RentACar', N'Lookup', N'Araç Kiralama', N'Rent a Car'),
(N'Lookup.RequestType.Visa', N'Lookup', N'Vize', N'Visa'),
(N'Lookup.RequestType.Tour', N'Lookup', N'Tur', N'Tour'),
(N'Lookup.RequestType.Insurance', N'Lookup', N'Sigorta', N'Insurance'),
(N'Lookup.RequestType.Package', N'Lookup', N'Paket / Karma Talep', N'Package / Mixed Request'),
(N'Lookup.RequestType.Other', N'Lookup', N'Diğer Hizmet', N'Other Service'),

-- Request statuses
(N'Lookup.RequestStatus.New', N'Lookup', N'Yeni Talep', N'New Request'),
(N'Lookup.RequestStatus.Assigned', N'Lookup', N'Personele Atandı', N'Assigned'),
(N'Lookup.RequestStatus.InProgress', N'Lookup', N'İşleme Alındı', N'In Progress'),
(N'Lookup.RequestStatus.WaitingInfo', N'Lookup', N'Bilgi Bekleniyor', N'Waiting for Information'),
(N'Lookup.RequestStatus.PreparingOffer', N'Lookup', N'Alternatif Hazırlanıyor', N'Preparing Offer'),
(N'Lookup.RequestStatus.OfferPresented', N'Lookup', N'Teklif Sunuldu', N'Offer Presented'),
(N'Lookup.RequestStatus.CustomerReview', N'Lookup', N'Müşteri Değerlendiriyor', N'Customer Reviewing'),
(N'Lookup.RequestStatus.RevisionRequested', N'Lookup', N'Revize İstendi', N'Revision Requested'),
(N'Lookup.RequestStatus.Accepted', N'Lookup', N'Kabul Edildi', N'Accepted'),
(N'Lookup.RequestStatus.ConvertedToSale', N'Lookup', N'Satışa Çevrildi', N'Converted to Sale'),
(N'Lookup.RequestStatus.Rejected', N'Lookup', N'Reddedildi', N'Rejected'),
(N'Lookup.RequestStatus.Cancelled', N'Lookup', N'İptal Edildi', N'Cancelled'),
(N'Lookup.RequestStatus.Closed', N'Lookup', N'Kapatıldı', N'Closed'),

-- Offer statuses
(N'Lookup.OfferStatus.Draft', N'Lookup', N'Taslak', N'Draft'),
(N'Lookup.OfferStatus.Presented', N'Lookup', N'Müşteriye Sunuldu', N'Presented'),
(N'Lookup.OfferStatus.RevisionRequested', N'Lookup', N'Revize İstendi', N'Revision Requested'),
(N'Lookup.OfferStatus.Rejected', N'Lookup', N'Reddedildi', N'Rejected'),
(N'Lookup.OfferStatus.Accepted', N'Lookup', N'Kabul Edildi', N'Accepted'),
(N'Lookup.OfferStatus.Expired', N'Lookup', N'Süresi Doldu', N'Expired'),
(N'Lookup.OfferStatus.ConvertedToSale', N'Lookup', N'Satışa Çevrildi', N'Converted to Sale'),
(N'Lookup.OfferStatus.Cancelled', N'Lookup', N'İptal Edildi', N'Cancelled'),

-- Service types
(N'Lookup.ServiceType.FlightTicket', N'Lookup', N'Uçak Bileti', N'Flight Ticket'),
(N'Lookup.ServiceType.Hotel', N'Lookup', N'Otel', N'Hotel'),
(N'Lookup.ServiceType.Transfer', N'Lookup', N'Transfer', N'Transfer'),
(N'Lookup.ServiceType.RentACar', N'Lookup', N'Araç Kiralama', N'Rent a Car'),
(N'Lookup.ServiceType.Visa', N'Lookup', N'Vize', N'Visa'),
(N'Lookup.ServiceType.Insurance', N'Lookup', N'Sigorta', N'Insurance'),
(N'Lookup.ServiceType.Other', N'Lookup', N'Diğer Hizmet', N'Other Service'),

-- Transaction types
(N'Lookup.TransactionType.Sale', N'Lookup', N'Satış', N'Sale'),
(N'Lookup.TransactionType.Refund', N'Lookup', N'İade', N'Refund'),
(N'Lookup.TransactionType.Reissue', N'Lookup', N'Reissue / Değişiklik', N'Reissue'),
(N'Lookup.TransactionType.Void', N'Lookup', N'Void / İptal', N'Void'),
(N'Lookup.TransactionType.Emd', N'Lookup', N'EMD', N'EMD'),
(N'Lookup.TransactionType.Penalty', N'Lookup', N'Ceza', N'Penalty'),
(N'Lookup.TransactionType.Deposit', N'Lookup', N'Depozit', N'Deposit'),

-- UI labels
(N'Ui.Request.RequestNo', N'UiLabel', N'Talep No', N'Request No'),
(N'Ui.Request.Customer', N'UiLabel', N'Müşteri', N'Customer'),
(N'Ui.Request.Channel', N'UiLabel', N'Kanal', N'Channel'),
(N'Ui.Request.Status', N'UiLabel', N'Durum', N'Status'),
(N'Ui.Request.AssignedEmployee', N'UiLabel', N'Atanan Personel', N'Assigned Employee'),
(N'Ui.Button.Save', N'Button', N'Kaydet', N'Save'),
(N'Ui.Button.Cancel', N'Button', N'Vazgeç', N'Cancel'),
(N'Ui.Button.ConvertToSale', N'Button', N'Satışa Çevir', N'Convert to Sale'),

-- API messages
(N'Message.Request.NotFound', N'ApiMessage', N'Talep bulunamadı.', N'Request not found.'),
(N'Message.Request.ConvertedToSale', N'ApiMessage', N'Talep başarıyla satışa çevrildi.', N'Request has been successfully converted to sale.'),
(N'Message.Offer.Accepted', N'ApiMessage', N'Teklif kabul edildi.', N'Offer has been accepted.');

INSERT INTO dbo.SysResource(ResourceKey, ResourceType, Description)
SELECT r.ResourceKey, r.ResourceType, r.ResourceKey
FROM @Resources r
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.SysResource sr
    WHERE sr.ResourceKey = r.ResourceKey
);

DECLARE @TrLanguageID INT = (SELECT ID FROM dbo.SysLanguage WHERE Code = N'tr-TR');
DECLARE @EnLanguageID INT = (SELECT ID FROM dbo.SysLanguage WHERE Code = N'en-US');

MERGE dbo.SysResourceTranslation AS target
USING
(
    SELECT sr.ID AS ResourceID, @TrLanguageID AS LanguageID, r.TrValue AS Value
    FROM @Resources r
    INNER JOIN dbo.SysResource sr ON sr.ResourceKey = r.ResourceKey
) AS source
ON target.ResourceID = source.ResourceID
AND target.LanguageID = source.LanguageID
WHEN MATCHED THEN
    UPDATE SET Value = source.Value
WHEN NOT MATCHED THEN
    INSERT(ResourceID, LanguageID, Value)
    VALUES(source.ResourceID, source.LanguageID, source.Value);

MERGE dbo.SysResourceTranslation AS target
USING
(
    SELECT sr.ID AS ResourceID, @EnLanguageID AS LanguageID, r.EnValue AS Value
    FROM @Resources r
    INNER JOIN dbo.SysResource sr ON sr.ResourceKey = r.ResourceKey
) AS source
ON target.ResourceID = source.ResourceID
AND target.LanguageID = source.LanguageID
WHEN MATCHED THEN
    UPDATE SET Value = source.Value
WHEN NOT MATCHED THEN
    INSERT(ResourceID, LanguageID, Value)
    VALUES(source.ResourceID, source.LanguageID, source.Value);
GO

DECLARE @Groups TABLE
(
    Code NVARCHAR(100) NOT NULL,
    ResourceKey NVARCHAR(250) NOT NULL,
    SortOrder INT NOT NULL
);

INSERT INTO @Groups(Code, ResourceKey, SortOrder)
VALUES
(N'RequestChannel', N'LookupGroup.RequestChannel', 10),
(N'RequestType', N'LookupGroup.RequestType', 20),
(N'RequestStatus', N'LookupGroup.RequestStatus', 30),
(N'OfferStatus', N'LookupGroup.OfferStatus', 40),
(N'ServiceType', N'LookupGroup.ServiceType', 50),
(N'TransactionType', N'LookupGroup.TransactionType', 60);

INSERT INTO dbo.SysLookupGroup(Code, ResourceKey, SortOrder)
SELECT g.Code, g.ResourceKey, g.SortOrder
FROM @Groups g
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.SysLookupGroup lg
    WHERE lg.Code = g.Code
);

DECLARE @Items TABLE
(
    GroupCode NVARCHAR(100) NOT NULL,
    Code NVARCHAR(100) NOT NULL,
    ResourceKey NVARCHAR(250) NOT NULL,
    SortOrder INT NOT NULL,
    IsDefault BIT NOT NULL
);

INSERT INTO @Items(GroupCode, Code, ResourceKey, SortOrder, IsDefault)
VALUES
-- RequestChannel
(N'RequestChannel', N'PHONE', N'Lookup.RequestChannel.Phone', 10, 1),
(N'RequestChannel', N'WHATSAPP', N'Lookup.RequestChannel.WhatsApp', 20, 0),
(N'RequestChannel', N'EMAIL', N'Lookup.RequestChannel.Email', 30, 0),
(N'RequestChannel', N'WEB_FORM', N'Lookup.RequestChannel.WebForm', 40, 0),
(N'RequestChannel', N'OFFICE', N'Lookup.RequestChannel.Office', 50, 0),
(N'RequestChannel', N'AGENCY', N'Lookup.RequestChannel.Agency', 60, 0),
(N'RequestChannel', N'MOBILE_APP', N'Lookup.RequestChannel.MobileApp', 70, 0),

-- RequestType
(N'RequestType', N'FLIGHT', N'Lookup.RequestType.Flight', 10, 1),
(N'RequestType', N'HOTEL', N'Lookup.RequestType.Hotel', 20, 0),
(N'RequestType', N'TRANSFER', N'Lookup.RequestType.Transfer', 30, 0),
(N'RequestType', N'RENT_A_CAR', N'Lookup.RequestType.RentACar', 40, 0),
(N'RequestType', N'VISA', N'Lookup.RequestType.Visa', 50, 0),
(N'RequestType', N'TOUR', N'Lookup.RequestType.Tour', 60, 0),
(N'RequestType', N'INSURANCE', N'Lookup.RequestType.Insurance', 70, 0),
(N'RequestType', N'PACKAGE', N'Lookup.RequestType.Package', 80, 0),
(N'RequestType', N'OTHER', N'Lookup.RequestType.Other', 90, 0),

-- RequestStatus
(N'RequestStatus', N'NEW', N'Lookup.RequestStatus.New', 10, 1),
(N'RequestStatus', N'ASSIGNED', N'Lookup.RequestStatus.Assigned', 20, 0),
(N'RequestStatus', N'IN_PROGRESS', N'Lookup.RequestStatus.InProgress', 30, 0),
(N'RequestStatus', N'WAITING_INFO', N'Lookup.RequestStatus.WaitingInfo', 40, 0),
(N'RequestStatus', N'PREPARING_OFFER', N'Lookup.RequestStatus.PreparingOffer', 50, 0),
(N'RequestStatus', N'OFFER_PRESENTED', N'Lookup.RequestStatus.OfferPresented', 60, 0),
(N'RequestStatus', N'CUSTOMER_REVIEW', N'Lookup.RequestStatus.CustomerReview', 70, 0),
(N'RequestStatus', N'REVISION_REQUESTED', N'Lookup.RequestStatus.RevisionRequested', 80, 0),
(N'RequestStatus', N'ACCEPTED', N'Lookup.RequestStatus.Accepted', 90, 0),
(N'RequestStatus', N'CONVERTED_TO_SALE', N'Lookup.RequestStatus.ConvertedToSale', 100, 0),
(N'RequestStatus', N'REJECTED', N'Lookup.RequestStatus.Rejected', 110, 0),
(N'RequestStatus', N'CANCELLED', N'Lookup.RequestStatus.Cancelled', 120, 0),
(N'RequestStatus', N'CLOSED', N'Lookup.RequestStatus.Closed', 130, 0),

-- OfferStatus
(N'OfferStatus', N'DRAFT', N'Lookup.OfferStatus.Draft', 10, 1),
(N'OfferStatus', N'PRESENTED', N'Lookup.OfferStatus.Presented', 20, 0),
(N'OfferStatus', N'REVISION_REQUESTED', N'Lookup.OfferStatus.RevisionRequested', 30, 0),
(N'OfferStatus', N'REJECTED', N'Lookup.OfferStatus.Rejected', 40, 0),
(N'OfferStatus', N'ACCEPTED', N'Lookup.OfferStatus.Accepted', 50, 0),
(N'OfferStatus', N'EXPIRED', N'Lookup.OfferStatus.Expired', 60, 0),
(N'OfferStatus', N'CONVERTED_TO_SALE', N'Lookup.OfferStatus.ConvertedToSale', 70, 0),
(N'OfferStatus', N'CANCELLED', N'Lookup.OfferStatus.Cancelled', 80, 0),

-- ServiceType
(N'ServiceType', N'FLIGHT_TICKET', N'Lookup.ServiceType.FlightTicket', 10, 1),
(N'ServiceType', N'HOTEL', N'Lookup.ServiceType.Hotel', 20, 0),
(N'ServiceType', N'TRANSFER', N'Lookup.ServiceType.Transfer', 30, 0),
(N'ServiceType', N'RENT_A_CAR', N'Lookup.ServiceType.RentACar', 40, 0),
(N'ServiceType', N'VISA', N'Lookup.ServiceType.Visa', 50, 0),
(N'ServiceType', N'INSURANCE', N'Lookup.ServiceType.Insurance', 60, 0),
(N'ServiceType', N'OTHER', N'Lookup.ServiceType.Other', 70, 0),

-- TransactionType
(N'TransactionType', N'SALE', N'Lookup.TransactionType.Sale', 10, 1),
(N'TransactionType', N'REFUND', N'Lookup.TransactionType.Refund', 20, 0),
(N'TransactionType', N'REISSUE', N'Lookup.TransactionType.Reissue', 30, 0),
(N'TransactionType', N'VOID', N'Lookup.TransactionType.Void', 40, 0),
(N'TransactionType', N'EMD', N'Lookup.TransactionType.Emd', 50, 0),
(N'TransactionType', N'PENALTY', N'Lookup.TransactionType.Penalty', 60, 0),
(N'TransactionType', N'DEPOSIT', N'Lookup.TransactionType.Deposit', 70, 0);

INSERT INTO dbo.SysLookupItem(GroupID, Code, ResourceKey, SortOrder, IsDefault)
SELECT
    g.ID,
    i.Code,
    i.ResourceKey,
    i.SortOrder,
    i.IsDefault
FROM @Items i
INNER JOIN dbo.SysLookupGroup g ON g.Code = i.GroupCode
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.SysLookupItem li
    WHERE li.GroupID = g.ID
      AND li.Code = i.Code
);
GO

PRINT 'Seed completed: request workflow localization and lookup values.';
GO
