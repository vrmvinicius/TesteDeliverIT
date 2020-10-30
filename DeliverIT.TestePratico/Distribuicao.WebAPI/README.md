# TesteDeliverIT
Nome: Vinícius Rafael Migliorança.
E-mail: vrmvinicius@gmail.com

Além da web-api para receber as requisões de inclusão e listagem, desenvolvi as funcionalidades
em cima de um parte do que é o DDD (Domain-Driven Design). Desta forma é possível avaliar melhor
a organização dos fontes, qualidade das implementações e demais aspectos. Com certeza cabem muitas
otimizações aqui, o uso de mais padrões de projetos, e refatorações.

Para a persistência dos dados eu optei por um banco SQL Server local (LocalDB). Facilita bastante já que
não precisa de nada especial para criar o banco e populá-lo. 

A operação de POST para inclusão das contas esta definido como um Array. Fiz essa opção para facilitar
a inclusão de dados no banco para testes. A criação de banco pode ser feita utilizando o comando 'update-database'
do 'migrations'. Os arquivos gerados pelo migrations estão em Infra.Dados.Principal.Migrations.

Os calculos de juros eu fiz não considerando o 'juro sobre juro', caso assim necessário fosse, eu poderia
rapidamente alterar os métodos que fazem estes calculos. Se necessário é só me avisar que eu altero, commito,
e já disponibilizo uma versão atualizada.

Qualquer dúvida referente as decisões que tomei na implementação deste teste, por favor, não exitem em me contactar.

Abaixo deixo um algumas linhas para facilitar a inclusão de dados no banco para testes, pra facilitar.

[    
    { "Nome": "ContaPagar01", "DataVencimento": "2020-10-05", "ValorOriginal": 50,  "DataPagamento": "2020-10-04" },
    { "Nome": "ContaPagar02", "DataVencimento": "2020-10-05", "ValorOriginal": 100, "DataPagamento": "2020-10-05" },
    { "Nome": "ContaPagar03", "DataVencimento": "2020-10-05", "ValorOriginal": 150, "DataPagamento": "2020-10-06" },
    { "Nome": "ContaPagar04", "DataVencimento": "2020-10-05", "ValorOriginal": 200, "DataPagamento": "2020-10-07" },
    { "Nome": "ContaPagar05", "DataVencimento": "2020-10-05", "ValorOriginal": 250, "DataPagamento": "2020-10-08" },
    { "Nome": "ContaPagar06", "DataVencimento": "2020-10-05", "ValorOriginal": 300, "DataPagamento": "2020-10-09" },
    { "Nome": "ContaPagar07", "DataVencimento": "2020-10-05", "ValorOriginal": 350, "DataPagamento": "2020-10-10" },
    { "Nome": "ContaPagar08", "DataVencimento": "2020-10-05", "ValorOriginal": 400, "DataPagamento": "2020-10-11" },
    { "Nome": "ContaPagar09", "DataVencimento": "2020-10-05", "ValorOriginal": 450, "DataPagamento": "2020-10-12" },
    { "Nome": "ContaPagar10", "DataVencimento": "2020-10-05", "ValorOriginal": 500, "DataPagamento": "2020-10-13" },
	{ "Nome": "ContaPagar11", "DataVencimento": "2020-10-05", "ValorOriginal": 550, "DataPagamento": "2020-10-14" },
	{ "Nome": "ContaPagar12", "DataVencimento": "2020-10-05", "ValorOriginal": 600, "DataPagamento": "2020-10-15" }
]