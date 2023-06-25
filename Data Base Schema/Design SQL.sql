/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     5/17/2023 1:35:43 AM                         */
/*==============================================================*/

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table Admin (
   AdminID             int                  not null,
   fname               varchar(50)          not null,
   lname               varchar(50)          not null,
   gendar              varchar(15)          not null,
   dateOfBirth         datetime             not null,
   email               varchar(30)          not null     unique,
   age                 int                  not null, 
   PASSWORD            varchar(30)          not null,     
   constraint PK_ADMIN primary key (AdminID)

)


/*==============================================================*/
/* Table: ADMIN_PHONE                                           */
/*==============================================================*/
create table Admin_phone (
   phone               char(11)             not null,
   AdminID             int                  not null,
   constraint PK_ADMIN_PHONE primary key (phone, AdminID),
   constraint FK_AdminID_phone foreign key (AdminID)
   references Admin (AdminID)
   ON DELETE CASCADE
   
)


/*==============================================================*/
/* Table: AIRCRAFT                                              */
/*==============================================================*/
create table Aircraft (
   aircraftID           int                  not null,
   model                varchar(50)          not null,
   color                varchar(15)          null,
   capacity             int                  not null,
   constraint PK_AIRCRAFT primary key (aircraftID)
)

/*==============================================================*/
/* Table: AIRCRAFT_CLASS                                        */
/*==============================================================*/
create table Aircraft_Class (
   class              varchar(50)          not null,
   aircraftID         int                  not null,
   constraint PK_AIRCRAFT_CLASS primary key (class, aircraftID),
   constraint FK_aircraftID_class foreign key (aircraftID)
   references Aircraft (aircraftID) 
   ON DELETE CASCADE
)


/*==============================================================*/
/* Table: FLIGHT                                                */
/*==============================================================*/
create table Flight (
   FlightID              int                  not null,
   aircraftID            int                  not null,
   source                varchar(20)          not null,
   destination           varchar(20)          not null,
   arrivalDate           datetime             not null,
   arrivalTime           datetime             not null,
   depatureDate          datetime             not null,
   depatureTime          datetime             not null,
   state                 varchar(50)          not null,
   requiredNumberOfSeats int                  not null,
   duration				 datetime,				
   constraint PK_FLIGHT primary key (FLIGHTID),
   constraint FK_aircraftID_flight foreign key (aircraftID)
   references Aircraft (aircraftID)
   ON DELETE CASCADE
)


/*==============================================================*/
/* Table: FMANAGE                                               */
/*==============================================================*/
create table manageFlight (
   AdminID             int                  not null,
   FlightID            int                  not null,
   constraint PK_FMANAGE primary key (AdminID, FlightID),
   constraint FK_AdminID_flight foreign key (AdminID)
   references Admin (AdminID),
   constraint FK_FlightID_flight foreign key (FlightID)
   references Flight (FlightID)
   ON DELETE CASCADE

)

/*==============================================================*/
/* Table: MANAGEAIRCRAFT                                        */
/*==============================================================*/
create table manageAircraft (
   AdminID              int                  not null,
   AircraftID           int                  not null,
   constraint PK_MANAGEAIRCRAFT primary key (adminID, AircraftID),
   constraint FK_AdminID_Aircraft foreign key (AdminID)
   references Admin (AdminID),
   constraint FK_AircraftID_Aircraft foreign key (AircraftID)
   references Aircraft (AircraftID)
   ON DELETE CASCADE

)


/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table Customer (
   CustomerID               int                  not null,
   fname                    varchar(50)          not null,
   lname                    varchar(50)          not null,
   gender                   varchar(10)          not null,
   DataOfBirth              datetime             not null,
   email                    varchar(30)          not null    unique,
   password                 varchar(30)          not null,
   age						int					 ,
   constraint PK_Customer primary key (CustomerID)
)

/*==============================================================*/
/* Table: CUSTOMER_PHONE                                        */
/*==============================================================*/
create table Customer_Phone (
   phone                    char(11)             not null,
   CustomerID               int                  not null,
   constraint PK_Customer_PHONE primary key (phone, CustomerID),
   constraint FK_CustomerID_Phone foreign key (CustomerID)
   references Customer (CustomerID)
   ON DELETE CASCADE

)


/*==============================================================*/
/* Table: RESERVATION                                           */
/*==============================================================*/
create table Reservation (
   CustomerID               int                  not null,
   FlightID                 int                  not null,
   price                    float(10)            not null,
   class                    varchar(50)          not null,
   seatNumber               int                  not null,
   type                     varchar(15)          not null,
   state                    varchar(50)          not null,
   constraint PK_RESERVATION primary key (CustomerID, FlightID,seatNumber ),
   constraint FK_CustomerID_Reservation foreign key (CustomerID)
   references Customer (CustomerID),
   constraint FK_FlightID_Reservation foreign key (FlightID)
   references Flight (FlightID)
   ON DELETE CASCADE
)

