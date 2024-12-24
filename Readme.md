O projeto conta com a geração automática de documentação do swagger


SCRIPT PARA CRIAÇÃO DE BANCO DE DADOS:

CREATE DATABASE MicroSass;

USE MicroSass;

CREATE TABLE Responsavel (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(255) NOT NULL
);

CREATE TABLE TipoUsuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(255) NOT NULL
);

CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    IdTipoUsuario INT NOT NULL,
    IdResponsavel INT NOT NULL,
    FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(Id),
    FOREIGN KEY (IdResponsavel) REFERENCES Responsavel(Id)
);
