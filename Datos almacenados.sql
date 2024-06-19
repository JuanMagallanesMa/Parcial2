use [Proyecto TeleShopping]
--TABLA  USUARIO
create table usuarios
( 
id_usuario  int  primary key IDENTITY(1,1),
nombre_completo varchar(50) null,
usuario varchar(50) null,
correo varchar(60) null,
contrasena varchar(50) null,
tipo_usuario varchar(50) null
);

--TABLA PRODUCTOS
create table productos
(
id_producto int  primary key IDENTITY(1,1),
id_proveedor int,
nombre_producto varchar(70),
descripcion varchar(100),
cantidad int,
precio float,
total float,
imagen varbinary(max),
FOREIGN KEY (id_proveedor) REFERENCES usuarios(id_usuario)
);

SELECT *FROM USUARIOS
select *from productos
------------------------------------------------------------

--CREAR LOS DATOS ALMACENADOS DE INGRESO DE USUARIO
GO
CREATE procedure SP_RegistrarUsuarios
@nombre_completo varchar(50),
@usuario varchar(50),
@correo varchar(70), 
@contrasena varchar (50),
@tipo_usuario varchar(50)

AS
BEGIN
	insert into usuarios(nombre_completo, usuario, correo, contrasena, tipo_usuario)
	values(@nombre_completo, @usuario, @correo, @contrasena, @tipo_usuario)
END
GO
--BUSCAR DATO USUARIO
CREATE PROCEDURE SP_BuscarCorreoUsuarios
    @Correo VARCHAR(70),
	@TipoUsuario VARCHAR(50)
AS
BEGIN
    SELECT id_usuario, nombre_completo, usuario, correo, contrasena, tipo_usuario
    FROM usuarios
    WHERE correo = @Correo AND tipo_usuario = @TipoUsuario;
END;

go
--DATOS ALMACENADOS PARA MODIFICAR DATOS DEL USUARIO
CREATE procedure SP_ModificarUsuarios
@id int, 
@nombre varchar(50),
@usuario varchar(50),
@correo varchar(70),
@contrasena varchar(50),
@tipo_usuario varchar(50)
as
update usuarios set nombre_completo = @nombre, usuario = @usuario, correo = @correo, contrasena = @contrasena, tipo_usuario = @tipo_usuario where id_usuario = @id;
GO

--ELIMINAR USUARIO
CREATE PROCEDURE SP_EliminarUsuarios
    @id int  
AS
BEGIN
    DELETE FROM usuarios WHERE id_usuario = @id; 
END;

--CREAR LOS DATOS ALMACENADOS DE INGRESO DE PRODUCTOS
GO
CREATE PROCEDURE SP_RegistrarProductos
    @proveedor VARCHAR(50),
    @nombre_producto VARCHAR(70),
    @descripcion VARCHAR(100), 
    @cantidad FLOAT,
    @precio FLOAT,
    @total FLOAT,
    @imagen VARBINARY(MAX),
    @nombre_completo_proveedor VARCHAR(50) OUTPUT
AS
BEGIN
    DECLARE @id_proveedor INT;

    -- Buscar el id_usuario correspondiente al proveedor y obtener el nombre completo
    SELECT @id_proveedor = id_usuario,
           @nombre_completo_proveedor = nombre_completo
    FROM usuarios
    WHERE nombre_completo = @proveedor OR usuario = @proveedor;

    INSERT INTO productos (id_proveedor, nombre_producto, descripcion, cantidad, precio, total, imagen)
    VALUES (@id_proveedor, @nombre_producto, @descripcion, @cantidad, @precio, @total, @imagen);
END


--BUSCAR DATO PRODUCTO
go
CREATE PROCEDURE SP_BuscarProducto
    @nombre_producto VARCHAR(70) 
AS
BEGIN
    SELECT id_producto, id_proveedor, nombre_producto, descripcion, cantidad, precio, total, imagen
    FROM productos
    WHERE nombre_producto = @nombre_producto;
END;


go
--DATOS ALMACENADOS PARA MODIFICAR DATOS DEL PRODUCTO
CREATE PROCEDURE SP_ModificarProducto
    @id_producto int,
    @id_proveedor int, -- Cambiado a @id_proveedor
    @nombre_producto VARCHAR(70),
    @descripcion VARCHAR(100), 
    @cantidad FLOAT,
    @precio FLOAT,
    @total FLOAT,
    @imagen VARBINARY(MAX)
AS
BEGIN
    UPDATE productos 
    SET id_proveedor = @id_proveedor, -- Modificado a @id_proveedor
        nombre_producto = @nombre_producto, 
        descripcion = @descripcion, 
        cantidad = @cantidad, 
        precio = @precio, 
        total = @total 
    WHERE id_producto = @id_producto;
END;

go
--ELIMINAR PRODUCTO
CREATE PROCEDURE SP_EliminarProducto
    @id int
AS
BEGIN
    -- Verificar si el producto está referenciado en la tabla de usuarios
    IF NOT EXISTS (SELECT 1 FROM usuarios WHERE id_usuario = @id)
    BEGIN
        -- Si no hay referencias, eliminar el producto
        DELETE FROM productos WHERE id_producto = @id;
        PRINT 'Producto eliminado correctamente.';
    END
    ELSE
    BEGIN
        -- Si hay referencias, mostrar un mensaje indicando que no se puede eliminar
        PRINT 'No se puede eliminar el producto. Está siendo utilizado por usuarios.';
    END
END;

