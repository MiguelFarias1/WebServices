# Projeto de Estudos da Plataforma .NET

Este é um projeto de estudos da plataforma .NET, onde estamos explorando várias tecnologias e conceitos importantes para o desenvolvimento de aplicações web.

## Tecnologias Utilizadas

- **Entity Framework**: Utilizado como ORM (Object-Relational Mapping) para facilitar o acesso e manipulação de dados no banco de dados MySQL.
- **MySQL**: Banco de dados relacional utilizado para armazenar os dados da aplicação.
- **Paginação**: Estudo e implementação de técnicas de paginação para melhorar a performance e usabilidade da aplicação.
- **DTO (Data Transfer Object)**: Utilização de DTOs para transferência de dados entre a camada de apresentação e a camada de acesso a dados.
- **Padrões de Projeto com IUnitOfWork**: Estudo e aplicação de padrões de projeto, como o padrão de projeto Unit of Work, para garantir a separação de responsabilidades e facilitar a manutenção do código.

## Configuração do Ambiente de Desenvolvimento

Para executar este projeto em sua máquina local, siga os passos abaixo:

1. Clone este repositório.
2. Abra o projeto em sua IDE de preferência (por exemplo, Visual Studio).
3. Configure a conexão com o banco de dados MySQL no arquivo `appsettings.json`.
4. Execute o comando `dotnet ef database update` para criar o banco de dados e aplicar as migrações.
5. Execute a aplicação.
