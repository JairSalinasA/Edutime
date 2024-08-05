 -- CRUD para la tabla Roles
CREATE PROCEDURE CreateRol @NombreRol NVARCHAR(100) AS BEGIN INSERT INTO Roles (NombreRol) VALUES (@NombreRol); END; GO
CREATE PROCEDURE GetAllRoles AS BEGIN SELECT * FROM Roles; END; GO
CREATE PROCEDURE GetRolById @RolID INT AS BEGIN SELECT * FROM Roles WHERE RolID = @RolID; END; GO
CREATE PROCEDURE UpdateRol @RolID INT, @NombreRol NVARCHAR(100) AS BEGIN UPDATE Roles SET NombreRol = @NombreRol WHERE RolID = @RolID; END; GO
CREATE PROCEDURE DeleteRol @RolID INT AS BEGIN DELETE FROM Roles WHERE RolID = @RolID; END; GO

-- CRUD para la tabla Usuarios
CREATE PROCEDURE CreateUsuario @NombreUsuario NVARCHAR(100), @Contraseña NVARCHAR(255), @RolID INT AS BEGIN INSERT INTO Usuarios (NombreUsuario, Contraseña, RolID) VALUES (@NombreUsuario, @Contraseña, @RolID); END; GO
CREATE PROCEDURE GetAllUsuarios AS BEGIN SELECT * FROM Usuarios; END; GO
CREATE PROCEDURE GetUsuarioById @UsuarioID INT AS BEGIN SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID; END; GO
CREATE PROCEDURE UpdateUsuario @UsuarioID INT, @NombreUsuario NVARCHAR(100), @Contraseña NVARCHAR(255), @RolID INT AS BEGIN UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, RolID = @RolID WHERE UsuarioID = @UsuarioID; END; GO
CREATE PROCEDURE DeleteUsuario @UsuarioID INT AS BEGIN DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID; END; GO

-- CRUD para la tabla Permisos
CREATE PROCEDURE CreatePermiso @NombrePermiso NVARCHAR(100) AS BEGIN INSERT INTO Permisos (NombrePermiso) VALUES (@NombrePermiso); END; GO
CREATE PROCEDURE GetAllPermisos AS BEGIN SELECT * FROM Permisos; END; GO
CREATE PROCEDURE GetPermisoById @PermisoID INT AS BEGIN SELECT * FROM Permisos WHERE PermisoID = @PermisoID; END; GO
CREATE PROCEDURE UpdatePermiso @PermisoID INT, @NombrePermiso NVARCHAR(100) AS BEGIN UPDATE Permisos SET NombrePermiso = @NombrePermiso WHERE PermisoID = @PermisoID; END; GO
CREATE PROCEDURE DeletePermiso @PermisoID INT AS BEGIN DELETE FROM Permisos WHERE PermisoID = @PermisoID; END; GO

-- CRUD para la tabla Cursos
CREATE PROCEDURE CreateCurso @NombreCurso NVARCHAR(100), @Descripcion NVARCHAR(255) AS BEGIN INSERT INTO Cursos (NombreCurso, Descripcion) VALUES (@NombreCurso, @Descripcion); END; GO
CREATE PROCEDURE GetAllCursos AS BEGIN SELECT * FROM Cursos; END; GO
CREATE PROCEDURE GetCursoById @CursoID INT AS BEGIN SELECT * FROM Cursos WHERE CursoID = @CursoID; END; GO
CREATE PROCEDURE UpdateCurso @CursoID INT, @NombreCurso NVARCHAR(100), @Descripcion NVARCHAR(255) AS BEGIN UPDATE Cursos SET NombreCurso = @NombreCurso, Descripcion = @Descripcion WHERE CursoID = @CursoID; END; GO
CREATE PROCEDURE DeleteCurso @CursoID INT AS BEGIN DELETE FROM Cursos WHERE CursoID = @CursoID; END; GO

