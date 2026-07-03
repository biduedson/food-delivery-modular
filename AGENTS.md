# AGENTS.md — Instruções para o Codex

## Visão Geral do Projeto

Este é um projeto **CustomerApi** construído com:
- **Clean Architecture** (Domain, Application, Infrastructure, WebApi, Query)
- **CQRS + Event Sourcing**
- **MediatR + FluentValidation**
- **Entity Framework Core + SQLite** (testes)
- **Docker + docker-compose**
- **xUnit** para testes unitários

Estrutura de pastas:
```
src/
├── CustomerApi.Application      → Commands, Handlers, Behaviors, Validators
├── CustomerApi.Core             → Interfaces, abstrações compartilhadas
├── CustomerApi.Domain           → Entidades, Value Objects, Domain Events
├── CustomerApi.Infrastructure   → DbContext, Repositórios, Serviços externos
├── CustomerApi.Query            → Queries, Read models
└── CustomerApi.WebApi           → Endpoints, Controllers, Program.cs
tests/
└── CustomerApi.UnitTests        → Testes unitários com xUnit + SQLite in-memory
```

---

## Regras de Commit

### ❌ NUNCA faça isso
- **Nunca executar `git push`** — apenas commits locais
- Nunca misturar mudanças de contextos diferentes num único commit
- Nunca commitar arquivos de build, bin/, obj/, .vs/
- Nunca commitar secrets, connection strings reais ou arquivos .env
- Nunca fazer um commit gigante com tudo de uma vez

### ✅ Sempre faça isso
- **Analisar todos os arquivos modificados antes de commitar**
- **Separar os arquivos por contexto** e fazer um commit por contexto
- **Verificar se faz sentido** agrupar os arquivos antes de juntar no mesmo commit
- Usar sempre o **formato convencional** de commit (ver abaixo)

---

## Formato de Commit

### Estrutura obrigatória:
```
<tipo>(<escopo>): <descrição em inglês, imperativo>
```

### Tipos permitidos:

| Tipo | Quando usar |
|---|---|
| `feat` | Nova funcionalidade |
| `fix` | Correção de bug |
| `refactor` | Refatoração sem mudar comportamento |
| `test` | Adição ou correção de testes |
| `chore` | Configuração, build, dependências |
| `docs` | Documentação |
| `style` | Formatação, espaços, ponto e vírgula |
| `perf` | Melhoria de performance |

### Escopos sugeridos para este projeto:

| Escopo | Representa |
|---|---|
| `domain` | CustomerApi.Domain |
| `application` | CustomerApi.Application |
| `infrastructure` | CustomerApi.Infrastructure |
| `query` | CustomerApi.Query |
| `webapi` | CustomerApi.WebApi |
| `tests` | CustomerApi.UnitTests |
| `config` | .editorconfig, docker-compose, nuget.config |
| `ci` | .github/workflows |

### Exemplos corretos:
```
feat(domain): add Customer entity with Email value object
fix(application): fix handler validation for empty name
refactor(infrastructure): extract DbContext config to separate class
test(tests): add tests for CreateCustomerCommandHandler
chore(config): update editorconfig naming rules
feat(webapi): add GET /customers/{id} endpoint
```

### Exemplos errados:
```
❌ update files
❌ fixes
❌ WIP
- **Inglês sempre**, máximo 50 caracteres, sem ponto final
- Verbo no imperativo: `add`, `fix`, `remove`, `update`, `extract`
- Nunca: `added`, `fixed`, `adding`

❌ added the new customer entity with all value objects
❌ feat: multiple things changed at once
```

---

## Como Analisar e Separar os Commits

Antes de commitar, siga este processo:

### 1. Verificar o que foi modificado
```bash
git status
git diff --stat
```

### 2. Agrupar por contexto
Analise cada arquivo e pergunte:
- Esse arquivo pertence a qual camada?
- Essa mudança tem relação com as outras mudanças?
- Se eu reverter esse commit, faz sentido reverter esses arquivos juntos?

### 3. Exemplos de agrupamento correto

**Cenário: você adicionou uma feature completa**
```
# commit 1 — a entidade de domínio
git add src/CustomerApi.Domain/
git commit -m "feat(domain): add Customer entity"

# commit 2 — o command e handler
git add src/CustomerApi.Application/
git commit -m "feat(application): add CreateCustomerCommand and handler"

# commit 3 — o endpoint
git add src/CustomerApi.WebApi/
git commit -m "feat(webapi): add POST /customers endpoint"

# commit 4 — os testes
git add tests/
git commit -m "test(tests): add unit tests for CreateCustomer"
```

**Cenário: você só corrigiu um bug no handler**
```
# um commit só — mudança pequena e focada
git add src/CustomerApi.Application/Handlers/CreateCustomerHandler.cs
git commit -m "fix(application): fix duplicate email validation in handler"
```

### 4. Nunca misture esses contextos no mesmo commit
```
❌ Domain + Infrastructure juntos
❌ Feature nova + correção de bug
❌ Código de produção + testes
✅ Testes podem ir separados sempre
✅ Cada camada preferencialmente em commit separado
```

---

## Regras de Código

### Nomenclatura (seguir o .editorconfig do projeto)
- Campos privados: `_camelCase` com underscore
- Classes, métodos, propriedades: `PascalCase`
- Parâmetros e variáveis locais: `camelCase`
- Constantes: `PascalCase`

### Padrões obrigatórios
- Sempre usar `var` quando o tipo for aparente
- Sempre usar `file-scoped namespace`: `namespace CustomerApi.Domain;`
- Sempre usar `readonly` em campos que não mudam após o construtor
- Nunca deixar `using` desnecessário
- Sempre que criar um Command, criar o Validator correspondente
- Sempre que criar um Handler, criar o teste correspondente

### Documentação XML e comentários
- Em projetos com caráter estudantil, documentar bem as APIs públicas ajuda a demonstrar intenção, organização e entendimento da arquitetura.
- Usar `/// <summary>` em pt-BR para APIs públicas e reutilizáveis, principalmente em BuildingBlocks, interfaces, exceptions, extensions, abstractions, middlewares, behaviors, value objects, entidades e métodos com regra de negócio ou validação.
- Evitar excesso de comentários em código privado, local ou óbvio. Prefira comentários somente quando eles explicarem intenção, contrato, regra ou motivo técnico.
- Quando o usuário pedir para documentar arquivos, revisar onde realmente cabe `summary` e adicionar de forma objetiva, sem transformar o código em documentação repetitiva.
- Comentários e mensagens de erro voltadas ao usuário devem ficar em pt-BR, salvo quando houver motivo técnico para manter inglês, como nomes de tipos, protocolos, padrões ou códigos oficiais.

### Arquivos que nunca devem ser commitados
```
bin/
obj/
.vs/
*.user
*.suo
appsettings.Development.json   ← pode conter secrets
.env
```

---

## Checklist antes de cada commit

```
[ ] Analisei todos os arquivos modificados com git status
[ ] Separei os arquivos por contexto/camada
[ ] O commit tem apenas uma responsabilidade
[ ] A mensagem está no formato: tipo(escopo): descrição
[ ] A descrição está em inglês e no imperativo
[ ] Não estou incluindo arquivos de bin/, obj/, .vs/
[ ] NÃO executei git push
```
