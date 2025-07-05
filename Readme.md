## 📚 API Biblioteca (.NET + MySQL)
Esta é uma API RESTful para gerenciamento de livros, usuários e empréstimos, desenvolvida com C#, ASP.NET Core Web API, Entity Framework Core e MySQL.

O projeto foi estruturado com boas práticas, como separação em camadas (Model, Service, Controller), uso de injeção de dependência e documentação automática com Swagger.

## 🚀 Tecnologias utilizadas
.NET 8 / 10 (preview)

ASP.NET Core Web API

Entity Framework Core

Pomelo MySQL Provider

MySQL

Swagger (Swashbuckle)

Visual Studio Code

## 📦 Funcionalidades
✅ Cadastro, listagem, edição e remoção de livros

✅ Gerenciamento de usuários

✅ Controle de empréstimos

✅ Documentação interativa com Swagger

✅ Uso de banco de dados MySQL com migrations

## ⚙️ Requisitos para rodar
.NET SDK 8 ou superior

MySQL Server

Editor de código (VS Code ou Visual Studio)

Git instalado

## 🧪 Como rodar o projeto localmente

1° - `git clone https://github.com/GokuDBZSSJ7/sistema-biblioteca-api.git`

2° - No arquivo de appsettings.json, edite a string de conexão com os dados do seu MySQL: `"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=api_biblioteca;user=root;password=sua_senha"
}`

3° - `dotnet ef database update`

4° - `dotnet run`

5° - Acesse no navegador: `https://localhost:7044/swagger`

## ​📷​ Imagens do Projeto

![Tela do Projeto](./print.jfif)