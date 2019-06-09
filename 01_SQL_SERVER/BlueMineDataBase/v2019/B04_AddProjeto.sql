USE [BlueMine]
GO

declare @clienteId int;
select @clienteId = max(ClienteId) From Cliente
declare @gerenteId int;
 Select @gerenteId=Max(usuarioId) from Usuario 


INSERT INTO [dbo].[Projeto]
           ([ClienteId]
           ,[Nome]
           ,[Prazo]
           ,[DataInicio]
           ,[DataFinalizacao]
           ,[GerenteId])
     VALUES
           (@clienteId
           ,'Primeiro Projeto'
           ,DATEADD(month, 8, getdate()) -- Prazo de 6 meses
           ,DATEADD(day, 3, getdate()) -- Inicia em 3 dias
           ,NULL
           , @gerenteId
           )
GO


