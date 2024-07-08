create database ComexDB;
use ComexDB;

CREATE TABLE Produtos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome NVARCHAR(255) NOT NULL,
	Descricao NVARCHAR(500) NOT NULL,
	PrecoUnitario FLOAT NOT NULL,
	Quantidade INT NOT NULL
);

insert into Produtos (Nome, Descricao, PrecoUnitario, Quantidade ) values ('Produto', 'Produto de teste', 10, 5);