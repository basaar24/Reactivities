# Graph Report - .  (2026-07-06)

## Corpus Check
- 77 files · ~32,432 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 525 nodes · 657 edges · 62 communities (28 shown, 34 thin omitted)
- Extraction: 90% EXTRACTED · 10% INFERRED · 0% AMBIGUOUS · INFERRED: 68 edges (avg confidence: 0.86)
- Token cost: 176,417 input · 0 output

## Community Hubs (Navigation)
- [[_COMMUNITY_API Controllers & Middleware|API Controllers & Middleware]]
- [[_COMMUNITY_Docs BackendFrontendData-Model Standards|Docs: Backend/Frontend/Data-Model Standards]]
- [[_COMMUNITY_Client package.json Dependencies|Client package.json Dependencies]]
- [[_COMMUNITY_Activity Mapping & Validation|Activity Mapping & Validation]]
- [[_COMMUNITY_AutoMapper to Custom Mapper Migration Spec|AutoMapper to Custom Mapper Migration Spec]]
- [[_COMMUNITY_Activity CQRS Commands & Queries|Activity CQRS Commands & Queries]]
- [[_COMMUNITY_Claude Rules, Memories & OpenSpec Skills|Claude Rules, Memories & OpenSpec Skills]]
- [[_COMMUNITY_Client devDependencies & Husky|Client devDependencies & Husky]]
- [[_COMMUNITY_LTI Project Docs (external context)|LTI Project Docs (external context)]]
- [[_COMMUNITY_Client tsconfig.app.json|Client tsconfig.app.json]]
- [[_COMMUNITY_Writing-Skills (Anthropic Skill Guidance)|Writing-Skills (Anthropic Skill Guidance)]]
- [[_COMMUNITY_Client tsconfig.node.json|Client tsconfig.node.json]]
- [[_COMMUNITY_Docs Meta READMEAGENTSCLAUDE.md Links|Docs Meta: README/AGENTS/CLAUDE.md Links]]
- [[_COMMUNITY_Backend .csproj & NuGet Dependencies|Backend .csproj & NuGet Dependencies]]
- [[_COMMUNITY_Frontend Errors & Routing|Frontend Errors & Routing]]
- [[_COMMUNITY_AutoMapper Migration CLAUDE.md & Design|AutoMapper Migration: CLAUDE.md & Design]]
- [[_COMMUNITY_API launchSettings.json|API launchSettings.json]]
- [[_COMMUNITY_API Program.cs Startup|API Program.cs Startup]]
- [[_COMMUNITY_Code-Auditing & Adversarial-Review Skills|Code-Auditing & Adversarial-Review Skills]]
- [[_COMMUNITY_LTI API Spec Schemas|LTI API Spec Schemas]]
- [[_COMMUNITY_AI Agent Spec Definitions|AI Agent Spec Definitions]]
- [[_COMMUNITY_MediatR ValidationBehavior Pipeline|MediatR ValidationBehavior Pipeline]]
- [[_COMMUNITY_AutoMapper Migration Tasks Checklist|AutoMapper Migration Tasks Checklist]]
- [[_COMMUNITY_Backend Agent Spec Variants|Backend Agent Spec Variants]]
- [[_COMMUNITY_Frontend Agent Spec Variants|Frontend Agent Spec Variants]]
- [[_COMMUNITY_ActivityDetailsHeader Component|ActivityDetailsHeader Component]]
- [[_COMMUNITY_Client IndexReact QueryREADME|Client Index/React Query/README]]
- [[_COMMUNITY_Client Root tsconfig|Client Root tsconfig]]
- [[_COMMUNITY_Serena Project Config|Serena Project Config]]
- [[_COMMUNITY_AppDbContext  Persistence|AppDbContext / Persistence]]
- [[_COMMUNITY_PLAN-ActivityRequestMapper Doc|PLAN-ActivityRequestMapper Doc]]
- [[_COMMUNITY_NavBar & useStore Hook|NavBar & useStore Hook]]
- [[_COMMUNITY_Product Strategy Analyst Agent|Product Strategy Analyst Agent]]
- [[_COMMUNITY_Code Review Script|Code Review Script]]
- [[_COMMUNITY_CLAUDE.md Feature-Based React & React Query|CLAUDE.md: Feature-Based React & React Query]]
- [[_COMMUNITY_OpenSpec Change Lifecycle & Sync-Specs|OpenSpec Change Lifecycle & Sync-Specs]]
- [[_COMMUNITY_Reactivities App Concept & README|Reactivities App Concept & README]]
- [[_COMMUNITY_Symlink Mirror & Sync-Agent-Symlinks Skill|Symlink Mirror & Sync-Agent-Symlinks Skill]]
- [[_COMMUNITY_AppException|AppException]]
- [[_COMMUNITY_Domain Activity Entity|Domain Activity Entity]]
- [[_COMMUNITY_CreateActivityRequest (Requests DTO)|CreateActivityRequest (Requests DTO)]]
- [[_COMMUNITY_Git Worktrees Skill|Git Worktrees Skill]]
- [[_COMMUNITY_Specboot Instructions|Specboot Instructions]]
- [[_COMMUNITY_BaseApiController|BaseApiController]]
- [[_COMMUNITY_CLAUDE.md Reactivities Architecture|CLAUDE.md Reactivities Architecture]]
- [[_COMMUNITY_MenuItemLink Component|MenuItemLink Component]]
- [[_COMMUNITY_CreateActivityDto|CreateActivityDto]]
- [[_COMMUNITY_CreateActivityRequest|CreateActivityRequest]]
- [[_COMMUNITY_ActivityDashboard Component|ActivityDashboard Component]]
- [[_COMMUNITY_ActivityDetailsPage Component|ActivityDetailsPage Component]]
- [[_COMMUNITY_Memory Maintenance Doc|Memory Maintenance Doc]]
- [[_COMMUNITY_ESLintPrettierHusky Setup Plan|ESLint/Prettier/Husky Setup Plan]]
- [[_COMMUNITY_Profile (isolated)|Profile (isolated)]]
- [[_COMMUNITY_Result (isolated)|Result (isolated)]]
- [[_COMMUNITY_Commit Skill|Commit Skill]]
- [[_COMMUNITY_Enrich-US Skill|Enrich-US Skill]]
- [[_COMMUNITY_Explain Skill|Explain Skill]]
- [[_COMMUNITY_Meta-Prompt Skill|Meta-Prompt Skill]]
- [[_COMMUNITY_Update-Docs Skill|Update-Docs Skill]]
- [[_COMMUNITY_CounterStore|CounterStore]]
- [[_COMMUNITY_UiStore|UiStore]]
- [[_COMMUNITY_UpdateActivityDto|UpdateActivityDto]]

