Projeto ASP.NET API - MicroSass
Este é um projeto de API em ASP.NET 8, que inclui a geração automática de documentação via Swagger e um script para criação do banco de dados MySQL.

Pré-requisitos
Antes de rodar o projeto, verifique se você tem os seguintes requisitos instalados:

Visual Studio 2022 ou superior com suporte para .NET 8.
.NET SDK 8: O projeto é desenvolvido para .NET 8, então é necessário ter o SDK instalado. Baixe o .NET 8 SDK aqui.
MySQL Server: A API utiliza um banco de dados MySQL. Se ainda não tiver o MySQL instalado, faça o download aqui.
Ferramentas do Swagger: A documentação será gerada automaticamente ao iniciar o projeto.
Passo a Passo para Rodar o Projeto
1. Clone ou Baixe o Repositório
Baixe o código do repositório para o seu ambiente local.

2. Instale as Dependências
Abra o Visual Studio e carregue o projeto.

O Visual Studio automaticamente baixará as dependências do projeto se você estiver conectado à internet.

3. Crie o Banco de Dados
Utilize o script SQL abaixo para criar as tabelas necessárias no seu banco de dados MySQL:

Crie o banco de dados:

CREATE DATABASE MicroSass;

Em seguida, selecione o banco de dados:

USE MicroSass;

Crie a tabela Responsavel:

CREATE TABLE Responsavel ( Id INT AUTO_INCREMENT PRIMARY KEY, Descricao VARCHAR(255) NOT NULL );

Crie a tabela TipoUsuario:

CREATE TABLE TipoUsuario ( Id INT AUTO_INCREMENT PRIMARY KEY, Descricao VARCHAR(255) NOT NULL );

Crie a tabela Usuario:

CREATE TABLE Usuario ( Id INT AUTO_INCREMENT PRIMARY KEY, Email VARCHAR(255) NOT NULL UNIQUE, Senha VARCHAR(255) NOT NULL, IdTipoUsuario INT NOT NULL, IdResponsavel INT NOT NULL, FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(Id), FOREIGN KEY (IdResponsavel) REFERENCES Responsavel(Id) );

Conecte-se ao MySQL usando o MySQL Workbench ou qualquer outro cliente MySQL de sua preferência. Crie o banco de dados MicroSass. Execute o script SQL acima para criar as tabelas necessárias.

4. Configuração do Banco de Dados no Projeto
Abra o arquivo appsettings.json no projeto. Altere a string de conexão do banco de dados para refletir o seu ambiente MySQL.

Exemplo:

{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=MicroSass;User=root;Password=SuaSenhaAqui;" } }

5. Rodando o Projeto
No Visual Studio, selecione o projeto como o Start Project (Projeto inicial). Clique em Run ou pressione Ctrl + F5 para iniciar a API. A API estará rodando e você poderá acessar os endpoints via Swagger ou qualquer cliente HTTP (como Postman).
