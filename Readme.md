-- Criar o banco de dados
CREATE DATABASE MicroSass;

-- Usar o banco de dados criado
USE MicroSass;

-- Criar a tabela Responsavel
CREATE TABLE Responsavel (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(255) NOT NULL
);

-- Criar a tabela TipoUsuario
CREATE TABLE TipoUsuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(255) NOT NULL
);

-- Criar a tabela Usuario
CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    IdTipoUsuario INT NOT NULL,
    IdResponsavel INT NOT NULL,
    FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(Id),
    FOREIGN KEY (IdResponsavel) REFERENCES Responsavel(Id)
);
