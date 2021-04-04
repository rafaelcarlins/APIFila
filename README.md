# APIFila
- projeto criado utilizando swagger;
- utiliza 3 procedures e uma tabela, script de criação segue abaixo;
- necessário criar um banco local para utilizar os scripts;
- necessário alterar a conection string que se encontra dentro da classe FilaBusiness na linha 15:
- SqlConnection conn = new SqlConnection("alterar a string para uma string do banco que será criado");

CREATE TABLE [dbo].[Fila] (
    [Id]          INT       IDENTITY (1, 1) NOT NULL,
    [Moeda]       NCHAR (3) NULL,
    [Data_Inicio] DATE      NULL,
    [Data_Fim]    DATE      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE PROCEDURE [dbo].[SP_AddItemFila]
	@Moeda nchar(3),
	@Data_Inicio date,
	@Data_Fim date
AS
	
	insert into Fila(Moeda, Data_Inicio, Data_Fim)
	values(@Moeda, @Data_Inicio, @Data_Fim)

CREATE PROCEDURE [dbo].[SP_DeleteItemFila]
	@ID int
AS
	
	delete from Fila where Id = @ID


CREATE PROCEDURE [dbo].[SP_GetItemFila]
	
AS
	
	SELECT * FROM Fila
	ORDER BY id DESC
  
  
