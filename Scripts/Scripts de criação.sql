 -- ID, Nome, Data de Nascimento e Salário.

 
USE testedb
GO 
DROP TABLE [dbo].[Funcionarios]
GO
CREATE TABLE [dbo].[Funcionarios](
	[FuncionarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Nascimento] [smalldatetime] NOT NULL,
	[Salario] decimal(10, 2) NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[FuncionarioId] ASC
) 
)
GO

DROP TABLE [dbo].[Filhos]
GO

CREATE TABLE [dbo].[Filhos](
	[FilhoId] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioId] [int] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Nascimento] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Filhos] PRIMARY KEY CLUSTERED 
(
	[FilhoId] ASC
)
) 
GO
