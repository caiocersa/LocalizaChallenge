# Localiza Challenger
Projeto de calculadora capaz de decompor um número em todos os seus divisores, enumerando também aqueles que forem primos. Serviço desacoplado sendo utilizado
no contexto de um sistema WEB e API.

## Iniciando

### Pre-requisitos

É necessario instalar os seguintes programas para realizar o build e deploy do projeto:

```
Visual Studio 2019
.NET Core 3.1 SDK
ASP.NET Core 3.1 Runtime (v3.1.3) - Windows Hosting Bundle
```

## Executando o projeto WEB
1. Ir para a pasta LocalizaChallenge -> LocalizaChallenge.WEB
1. Abrir o powershell
1. Executar o comando dotnet build
1. Executar o comando dotnet run
1. entrar na url https://localhost:5001/ ou url exibida no console após o "Now listening on:"

## Executando o projeto de API
1. Ir para a pasta LocalizaChallenge -> LocalizaChallenge.API
1. Abrir o powershell
1. Executar o comando dotnet build
1. Executar o comando dotnet run
1. copiar url https://localhost:5001/ ou url exibida no console após o "Now listening on:"
1. Realizar requisições POST para a controladora Decomposicao metodos ObterDivisoresPrimos ou ObterDivisores.
  Exemplos: https://localhost:5001/Decomposicao/ObterDivisoresPrimos e
            https://localhost:5001/Decomposicao/ObterDivisores
1. Passar no Body JSON com a estrutura 
{
  "Numero": xxxx
}

## Executando no Visual Studio
1. Abrir o Visual Sturio
1. Carregar a solução LocalizaChallenge.sln
1. Executar com o perfil IISExpress o projeto LocalizaChallenge.WEB ou LocalizaChallenge.API que estão dentro da pasta 1 - Application.

## Autores

* **Caio César Alves de Souza** - *Desenvolvedor inicial* - [Contato](https://linkedin.com/in/caioalvs/)
