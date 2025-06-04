# 🛠️ .NET CLI - Comandos Essenciais

Este documento reúne os comandos básicos e mais utilizados do .NET CLI para criação, execução, build e gerenciamento de projetos e soluções .NET.

---

## 📦 Criação de projetos

### Criar um projeto console
```bash
dotnet new console -o hello-world
````

### Criar um projeto webapi

```bash
dotnet new webapi -o minha-api
```

### Criar uma biblioteca de classes

```bash
dotnet new classlib -o minha-lib
```

---

## 🧪 Execução e build

### Executar o projeto

```bash
dotnet run
```

### Compilar o projeto

```bash
dotnet build
```

### Restaurar pacotes NuGet

```bash
dotnet restore
```

---

## 📁 Soluções (.sln)

### Criar uma solução

```bash
dotnet new sln -n MinhaSolucao
```

### Adicionar projeto à solução

```bash
dotnet sln add caminho/para/projeto.csproj
```

---

## 📄 Informações úteis

### Ver versão do SDK instalado

```bash
dotnet --version
```

### Listar templates disponíveis

```bash
dotnet new --list
```

### Atualizar ferramentas do .NET

```bash
dotnet workload update
```

---

## 📚 Referências oficiais

* [Documentação .NET CLI](https://learn.microsoft.com/dotnet/core/tools/)

```