## God Nodes (most connected - your core abstractions)
1. `compilerOptions` - 17 edges
2. `compilerOptions` - 16 edges
3. `Result` - 16 edges
4. `Backend Standards` - 14 edges
5. `Base Standards (AI Governance Root)` - 12 edges
6. `Data Model Documentation` - 11 edges
7. `Reactivities API (OpenAPI Spec)` - 10 edges
8. `Frontend Standards` - 10 edges
9. `OpenSpec Tasks Mandatory Steps` - 10 edges
10. `OpenSpec config.yaml` - 9 edges

## Surprising Connections (you probably didn't know these)
- `LTI API OpenAPI 3.0 Specification` --semantically_similar_to--> `Reactivities API Routes /api/activities`  [INFERRED] [semantically similar]
  Reactivities/docs/api-spec.yml → CLAUDE.md
- `AutoMapper MappingProfiles` --conceptually_related_to--> `IActivityMapper Interface Design Decision`  [INFERRED]
  CLAUDE.md → openspec/changes/migrate-automapper-to-custommapper/design.md
- `Mandatory Graphify Pre-Task Protocol` --conceptually_related_to--> `Specboot: Augmented Spec-Driven Development Framework`  [INFERRED]
  CLAUDE.md → Reactivities/README.md
- `.NET / C# Rules` --conceptually_related_to--> `Backend Architecture Memory`  [INFERRED]
  .claude/rules/dotnet-csharp.md → .serena/memories/backend/core.md
