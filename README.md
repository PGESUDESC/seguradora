# seguradora
Trabalho da disciplina de Trabalho Final do módulo II da PGES Udesc 2015

##Professor 
Nilson Modro
##Alunos
ALex Michelon  
Leandro Battisti  
Ricardo Voigt  

##Definição
Cada empresa seguradora, direta ou indiretamente, vende aos seus clientes “segurança” (ou seja, “cobertura de risco”), sob a forma de seguros que podem ser de vários tipos, mais ou menos comuns.   
Há seguros de automóveis, de casa (de exterior ou de interiores), de vida, de saúde, de viajem, industriais, etc. Inicialmente deve ser considerada pelo menos a categoria “seguro de automóvel”. O seguro de automóvel depende se é um veículo de passageiros, de transporte público ou de transporte de carga. Os seguros, qualquer que seja a sua categoria, possuem algumas características comuns que devem ser consideradas:   
* Têm um código único definido pela seguradora;
* Têm um titular cujo nome, local de residência, Identidade e CPF é obrigatório; 
*	Têm um preço anual a pagar, curiosamente designado prémio base anual, que poderá ser aumentado em função das opções adicionais escolhidas pelo titular ou até diminuído de um dado valor caso não se registe nenhuma ocorrência; 
*	Têm adicionalmente um agravamento de % por ocorrência registada;
* Têm um segurado, ou seja, a descrição do objeto do seguro. 

Para cada categoria de seguro, por exemplo veículos, devemos possuir todas as opções possíveis sob a forma de aditamentos ou cláusulas. Cada uma destas cláusulas deverá possuir um texto, e um valor de % a adicionar ao prémio base. Ao realizar-se o seguro, o titular poderá aderir ou não a tais aditamentos. Por exemplo, num seguro de automóvel normal, o titular pode querer incluir “quebra de vidros”, “assistência em viagem”, etc. Para cada tipo de seguro as cláusulas variam, incluem um texto descritivo que o titular aceita ou não, e que corresponde a um aumento de % no prêmio. Exemplos para seguro de veículos:
*	Cláusula A: Vidros involuntariamente partidos => mais X%; 
* Cláusula B: Cobertura de todos os riscos => mais X%;
* Cláusula C: Mais de 10 anos em circulação=> mais X%; 

Assim, temos o essencial da informação gerida por uma única seguradora.

Tendo em atenção o descrito acima, proponha uma solução de software que permita:
* A gestão de seguros de uma empresa seguradora desde o registo à entrada, passando pelos diferentes pontos de atendimento, até à entrega final ao cliente;
* A produção dos relatórios para a gestão.

##Processo de Desenvolvimento:

###1.	Informações gerais:
* as equipes devem ter no mínimo três e no máximo quatro integrantes;
* deve ser considerado que cada membro da equipe tem disponibilidade de 12 horas por semana (segunda a domingo) para o desenvolvimento desse software;
* os softwares podem ser desenvolvidos em qualquer linguagem de programação (desde que orientada a objetos) e qualquer banco de dados relacional.

###2.	Gerenciamento de Configuração:
* A equipe deve escolher um repositório público de versionamento de projetos, tais como, Google Code, SourceForge ou GitHub, e criar um projeto em um desses repositórios. Associar todos os membros da equipe, e enviar um convite ao professor da disciplina (nilsonmodro@gmail.com) para fazer parte da equipe. Esse procedimento deve ser realizado até o dia 15/11. Todos os artefatos do projeto devem estar sincronizados com esse repositório;

* Criar uma pasta seguradora, onde devem estar todo o código fonte, scripts, arquivos de configuração, e qualquer outro arquivo necessário para a execução e implantação do software que simula a gestão da seguradora;

* Criar uma pasta docs, onde serão organizados os artefatos que não se relacionam ao software em si, mas a documentação, especificação e outros documentos descritos adiante. Todos os arquivos pdf, e do EA, solicitados daqui por diante, devem ser armazenados nessa pasta.
###3.	Gerenciamento do Projeto:
* Disponibilizar um arquivo termo_abertura.pdf e plano_gerenciamento_projetos.pdf (até 21/11). 
* Existirão duas sprints: uma que termina no dia 28/11 e outra que termina no dia 05/12;
* Disponibilizar um arquivo backlog_inicial.pdf (até 28/05), contendo a lista de casos de uso (ver o item 4. Engenharia de Requisitos e Prototipação) e prioridade segundo o cliente. Também deve constar a estimativa de esforço de cada funcionalidade, e ao final do documento descrever qual foi à técnica de estimativa utilizada e como ela se desenvolveu;

* Disponibilizar um arquivo sprint_backlog_1.pdf (até 28/05) e sprint_backlog_2.pdf (até 04/06). Cada arquivo deve conter a lista de funcionalidades a serem implementadas com suas respectivas observações, por exemplo, uma nova versão do cenário do caso de uso, contendo parte dos passos do cenário completo. Para a sprint 2 devem ser considerados os resultados da sprint 1 e recálculo de estimativas de esforço (que devem constar no arquivo sprint_backlog_2.pdf);

