# API de Cadastro e Autenticação de Usuários

## Visão Geral

Este projeto é uma API de Cadastro e Autenticação de Usuários construída com C# e .NET. Ela utiliza várias ferramentas e bibliotecas, incluindo Entity Framework, Tokens JWT, Identity, Autorização, MVC e User Secrets para um sistema de gerenciamento de usuários abrangente e seguro.

## Funcionalidades

- **Cadastro de Usuários**: Permite que os usuários se registrem com seus dados.
- **Autenticação de Usuários**: Utiliza tokens JWT para autenticação segura.
- **Autorização de Usuários**: Controla o acesso a diferentes partes da API com base em papéis de usuário.
- **Arquitetura MVC**: Utiliza a arquitetura Model-View-Controller para um código organizado e escalável.
- **Entity Framework**: Gerencia operações de banco de dados com migrações.
- **User Secrets**: Armazena informações sensíveis de forma segura durante o desenvolvimento.

## Tecnologias Utilizadas

- **.NET**: O framework para construir a API.
- **C#**: A linguagem de programação utilizada.
- **Entity Framework**: Para gerenciamento de banco de dados e migrações.
- **MySQL**: O sistema de banco de dados utilizado.
- **Tokens JWT**: Para autenticação segura.
- **Identity**: Para gerenciamento de usuários.
- **Autorização**: Para controle de acesso baseado em papéis.
- **MVC**: Para estruturação da aplicação.
- **User Secrets**: Para armazenar dados sensíveis de forma segura.

## Começando

### Pré-requisitos

- .NET SDK
- MySQL Server
- Postman ou qualquer outra ferramenta de teste de API

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/ThiegoGagliardi/AluraControleUsuarioAPI.git
    cd seu-repo
    ```

2. Instale os pacotes necessários:
    ```sh
    dotnet restore
    ```

3. Aplique as migrações ao banco de dados:
    ```sh
    dotnet ef database update
    ```

4. Adicione User Secrets para armazenar informações sensíveis:
    ```sh
    dotnet user-secrets init
    dotnet user-secrets set "SymmetricSecurityKey" "SuaChaveSecreta"
    dotnet user-secrets set "ConnectionStrings:UserConnection" "SuaChaveSecreta"
    ```

### Executando a Aplicação

1. Compile e execute a aplicação:
    ```sh
    dotnet run
    ```

2. A API estará disponível em `https://localhost:7193`.

## Uso

### Endpoints

#### Registrar Usuário

- **URL**: `https://localhost:7193/User/cadastro`
- **Método**: `POST`
- **Corpo**:
    ```json
    {
        "userName": "string",
        "dateBirth": "string",
        "password": "string",
        "confirmPassword": "string"
    }    
    ```

#### Login do Usuário

- **URL**: `https://localhost:7193/User/login`
- **Método**: `POST`
- **Corpo**:
    ```json
    {
        "username": "string",
        "password": "string"
    }
    ```

#### Acessar Recurso Protegido

- **URL**: `https://localhost:7193/Acess`
- **Método**: `GET`
- **Cabeçalhos**:
    ```sh
    Authorization: Bearer {token}
    ```

## Agradecimentos

- Agradecimentos à comunidade .NET por fornecer excelente documentação e recursos.
