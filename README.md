# 📦 ApiCeps
Esse Projeto é um desafio backend de uma vaga para Estagiário como Dev Full Stack. Empresa AcessStage, grupo Negocie.

## 🎯 Objetivo do Projeto

Criar uma API RESTful utilizando ASP.NET Core que permite consultar CEPs através da API pública ViaCEP e armazenar os resultados em um banco de dados PostgreSQL. A API permite:

- Cadastrar um novo endereço a partir de um CEP.
- Consultar endereços já salvos no banco de dados.
- Evitar duplicações de CEPs armazenados.

---

## 🎆 Features

- 🔍 Consulta automática de CEP pela API ViaCEP.
- 🛡️ Verificação de CEP duplicado antes de salvar.
- 📦 Armazenamento dos dados de endereço com Entity Framework Core.
- 📡 Testes dos métodos Post e Get com Swagger.
- 🔁 Migrations configuradas com EF Core.

---

## 🏅 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- ViaCEP API
- Swagger / Swashbuckle

---

## 💻 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio ou VSCode](https://code.visualstudio.com/)

---

## 🚀 Rodando localmente

### 🔧 Clonando o projeto

```bash
git clone https://github.com/seu-usuario/ApiCeps.git
cd ApiCeps
```

### 🧱 Configurando o banco
Crie um banco de dados PostgreSQL com o nome que desejar e atualize a connectionString no appsettings.json:

```json
  "ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=seu_banco;Username=seu_usuario;Password=sua_senha"
}
```

### 🧱 Aplicando as Migrations

```bash
dotnet ef database update
```

### ▶️ Executando o projeto

```bash
dotnet watch run
```

Caso o Swagger não seja aberto diretamente, acesse pelo localhost: http://localhost:{SuaPorta}/swagger

### 📁 Estrutura do Projeto

```pgsql
ApiCeps/
├── bin/
├── context/
│   └── AddressContext.cs
├── Controller/
│   ├── AddressController.cs
│   └── Services/
│       └── AddressService.cs
├── Entities/
│   └── Address.cs
├── Migrations/
│   ├── _AddressTable.cs
│   ├── _AddressTable.Designer.cs
│   └── AddressContextModelSnapshot.cs
├── obj/
├── Properties/
├── ApiCeps.csproj
├── ApiCeps.http
├── ApiCeps.sln
├── appsettings.Development.json
├── appsettings.json
└── Program.cs
```

### 🎓 Conclusão
Esse projeto demonstrou como criar uma API robusta e organizada com ASP.NET Core, consumindo serviços externos (ViaCEP) e persistindo dados com PostgreSQL e Entity Framework. Ideal para aprendizado de:

Boas práticas em APIs REST

Endpoints

Integração com serviços externos

Uso de Swagger

Tratamento de erros e validações

NuGet com pacotes externos

## 🛠 Futuras melhorias

- 📦 Criar endpoints para atualizar e remover CEPs do banco de dados.
- 🔐 Implementar autenticação/autorização nos endpoints.
- 🐳 Docker para facilitar execução e deploy.
- 💻 TreinaWeb para documentar a API com o Swagger.