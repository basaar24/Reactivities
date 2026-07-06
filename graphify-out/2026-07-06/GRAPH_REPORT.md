# Graph Report - Reactivities  (2026-07-06)

## Corpus Check
- 128 files · ~31,871 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 618 nodes · 701 edges · 72 communities (46 shown, 26 thin omitted)
- Extraction: 93% EXTRACTED · 7% INFERRED · 0% AMBIGUOUS · INFERRED: 47 edges (avg confidence: 0.88)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `91821b61`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- [[_COMMUNITY_Reactivities CQRS Handlers|Reactivities CQRS Handlers]]
- [[_COMMUNITY_Frontend Dependencies|Frontend Dependencies]]
- [[_COMMUNITY_Reactivities Architecture Docs|Reactivities Architecture Docs]]
- [[_COMMUNITY_Frontend Dev Toolchain|Frontend Dev Toolchain]]
- [[_COMMUNITY_LTI Project Docs|LTI Project Docs]]
- [[_COMMUNITY_Backend Standards and Data Model|Backend Standards and Data Model]]
- [[_COMMUNITY_TypeScript App Config|TypeScript App Config]]
- [[_COMMUNITY_Writing Skills|Writing Skills]]
- [[_COMMUNITY_Multi-Copilot Agent Config|Multi-Copilot Agent Config]]
- [[_COMMUNITY_TypeScript Node Config|TypeScript Node Config]]
- [[_COMMUNITY_C Project Structure|C# Project Structure]]
- [[_COMMUNITY_OpenSpec Workflow Skills|OpenSpec Workflow Skills]]
- [[_COMMUNITY_ASP.NET Controller Base|ASP.NET Controller Base]]
- [[_COMMUNITY_Activity Mapper Planning|Activity Mapper Planning]]
- [[_COMMUNITY_ASP.NET Launch Config|ASP.NET Launch Config]]
- [[_COMMUNITY_Code Audit Skills|Code Audit Skills]]
- [[_COMMUNITY_LTI API Specification|LTI API Specification]]
- [[_COMMUNITY_Agent Symlink Mirrors|Agent Symlink Mirrors]]
- [[_COMMUNITY_EF Core DbContext and Seeding|EF Core DbContext and Seeding]]
- [[_COMMUNITY_LTI Backend Agent Specs|LTI Backend Agent Specs]]
- [[_COMMUNITY_LTI Frontend Agent Specs|LTI Frontend Agent Specs]]
- [[_COMMUNITY_Client Entry and React Query|Client Entry and React Query]]
- [[_COMMUNITY_TypeScript Config References|TypeScript Config References]]
- [[_COMMUNITY_Serena LSP Config|Serena LSP Config]]
- [[_COMMUNITY_ESLint Prettier Husky Setup|ESLint Prettier Husky Setup]]
- [[_COMMUNITY_AutoMapper Profiles|AutoMapper Profiles]]
- [[_COMMUNITY_Product Strategy Agent|Product Strategy Agent]]
- [[_COMMUNITY_Code Review Scripts|Code Review Scripts]]
- [[_COMMUNITY_OpenSpec Change Lifecycle|OpenSpec Change Lifecycle]]
- [[_COMMUNITY_Reactivities App README|Reactivities App README]]
- [[_COMMUNITY_Symlink Sync Skill|Symlink Sync Skill]]
- [[_COMMUNITY_Git Worktrees Skill|Git Worktrees Skill]]
- [[_COMMUNITY_Specboot Instructions|Specboot Instructions]]
- [[_COMMUNITY_API Program Startup|API Program Startup]]
- [[_COMMUNITY_MenuItemLink Component|MenuItemLink Component]]
- [[_COMMUNITY_Activity Dashboard Component|Activity Dashboard Component]]
- [[_COMMUNITY_Activity Details Page|Activity Details Page]]
- [[_COMMUNITY_Planning Model Requirement|Planning Model Requirement]]
- [[_COMMUNITY_Project Skills Reference|Project Skills Reference]]
- [[_COMMUNITY_Community 39|Community 39]]
- [[_COMMUNITY_Documentation AI Standards|Documentation AI Standards]]
- [[_COMMUNITY_Frontend Project Structure|Frontend Project Structure]]
- [[_COMMUNITY_useStore Hook|useStore Hook]]
- [[_COMMUNITY_Commit Skill|Commit Skill]]
- [[_COMMUNITY_Enrich User Story Skill|Enrich User Story Skill]]
- [[_COMMUNITY_Explain and Teach Skill|Explain and Teach Skill]]
- [[_COMMUNITY_Meta Prompt Engineering|Meta Prompt Engineering]]
- [[_COMMUNITY_Update Docs Skill|Update Docs Skill]]
- [[_COMMUNITY_CounterStore MobX|CounterStore MobX]]
- [[_COMMUNITY_UIStore MobX|UIStore MobX]]
- [[_COMMUNITY_Date Format Utility|Date Format Utility]]
- [[_COMMUNITY_Community 51|Community 51]]
- [[_COMMUNITY_Community 52|Community 52]]
- [[_COMMUNITY_Community 53|Community 53]]
- [[_COMMUNITY_Community 54|Community 54]]
- [[_COMMUNITY_Community 55|Community 55]]
- [[_COMMUNITY_Community 56|Community 56]]
- [[_COMMUNITY_Community 57|Community 57]]
- [[_COMMUNITY_Community 58|Community 58]]
- [[_COMMUNITY_Community 59|Community 59]]
- [[_COMMUNITY_Community 60|Community 60]]
- [[_COMMUNITY_Community 61|Community 61]]
- [[_COMMUNITY_Community 62|Community 62]]
- [[_COMMUNITY_Community 63|Community 63]]
- [[_COMMUNITY_Community 64|Community 64]]
- [[_COMMUNITY_Community 65|Community 65]]
- [[_COMMUNITY_Community 66|Community 66]]
- [[_COMMUNITY_Community 67|Community 67]]
- [[_COMMUNITY_Community 68|Community 68]]
- [[_COMMUNITY_Community 69|Community 69]]
- [[_COMMUNITY_Community 70|Community 70]]
- [[_COMMUNITY_Community 71|Community 71]]

## God Nodes (most connected - your core abstractions)
1. `compilerOptions` - 17 edges
2. `Result` - 16 edges
3. `compilerOptions` - 16 edges
4. `Backend Standards` - 13 edges
5. `Activity` - 9 edges
6. `.NET / C# Rules` - 8 edges
7. `React + TypeScript Rules` - 8 edges
8. `scripts` - 8 edges
9. `ActivitiesController` - 8 edges
10. `LTI Base Development Standards` - 8 edges

## Surprising Connections (you probably didn't know these)
- `LTI API OpenAPI 3.0 Specification` --semantically_similar_to--> `Reactivities API Routes /api/activities`  [INFERRED] [semantically similar]
  Reactivities/docs/api-spec.yml → CLAUDE.md
- `AutoMapper MappingProfiles` --conceptually_related_to--> `IActivityMapper Interface Design Decision`  [INFERRED]
  CLAUDE.md → openspec/changes/migrate-automapper-to-custommapper/design.md
- `Mandatory Graphify Pre-Task Protocol` --conceptually_related_to--> `Specboot: Augmented Spec-Driven Development Framework`  [INFERRED]
  CLAUDE.md → Reactivities/README.md
- `Test-Driven Development Principle (Base Standards)` --semantically_similar_to--> `TDD for Documentation (RED-GREEN-REFACTOR)`  [INFERRED] [semantically similar]
  Reactivities/docs/base-standards.md → Reactivities/ai-specs/skills/writing-skills/SKILL.md
- `Reactivities Tech Stack Context (.NET 10 + React 19)` --conceptually_related_to--> `Reactivities Full-Stack Architecture`  [INFERRED]
  openspec/config.yaml → CLAUDE.md

## Import Cycles
- 3-file cycle: `client/src/app/router/Routes.tsx -> client/src/features/errors/TestErrors.tsx -> client/src/lib/api/agent.ts -> client/src/app/router/Routes.tsx`

## Hyperedges (group relationships)
- **OpenSpec Change Lifecycle (Propose → Apply → Archive)** — opsx_propose_opsx_propose_command, opsx_apply_opsx_apply_command, opsx_archive_opsx_archive_command [EXTRACTED 0.95]
- **OPSX Skill-Command Mirror Pairs** — openspec_apply_change_skill, openspec_archive_change_skill, openspec_propose_skill, openspec_explore_skill, openspec_sync_specs_skill [EXTRACTED 0.95]
- **Agent plan-only pattern (backend + frontend plan output to .claude/doc/)** — agents_backend_developer, agents_frontend_developer, agents_backend_plan_output, agents_frontend_plan_output [EXTRACTED 1.00]
- **OpenSpec Change Artifacts: proposal + design + spec + tasks** — openspec_change_migrate_automapper, proposal_migrate_automapper, design_iactivitymapper_interface, spec_map_createactivityrequest_to_activity, spec_update_activity_from_activity, tasks_migrate_automapper [EXTRACTED 1.00]
- **Multi-Copilot Config Files All Referencing base-standards.md** — reactivities_agents_md_base_standards, reactivities_claude_md_base_standards, reactivities_gemini_md_base_standards, readme_base_standards_single_source [EXTRACTED 1.00]
- **Reactivities Backend Architecture: Clean Architecture + CQRS + MediatR** — claude_md_clean_architecture_cqrs, claude_md_mediator_pattern, claude_md_automapper, openspec_config_tech_stack [INFERRED 0.85]

## Communities (72 total, 26 thin omitted)

### Community 0 - "Reactivities CQRS Handlers"
Cohesion: 0.22
Nodes (8): Architecture & structure, Async & performance, Dependency injection, Error handling, Naming & style, .NET / C# Rules, Nullability & types, Testing

### Community 1 - "Frontend Dependencies"
Cohesion: 0.06
Nodes (32): dependencies, axios, date-fns, @emotion/react, @emotion/styled, @fontsource/roboto, mobx, mobx-react-lite (+24 more)

### Community 2 - "Reactivities Architecture Docs"
Cohesion: 0.12
Nodes (19): AutoMapper MappingProfiles, Clean Architecture + CQRS Pattern, Feature-Based React Structure, Controller → MediatR → Handler → DbContext Pattern, TanStack React Query v5 Server State, Reactivities Full-Stack Architecture, ActivityMapper Placement in Application/Core/, IActivityMapper Interface Design Decision (+11 more)

### Community 3 - "Frontend Dev Toolchain"
Cohesion: 0.08
Nodes (23): husky.sh script, devDependencies, @babel/core, babel-plugin-react-compiler, eslint, eslint-config-prettier, @eslint/js, eslint-plugin-react-hooks (+15 more)

### Community 4 - "LTI Project Docs"
Cohesion: 0.11
Nodes (22): AI Specs Learning from Feedback, Application Entity (LTI), LTI Backend Standards (Node.js/TypeScript/Express), LTI Base Development Standards, Candidate Entity (LTI), Cypress E2E Testing (LTI Frontend), LTI Data Model Documentation, Domain-Driven Design Principles (LTI) (+14 more)

### Community 5 - "Backend Standards and Data Model"
Cohesion: 0.40
Nodes (5): Development Guide — Manual API Testing with curl, OpenSpec Tasks Mandatory Steps — Agent Must Execute Tests, OpenSpec Tasks Mandatory Steps — Build Verification & DB Check, OpenSpec Tasks Mandatory Steps — Implementation Checklist, OpenSpec Tasks Mandatory Steps — E2E Testing with Playwright MCP

### Community 6 - "TypeScript App Config"
Cohesion: 0.11
Nodes (18): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, jsx, lib, module, moduleDetection, moduleResolution (+10 more)

### Community 7 - "Writing Skills"
Cohesion: 0.13
Nodes (19): Anthropic Skill Authoring Best Practices, Evaluation-Driven Development for Skills, Progressive Disclosure Pattern (Skills), Skill Description Field Best Practices, CLAUDE_MD Testing Documentation Variants, Pressure Test Scenarios for Skills, Authority Persuasion Principle, Cialdini Influence Principles (2021) (+11 more)

### Community 8 - "Multi-Copilot Agent Config"
Cohesion: 0.14
Nodes (17): Mandatory Graphify Pre-Task Protocol, Parallel Tasks File Format (Task Block Structure), AGENTS.md Reference to base-standards.md, CLAUDE.md Reference to base-standards.md (Reactivities sub), GEMINI.md Reference to base-standards.md, ai-specs/skills Reusable Workflow Skills, base-standards.md Single Source of Truth Principle, docs/ Technical Context Folder (+9 more)

### Community 9 - "TypeScript Node Config"
Cohesion: 0.11
Nodes (17): compilerOptions, allowImportingTsExtensions, erasableSyntaxOnly, lib, module, moduleDetection, moduleResolution, noEmit (+9 more)

### Community 10 - "C# Project Structure"
Cohesion: 0.14
Nodes (13): net10.0, net10.0, Microsoft.NET.Sdk, net10.0, Microsoft.NET.Sdk, net10.0, Microsoft.NET.Sdk, Domain (+5 more)

### Community 11 - "OpenSpec Workflow Skills"
Cohesion: 0.23
Nodes (13): Delta Spec Sync Pattern, OpenSpec Workflow System, Spec-Driven Change Lifecycle, openspec-apply-change Skill, openspec-archive-change Skill, openspec-explore Skill, openspec-propose Skill, openspec-sync-specs Skill (+5 more)

### Community 12 - "ASP.NET Controller Base"
Cohesion: 0.14
Nodes (13): Activity, ActivityMapper, IActivityMapper, CreateActivityDto, Activity, List, GetActivityDetails, Handler (+5 more)

### Community 13 - "Activity Mapper Planning"
Cohesion: 0.67
Nodes (3): Plan: ActivityRequestMapper, ActivityRequest DTO Mapping Plan, ActivityRequestMapper implements IMapper

### Community 14 - "ASP.NET Launch Config"
Cohesion: 0.20
Nodes (9): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, profiles, https (+1 more)

### Community 15 - "Code Audit Skills"
Cohesion: 0.22
Nodes (9): adversarial-review skill, Red-team / adversarial review methodology, code-auditing skill, deadcode (Python dead code detection tool), Knip (JS/TS dead code detection tool), 6-phase code audit methodology, audit-methodology.md (code audit reference), dead-code-methodology.md (dead code reference) (+1 more)

### Community 16 - "LTI API Specification"
Cohesion: 0.29
Nodes (8): Application Schema (Candidate Job Application), Candidate Domain Schema, Candidates REST Endpoint (/candidates), InterviewFlow and InterviewStep Schemas, LTI API OpenAPI 3.0 Specification, Position Domain Schema, Positions REST Endpoint (/positions), Reactivities API Routes /api/activities

### Community 17 - "Agent Symlink Mirrors"
Cohesion: 0.29
Nodes (7): Backend Developer Agent (Claude), Backend Developer Agent (Cursor), Frontend Developer Agent (Claude), Frontend Developer Agent (Cursor), Product Strategy Analyst Agent (Claude), Product Strategy Analyst Agent (Cursor), AI Agent Spec Files

### Community 19 - "LTI Backend Agent Specs"
Cohesion: 0.40
Nodes (5): Domain-Driven Design (DDD) layered architecture, backend-developer agent, Express (HTTP framework), Implementation plan output: .claude/doc/{feature_name}/backend.md, Prisma ORM (backend persistence)

### Community 20 - "LTI Frontend Agent Specs"
Cohesion: 0.40
Nodes (5): frontend-developer agent, Implementation plan output: .claude/doc/{feature_name}/frontend.md, React component-based architecture, React Bootstrap (UI library), React Router (client-side routing)

### Community 21 - "Client Entry and React Query"
Cohesion: 0.67
Nodes (3): Client Entry HTML (index.html), TanStack React Query v5 State Management, Reactivities React Client README

### Community 23 - "Serena LSP Config"
Cohesion: 0.67
Nodes (3): Serena Language Server Configuration, Serena Project Config, Serena Project Local Config

### Community 24 - "ESLint Prettier Husky Setup"
Cohesion: 0.67
Nodes (3): Development Guide — Frontend Setup (Vite / React), Frontend Standards — Code Quality (ESLint/Prettier/Husky), Implementation Plan — ESLint + Prettier + Husky Setup

### Community 33 - "API Program Startup"
Cohesion: 0.12
Nodes (13): Program, AppDbContext, Exception, HttpContext, IMiddleware, JsonSerializerOptions, ExceptionMiddleware, DbInitializer (+5 more)

### Community 37 - "Planning Model Requirement"
Cohesion: 0.67
Nodes (3): Frontend Standards — HTTP Client (Axios with interceptors), Frontend Standards — Client State with MobX (uiStore), Frontend Standards — Data Fetching with React Query

### Community 39 - "Community 39"
Cohesion: 0.14
Nodes (21): CancellationToken, Command, CreateActivity, Handler, Command, DeleteActivity, Handler, Command (+13 more)

### Community 40 - "Documentation AI Standards"
Cohesion: 0.05
Nodes (40): Architecture Patterns, Backend Standards, Build Verification, Code Style, Controller Pattern, CORS, CQRS with MediatR, Dependency Injection (+32 more)

### Community 51 - "Community 51"
Cohesion: 0.22
Nodes (8): Cleanup, Component design, Naming & structure, React + TypeScript Rules, State & data, Styling, Testing, TypeScript strictness

### Community 52 - "Community 52"
Cohesion: 0.09
Nodes (16): ActionResult, WeatherForecast, BaseApiController, ControllerBase, ActivitiesController, BaseApiController, BuggyController, WeatherForecastController (+8 more)

### Community 53 - "Community 53"
Cohesion: 0.33
Nodes (5): API Routes (`/api/activities`), Backend — Core, Key registrations (Program.cs), Mapping, Project Structure

### Community 54 - "Community 54"
Cohesion: 0.33
Nodes (5): Data flow, Environment, Frontend — Core, Project Structure, Route table

### Community 55 - "Community 55"
Cohesion: 0.33
Nodes (5): Add/update threshold, Discovery Model, Maintenance Actions, Memory Maintenance, Style

### Community 56 - "Community 56"
Cohesion: 0.33
Nodes (5): 1. Add Custom Mapper Interface and Implementation, 2. Update DI Registration, 3. Update MediatR Handlers, 4. Remove AutoMapper, 5. Verify

### Community 57 - "Community 57"
Cohesion: 0.40
Nodes (4): Backend (C#), Conventions, Frontend (TypeScript / React), OpenSpec workflow

### Community 58 - "Community 58"
Cohesion: 0.40
Nodes (4): Layout, Project-wide invariants, Reactivities — Project Core, Sub-project memories

### Community 59 - "Community 59"
Cohesion: 0.40
Nodes (4): Backend (run from repo root or `backend/`), Frontend (run from `client/`), Suggested Commands, Windows-specific notes

### Community 60 - "Community 60"
Cohesion: 0.40
Nodes (4): Backend changes, Both, Frontend changes, Task Completion Checklist

### Community 61 - "Community 61"
Cohesion: 0.50
Nodes (3): Backend, Frontend, Tech Stack

### Community 62 - "Community 62"
Cohesion: 0.15
Nodes (12): activity-mapping Specification, Purpose, Requirements, Requirement: Map CreateActivityRequest to Activity, Requirement: Mapper is registered in the DI container, Requirement: Update Activity from another Activity, Scenario: All required fields produce a valid Activity, Scenario: Destination Id is never overwritten (+4 more)

### Community 63 - "Community 63"
Cohesion: 0.18
Nodes (10): 1. Interface `IActivityMapper` over a static class, 2. Placement in `Application/Core/` (not `Domain/`), 3. Two methods on the interface, 4. `AddScoped` registration, Context, Decisions, Goals / Non-Goals, Migration Plan (+2 more)

### Community 64 - "Community 64"
Cohesion: 0.18
Nodes (10): ADDED Requirements, Requirement: Map CreateActivityRequest to Activity, Requirement: Mapper is registered in the DI container, Requirement: Update Activity from another Activity, Scenario: All required fields produce a valid Activity, Scenario: Destination Id is never overwritten, Scenario: Handlers resolve IActivityMapper from DI, Scenario: IsCancelled is carried over in updates (+2 more)

### Community 65 - "Community 65"
Cohesion: 0.22
Nodes (8): Agent Role, Capabilities, Impact, Modified Capabilities, New Capabilities, Non-goals, What Changes, Why

### Community 66 - "Community 66"
Cohesion: 0.33
Nodes (5): 1. Add Custom Mapper Interface and Implementation, 2. Update DI Registration, 3. Update MediatR Handlers, 4. Remove AutoMapper, 5. Verify

### Community 68 - "Community 68"
Cohesion: 0.18
Nodes (8): AbstractValidator, Command, BaseActivityDto, CreateActivityDto, UpdateActivityDto, BaseActivityValidator, CreateActivityValidator, UpdateActivityValidator

### Community 70 - "Community 70"
Cohesion: 0.22
Nodes (4): agent, ServerError(), router, queryClient

### Community 71 - "Community 71"
Cohesion: 0.29
Nodes (6): Code quality bar, Communication, Errors and type safety, Scope discipline, Verification, Workflow & Collaboration Rules

## Knowledge Gaps
- **308 isolated node(s):** `Architecture & structure`, `Async & performance`, `Nullability & types`, `Error handling`, `Testing` (+303 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **26 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `devDependencies` connect `Frontend Dev Toolchain` to `Frontend Dependencies`?**
  _High betweenness centrality (0.005) - this node is a cross-community bridge._
- **Why does `Result` connect `Community 39` to `Community 52`, `ASP.NET Controller Base`?**
  _High betweenness centrality (0.005) - this node is a cross-community bridge._
- **What connects `Architecture & structure`, `Async & performance`, `Nullability & types` to the rest of the system?**
  _316 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Frontend Dependencies` be split into smaller, more focused modules?**
  _Cohesion score 0.06060606060606061 - nodes in this community are weakly interconnected._
- **Should `Reactivities Architecture Docs` be split into smaller, more focused modules?**
  _Cohesion score 0.12280701754385964 - nodes in this community are weakly interconnected._
- **Should `Frontend Dev Toolchain` be split into smaller, more focused modules?**
  _Cohesion score 0.08333333333333333 - nodes in this community are weakly interconnected._
- **Should `LTI Project Docs` be split into smaller, more focused modules?**
  _Cohesion score 0.11255411255411256 - nodes in this community are weakly interconnected._