# API REST - Registro de Logs de Ações de Usuários

Este projeto consiste em uma API REST desenvolvida com .NET 8 que permite o **registro e recuperação de logs de ações de usuários** em uma aplicação. 
A aplicação foi desenvolvida pelo projeto de extensão Desenvolvimento de Web Services, ministrado pelo professor Bruno Honorato, com foco na prática de conceitos 
fundamentais de desenvolvimento de Web Services, boas práticas de organização de código e testes com o Postman.

---

## 📚 Tecnologias Utilizadas

- [.NET 8]
- ASP.NET Core
- C#
- Postman (para testes de requisições)
- Git e GitHub (para versionamento)

---

## 🔧 Funcionalidades Implementadas

### ✅ GET `/api/logs`

Retorna todos os logs de ações registrados.

### ✅ GET `/api/logs/{username}`

Retorna os logs de ações filtrando pelo nome do usuário.

### ✅ POST `/api/logs`

Cria um novo log de ação.

---

###🧪 Testes com o Postman

Foram realizados testes com os métodos GET e POST, incluindo:

Registro de logs com dados variados.

Visualização de todos os logs.

Filtragem de logs por nome de usuário.

As requisições foram salvas em uma coleção do Postman e exportadas no formato .postman_collection.json.

--- 

###✅ Como Executar o Projeto

1) Clone o repositório: git clone https://github.com/Iarafarias/api-user-logs.git
cd api-user-logs

2) Execute a aplicação: dotnet run

A API será iniciada em https://localhost:port (a porta será exibida no terminal).

3) Use o Postman para testar os endpoints.

### 📂 Exportação da Coleção

A coleção de testes do Postman se encontra dentro da pasta /postman com o nome:

Api_rest.postman_collection.json

###👩‍💻 Desenvolvido por
Iara Farias
Estudante de Sistemas de Informação
Contato: [https://www.linkedin.com/in/iara-farias-a72b19229/]



