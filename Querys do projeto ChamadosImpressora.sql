-- Query criar tblImpressora e query de inserção de dados na tabela
CREATE TABLE tblImpressora (
ID_Impressora INT IDENTITY(1000,1) NOT NULL
CONSTRAINT PK_ID_Impressora PRIMARY KEY,
Modelo VARCHAR(100) NOT NULL,
DataDeCadastro DATETIME DEFAULT GETDATE(),
DataUltimaAlteracao DATETIME DEFAULT GETDATE()
);

INSERT INTO tblImpressora VALUES ('MX611',GETDATE(),GETDATE());
INSERT INTO tblImpressora VALUES ('MS610',GETDATE(),GETDATE());
INSERT INTO tblImpressora VALUES ('MX911',GETDATE(),GETDATE());
INSERT INTO tblImpressora VALUES ('X792',GETDATE(),GETDATE());

-- Query criar tblSeccional e query de inserção de dados na tabela
CREATE TABLE tblSeccional (
ID_Seccional INT IDENTITY(1,1) NOT NULL
CONSTRAINT PK_ID_Seccional PRIMARY KEY,
Nome VARCHAR(100) NOT NULL,
DataDeCadastro DATETIME DEFAULT GETDATE(),
DataUltimaAlteracao DATETIME DEFAULT GETDATE()
);

INSERT INTO tblSeccional VALUES ('Sede',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Adamantina',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Araçatuba',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Araraquara',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Avaré',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Barretos',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Bauru',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Bragança Paulista',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Campinas',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Caraguatatuba',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Fernandópolis',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Franca',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Guarulhos',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Jundiaí',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Leste',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Marília',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Mogi das Cruzes',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Osasco',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Piracicaba',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Presidente Prudente',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Registro',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Ribeirão Petro',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Santana -  Subsedenorte',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Santo André',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Santos',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional São João da Boa Vista',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional São José do Rio Preto',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional São José dos Campos',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Sorocaba',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Subsede - Centro',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Sul',GETDATE(),GETDATE());
INSERT INTO tblSeccional VALUES ('Seccional Tatuapé - Subsede Leste',GETDATE(),GETDATE());

-- Query criar tblDepartamento e query de inserção de dados na tabela
CREATE TABLE tblDepartamento (
ID_Departamento INT IDENTITY NOT NULL
CONSTRAINT PK_ID_Departamento PRIMARY KEY,
Nome VARCHAR(100) NOT NULL,
DataDeCadastro DATETIME DEFAULT GETDATE(),
DataUltimaAlteracao DATETIME DEFAULT GETDATE()
);

-- Query para criação de procedure de consulta seccionais cadastradas
CREATE PROCEDURE spBuscaSeccionais
AS 
BEGIN
SELECT ID_Seccional,Nome
FROM tblSeccional
END