- `React + TypeScript Rules` --conceptually_related_to--> `Frontend Architecture Memory`  [INFERRED]
  .claude/rules/react-typescript.md → .serena/memories/frontend/core.md

## Import Cycles
- 3-file cycle: `client/src/app/router/Routes.tsx -> client/src/features/errors/TestErrors.tsx -> client/src/lib/api/agent.ts -> client/src/app/router/Routes.tsx`

## Hyperedges (group relationships)
- **OpenSpec Workflow Duplicated Across Slash Commands and Skills** — opsx_apply, opsx_archive, opsx_explore, opsx_propose, opsx_sync, openspec_apply_change_skill_skill, openspec_archive_change_skill_skill, openspec_explore_skill_skill, openspec_propose_skill_skill, openspec_sync_specs_skill_skill [INFERRED 0.85]
- **Serena Memory Graph Rooted at core.md** — memories_core_project_core, backend_core_backend_architecture, frontend_core_frontend_architecture, memories_tech_stack_tech_stack, memories_conventions_conventions, memories_task_completion_task_completion, memories_suggested_commands_suggested_commands [EXTRACTED 1.00]
- **Claude Code Project Rules Set** — rules_dotnet_csharp_rules, rules_react_typescript_rules, rules_security_rules, rules_workflow_rules [INFERRED 0.75]
- **OpenSpec Change: Migrate AutoMapper to Custom Mapper (all artifacts)** — migrate_automapper_to_custommapper_openspec_yaml, migrate_automapper_to_custommapper_proposal_document, migrate_automapper_to_custommapper_design_document, migrate_automapper_to_custommapper_tasks_document, activity_mapping_spec_archived_document [EXTRACTED 1.00]
- **Activity Entity Shape Shared Across API Spec, Data Model, Backend, and Frontend Docs** — docs_api_spec_activity_schema, docs_data_model_activity_entity, docs_backend_standards_activity_entity, docs_frontend_standards_activity_type, docs_data_model_frontend_activity_type [INFERRED 0.90]
- **OpenSpec Mandatory Task Workflow Steps** — docs_openspec_tasks_mandatory_steps_step0_branch, docs_openspec_tasks_mandatory_steps_build_verification, docs_openspec_tasks_mandatory_steps_curl_testing, docs_openspec_tasks_mandatory_steps_e2e_playwright, docs_openspec_tasks_mandatory_steps_doc_update_step [EXTRACTED 1.00]

## Communities (62 total, 34 thin omitted)

### Community 0 - "API Controllers & Middleware"
Cohesion: 0.07
Nodes (24): ActionResult, WeatherForecast, AppDbContext, ControllerBase, ActivitiesController, BaseApiController, BuggyController, WeatherForecastController (+16 more)

### Community 1 - "Docs: Backend/Frontend/Data-Model Standards"
Cohesion: 0.07
Nodes (43): Activity Schema, CreateActivityRequest Schema, DELETE /activities/{id} endpoint, GET /activities endpoint, POST /activities endpoint, Reactivities API (OpenAPI Spec), Activity Domain Entity (Backend Standards), Core Principles (baby steps, TDD, type safety) (+35 more)

### Community 2 - "Client package.json Dependencies"
Cohesion: 0.06
Nodes (32): dependencies, axios, date-fns, @emotion/react, @emotion/styled, @fontsource/roboto, mobx, mobx-react-lite (+24 more)

### Community 3 - "Activity Mapping & Validation"
Cohesion: 0.10
Nodes (15): AbstractValidator, Activity, Command, ActivityMapper, IActivityMapper, BaseActivityDto, CreateActivityDto, UpdateActivityDto (+7 more)

### Community 4 - "AutoMapper to Custom Mapper Migration Spec"
Cohesion: 0.09
Nodes (31): activity-mapping Spec (archived change), Requirement: Mapper Registered in DI Container, Requirement: Map CreateActivityRequest to Activity, Requirement: Update Activity from another Activity, activity-mapping Spec (current), Requirement: Mapper Registered in DI Container (current spec), Requirement: Map CreateActivityRequest to Activity (current spec), Requirement: Update Activity from another Activity (current spec) (+23 more)

