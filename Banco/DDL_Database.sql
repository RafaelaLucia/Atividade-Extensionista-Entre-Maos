CREATE DATABASE entreMaos;
USE entreMaos;

CREATE TABLE entreMaos.EstadoCivil (
 estadoCivil_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 estadoCivil varchar(100)
);

CREATE TABLE entreMaos.Convenio (
 postoConvenio_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 nomeConvenio varchar(200)
);

CREATE TABLE entreMaos.MoraCom (
 moraCom_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 moraCom varchar(100)
);

CREATE TABLE entreMaos.Residencia (
 residencia_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 tipoResidencia varchar(100)
);

CREATE TABLE entreMaos.Morador (
 morador_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 nomeFamiliar varchar(300),
 parentesco varchar(100),
 dataNascimento DATE,
 situacaoAtual varchar(200)
);

CREATE TABLE entreMaos.CestaBasica (
 cestaBasica_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 dataRetirada DATE,
 descricaoItens varchar(500)
);

CREATE TABLE entreMaos.AdministradorDoSite (
 administrador_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 emailAdm varchar(250),
 senhaAdm varchar(100), 
 nomeAdm varchar(200),
 fotoAdm varchar(200)
);

CREATE TABLE entreMaos.Contemplado (
 contemplado_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 estadoCivil_id INT, 
 postoConvenio_id INT, 
 moraCom_id INT, 
 residencia_id INT, 
 nomeContemplado varchar(300) NOT NULL, 
 dataNascimento DATE NOT NULL,
 RG varchar(15), 
 CPF varchar(15),
 escolaridade varchar(100), 
 endereco varchar(200), 
 naturalidade varchar(100), 
 telefone varchar(20), 
 bairro varchar(200), 
 ajudaGoverno varchar(100), 
 gastoComMedicamento varchar(100), 
 dívida varchar(100), 
 rendaFamiliar varchar(100), 
 temVeiculo boolean, 
 necessidadeDeLeite boolean, 
 necessidadeDeFralda boolean, 
 problemaComCigarroOuDrogas varchar(50), 
 problemaComBebida varchar(50),
 deficiencia varchar(100), 
 responsavelFamilia varchar(50), 
 tamanhoFamilia int, 
 anotacoesGerais varchar(500), 
 cadastro DATE,
 desligamento boolean, 
 indicacao varchar(100), 
 nomePosto varchar(100), 
 aluguel varchar(100), 
 fotoContemplado varchar(500), 
 CONSTRAINT estadoCivil_idFK FOREIGN KEY (estadoCivil_id) REFERENCES EstadoCivil(estadoCivil_id),
 CONSTRAINT postoConvenio_idFK FOREIGN KEY (postoConvenio_id) REFERENCES Convenio(postoConvenio_id),
 CONSTRAINT moraCom_idFK FOREIGN KEY (moraCom_id) REFERENCES MoraCom(moraCom_id),
 CONSTRAINT residencia_idFK FOREIGN KEY (residencia_id) REFERENCES Residencia(residencia_id)
);

CREATE TABLE entreMaos.CestaBasica_Contemplado (
 cestaBasica_Contemplado_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 contemplado_id  int,
 cestaBasica_id int,
 recebidoPor varchar(100),
 recebido Boolean,
 CONSTRAINT contemplado_idFK FOREIGN KEY (contemplado_id) REFERENCES Contemplado(contemplado_id),
 CONSTRAINT cestaBasica_idFK FOREIGN KEY (cestaBasica_id) REFERENCES CestaBasica(cestaBasica_id)
);

CREATE TABLE entreMaos.ComposicaoFamiliar (
  composicaoFamiliar_id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  contemplado_id  int,
  morador_id  int,
  CONSTRAINT contemplado_idFKFamilia FOREIGN KEY (contemplado_id) REFERENCES Contemplado(contemplado_id),
  CONSTRAINT morador_idFK FOREIGN KEY (morador_id) REFERENCES Morador(morador_id)
);