INSERT INTO tblDepartamento VALUES ('Administração',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Atendimento',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Comunicação',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Controladoria',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Etica',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Eventos',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Fiscalização',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Jurídico',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Licitações',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Logistica',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Processo Fiscal',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('RH',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Secol',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('TI',GETDATE(),GETDATE());
INSERT INTO tblDepartamento VALUES ('Triagem',GETDATE(),GETDATE());

-- Query para criação de procedure de consulta os departamentos por seccional
CREATE PROCEDURE spBuscaDepartamentosPorSeccional
@ID_Seccional INT
AS 
BEGIN
SELECT D.ID_Departamento, D.Nome AS 'Departamento'
FROM tblDepartamento D
INNER JOIN tblImpressorasAlocadas IA ON IA.ID_Departamento = D.ID_Departamento
INNER JOIN tblSeccional S ON S.ID_Seccional = IA.ID_Seccional
WHERE IA.ID_Seccional = @ID_Seccional
END

exec spBuscaDepartamentosNaSeccional 2

-- Query criar tblImpressorasAlocadas e query de inserção de dados na tabela
CREATE TABLE tblImpressorasAlocadas (
ID_Seccional INT NOT NULL
CONSTRAINT FK_ID_Seccional_tblImpressorasAlocadas_tblSeccional FOREIGN KEY (ID_Seccional) REFERENCES tblSeccional(ID_Seccional),
ID_Departamento INT NOT NULL
CONSTRAINT FK_ID_Departamento_tblImpressorasAlocadas_tblDepartamento FOREIGN KEY (ID_Departamento) REFERENCES tblDepartamento(ID_Departamento),
ID_Impressora INT NOT NULL
CONSTRAINT FK_ID_Departamento_tblImpressorasAlocadas_tblImpressora FOREIGN KEY (ID_Impressora) REFERENCES tblImpressora(ID_Impressora),
DataDeCadastro DATETIME DEFAULT GETDATE(),
DataUltimaAlteracao DATETIME DEFAULT GETDATE()
);

-- Query para criação de procedure de consulta de impressoras alocadas
CREATE PROCEDURE spBuscaImpressorasDepartamento
@ID_Seccional INT,
@ID_Departamento INT
AS
BEGIN
SELECT I.ID_Impressora, I.Modelo AS 'Impressora'
FROM tblImpressorasAlocadas IA
INNER JOIN tblSeccional S ON S.ID_Seccional = IA.ID_Seccional
INNER JOIN tblDepartamento D ON D.ID_Departamento = IA.ID_Departamento
INNER JOIN tblImpressora I ON I.ID_Impressora = IA.ID_Impressora
WHERE IA.ID_Seccional = @ID_Seccional
AND IA.ID_Departamento = @ID_Departamento
END

INSERT INTO tblImpressorasAlocadas VALUES (1,1,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,3,1002,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,4,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,5,1003,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,6,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,7,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,8,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,9,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,10,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,11,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,12,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,13,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,14,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (1,15,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (2,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (3,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (4,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (5,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (6,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (7,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (8,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (9,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (10,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (11,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (12,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (13,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (14,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (15,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (16,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (17,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (18,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (19,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (20,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (21,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (22,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (23,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (24,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (25,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (26,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (27,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (28,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (29,2,1000,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (30,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (31,2,1001,GETDATE(),GETDATE());
INSERT INTO tblImpressorasAlocadas VALUES (32,2,1001,GETDATE(),GETDATE());

-- Query criar tblStatus e query de inserção de dados na tabela
CREATE TABLE tblStatus (
ID_Status BIT NOT NULL
CONSTRAINT PK_ID_Status PRIMARY KEY,
Descricao VARCHAR(100) NOT NULL
)

INSERT INTO tblStatus VALUES (1,'Aberto');
INSERT INTO tblStatus VALUES (0,'Encerrado');

CREATE TABLE tblCategoriaChamado (
ID_Categoria INT IDENTITY(1,1) NOT NULL
CONSTRAINT PK_ID_Categoria PRIMARY KEY,
Descricao VARCHAR(100) NOT NULL
)

INSERT INTO tblCategoriaChamado VALUES ('Impressão manchada');
INSERT INTO tblCategoriaChamado VALUES ('Folha travando na impressora');
INSERT INTO tblCategoriaChamado VALUES ('Não digitaliza');
INSERT INTO tblCategoriaChamado VALUES ('Suprimento com defeito');

-- Query para criação de procedure de consulta seccionais cadastradas
CREATE PROCEDURE spBuscaCategoriaChamado
AS 
BEGIN
SELECT ID_Categoria,Descricao
FROM tblCategoriaChamado
END

-- Query criar tblRegistroChamados e query de inserção de dados na tabela
CREATE TABLE tblRegistroChamados (
ID_Chamado INT NOT NULL
CONSTRAINT PK_ID_Chamado PRIMARY KEY,
ID_Seccional INT NOT NULL
CONSTRAINT FK_ID_Seccional_tblRegistroChamados_tblSeccional FOREIGN KEY (ID_Seccional) REFERENCES tblSeccional(ID_Seccional),
ID_Departamento INT NOT NULL
CONSTRAINT FK_ID_Departamento_tblRegistroChamados_tblDepartamento FOREIGN KEY (ID_Departamento) REFERENCES tblDepartamento(ID_Departamento),
ID_Impressora INT NOT NULL
CONSTRAINT FK_ID_Departamento_tblRegistroChamados_tblImpressora FOREIGN KEY (ID_Impressora) REFERENCES tblImpressora(ID_Impressora),
ID_Categoria INT NOT NULL
CONSTRAINT FK_ID_Categoria_tblRegistroChamados_tblCategoriaChamado FOREIGN KEY (ID_Categoria) REFERENCES tblCategoriaChamado(ID_Categoria),
Descricao VARCHAR(MAX) NOT NULL,
Observacao VARCHAR(MAX),
ID_Status BIT NOT NULL DEFAULT 1
CONSTRAINT FK_ID_StatusChamado_tblRegistroChamados_tblStatus FOREIGN KEY (ID_StatusChamado) REFERENCES tblStatus(ID_Status),
DataAberturaChamado DATETIME DEFAULT GETDATE()
)

EXEC sp_RENAME 'tblRegistroChamados.ID_StatusChamado' , 'ID_Status', 'COLUMN' 

INSERT INTO tblRegistroChamados (ID_Seccional,ID_Departamento,ID_Impressora,ID_Categoria,Descricao,DataAberturaChamado) VALUES (6,2,1000,3,'Folhas trava na impressora.',GETDATE())
INSERT INTO tblRegistroChamados VALUES (5,2,1000,'Folhas estão saindo manchadas.',NULL,0,GETDATE())
INSERT INTO tblRegistroChamados VALUES (19,2,1001,'Impressora não envia digitalização por e-mail.',NULL,1,GETDATE())
INSERT INTO tblRegistroChamados VALUES (15,2,1000,'Folhas estão saindo manchadas.',NULL,0,GETDATE())
INSERT INTO tblRegistroChamados VALUES (17,2,1000,'Folhas estão saindo manchadas.',NULL,0,GETDATE())
INSERT INTO tblRegistroChamados VALUES (1,9,1000,'Folhas estão saindo manchadas.',NULL,1,GETDATE())
INSERT INTO tblRegistroChamados VALUES (1,3,1002,'Folhas estão saindo manchadas.',NULL,0,GETDATE())
INSERT INTO tblRegistroChamados VALUES (1,6,1000,'Folhas estão saindo manchadas.',NULL,1,GETDATE())
INSERT INTO tblRegistroChamados VALUES (9,2,1001,'Folhas estão saindo manchadas.',NULL,1,GETDATE())

-- Query para criação de procedure de consulta de chamados
CREATE PROCEDURE spRegistraChamado
@ID_Seccional INT,
@ID_Departamento INT,
@ID_Impressora INT,
@ID_CategoriaChamado INT,
@DescricaoChamado VARCHAR(MAX)
AS
BEGIN
INSERT INTO tblRegistroChamados (ID_Seccional,ID_Departamento,ID_Impressora,ID_Categoria,Descricao)
VALUES (@ID_Seccional,@ID_Departamento,@ID_Impressora,@ID_CategoriaChamado,@DescricaoChamado)
END

-- Query para criação da procedure de consulta de chamados
CREATE PROCEDURE spConsultaChamados
AS
BEGIN
SELECT RC.ID_Chamado, RC.ID_Seccional, S.Nome AS 'Seccional', RC.ID_Departamento, D.Nome AS 'Departamento', RC.ID_Impressora, I.Modelo AS 'Impressora', RC.ID_Categoria, CC.Descricao AS 'Categoria', RC.ID_Status, ST.Descricao AS 'Status', RC.Descricao, RC.Observacao, RC.DataAberturaChamado FROM tblRegistroChamados RC
INNER JOIN tblSeccional S ON S.ID_Seccional = RC.ID_Seccional
INNER JOIN tblDepartamento D ON D.ID_Departamento = RC.ID_Departamento
INNER JOIN tblImpressora I ON I.ID_Impressora = RC.ID_Impressora
INNER JOIN tblStatus ST ON ST.ID_Status = RC.ID_Status
INNER JOIN tblCategoriaChamado CC ON CC.ID_Categoria = RC.ID_Categoria
END;

-- Query para criação da procedure de consulta de chamados por Id
CREATE PROCEDURE spConsultaChamadosPorId
@ID_Chamado INT
AS
BEGIN
SELECT RC.ID_Chamado, RC.ID_Seccional, S.Nome AS 'Seccional', RC.ID_Departamento, D.Nome AS 'Departamento', RC.ID_Impressora, I.Modelo AS 'Impressora', RC.ID_Categoria, CC.Descricao AS 'Categoria', RC.ID_Status, ST.Descricao AS 'Status', RC.Descricao, RC.Observacao, RC.DataAberturaChamado FROM tblRegistroChamados RC
INNER JOIN tblSeccional S ON S.ID_Seccional = RC.ID_Seccional
INNER JOIN tblDepartamento D ON D.ID_Departamento = RC.ID_Departamento
INNER JOIN tblImpressora I ON I.ID_Impressora = RC.ID_Impressora
INNER JOIN tblStatus ST ON ST.ID_Status = RC.ID_Status
INNER JOIN tblCategoriaChamado CC ON CC.ID_Categoria = RC.ID_Categoria
WHERE RC.ID_Chamado = @ID_Chamado
END;

-- Query para criação da procedure de consulta de chamados por Id
CREATE PROCEDURE spConsultaChamadosPorNomeSeccional
@Nome VARCHAR(100)
AS
BEGIN
SELECT RC.ID_Chamado, RC.ID_Seccional, S.Nome AS 'Seccional', RC.ID_Departamento, D.Nome AS 'Departamento', RC.ID_Impressora, I.Modelo AS 'Impressora', RC.ID_Categoria, CC.Descricao AS 'Categoria', RC.ID_Status, ST.Descricao AS 'Status', RC.Descricao, RC.Observacao, RC.DataAberturaChamado FROM tblRegistroChamados RC
INNER JOIN tblSeccional S ON S.ID_Seccional = RC.ID_Seccional
INNER JOIN tblDepartamento D ON D.ID_Departamento = RC.ID_Departamento
INNER JOIN tblImpressora I ON I.ID_Impressora = RC.ID_Impressora
INNER JOIN tblStatus ST ON ST.ID_Status = RC.ID_Status
INNER JOIN tblCategoriaChamado CC ON CC.ID_Categoria = RC.ID_Categoria
WHERE S.Nome=@Nome
END;

-- Consulta de impressoras alocadas
SELECT S.ID_Seccional, S.Nome AS 'Unidade', D.ID_Departamento, D.Nome 'Departamento', I.ID_Impressora, I.Modelo AS 'Modelo', IA.DataDeCadastro AS 'Data_De_Abertura', IA.DataUltimaAlteracao AS 'Data_De_Ultima_Alteracao' FROM tblSeccional S
INNER JOIN tblImpressorasAlocadas IA ON IA.ID_Seccional = S.ID_Seccional
INNER JOIN tblImpressora I ON I.ID_Impressora = IA.ID_Impressora
INNER JOIN tblDepartamento D ON D.ID_Departamento = IA.ID_Departamento
WHERE S.ID_Seccional = 1;

-- Query para criação da procedure de finalizar chamados
CREATE PROCEDURE spFinalizaChamado
@ID_Chamado INT,
@Observacao VARCHAR(MAX)
AS
BEGIN
UPDATE tblRegistroChamados SET ID_Status = 0, Observacao = @Observacao 
WHERE ID_Chamado = @ID_Chamado 
AND ID_Status = 1
SELECT COUNT(*) FROM tblRegistroChamados
WHERE ID_Chamado = @ID_Chamado
AND ID_Status = 0;
END;

CREATE TABLE tblUsuario (
ID_Usuario INT IDENTITY(10,1) NOT NULL
CONSTRAINT PK_ID_Usuario PRIMARY KEY,
NomeUsuario VARCHAR(100) NOT NULL,
SenhaUsuario1 VARCHAR(100) NOT NULL,
SenhaUsuario2 VARCHAR(100) NOT NULL,
DataDeCadastro DATETIME DEFAULT GETDATE(),
DataUltimaAlteracao DATETIME DEFAULT GETDATE()
);

INSERT INTO tblUsuario VALUES ('Administrador','adm','adm',GETDATE(),GETDATE());

-- Query para criação de procedure para criar usuário
CREATE PROCEDURE spCadastrarUsuario
@NomeUsuario VARCHAR(100),
@SenhaUsuario1 VARCHAR(100),
@SenhaUsuario2 VARCHAR(100)
AS 
BEGIN
INSERT INTO tblUsuario (NomeUsuario,SenhaUsuario1,SenhaUsuario2)
VALUES (@NomeUsuario,@SenhaUsuario1,@SenhaUsuario2)
END

-- Query para criação de procedure para criar usuário
CREATE PROCEDURE spValidaUsuario
@NomeUsuario VARCHAR(100),
@SenhaUsuario1 VARCHAR(100)
AS 
BEGIN
SELECT COUNT(*)
FROM tblUsuario
WHERE NomeUsuario=@NomeUsuario
AND SenhaUsuario1=@SenhaUsuario1
END

--CREATE TABLE tblUsuarioPermissoes (
--ID_Usuario INT NOT NULL
--CONSTRAINT FK_ID_Usuario_tblUsuarioPermissoes_tblUsuario FOREIGN KEY (ID_Usuario) REFERENCES tblUsuario(ID_Usuario),
--ID_Formulario INT NOT NULL
--CONSTRAINT FK_ID_Formulario_tblUsuarioPermissoes_tblFormulario FOREIGN KEY (ID_Formulario) REFERENCES tblFormulario(ID_Formulario),
--Cadastrar BIT NOT NULL DEFAULT 0,
--Editar BIT NOT NULL DEFAULT 0,
--Excluir BIT NOT NULL DEFAULT 0,
--Pesquisar BIT NOT NULL DEFAULT 0,
--DataDeCadastro DATETIME DEFAULT GETDATE(),
--DataUltimaAlteracao DATETIME DEFAULT GETDATE()
--);

--INSERT INTO tblUsuarioPermissoes VALUES (10,1,1,1,1,GETDATE(),GETDATE());