CREATE PROC FI_SP_IncBeneficiario
    @Nome          VARCHAR (50) ,
    @CPF varchar(14),
    @IdCliente int
AS
BEGIN
	INSERT INTO BENEFICIARIOS (NOME, IDCLIENTE, CPF)
	VALUES (@Nome,@IdCliente,@CPF)

	SELECT SCOPE_IDENTITY()
END