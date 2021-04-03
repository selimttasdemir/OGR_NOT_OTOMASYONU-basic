# OGR_NOT_OTOMASYONU-basic
personal student grading system for teachers (simple)


sql code:

create database DBnotKayitSistemi
use DBnotKayitSistemi
create table tblDers
(
OGRID smallint identity(1,1) primary key,
OGRNUMARA char(4),
OGRAD varchar(50),
OGRSOYAD varchar(50),
OGRS1 tinyint,
OGRS2 tinyint,
OGRS3 tinyint,
ORTALAMA decimal(18,2),
DURUM bit
)
