-- CREATE DATABASE DesafioCrud;

USE DesafioCrud;

CREATE TABLE CLIENTE (
	CLI_ID INTEGER NOT NULL IDENTITY(1,1),
	CLI_NOME VARCHAR(120) NOT NULL,
	CLI_DATANASCIMENTO DATE NOT NULL,
	CLI_ATIVO BIT NOT NULL,

	CONSTRAINT PK_CLI_ID PRIMARY KEY (CLI_ID)
);