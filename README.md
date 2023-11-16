# Projeto Sistema de Tarefas

### Criando um projeto
```bash
dotnet new webapi -n SistemaDeTarefas -f net6.0
```

### Instalando o EntityFramework
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0
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

### Gerando inicial migration
```bash
dotnet ef migrations add InitialDB --context SistemaTarefasDBContext
```