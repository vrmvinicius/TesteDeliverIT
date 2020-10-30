# TesteDeliverIT
Nome: Vin�cius Rafael Miglioran�a.
E-mail: vrmvinicius@gmail.com

Al�m da web-api para receber as requis�es de inclus�o e listagem, desenvolvi as funcionalidades
em cima de um parte do que � o DDD (Domain-Driven Design). Desta forma � poss�vel avaliar melhor
a organiza��o dos fontes, qualidade das implementa��es e demais aspectos. Com certeza cabem muitas
otimiza��es aqui, o uso de mais padr�es de projetos, e refatora��es.

Para a persist�ncia dos dados eu optei por um banco SQL Server local (LocalDB). Facilita bastante j� que
n�o precisa de nada especial para criar o banco e popul�-lo. 

A opera��o de POST para inclus�o das contas esta definido como um Array. Fiz essa op��o para facilitar
a inclus�o de dados no banco para testes. A cria��o de banco pode ser feita utilizando o comando 'update-database'
do 'migrations'. Os arquivos gerados pelo migrations est�o em Infra.Dados.Principal.Migrations.

Os calculos de juros eu fiz n�o considerando o 'juro sobre juro', caso assim necess�rio fosse, eu poderia
rapidamente alterar os m�todos que fazem estes calculos. Se necess�rio � s� me avisar que eu altero, commito,
e j� disponibilizo uma vers�o atualizada.

Qualquer d�vida referente as decis�es que tomei na implementa��o deste teste, por favor, n�o exitem em me contactar.

Abaixo deixo um algumas linhas para facilitar a inclus�o de dados no banco para testes, pra facilitar.

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