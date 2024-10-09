USE entremaos;

SELECT * FROM ComposicaoFamiliar
INNER JOIN contemplado ON ComposicaoFamiliar.contemplado_id = contemplado.contemplado_id
INNER JOIN morador ON ComposicaoFamiliar.morador_id = morador.morador_id;

SELECT contemplado_id, nomeContemplado as 'Nome do Contemplado(a)', dataNascimento as 'Data de Nascimento', RG, CPF,
escolaridade, endereco as 'Endereço', naturalidade, telefone, bairro, ajudaGoverno as 'Possui Ajuda do Governo?',
gastoComMedicamento as 'Gastos com Medicamento?', dívida, rendaFamiliar as 'Renda Familiar', necessidadeDeLeite as 'Possui Necessidade de Leite?',
necessidadeDeFralda as 'Possui Necessidade de Fralda?', problemaComCigarroOuDrogas as 'Problema com Cigarro ou Drogas?', problemaComBebida as 'Problema com Bebida?',
deficiencia, responsavelFamilia as 'Responsável pela Família', tamanhoFamilia as 'Tamanho da Família', anotacoesGerais as 'Anotações Gerais', cadastro,
desligamento, indicacao as 'Indicação', nomePosto as 'Nome Posto', aluguel, fotoContemplado as 'Foto Contemplado', estadoCivil as 'Estado Civil', nomeConvenio as 'Nome do Convênio', moraCom as 'Mora Com',
tipoResidencia as 'Tipo de Residência' FROM contemplado
INNER JOIN estadocivil on contemplado.estadoCivil_id = estadocivil.estadoCivil_id
INNER JOIN convenio on contemplado.postoConvenio_id = convenio.postoConvenio_id
INNER JOIN moracom on contemplado.moraCom_id = moracom.moraCom_id
INNER JOIN residencia on contemplado.residencia_id = residencia.residencia_id;

SELECT dataRetirada, recebidoPor, recebido, descricaoItens FROM CestaBasica_Contemplado
INNER JOIN contemplado on CestaBasica_Contemplado.contemplado_id = contemplado.contemplado_id
INNER JOIN cestabasica on CestaBasica_Contemplado.cestaBasica_id = cestabasica.cestaBasica_id;

