# Saldo Inteligente

Projeto desenvolvido com arquitetura DDD no backend, e clean archtecture no front com angular.

Apesar do projeto do teste em si ser pequeno, ele trata de um assunto de um grande projeto, que é o extrato de uma conta bancária e por esse motivo, é excencial utilizar uma arquitetura escalavel e de facil organização de contextos e responsabilidades, de facil testabilidade e manutenção. 

No caso do front, escolhi utilizar a arquitetura clean, pois ela é mais simples que o conceito da arquitetura DDD, mas no front, daria para utilizar uma arquitetura de componentes apenas, mas gostaria também de mostrar meu conhecimento na clean archteture.

Utilizei um código limpo, e com uma definição clara de responsabilidadess.

Eu mesmo idealizei e desenvolvi a simples interface do projeto, utilizando a ferramenta gratuita `https://penpot.app/`, coloquei uma cópia dele no diretorio `Design/penpot.pdf`, deixei também, dentro do pdf, os dois prints (um da microsoft e um print do video do youtube) que foram as inspirações para desenhar as telas. 


## Instruções para inicializar o banckend

Primeiramente configure a string de conexão do banco de dados mysql, que está dentro da pasta `./SaldoInteligente.API/appsettings.Development.json`

Agora, para rodar a migrations em seu banco de dados, abra seu terminal dentro da pasta raiz da solução, e rode o seguinte comando abaixo:

`dotnet ef --startup-project .\SaldoInteligente.API\SaldoInteligente.API.csproj --project .\SaldoInteligente.Infrastructure.csproj database update`

Feito isso, coloque o backend para rodar com o seguinte comando

`dotnet run`

Pronto, espero que tudo tenha dado certo ;>


## Instruções para inicializar o frontend

Se você seguiu as instruções de como inicializar o backend, abra um novo terminal, no terminar va até a pasta do projeto web, `./SaldoInteligente.WEB`, dentro desse diretorio, execute o seguinte comando para atualizar as dependencias e pacotes do node:

`yarn` ou `npm install` / `npm i`

Feito isso, basta apenas executar o projeto web:

`yarn start`

Obs: Verifique se o arquivo `./SaldoInteligente.WEB/enviroments/enviroment.ts` está com a variavel `serverUrl`, configurada para a url e porta correta para o seu backend. Deixei o enviromente configurado com o padrão, então imagino que não seja necessario alterar.

Tento feito isso, basta apenas executar o projeto.

`http://localhost:4200`

