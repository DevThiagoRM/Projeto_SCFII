# 👥 Sistema de Cadastro de Funcionários com Indicador de Inclusão

Projeto desenvolvido com o objetivo de registrar e monitorar dados de diversidade no ambiente de trabalho, em alinhamento com o **ODS 10 – Redução das Desigualdades** da ONU.

---

## 🎯 Objetivo

Criar um sistema de cadastro de funcionários (CRUD) que, além dos dados básicos, permita registrar informações sobre:

- Gênero
- Raça/Cor
- Deficiência (PCD)

Essas informações serão utilizadas para construir indicadores de inclusão no dashboard, ajudando a empresa a tomar decisões mais justas e representativas.

---

## 💻 Tecnologias Utilizadas

- **.NET 9 (ASP.NET Core MVC)**
- **Entity Framework Core 9**
- **SQL Server**
- **Razor Pages / Bootstrap**
- **BCrypt.Net-Next** (para hash de senhas)

---

## 📦 Dependências

As principais dependências do projeto estão listadas no `.csproj`, incluindo:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.6" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.6" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.6" />
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
```

---

## 🧩 Funcionalidades

- Cadastro de Funcionários
  - Nome completo
  - E-mail
  - Telefone
  - Cargo
  - Departamento
  - Data de admissão
  - Gênero (Masculino, Feminino, Não binário, Prefere não dizer)
  - Raça/Cor (Branca, Preta, Parda, Amarela, Indígena, Prefere não dizer)
  - Pessoa com deficiência (Sim/Não)
- Filtros na listagem
  - Por departamento, gênero, raça/cor e PCD
- Edição e exclusão de registros
- Dashboard com indicadores (se implementado)
  - Percentual de mulheres
  - Percentual de PCDs
  - Diversidade racial

---

## 🧠 Justificativa

O projeto busca promover práticas inclusivas através da coleta de dados sensíveis à diversidade. Ele contribui diretamente com os princípios da **ODS 10**, permitindo que empresas acompanhem a composição social de seus colaboradores e adotem políticas mais justas e igualitárias.

---

## 🚀 Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/nome-do-repo.git
```

2. Configure a connection string no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InclusaoDb;Trusted_Connection=True;"
}
```

3. Execute as migrations:

```bash
add-Migration CriandoDB
update-migration
```

4. Rode a aplicação:

```bash
dotnet run
```

A aplicação estará disponível em: `https://localhost:7025`

---

## Para testes será necessário ter uma instancia e o gerenciador SSMS do SQL SERVER

``` Em anexo ao projeto há um arquivo com o Script SQL para inserir dados de 500 usuários ficticios para simular a análises de usuários no Dashboard ``

## 📊 Exemplos de Indicadores no Dashboard

| Indicador       | Valor Exemplo |
|-----------------|----------------|
| Mulheres        | 40%            |
| PCDs            | 12%            |
| Raça Diversa    | 38%            |

---

## 🗂️ Organização

O projeto está estruturado em camadas:

- `DTOs` para transporte de dados
- `Entities` para mapeamento das tabelas
- `Services` para regras de negócio
- `Controllers` para manipulação das views e APIs

---

## 📃 Licença

Este projeto é acadêmico e livre para uso com fins educacionais.

---

## ✨ Contato

Desenvolvido por **Thiago Recetto Moraes**

📧 thiago.social@outlook.com  

📎 Projeto para disciplina Extensionista do curso de Análise e Desenvolvimento de Sistemas - UNINTER
