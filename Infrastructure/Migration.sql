create database CompanyDB;


create table Company
(
    Id serial primary key,
    Name varchar(100),
    Address text,
    Description text
);

create table Department
(
    Id serial primary key,
    Name varchar(100),
    Address text,
    Description text,
    CompanyId int references Company(Id)
);

create table Branch
(
    Id serial primary key,
    Name varchar(100),
    Address text,
    Description text,
    DepartmentId int references Department(Id)
);
create table Employee
(
    Id serial primary key,
    FirstName varchar(50),
    LastName varchar(50),
    Email varchar(255),
    PhoneNumber varchar(20),
    Address text,
    HireDate date default CURRENT_DATE,
    BranchId int references Baranch(Id)
)