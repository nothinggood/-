CREATE TABLE [dbo].[PRODUCTS]
(
НАЗВАНИЕ nvarchar(100) CONSTRAINT PRODUCTS_НАЗВАНИЕ_PK PRIMARY KEY  not null,
ТИП nvarchar(50) not null,
КАЛОРИЙНОСТЬ INT NOT NULL,
БЕЛКИ REAL,
ЖИРЫ REAL,
УГЛЕВОДЫ REAL,
СПИРТ REAL);
