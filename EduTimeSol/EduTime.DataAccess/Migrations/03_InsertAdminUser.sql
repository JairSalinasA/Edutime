-- Insertar un rol de administrador
INSERT INTO Roles (NombreRol) VALUES ('Administrador');

-- Insertar permisos básicos (añadir según necesidades)
INSERT INTO Permisos (NombrePermiso) VALUES ('Gestionar Usuarios');
INSERT INTO Permisos (NombrePermiso) VALUES ('Gestionar Cursos');
INSERT INTO Permisos (NombrePermiso) VALUES ('Gestionar Profesores');
INSERT INTO Permisos (NombrePermiso) VALUES ('Gestionar Horarios');

-- Asignar permisos al rol de administrador
INSERT INTO RolPermisos (RolID, PermisoID) SELECT RolID, PermisoID FROM Roles, Permisos WHERE Roles.NombreRol = 'Administrador';

-- Insertar un usuario administrador
INSERT INTO Usuarios (NombreUsuario, Contraseña, RolID) VALUES ('admin', 'admin_password_hash', (SELECT RolID FROM Roles WHERE NombreRol = 'Administrador'));
