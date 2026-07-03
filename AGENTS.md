# AGENTS.md — Instruções para o Codex

## Visão Geral do Projeto

Este é um projeto **food-delivery-modular** com foco em **BuildingBlocks** reutilizáveis, hoje começando por:
- **BuildingBlocks.Abstractions** como biblioteca compartilhada
- **.NET 9**
- **Clean Architecture** aplicada de forma modular
- **CQRS + Event Sourcing**
- **MediatR**
- **Entity Framework Core**
- **MongoDB**
- **xUnit** para testes quando aplicável

Estrutura de pastas atual:
```
src/
└── BuildingBlocks/
    └── BuildingBlocks.Abstractions   → Contratos, abstrações e utilitários compartilhados
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
| `abstractions` | BuildingBlocks.Abstractions |
| `caching` | Cache e contratos relacionados |
| `cqrs` | Commands, Queries, Events e handlers |
| `domain` | Entidades, value objects e regras de domínio |
| `messaging` | Mensageria, contexto e persistência de mensagens |
| `persistence` | EfCore, EventStore e Mongo |
| `scheduling` | Agendamento e jobs |
| `serialization` | Serialização e desserialização |
| `types` | Tipos compartilhados |
| `web` | Minimal API, módulos e storage web |
| `config` | `Directory.Build.props`, `Directory.Packages.props`, `Directory.Build.targets` |
| `tests` | Testes automatizados |
| `ci` | GitHub Actions e automação |

### Exemplos corretos:
```
feat(abstractions): add cache manager contract
fix(caching): improve cache key handling
refactor(persistence): extract mongo abstractions
test(tests): add coverage for cache manager
chore(config): update central package versions
feat(web): add minimal api module contracts
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

**Cenário: você adicionou uma abstração compartilhada**
```
# commit 1 — contrato ou tipo de abstração
git add src/BuildingBlocks/BuildingBlocks.Abstractions/
git commit -m "feat(abstractions): add shared cache contract"

# commit 2 — ajuste de configuração
git add src/Directory.Packages.props src/Directory.Build.props src/Directory.Build.targets
git commit -m "chore(config): centralize build settings"
```

**Cenário: você só corrigiu um bug em uma abstração**
```
# um commit só — mudança pequena e focada
git add src/BuildingBlocks/BuildingBlocks.Abstractions/Caching/ICacheManager.cs
git commit -m "fix(caching): improve cache manager contract"
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
- Sempre usar `file-scoped namespace`
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
