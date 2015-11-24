
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Marca](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[TipoVeiculo] [int] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AnoModelo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[Marca] [int] NOT NULL,
	[Modelo] [int] NOT NULL,
	[TipoVeiculo] [int] NOT NULL,
 CONSTRAINT [PK_AnoModelo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AnoModelo]  WITH CHECK ADD  CONSTRAINT [FK_AnoModelo_Marca] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marca] ([ID])
GO

ALTER TABLE [dbo].[AnoModelo] CHECK CONSTRAINT [FK_AnoModelo_Marca]
GO

ALTER TABLE [dbo].[AnoModelo]  WITH CHECK ADD  CONSTRAINT [FK_AnoModelo_Modelo] FOREIGN KEY([Modelo])
REFERENCES [dbo].[Modelo] ([ID])
GO

ALTER TABLE [dbo].[AnoModelo] CHECK CONSTRAINT [FK_AnoModelo_Modelo]
GO


SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Modelo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[Marca] [int] NOT NULL,
	[TipoVeiculo] [int] NOT NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Marca] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marca] ([ID])
GO

ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Marca]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Veiculo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Marca] [int] NOT NULL,
	[Modelo] [int] NOT NULL,
	[AnoModelo] [int] NOT NULL,
	[Combustivel] [varchar](100) NOT NULL,
	[CodigoFipe] [varchar](100) NOT NULL,
	[MesReferencia] [varchar](100) NOT NULL,
	[TipoVeiculo] [int] NOT NULL,
	[SiglaCombustivel] [varchar](2) NOT NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_AnoModelo] FOREIGN KEY([AnoModelo])
REFERENCES [dbo].[AnoModelo] ([ID])
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_Veiculo_AnoModelo]
GO

ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_Marca] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marca] ([ID])
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_Veiculo_Marca]
GO

ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_Modelo] FOREIGN KEY([Modelo])
REFERENCES [dbo].[Modelo] ([ID])
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_Veiculo_Modelo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Segurado](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Documento] [varchar](255) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [int] NOT NULL,
	[EstadoCivil] [int] NOT NULL,
	[FoneResidencial] [varchar](100) NULL,
	[FoneCelular] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Rua] [varchar](100) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[CEP] [varchar](9) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Estado] [varchar](2) NOT NULL,
	[BonusAtual] [varchar](100) NULL,
	[SeguradoraAnterior] [varchar](100) NULL,
	[NumeroCNH] [varchar](100) NOT NULL,
	[PrimeiraHabilitacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Segurado] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ObjetoSegurado](
	[Codigo] [int] NOT NULL,
	[Segurado] [int] NOT NULL,
	[TipoAutomovel] [varchar](20) NULL,
	[CodigoFipe] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL,
	[Marca] [int] NULL,
	[Modelo] [int] NULL,
	[Potencia] [int] NULL,
	[AnoDeFabricacao] [datetime] NULL,
	[AnoModelo] [datetime] NULL,
	[Chassi] [varchar](30) NULL,
	[Placa] [varchar](10) NULL,
	[QtdPortas] [int] NULL,
	[NroPassageiros] [int] NULL,
	[CepPernoite] [varchar](20) NULL,
	[Renavam] [varchar](30) NULL,
	[ValorFipe] [decimal](18, 0) NULL,
	[ValorCotado] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ObjetoSegurado1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ObjetoSegurado]  WITH CHECK ADD  CONSTRAINT [FK_ObjetoSegurado1_Marca] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marca] ([ID])
GO

ALTER TABLE [dbo].[ObjetoSegurado] CHECK CONSTRAINT [FK_ObjetoSegurado1_Marca]
GO

ALTER TABLE [dbo].[ObjetoSegurado]  WITH CHECK ADD  CONSTRAINT [FK_ObjetoSegurado1_Modelo] FOREIGN KEY([Modelo])
REFERENCES [dbo].[Modelo] ([ID])
GO

ALTER TABLE [dbo].[ObjetoSegurado] CHECK CONSTRAINT [FK_ObjetoSegurado1_Modelo]
GO

ALTER TABLE [dbo].[ObjetoSegurado]  WITH CHECK ADD  CONSTRAINT [FK_ObjetoSegurado1_Segurado] FOREIGN KEY([Segurado])
REFERENCES [dbo].[Segurado] ([Codigo])
GO

ALTER TABLE [dbo].[ObjetoSegurado] CHECK CONSTRAINT [FK_ObjetoSegurado1_Segurado]
GO

ALTER TABLE [dbo].[ObjetoSegurado]  WITH CHECK ADD  CONSTRAINT [FK_ObjetoSegurado1_Segurado1] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Segurado] ([Codigo])
GO

ALTER TABLE [dbo].[ObjetoSegurado] CHECK CONSTRAINT [FK_ObjetoSegurado1_Segurado1]
GO
