# Projeto Sistema de Tarefas

## Diagrama de Classes

```mermaid
classDiagram
    class Tarefa {
      +int id
      +string nome
      +string descricao
      +int status
      +int usuarioId
      +Usuario usuario
    }

    class Usuario {
      +int id
      +string nome
      +string email
    }

    Tarefa "1" --o "0..*" Usuario : tem
```

### Criando o projeto
```bash
dotnet new webapi -n SistemaDeTarefas -f net6.0
```

### Instalando o EntityFramework
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.1
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0

```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Gerando a primeira migration `Usuários`
```bash
dotnet ef migrations add InitialCreate
```

### Executando migrations pendentes
```bash
dotnet ef database update
```

### Gerando a segunda migration `Tarefas`
```bash
dotnet ef migrations add usuario-tarefa
```

### Executando migration pendentes
```bash
dotnet ef database update
```

### Exemplo do banco de dados local
![Alt text](imagens/azure.png)

### `GET` api/Tarefa
![Alt text](imagens/getTarefas.png)

## Como usar o projeto?

### Instale as dependências
```bash
dotnet restore
```
### Coloque o servidor no ar `localmente`
```bash
dotnet run
```

### Utilize as rotas pelo `Swagger`

[Swagger](https://localhost:7190/swagger/index.html)
![Alt text](imagens/image.png)



