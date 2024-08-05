CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL,
    RolID INT,
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

CREATE TABLE Permisos (
    PermisoID INT IDENTITY(1,1) PRIMARY KEY,
    NombrePermiso NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RolPermisos (
    RolID INT,
    PermisoID INT,
    PRIMARY KEY (RolID, PermisoID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID),
    FOREIGN KEY (PermisoID) REFERENCES Permisos(PermisoID)
);

CREATE TABLE Cursos (
    CursoID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCurso NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Profesores (
    ProfesorID INT IDENTITY(1,1) PRIMARY KEY,
    NombreProfesor NVARCHAR(100) NOT NULL,
    ApellidoProfesor NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255)
);

CREATE TABLE Horarios (
    HorarioID INT IDENTITY(1,1) PRIMARY KEY,
    CursoID INT,
    ProfesorID INT,
    DiaSemana NVARCHAR(50) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID),
    FOREIGN KEY (ProfesorID) REFERENCES Profesores(ProfesorID)
);

CREATE TABLE LlaveActivacion (
    LlaveID INT IDENTITY(1,1) PRIMARY KEY,
    Llave NVARCHAR(255) NOT NULL UNIQUE,
    FechaCreacion DATETIME NOT NULL,
    FechaExpiracion DATETIME NOT NULL
);
