USE entremaos;

INSERT INTO entremaos.estadocivil (estadoCivil) VALUES
('Solteiro(a)'),
('Casado(a)'),
('Separado(a)'),
('Divorciado(a)'),
('Viúvo(a)');

INSERT INTO entremaos.convenio (nomeConvenio) VALUES
('Santa Helena');

INSERT INTO entremaos.moracom (moraCom) VALUES
('Família'),('Sozinho'),('Amigos'),('Outros');

INSERT INTO entremaos.Residencia (tipoResidencia) VALUES
('Própria'),('Alugada'),('Emprestada/Cedida');

INSERT INTO entremaos.cestabasica (dataRetirada, descricaoItens) VALUES
(STR_TO_DATE('31-07-2023', '%d-%m-%Y'), 'Arroz, Feijão, Macarrão, Bolacha, Detergente, Leite, Margarina, Chá Mate, Óleo, Ovos, Farofa tradicional, Molho de Tomate, Macarrão, Café, Pão de forma');

INSERT INTO entremaos.morador (nomeFamiliar, parentesco, dataNascimento, situacaoAtual) VALUES
('Antonella Freitas Souza', 'Filha', STR_TO_DATE('09-10-2018', '%d-%m-%Y'),'Estudante');

INSERT INTO entremaos.administradordosite (emailAdm, senhaAdm, nomeAdm, fotoAdm) VALUES
('Solangeadministrador@gmail.com', '12345678', 'Solange Lucia', 'https://images.pexels.com/photos/3718351/pexels-photo-3718351.jpeg?cs=srgb&dl=pexels-slawek-1207257-3718351.jpg&fm=jpg');

INSERT INTO entremaos.contemplado (estadoCivil_id, postoConvenio_id, moraCom_id, residencia_id, nomeContemplado, dataNascimento, RG, CPF, escolaridade, endereco, naturalidade,
telefone, bairro, ajudaGoverno, gastoComMedicamento, dívida, rendaFamiliar, temVeiculo, necessidadeDeLeite, necessidadeDeFralda,
problemaComCigarroOuDrogas, problemaComBebida, deficiencia, responsavelFamilia, tamanhoFamilia, anotacoesGerais, cadastro,
desligamento, indicacao, nomePosto, aluguel, fotoContemplado) VALUES
(1, 1, 1, 3, 'Mayara',STR_TO_DATE('17-03-1993', '%d-%m-%Y'), '26.088.968-4', '353.687.428-27', 'Ensino Médio Completo', 'Rua Ilha da Trindade, 500', 'São Paulo/SP', '(11) 99137-3669', 'Parque Santa Madalena', 'Bolsa Família - R$750', 'Não', 'Não', 'Até 1500,00', false, false, 
false, 'Não', 'Não', 'Não', 'O próprio entrevistado(a)', 2, 'Mora com a filha, a Casa foi herança, filha é intolerante a lactose e tem dermatite. Trabalha como diarista - valor R$150 quando aparece', STR_TO_DATE('24-07-2023', '%d-%m-%Y'), false, 'Portão', 'Pastoral', 'Não', 
'C:\\Users\\rafae\\Downloads\\grupo.jpg');

INSERT INTO entremaos.composicaoFamiliar (contemplado_id, morador_id) VALUES
(1,1);

INSERT INTO entremaos.CestaBasica_Contemplado ( contemplado_id, cestaBasica_id, recebidoPor, recebido ) VALUES
(1, 1, 'Marcela Freitas Souza', true);

UPDATE administradordosite set fotoAdm = 'C:\\Users\\rafae\\Downloads\\Extensionista\\Imagens\\foto_perfil.jpg' where administrador_id = 2;