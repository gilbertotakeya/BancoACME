# BancoACME
Aplicativo para teste de API, Banco ACME.<br>
Para realizar o teste do aplicativo, abra a solução BancoACME.API.Dados e faça o deploy da mesma. Copie a URL que a mesma gerou<br>
Para executar o aplicativo abra o projeto BancoACME.API.CalculadoraOnline<br>
Antes de realizar o deploy, verifique a URL do dicionário de dados (BancoACME.API.Dados)<br>
Caso ela seja diferente de https://localhost:44309/ vá no projeto BancoACME.Repositorio da solução BancoACME.API.CalculadoraOnline, abra o arquivo Calculadora.cs e 
adicione a URL do seu projeto na linha 22;<br>
Realizado este processo, execute o deploy da aplicação.<br>

Esta consulta a API contém, 2 Projetos sendo:
1) BancoACME\APIs: Dicionário de dados, onde ficará todos as definições do BancoACME<br>
-- BancoACME.API.Dados - Dicionário de dados do Banco ACME<br>
-- BancoACME.Repositorio - Repositorio de dados do banco ACME<br>
-- BancoACME.VisaoModelo - As views do projeto<br>

2) BancoACME\API Calculadora: Projeto da API onde o sistema realizará o cálculos online de juros compostos e retornará a informação do repositório.<br>
-- BancoACME.API.CalculadoraOnline - Dicionário de dados do Banco ACME<br>
-- BancoACME.API.CalculadoraOnline.Test - Teste da API de Calculo de Juros<br>
-- BancoACME.Interface - Interface do projeto<br>
-- BancoACME.Repositorio - Repositorio/Microsserviços do projeto<br>
-- BancoACME.VisaoModelo - As views do projeto<br>
