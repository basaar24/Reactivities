# Graph Report - .  (2026-06-24)

## Corpus Check
- 203 files · ~138,762 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 564 nodes · 666 edges · 56 communities (37 shown, 19 thin omitted)
- Extraction: 89% EXTRACTED · 11% INFERRED · 0% AMBIGUOUS · INFERRED: 72 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Community Hubs (Navigation)
- [[_COMMUNITY_LTI Backend Standards|LTI Backend Standards]]
- [[_COMMUNITY_Reactivities CQRS Handlers|Reactivities CQRS Handlers]]
- [[_COMMUNITY_AI Agent Specifications|AI Agent Specifications]]
- [[_COMMUNITY_React Activity Dashboard|React Activity Dashboard]]
- [[_COMMUNITY_Claude Writing Skills|Claude Writing Skills]]
- [[_COMMUNITY_Frontend Dependencies|Frontend Dependencies]]
- [[_COMMUNITY_App State and Navigation|App State and Navigation]]
- [[_COMMUNITY_Frontend Dev Toolchain|Frontend Dev Toolchain]]
- [[_COMMUNITY_LTI Project Docs|LTI Project Docs]]
- [[_COMMUNITY_Code Audit Skills|Code Audit Skills]]
- [[_COMMUNITY_TypeScript App Config|TypeScript App Config]]
- [[_COMMUNITY_TypeScript Node Config|TypeScript Node Config]]
- [[_COMMUNITY_C Project Structure|C# Project Structure]]
- [[_COMMUNITY_LTI API Specification|LTI API Specification]]
- [[_COMMUNITY_EF Core Migration Designers|EF Core Migration Designers]]
- [[_COMMUNITY_OpenSpec Workflow|OpenSpec Workflow]]
- [[_COMMUNITY_EF Core Migrations|EF Core Migrations]]
- [[_COMMUNITY_ASP.NET Controller Base|ASP.NET Controller Base]]
- [[_COMMUNITY_Activity Mapper Planning|Activity Mapper Planning]]
- [[_COMMUNITY_ASP.NET Launch Config|ASP.NET Launch Config]]
- [[_COMMUNITY_Graph Rendering Scripts lidr|Graph Rendering Scripts lidr]]
- [[_COMMUNITY_Graph Rendering Scripts Reactivities|Graph Rendering Scripts Reactivities]]
- [[_COMMUNITY_Agent Symlink Mirrors|Agent Symlink Mirrors]]
- [[_COMMUNITY_EF Core DbContext and Seeding|EF Core DbContext and Seeding]]
- [[_COMMUNITY_Core Architecture Concepts|Core Architecture Concepts]]
- [[_COMMUNITY_Client Entry and React Query|Client Entry and React Query]]
- [[_COMMUNITY_TypeScript Config References|TypeScript Config References]]
- [[_COMMUNITY_Commit and PR Skill|Commit and PR Skill]]
- [[_COMMUNITY_Serena LSP Config|Serena LSP Config]]
- [[_COMMUNITY_ESLint Prettier Husky|ESLint Prettier Husky]]
- [[_COMMUNITY_Jira User Story Enrichment|Jira User Story Enrichment]]
- [[_COMMUNITY_Explain and Teach Skill|Explain and Teach Skill]]
- [[_COMMUNITY_AutoMapper Profiles|AutoMapper Profiles]]
- [[_COMMUNITY_Activity Category Images|Activity Category Images]]
- [[_COMMUNITY_Symlink Sync Skill|Symlink Sync Skill]]
- [[_COMMUNITY_Git Worktrees Skill|Git Worktrees Skill]]
- [[_COMMUNITY_Product Strategy Agent|Product Strategy Agent]]
- [[_COMMUNITY_Code Review Scripts lidr|Code Review Scripts lidr]]
- [[_COMMUNITY_Code Review Scripts Reactivities|Code Review Scripts Reactivities]]
- [[_COMMUNITY_Activity Domain Entity|Activity Domain Entity]]
- [[_COMMUNITY_Meta Prompt Engineering|Meta Prompt Engineering]]
- [[_COMMUNITY_App Branding and Logo|App Branding and Logo]]
- [[_COMMUNITY_Film and Music Categories|Film and Music Categories]]
- [[_COMMUNITY_TypeScript Activity Type|TypeScript Activity Type]]
- [[_COMMUNITY_Specboot Instructions Reactivities|Specboot Instructions Reactivities]]
- [[_COMMUNITY_Codex Config|Codex Config]]
- [[_COMMUNITY_Documentation AI Rules|Documentation AI Rules]]
- [[_COMMUNITY_Frontend Project Structure|Frontend Project Structure]]
- [[_COMMUNITY_SVG Icon Sprite|SVG Icon Sprite]]
- [[_COMMUNITY_Food Category Image|Food Category Image]]
- [[_COMMUNITY_Travel Category Image|Travel Category Image]]
- [[_COMMUNITY_Specboot Instructions lidr|Specboot Instructions lidr]]
- [[_COMMUNITY_Update Docs Skill|Update Docs Skill]]

## God Nodes (most connected - your core abstractions)
1. `compilerOptions` - 17 edges
2. `compilerOptions` - 16 edges
3. `Base Standards — Core Principles` - 14 edges
4. `Writing Skills (SKILL.md)` - 12 edges
5. `ai-specs/skills/ directory` - 10 edges
6. `Application` - 8 edges
7. `scripts` - 8 edges
8. `OpenSpec Workflow (enrich-us, ff, apply, verify, adversarial-review, archive, commit)` - 8 edges
9. `LTI Base Development Standards` - 8 edges
10. `ActivitiesController` - 7 edges

## Surprising Connections (you probably didn't know these)
- `Default User Avatar (silhouette person on gray background)` --conceptually_related_to--> `Candidate Entity (Data Model)`  [INFERRED]
  client/public/images/user.png → lidr-specboot/docs/data-model.md
- `lidr-specboot Agent — backend-developer (DDD/TypeScript/Prisma/Express)` --conceptually_related_to--> `Base Standards — Core Principles`  [INFERRED]
  lidr-specboot/ai-specs/agents/backend-developer.md → docs/base-standards.md
- `lidr-specboot README — OpenSpec Workflow (enrich-us/ff/apply/verify/archive)` --conceptually_related_to--> `OpenSpec Tasks Mandatory Steps — Implementation Checklist`  [INFERRED]
  lidr-specboot/README.md → docs/openspec-tasks-mandatory-steps.md
- `Reactivities CLAUDE.md` --references--> `Reactivities Activity Management App`  [INFERRED]
  CLAUDE.md → README.md
- `Reactivities README` --references--> `Feature-Based React Architecture`  [INFERRED]
  README.md → CLAUDE.md

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **OpenSpec Change Lifecycle (Propose → Apply → Archive)** — opsx_propose_opsx_propose_command, opsx_apply_opsx_apply_command, opsx_archive_opsx_archive_command [EXTRACTED 0.95]
- **OPSX Skill-Command Mirror Pairs** — openspec_apply_change_skill, openspec_archive_change_skill, openspec_propose_skill, openspec_explore_skill, openspec_sync_specs_skill [EXTRACTED 0.95]
- **Reactivities Full-Stack Architecture** — concept_reactivities_app, concept_clean_architecture, concept_feature_based_react [INFERRED 0.85]
- **OpenSpec skill-driven development workflow** — reactivities_readme_openspec_workflow, skill_enrich_us, skill_adversarial_review, skill_commit, skill_using_git_worktrees, skill_openspec_sync_specs [EXTRACTED 1.00]
- **Multi-copilot single source of truth pattern** — reactivities_readme_base_standards, reactivities_readme_agents_md, reactivities_readme_claude_md, reactivities_readme_gemini_md [EXTRACTED 1.00]
- **Agent plan-only pattern (backend + frontend plan output to .claude/doc/)** — agents_backend_developer, agents_frontend_developer, agents_backend_plan_output, agents_frontend_plan_output [EXTRACTED 1.00]

## Communities (56 total, 19 thin omitted)

### Community 0 - "LTI Backend Standards"
Cohesion: 0.05
Nodes (49): Backend DDD Layered Architecture Standards, Prisma Repository Pattern, Serverless AWS Lambda Deployment, SOLID and DRY Principles (Backend), Backend Testing Standards (Jest, 90% coverage), Base Standards — Core Principles, Base Standards — Language Standards (English Only), Base Standards — Mandatory OpenSpec Artifact Updates (+41 more)

### Community 1 - "Reactivities CQRS Handlers"
Cohesion: 0.09
Nodes (28): ActionResult, Activity, CancellationToken, Command, CreateActivity, Handler, Command, DeleteActivity (+20 more)

### Community 2 - "AI Agent Specifications"
Cohesion: 0.06
Nodes (44): Domain-Driven Design (DDD) layered architecture, backend-developer agent, Express (HTTP framework), Implementation plan output: .claude/doc/{feature_name}/backend.md, Prisma ORM (backend persistence), frontend-developer agent, Implementation plan output: .claude/doc/{feature_name}/frontend.md, React component-based architecture (+36 more)

### Community 3 - "React Activity Dashboard"
Cohesion: 0.09
Nodes (13): agent, ActivityCard(), Props, ActivityDashboard(), ActivityList(), ActivityDetailsHeader(), Props, ActivityDetailsInfo() (+5 more)

### Community 4 - "Claude Writing Skills"
Cohesion: 0.08
Nodes (33): Anthropic Skill Authoring Best Practices, Context Window Token Budget, Evaluation-Driven Skill Development, Progressive Disclosure Pattern, CLAUDE.md Skills Documentation Testing, Documentation Variants Testing (A/B/C/D), Authority Principle in Skill Design, Persuasion Principles for Skill Design (+25 more)

### Community 5 - "Frontend Dependencies"
Cohesion: 0.06
Nodes (31): dependencies, axios, date-fns, @emotion/react, @emotion/styled, @fontsource/roboto, mobx, mobx-react-lite (+23 more)

### Community 6 - "App State and Navigation"
Cohesion: 0.12
Nodes (10): MenuItemLink(), Counter, useStore(), NavBar(), router, queryClient, CounterStore, Store (+2 more)

### Community 7 - "Frontend Dev Toolchain"
Cohesion: 0.08
Nodes (23): husky.sh script, devDependencies, @babel/core, babel-plugin-react-compiler, eslint, eslint-config-prettier, @eslint/js, eslint-plugin-react-hooks (+15 more)

### Community 8 - "LTI Project Docs"
Cohesion: 0.11
Nodes (22): AI Specs Learning from Feedback, Application Entity (LTI), LTI Backend Standards (Node.js/TypeScript/Express), LTI Base Development Standards, Candidate Entity (LTI), Cypress E2E Testing (LTI Frontend), LTI Data Model Documentation, Domain-Driven Design Principles (LTI) (+14 more)

### Community 9 - "Code Audit Skills"
Cohesion: 0.11
Nodes (19): adversarial-review Skill, OpenSpec Change Verification, Red-Team Adversarial Review, Finding Severity Classification (Blocker/Major/Minor), Code Audit Methodology Reference, Performance Issue Analysis, Security Vulnerability Analysis, Code Audit Phases (0-6) (+11 more)

### Community 10 - "TypeScript App Config"
Cohesion: 0.11
Nodes (18): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, jsx, lib, module, moduleDetection, moduleResolution (+10 more)

### Community 11 - "TypeScript Node Config"
Cohesion: 0.11
Nodes (17): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, lib, module, moduleDetection, moduleResolution, noEmit (+9 more)

### Community 12 - "C# Project Structure"
Cohesion: 0.15
Nodes (16): API, Application, net10.0, net10.0, Microsoft.NET.Sdk, net10.0, Microsoft.NET.Sdk, net10.0 (+8 more)

### Community 13 - "LTI API Specification"
Cohesion: 0.21
Nodes (15): Application API Schema, Candidate API Schema, File Upload Endpoint (/upload POST), InterviewFlow API Schema, LTI API Specification (OpenAPI 3.0), PaginationMetadata Schema, Position API Schema, Application Entity (Data Model) (+7 more)

### Community 14 - "EF Core Migration Designers"
Cohesion: 0.14
Nodes (8): InitialCreate, Persistence.Migrations, Persistence.Migrations, UpdateInitialCreate, AppDbContextModelSnapshot, Persistence.Migrations, ModelBuilder, ModelSnapshot

### Community 15 - "OpenSpec Workflow"
Cohesion: 0.23
Nodes (13): Delta Spec Sync Pattern, OpenSpec Workflow System, Spec-Driven Change Lifecycle, openspec-apply-change Skill, openspec-archive-change Skill, openspec-explore Skill, openspec-propose Skill, openspec-sync-specs Skill (+5 more)

### Community 16 - "EF Core Migrations"
Cohesion: 0.21
Nodes (6): Migration, MigrationBuilder, InitialCreate, Persistence.Migrations, Persistence.Migrations, UpdateInitialCreate

### Community 17 - "ASP.NET Controller Base"
Cohesion: 0.18
Nodes (7): WeatherForecast, ControllerBase, BaseApiController, WeatherForecastController, IEnumerable, IMediator, string

### Community 18 - "Activity Mapper Planning"
Cohesion: 0.22
Nodes (10): Plan: ActivityRequestMapper, ActivityRequest DTO Mapping Plan, ActivityRequestMapper implements IMapper, ActivityRequest Schema (API), Activity Resource (API Schema), Reactivities API Spec (OpenAPI 3.0), Reactivities Backend Standards, Clean Architecture (.NET 10) (+2 more)

### Community 19 - "ASP.NET Launch Config"
Cohesion: 0.20
Nodes (9): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, profiles, https (+1 more)

### Community 20 - "Graph Rendering Scripts lidr"
Cohesion: 0.31
Nodes (7): combineGraphs(), { execSync }, extractDotBlocks(), fs, main(), path, renderToSvg()

### Community 21 - "Graph Rendering Scripts Reactivities"
Cohesion: 0.31
Nodes (7): combineGraphs(), { execSync }, extractDotBlocks(), fs, main(), path, renderToSvg()

### Community 22 - "Agent Symlink Mirrors"
Cohesion: 0.29
Nodes (7): Backend Developer Agent (Claude), Backend Developer Agent (Cursor), Frontend Developer Agent (Claude), Frontend Developer Agent (Cursor), Product Strategy Analyst Agent (Claude), Product Strategy Analyst Agent (Cursor), AI Agent Spec Files

### Community 23 - "EF Core DbContext and Seeding"
Cohesion: 0.33
Nodes (3): DbContext, AppDbContext, DbInitializer

### Community 24 - "Core Architecture Concepts"
Cohesion: 0.80
Nodes (5): Clean Architecture + CQRS Pattern, Feature-Based React Architecture, Reactivities Activity Management App, Reactivities CLAUDE.md, Reactivities README

### Community 25 - "Client Entry and React Query"
Cohesion: 0.67
Nodes (3): Client Entry HTML (index.html), TanStack React Query v5 State Management, Reactivities React Client README

### Community 27 - "Commit and PR Skill"
Cohesion: 0.67
Nodes (3): commit Skill, Feature-Scoped Commit Workflow, Pull Request Creation (GitHub CLI)

### Community 28 - "Serena LSP Config"
Cohesion: 0.67
Nodes (3): Serena Language Server Configuration, Serena Project Config, Serena Project Local Config

### Community 29 - "ESLint Prettier Husky"
Cohesion: 0.67
Nodes (3): Development Guide — Frontend Setup (Vite / React), Frontend Standards — Code Quality (ESLint/Prettier/Husky), Implementation Plan — ESLint + Prettier + Husky Setup

### Community 30 - "Jira User Story Enrichment"
Cohesion: 0.67
Nodes (3): enrich-us Skill, Jira Integration Mode, User Story Enrichment

### Community 31 - "Explain and Teach Skill"
Cohesion: 0.67
Nodes (3): explain Skill, Interactive Quiz for Learning Validation, Skill Gap Identification

### Community 33 - "Activity Category Images"
Cohesion: 0.67
Nodes (3): Culture Category Image (Louvre Museum at night), Drinks Category Image (group toasting with beer glasses), Placeholder Image (generic image icon on gray background)

### Community 34 - "Symlink Sync Skill"
Cohesion: 1.00
Nodes (3): Canonical Skills Source (ai-specs/skills), Symlink Mirrors (.claude/skills, .cursor/skills), sync-agent-symlinks Skill

### Community 35 - "Git Worktrees Skill"
Cohesion: 0.67
Nodes (3): Native Worktree vs Git Fallback, using-git-worktrees Skill, Worktree Isolation Workflow

## Knowledge Gaps
- **234 isolated node(s):** `husky.sh script`, `code_review.sh script`, `fs`, `path`, `{ execSync }` (+229 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **19 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `devDependencies` connect `Frontend Dev Toolchain` to `Frontend Dependencies`?**
  _High betweenness centrality (0.006) - this node is a cross-community bridge._
- **Are the 2 inferred relationships involving `Base Standards — Core Principles` (e.g. with `lidr-specboot Agent — backend-developer (DDD/TypeScript/Prisma/Express)` and `lidr-specboot README — Specboot Augmented Spec-Driven Development`) actually correct?**
  _`Base Standards — Core Principles` has 2 INFERRED edges - model-reasoned connections that need verification._
- **What connects `husky.sh script`, `code_review.sh script`, `fs` to the rest of the system?**
  _240 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `LTI Backend Standards` be split into smaller, more focused modules?**
  _Cohesion score 0.05102040816326531 - nodes in this community are weakly interconnected._
- **Should `Reactivities CQRS Handlers` be split into smaller, more focused modules?**
  _Cohesion score 0.08686868686868687 - nodes in this community are weakly interconnected._
- **Should `AI Agent Specifications` be split into smaller, more focused modules?**
  _Cohesion score 0.05813953488372093 - nodes in this community are weakly interconnected._
- **Should `React Activity Dashboard` be split into smaller, more focused modules?**
  _Cohesion score 0.0907563025210084 - nodes in this community are weakly interconnected._