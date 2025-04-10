📘 Projeto API REST - Registro de Logs de Ações do Usuário
🎓 Contextualização
Este projeto foi desenvolvido para o projeto de extensão Desenvolvimento de Web Services, ministrado pelo professor Bruno Honorato, com o propósito de consolidar os 
conhecimentos adquiridos sobre desenvolvimento de APIs RESTful.

A proposta realizada consiste na construção de uma API capaz de registrar, consultar e filtrar logs de ações realizadas por usuários, promovendo o entendimento dos princípios de arquitetura REST, 
organização modular e testes de endpoints com ferramentas externas.

🎯 Objetivo
Desenvolver uma API REST que registre ações dos usuários com os seguintes dados:

Nome do usuário;

Tipo de ação executada (ex.: GET, POST);

Endpoint acessado;

Data e hora da execução.

A API permite tanto o registro de novas ações quanto a consulta completa ou filtrada por nome de usuário.

🧰 Tecnologias e Ferramentas Utilizadas
.NET 8

C#

Visual Studio Community

Postman (testes de requisições)

Git e GitHub (versionamento)

Arquitetura aplicada: MVC

🗂️ Estrutura do Projeto

api_rest/
├── Controllers/            # Controladores responsáveis pelas rotas
│   └── UserActionLogController.cs
├── Domain/                 # Camada de domínio
│   ├── Models/
│   │   └── UserActionLog.cs
│   └── Services/
│       └── UserActionLogServices.cs
├── Persistence/            # Camada de persistência de dados
│   └── Repositories/
│       └── UserActionLogRepository.cs
├── postman/                # Pasta contendo a coleção de testes Postman
│   └── Api_rest.postman_collection.json
└── README.md               # Documento explicativo do projeto

📌 Endpoints Desenvolvidos

GET /api/logs
Retorna a lista completa de logs registrados.

GET /api/logs/{username}
Filtra os registros de acordo com o nome de usuário informado na URL.

POST /api/logs
Adiciona um novo log. Exemplo de corpo da requisição:

🧪 Testes Realizados com Postman
Os testes das funcionalidades foram efetuados por meio da ferramenta Postman, onde foram verificadas as seguintes operações:

Consulta de todos os registros (GET /api/logs);

Consulta de registros filtrados por nome (GET /api/logs/{username});

Inserção de novos logs com diversos usuários e endpoints (POST /api/logs);

Exportação e salvamento da coleção de testes em JSON para entrega acadêmica.

A coleção completa encontra-se na pasta /postman com o nome Api_rest.postman_collection.json.

🧭 Passo a Passo para Execução

Clone o repositório: git clone https://github.com/Iarafarias/api_rest.git
Abra o projeto em sua IDE de preferência (Visual Studio ou VS Code).

Execute o projeto localmente. A API será iniciada nos endereços:

http://localhost:5000

https://localhost:5001

No Postman:

Vá em Importar > Arquivo > Api_rest.postman_collection.json.

Execute os testes da coleção.

📌 Considerações Finais
A API foi desenvolvida com foco didático, simulando persistência em memória.

A estrutura adota boas práticas de separação de responsabilidades.

As funcionalidades atendem aos requisitos básicos de um sistema de registro de ações.

Os testes comprovam a integridade e funcionamento dos endpoints.