-- CRUD para la tabla Profesores
CREATE PROCEDURE CreateProfesor @NombreProfesor NVARCHAR(100), @ApellidoProfesor NVARCHAR(100), @Email NVARCHAR(255) AS BEGIN INSERT INTO Profesores (NombreProfesor, ApellidoProfesor, Email) VALUES (@NombreProfesor, @ApellidoProfesor, @Email); END; GO
CREATE PROCEDURE GetAllProfesores AS BEGIN SELECT * FROM Profesores; END; GO
CREATE PROCEDURE GetProfesorById @ProfesorID INT AS BEGIN SELECT * FROM Profesores WHERE ProfesorID = @ProfesorID; END; GO
CREATE PROCEDURE UpdateProfesor @ProfesorID INT, @NombreProfesor NVARCHAR(100), @ApellidoProfesor NVARCHAR(100), @Email NVARCHAR(255) AS BEGIN UPDATE Profesores SET NombreProfesor = @NombreProfesor, ApellidoProfesor = @ApellidoProfesor, Email = @Email WHERE ProfesorID = @ProfesorID; END; GO
CREATE PROCEDURE DeleteProfesor @ProfesorID INT AS BEGIN DELETE FROM Profesores WHERE ProfesorID = @ProfesorID; END; GO

-- CRUD para la tabla Horarios
CREATE PROCEDURE CreateHorario @CursoID INT, @ProfesorID INT, @DiaSemana NVARCHAR(50), @HoraInicio TIME, @HoraFin TIME AS BEGIN INSERT INTO Horarios (CursoID, ProfesorID, DiaSemana, HoraInicio, HoraFin) VALUES (@CursoID, @ProfesorID, @DiaSemana, @HoraInicio, @HoraFin); END; GO
CREATE PROCEDURE GetAllHorarios AS BEGIN SELECT * FROM Horarios; END; GO
CREATE PROCEDURE GetHorarioById @HorarioID INT AS BEGIN SELECT * FROM Horarios WHERE HorarioID = @HorarioID; END; GO
CREATE PROCEDURE UpdateHorario @HorarioID INT, @CursoID INT, @ProfesorID INT, @DiaSemana NVARCHAR(50), @HoraInicio TIME, @HoraFin TIME AS BEGIN UPDATE Horarios SET CursoID = @CursoID, ProfesorID = @ProfesorID, DiaSemana = @DiaSemana, HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE HorarioID = @HorarioID; END; GO
CREATE PROCEDURE DeleteHorario @HorarioID INT AS BEGIN DELETE FROM Horarios WHERE HorarioID = @HorarioID; END; GO

-- CRUD para la tabla LlaveActivacion
CREATE PROCEDURE CreateLlaveActivacion @Llave NVARCHAR(255), @FechaCreacion DATETIME, @FechaExpiracion DATETIME AS BEGIN INSERT INTO LlaveActivacion (Llave, FechaCreacion, FechaExpiracion) VALUES (@Llave, @FechaCreacion, @FechaExpiracion); END; GO
CREATE PROCEDURE GetAllLlavesActivacion AS BEGIN SELECT * FROM LlaveActivacion; END; GO
CREATE PROCEDURE GetLlaveActivacionById @LlaveID INT AS BEGIN SELECT * FROM LlaveActivacion WHERE LlaveID = @LlaveID; END; GO
CREATE PROCEDURE UpdateLlaveActivacion @LlaveID INT, @Llave NVARCHAR(255), @FechaCreacion DATETIME, @FechaExpiracion DATETIME AS BEGIN UPDATE LlaveActivacion SET Llave = @Llave, FechaCreacion = @FechaCreacion, FechaExpiracion = @FechaExpiracion WHERE LlaveID = @LlaveID; END; GO
CREATE PROCEDURE DeleteLlaveActivacion @LlaveID INT AS BEGIN DELETE FROM LlaveActivacion WHERE LlaveID = @LlaveID; END; GO
