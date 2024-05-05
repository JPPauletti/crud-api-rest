# Sistema de Tarefas

## Visão Geral

Este é um projeto de um sistema de tarefas que implementa uma API RESTful em C# utilizando o framework ASP.NET Core. O sistema permite o gerenciamento de usuários e tarefas, além de integração com o serviço ViaCep para consulta de endereços.

## Pré-requisitos

### Windows

1. Instale o Visual Studio ou Visual Studio Code.
2. Instale o SDK do .NET Core.
3. Clone este repositório.

### Configurações

```json

No arquivo appsettings.json, substitua `YOUR_SERVER`, `YOUR_DATABASE`, `YOUR_USER` e `YOUR_PASSWORD` pelos valores correspondentes do seu ambiente de banco de dados.

## Instalação

1. Abra o projeto no Visual Studio ou Visual Studio Code.
2. Execute o comando `dotnet restore` para restaurar as dependências do projeto.

## Execução

1. Execute o projeto no Visual Studio ou Visual Studio Code.
2. Acesse a API através do endpoint fornecido.

## Endpoints

- `/api/user`: Endpoint para operações relacionadas a usuários.
- `/api/task`: Endpoint para operações relacionadas a tarefas.
- `/api/cep/{cep}`: Endpoint para consulta de endereços por CEP.

## Documentação

A documentação da API pode ser encontrada em `/swagger/index.html`.

