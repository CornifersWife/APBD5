create table Animals
(
    IdAnimal    int identity
        constraint PK_IdAnimal
            primary key,
    Name        nvarchar(200) not null collate SQL_Latin1_General_CP1_CI_AS,
    Description nvarchar(200) collate SQL_Latin1_General_CP1_CI_AS,
    Category    nvarchar(200) not null collate SQL_Latin1_General_CP1_CI_AS,
    Area        nvarchar(200) not null collate SQL_Latin1_General_CP1_CI_AS
)
go