### Community 5 - "Activity CQRS Commands & Queries"
Cohesion: 0.15
Nodes (18): CancellationToken, Command, CreateActivity, Handler, Command, DeleteActivity, Handler, Command (+10 more)

### Community 6 - "Claude Rules, Memories & OpenSpec Skills"
Cohesion: 0.13
Nodes (24): Backend Architecture Memory, IActivityMapper (custom mapping abstraction), Frontend Architecture Memory, Coding Conventions Memory, Reactivities Project Core Memory, Suggested Commands Memory, Task Completion Checklist Memory, Tech Stack Memory (+16 more)

### Community 7 - "Client devDependencies & Husky"
Cohesion: 0.08
Nodes (23): husky.sh script, devDependencies, @babel/core, babel-plugin-react-compiler, eslint, eslint-config-prettier, @eslint/js, eslint-plugin-react-hooks (+15 more)

### Community 8 - "LTI Project Docs (external context)"
Cohesion: 0.11
Nodes (22): AI Specs Learning from Feedback, Application Entity (LTI), LTI Backend Standards (Node.js/TypeScript/Express), LTI Base Development Standards, Candidate Entity (LTI), Cypress E2E Testing (LTI Frontend), LTI Data Model Documentation, Domain-Driven Design Principles (LTI) (+14 more)

### Community 9 - "Client tsconfig.app.json"
Cohesion: 0.11
Nodes (18): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, jsx, lib, module, moduleDetection, moduleResolution (+10 more)

### Community 10 - "Writing-Skills (Anthropic Skill Guidance)"
Cohesion: 0.13
Nodes (19): Anthropic Skill Authoring Best Practices, Evaluation-Driven Development for Skills, Progressive Disclosure Pattern (Skills), Skill Description Field Best Practices, CLAUDE_MD Testing Documentation Variants, Pressure Test Scenarios for Skills, Authority Persuasion Principle, Cialdini Influence Principles (2021) (+11 more)

### Community 11 - "Client tsconfig.node.json"
Cohesion: 0.11
Nodes (17): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, lib, module, moduleDetection, moduleResolution, noEmit (+9 more)

### Community 12 - "Docs Meta: README/AGENTS/CLAUDE.md Links"
Cohesion: 0.14
Nodes (17): Mandatory Graphify Pre-Task Protocol, Parallel Tasks File Format (Task Block Structure), AGENTS.md Reference to base-standards.md, CLAUDE.md Reference to base-standards.md (Reactivities sub), GEMINI.md Reference to base-standards.md, ai-specs/skills Reusable Workflow Skills, base-standards.md Single Source of Truth Principle, docs/ Technical Context Folder (+9 more)

### Community 13 - "Backend .csproj & NuGet Dependencies"
Cohesion: 0.16
Nodes (10): net10.0, net10.0, Microsoft.NET.Sdk, net10.0, Microsoft.NET.Sdk, FluentValidation.DependencyInjectionExtensions (12.1.1), MediatR (14.1.0), Microsoft.EntityFrameworkCore.Design (10.0.9) (+2 more)

### Community 14 - "Frontend Errors & Routing"
Cohesion: 0.22
Nodes (4): agent, ServerError(), router, queryClient

### Community 15 - "AutoMapper Migration: CLAUDE.md & Design"
Cohesion: 0.19
Nodes (13): AutoMapper MappingProfiles, Clean Architecture + CQRS Pattern, Controller → MediatR → Handler → DbContext Pattern, ActivityMapper Placement in Application/Core/, IActivityMapper Interface Design Decision, Property Drift Risk from Custom Mapper, Two Mapper Methods: ToActivity and UpdateActivity, OpenSpec Change: migrate-automapper-to-custommapper (+5 more)

### Community 16 - "API launchSettings.json"
Cohesion: 0.20
Nodes (9): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, profiles, https (+1 more)

### Community 17 - "API Program.cs Startup"
Cohesion: 0.39
Nodes (3): Program, WebApplication, WebApplicationBuilder

### Community 18 - "Code-Auditing & Adversarial-Review Skills"
Cohesion: 0.22
Nodes (9): adversarial-review skill, Red-team / adversarial review methodology, code-auditing skill, deadcode (Python dead code detection tool), Knip (JS/TS dead code detection tool), 6-phase code audit methodology, audit-methodology.md (code audit reference), dead-code-methodology.md (dead code reference) (+1 more)

