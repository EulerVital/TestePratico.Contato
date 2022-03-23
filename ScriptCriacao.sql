if not exists(select * from sys.tables where name = 'Contato')
begin
	
	create table Contato
	(
		 Id int primary key identity(1,1)
		,Nome varchar(100) not null
		,TelefoneResidencial varchar(100) not null
		,Celular varchar(100)
		,Excluido bit not null default(0) --Para exclusão logica
	)

end
go

if exists(select * from sys.procedures where name = 'usp_contato_get')
begin
	drop proc usp_contato_get	
end
go

create proc usp_contato_get
as
begin
	
	select
		 Id
		,Nome
		,TelefoneResidencial
		,Celular
		,Excluido
	from
		Contato
	where
		Excluido = 0

end
go

if exists(select * from sys.procedures where name = 'usp_contato_set')
begin
	drop proc usp_contato_set	
end
go

create proc usp_contato_set
(
	 @Id int = 0
	,@Nome varchar(100)
	,@TelefoneResidencial varchar(100)
	,@Celular varchar(100) = null
)
as
begin
	
	if @Id > 0
	begin
		
		update Contato set
			 Nome = @Nome
			,TelefoneResidencial = @TelefoneResidencial
			,Celular = @Celular
		where
			Id = @Id

	end
	else
	begin
		
		insert into Contato
		(
			 Nome
			,TelefoneResidencial
			,Celular
		)select
			 @Nome
			,@TelefoneResidencial
			,@Celular

		set @Id = SCOPE_IDENTITY();

	end

	select @Id

end
go

if exists(select * from sys.procedures where name = 'usp_contato_del')
begin
	drop proc usp_contato_del	
end
go

create proc usp_contato_del
(
	 @Id int
)
as
begin
		
	update Contato set
		Excluido = 1
	where
		Id = @Id	

end
go