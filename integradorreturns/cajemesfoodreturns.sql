create database cajemesfood;
go
use cajemesfood
go
create table usuario(
id_usuario int identity primary key not null,
contrasena varchar(20) not null,
Nombre varchar(50) not null,
Telefono nvarchar(10) not null);


create table administrador(
Matricula int identity primary key not null,
Nombre  varchar(50) not null,
Apellido varchar(50) not null,
contrasena varchar(20) not null,
);

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio int NOT NULL,
	
);

CREATE TABLE Compra
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    Total INT NOT NULL,
	Cantidad int not null
   
);
select * from administrador
SELECT * from usuario
delete from Compra
CREATE PROCEDURE comprarpedido
    @ProductId INT,
    @Total INT,
    @Cantidad INT,
	@Nombre Varchar(50)
AS
BEGIN
    INSERT INTO Compra (ProductId, Total, Cantidad, Nombre)
    VALUES (@ProductId, @Total, @Cantidad,@Nombre);
END
CREATE PROCEDURE ConsultarCompras
AS
BEGIN
    -- Selecciona todas las compras de la tabla Compra
    SELECT * FROM 
        Compra;
		end
		exec ConsultarCompras

select * from Compra
select * from administrador
CREATE PROCEDURE InsertarProducto
    @Nombre NVARCHAR(100),
    @Precio INT
AS
BEGIN
    -- Insertar un nuevo producto en la tabla Products
    INSERT INTO Products (Nombre, Precio)
    VALUES (@Nombre, @Precio);
END;
EXEC InsertarProducto 
    @Nombre = 'Alitas de pollo', 
    @Precio = 150;
	EXEC InsertarProducto 
    @Nombre = 'Boneless', 
    @Precio = 100;
	EXEC InsertarProducto 
    @Nombre = 'Taco Carne asada', 
    @Precio = 30;
	EXEC InsertarProducto 
    @Nombre = 'Desayuno', 
    @Precio = 30;
	EXEC InsertarProducto 
    @Nombre = 'Pechuga de pollo', 
    @Precio = 70;
	EXEC InsertarProducto 
    @Nombre = 'Pizza', 
    @Precio = 130;
	EXEC InsertarProducto 
    @Nombre = 'Quezabirria', 
    @Precio = 50;
		EXEC InsertarProducto 
    @Nombre = 'Sushi California', 
    @Precio = 100;
	select * from Products


create procedure insertarusuario 
@contrasena varchar(20),
@Nombre varchar(50),
@telefono nvarchar(20)

-- como
as
-- inicio
begin

set nocount on;

insert into usuario values (
@contrasena,
@Nombre,
@Telefono) 

-- fin
end
go



create procedure consultarespecifico 

@id_usuario int


-- como
as
-- inicio
begin

select * from usuario where id_usuario = ( select id_usuario
  from usuario
  where id_usuario =@id_usuario
  
 )

-- fin
end
go

create procedure consultarUsuarios

-- como
as
-- inicio
begin

select * from usuario;

-- fin
end
go


create procedure modificarUsuario (

@id_usuario int ,
@Nombre varchar(50),
@Telefono nvarchar(10),
@contrasena varchar(20)

)
-- como
as
-- inicio
begin

set nocount on;

update usuario set
Nombre = @Nombre, Telefono = @Telefono, contrasena = @contrasena where id_usuario = @id_usuario
end
go

-- fin
create procedure eliminarUsuario (

@id_usuario int 
)
-- como
as
-- inicio
begin

delete from usuario
where id_usuario = @id_usuario
-- fin
end
go

--ALMACENADOS PEDIDOS PACHECOON-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


--PROCEDIMIENTOS ADMINISTRADOR ALEX CANTU------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure insertaradmin
@Nombre varchar(50) ,
@Apellido varchar(50),
@contrasena varchar(20)
-- como
as
-- inicio
begin

set nocount on;

insert into administrador values (
@Nombre ,
@Apellido,
@contrasena)

-- fin
end
go



create procedure consultarADMIN

@Matricula int


-- como
as
-- inicio
begin

select * from administrador where Matricula = ( select Matricula
  from administrador
  where Matricula= @Matricula
 )

-- fin
end
go

create procedure consultaradministradores

-- como
as
-- inicio
begin

select * from administrador;

-- fin
end
go

create procedure modificaradmin (
@Matricula int ,
@Nombre varchar(50) ,
@Apellido varchar(50),
@contrasena varchar(20)

)
-- como
as
-- inicio
begin

set nocount on;
update administrador set
Nombre = @Nombre, Apellido = @Apellido, contrasena = @contrasena where Matricula = @Matricula
end


create procedure eliminaradmin (
@Matricula int 

)
-- como
as
-- inicio
begin

delete from administrador
where Matricula = @Matricula
-- fin
end
go



----------------PAGO CANTU---------------------------------




 
 
 


----------------trigger pacheco----------------------------