### Community 19 - "LTI API Spec Schemas"
Cohesion: 0.29
Nodes (8): Application Schema (Candidate Job Application), Candidate Domain Schema, Candidates REST Endpoint (/candidates), InterviewFlow and InterviewStep Schemas, LTI API OpenAPI 3.0 Specification, Position Domain Schema, Positions REST Endpoint (/positions), Reactivities API Routes /api/activities

### Community 20 - "AI Agent Spec Definitions"
Cohesion: 0.29
Nodes (7): Backend Developer Agent (Claude), Backend Developer Agent (Cursor), Frontend Developer Agent (Claude), Frontend Developer Agent (Cursor), Product Strategy Analyst Agent (Claude), Product Strategy Analyst Agent (Cursor), AI Agent Spec Files

### Community 21 - "MediatR ValidationBehavior Pipeline"
Cohesion: 0.38
Nodes (5): ValidationBehavior, IPipelineBehavior, RequestHandlerDelegate, TRequest, TResponse

### Community 22 - "AutoMapper Migration Tasks Checklist"
Cohesion: 0.33
Nodes (5): 1. Add Custom Mapper Interface and Implementation, 2. Update DI Registration, 3. Update MediatR Handlers, 4. Remove AutoMapper, 5. Verify

### Community 23 - "Backend Agent Spec Variants"
Cohesion: 0.40
Nodes (5): Domain-Driven Design (DDD) layered architecture, backend-developer agent, Express (HTTP framework), Implementation plan output: .claude/doc/{feature_name}/backend.md, Prisma ORM (backend persistence)

### Community 24 - "Frontend Agent Spec Variants"
Cohesion: 0.40
Nodes (5): frontend-developer agent, Implementation plan output: .claude/doc/{feature_name}/frontend.md, React component-based architecture, React Bootstrap (UI library), React Router (client-side routing)

### Community 26 - "Client Index/React Query/README"
Cohesion: 0.67
Nodes (3): Client Entry HTML (index.html), TanStack React Query v5 State Management, Reactivities React Client README

### Community 28 - "Serena Project Config"
Cohesion: 0.67
Nodes (3): Serena Language Server Configuration, Serena Project Config, Serena Project Local Config

### Community 30 - "PLAN-ActivityRequestMapper Doc"
Cohesion: 0.67
Nodes (3): Plan: ActivityRequestMapper, ActivityRequest DTO Mapping Plan, ActivityRequestMapper implements IMapper

## Knowledge Gaps
- **204 isolated node(s):** `CreateActivityRequest`, `1. Add Custom Mapper Interface and Implementation`, `2. Update DI Registration`, `3. Update MediatR Handlers`, `4. Remove AutoMapper` (+199 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **34 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Result` connect `Activity CQRS Commands & Queries` to `API Controllers & Middleware`?**
  _High betweenness centrality (0.008) - this node is a cross-community bridge._
- **Why does `devDependencies` connect `Client devDependencies & Husky` to `Client package.json Dependencies`?**
  _High betweenness centrality (0.007) - this node is a cross-community bridge._
- **Why does `Migrate AutoMapper to Custom Mapper — Proposal` connect `AutoMapper to Custom Mapper Migration Spec` to `Docs: Backend/Frontend/Data-Model Standards`?**
  _High betweenness centrality (0.006) - this node is a cross-community bridge._
- **What connects `CreateActivityRequest`, `1. Add Custom Mapper Interface and Implementation`, `2. Update DI Registration` to the rest of the system?**
  _224 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `API Controllers & Middleware` be split into smaller, more focused modules?**
  _Cohesion score 0.07149758454106281 - nodes in this community are weakly interconnected._
- **Should `Docs: Backend/Frontend/Data-Model Standards` be split into smaller, more focused modules?**
  _Cohesion score 0.07419712070874862 - nodes in this community are weakly interconnected._
- **Should `Client package.json Dependencies` be split into smaller, more focused modules?**
  _Cohesion score 0.06060606060606061 - nodes in this community are weakly interconnected._