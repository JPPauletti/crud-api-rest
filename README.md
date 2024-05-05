# CRUD API REST

Este é um projeto de uma API RESTful para realizar operações CRUD (Create, Read, Update, Delete) em usuários e tarefas. Desenvolvido por João Pedro de Oliveira Pauletti.

## Descrição

O projeto CRUD API REST é uma API desenvolvida em C# utilizando o framework ASP.NET Core. Ela fornece endpoints para gerenciar usuários e tarefas, permitindo a criação, leitura, atualização e exclusão de registros no banco de dados.

## Funcionalidades

- **Usuários**:
  - Criar um novo usuário
  - Obter detalhes de um usuário específico
  - Atualizar os detalhes de um usuário existente
  - Excluir um usuário

- **Tarefas**:
  - Criar uma nova tarefa associada a um usuário
  - Obter detalhes de uma tarefa específica
  - Atualizar os detalhes de uma tarefa existente
  - Excluir uma tarefa
  - 
## Uso do Refit para integração com os Correios

Além das operações CRUD em usuários e tarefas, este projeto também utiliza o Refit, uma biblioteca de criação de clientes HTTP declarativos em .NET, para integrar com os serviços dos Correios.

Ao enviar um CEP para a API, o sistema utiliza o Refit para realizar uma chamada à API pública dos Correios e obter informações detalhadas sobre o endereço associado ao CEP fornecido. Essas informações são então utilizadas pelo sistema para fornecer detalhes adicionais sobre o endereço ao usuário.

Essa integração com os Correios adiciona uma funcionalidade valiosa à API, permitindo aos usuários obterem rapidamente informações sobre um determinado endereço apenas fornecendo seu CEP.

## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- RESTful API
- Banco de Dados SQL Server
