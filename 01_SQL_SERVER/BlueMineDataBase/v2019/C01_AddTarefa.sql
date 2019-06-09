declare @projetoId int;
set @projetoId = (select max(projetoId) from Projeto);


WITH Acao as (
	Select Nome From (Values('Executar atividades de'), ('Pesquisar sobre'), ('Resolver problema de')) as d(Nome)
),
ContextoEProfissional  as (
	Select d.Nome, U.UsuarioId From (Values('SQL Server'), ('Migração de Dados'), ('Backups')) as d(Nome)
	cross join (select top 2 UsuarioId From Usuario WHere CargoId in (Select CargoId From Cargo where Cargo.Cargo like '%Banco%' or Cargo.Cargo like '%DBA%') ) as U
	union all
	Select d.Nome, U.UsuarioId From (Values ('Programção'), ('ERP da empresa')) as d(Nome)
	cross join (select top 2 UsuarioId From Usuario WHere CargoId in (Select CargoId From Cargo where Cargo.Cargo like '%Sistema%' or Cargo.Cargo like '%programador%') ) as U
	union all
	Select d.Nome, U.UsuarioId From (Values ('Segurança e Ataques')) as d(Nome)
	cross join (select top 2 UsuarioId From Usuario WHere CargoId in (Select CargoId From Cargo where Cargo.Cargo like '%Segurança%') ) as U
)

INSERT INTO [dbo].[Tarefa]
           ([Nome] ,[Descricao],[Prioridade],[Prazo],[Situacao],[DataFinalizacao]
           ,[ProjetoId],[UsuarioId])

Select Concat(acao.Nome, ' ', contexto.Nome) as Nome
,Concat('Detalhes ', contexto.Nome) as  Descricao
, 3 as prioridade
, dateAdd(day, 30, getdate()) as prazo
, 'A' as Situacao
, NULL as DataFinalizacao
, @projetoId as ProjetoId
, contexto.UsuarioId as UsuarioId
From acao
Cross Join ContextoEProfissional as contexto

     