USE [TesteMatricula]
GO

/****** Object:  Table [dbo].[matricula]    Script Date: 01/04/2023 23:27:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[matricula](
	[AlunoId] [int] NOT NULL,
	[TurmaId] [int] NOT NULL,
 CONSTRAINT [PK_matricula] PRIMARY KEY CLUSTERED 
(
	[AlunoId] ASC,
	[TurmaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_alunos_AlunoId] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[alunos] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_alunos_AlunoId]
GO

ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_turma_TurmaId] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[turma] ([Id])
GO

ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_turma_TurmaId]
GO