* Nos dias 28/11 e 05/11, pelo menos um membro da equipe deve apresentar ao cliente (professor da disciplina) o software produzido na sprint. O software deve ser apresentado no computador próprio da equipe. A apresentação pode durar até 60 minutos, e a primeira apresentação inicia às 09 horas.

###4.	Engenharia de Requisitos e Prototipação:
* Disponibilizar um arquivo prototipacao.pdf (até 21/11) contendo, como média ou alta fidelidade, todas as telas do sistema de controle de pontos;

* Disponibilizar um arquivo seguro.eap (até 21/11) na pasta docs, contendo todos os casos de uso com suas pré e pós-condições, e os cenários principais, alternativos e de exceção de todos os casos de uso.

###5.	Testes de Software:
* Disponibilizar um arquivo casos_teste_1.pdf (até 28/11), listando a implementação de testes unitários automatizados, com ou sem uso de frameworks, das funcionalidades da sprint 1;

* Disponibilizar um arquivo casos_teste_2.pdf (até 05/12), listando a implementação de testes unitários automatizados, com ou sem uso de frameworks, das funcionalidades da sprint 2;

###6.	Projeto de Software:
* Disponibilizar no arquivo seguro.eap (já citado no item 4. Engenharia de Requisitos e Prototipação) os diagramas de interação e classes suficiente para atender a sprint 1;

* Disponibilizar no arquivo seguro_v2.eap (até 04/12) os diagramas de interação e classes suficiente para atender a sprint 2. Faça uma cópia do seguro.eap, e realize as modificações necessárias para a sprint 2.

###Outras informações:
* No sábado pela manhã e a tarde (14/11), a partir das 09:00 horas, está marcada a entrevista com o cliente (o próprio professor da disciplina).
* Ainda no sábado, deve ser fornecido o nome da equipe, os membros e a função de cada um no projeto. Também será marcada a ordem das apresentações para os dias 28 de novembro e 05 de dezembro.
* A presença na disciplina não é obrigatória, mas o cliente estará somente disponível fisicamente para elucidar dúvidas de requisitos nos dias 14 de novembro.  

O Quadro abaixo apresenta o cronograma da disciplina  

|Data| ATIVIDADES|
|----|-----------|
|14 novembro|Disponibilidade do cliente; e Entrevista com o cliente, formação da equipe|
|15 novembro|Criação do repositório e convite para o professor|
|21 novembro|Termo de abertura, plano de gerenciamento, backlog inicial, sprint backlog 1, prototipação, seguro.eap|
|28 novembro| Casos de teste 1   e Apresentação Sprint 1|
|04 dezembro|seguro_v2.eap, sprint backlog 2|
|05 dezembro|Casos de teste 2 e Apresentação Sprint 2|


####Composição da Avaliação:
|Instrumentos|Critérios|Pontos|
|------------|---------|------|
|termo_abertura.pdf|Cumprimento do modelo, completude e coerência|0,5|
|plano_gerenciamento_projetos.pdf|Cumprimento do modelo, completude e coerência|1,0|
|prototipacao.pdf|Completude e coerência|1,0|
|seguro.eap|- Casos de uso: todos os UCs foram considerados, preenchidos com os dados solicitados no enunciado, e estão coerentes com a entrevista?  e Diagrama de interação e classes: de acordo com as funcionalidades eleitas da sprint 1 
|2,0|
|backlog_inicial.pdf|Coerência das funcionalidades e estimativas, e explicação dos procedimentos para a aferição das estimativas.|1,0|
|sprint_backlog_1.pdf|Coerência com o backlog inicial, com a lista de casos de uso e o tamanho da equipe|1,5|
|casos_teste_1.pdf|Completude e coerência com as funcionalidades apresentadas da sprint 1|0,75|
|Apresentação do Sprint 1|Software abrange as funcionalidades da sprint 1. Serão também avaliadas as justificativas para aquelas não cumpridas|1,0|
|seguro_v2.eap| Diagrama de interação e classes: de acordo com as funcionalidades eleitas da sprint 1|2,0|
|sprint_backlog_2.pdf|Coerência com o backlog inicial e sprint 1, com a lista de casos de uso e o tamanho da equipe|1,5|
|casos_teste_2.pdf|Completude e coerência com as funcionalidades apresentadas da sprint 2|0,75|
|Apresentação do Sprint 2|Software abrange as funcionalidades da sprint 2. Serão também avaliadas as justificativas para aquelas não cumpridas.|1,0|
|**TOTAL**||14,0|

* Atraso na entrega de algum desses documentos, será desconsiderado na pontuação, apesar de que ainda poderei realizar a avaliação sobre o mesmo.

* A nota máxima desse trabalho será considerada segundo a pontuação da tabela acima. Porém, a nota individual pode se diferenciar dentro da equipe, de acordo com a percepção do professor no comprometimento, participação e execução das tarefas pelo aluno.

* Apesar da soma ultrapassar a nota 10,0, será considerado o máximo a nota 10,0 na média. 



