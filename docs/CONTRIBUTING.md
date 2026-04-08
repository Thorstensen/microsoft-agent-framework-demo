# Contributing to DocuBot

Thank you for taking the time to contribute! This document describes our workflow, code standards, and review process.

---

## Table of Contents

1. [Code of Conduct](#code-of-conduct)
2. [Getting Started](#getting-started)
3. [Development Workflow](#development-workflow)
4. [Commit Conventions](#commit-conventions)
5. [Pull Request Process](#pull-request-process)
6. [Testing](#testing)
7. [Issue Triage](#issue-triage)

---

## Code of Conduct

All contributors are expected to follow our [Code of Conduct](./CODE_OF_CONDUCT.md). Be kind, constructive, and inclusive.

---

## Getting Started

```bash
git clone https://github.com/<your-username>/docubot.git
cd docubot
npm install
cp .env.example .env
docker compose up -d postgres redis
npm run dev
```

---

## Commit Conventions

| Type | When to use |
|---|---|
| `feat` | A new feature |
| `fix` | A bug fix |
| `docs` | Documentation only changes |
| `refactor` | Code change that neither fixes a bug nor adds a feature |
| `test` | Adding or updating tests |
| `chore` | Build process, dependency updates |
| `perf` | A performance improvement |

---

## Testing

| Command | Description |
|---|---|
| `npm test` | Run unit + integration tests |
| `npm run test:unit` | Unit tests only |
| `npm run test:e2e` | End-to-end tests |
| `npm run test:coverage` | Generate coverage report |

We target **>= 80% line coverage** on all new code paths.

---

## Issue Triage

- **Bug reports** — Include reproduction steps, expected vs. actual behavior, and environment details.
- **Feature requests** — Describe the problem you're solving, not just the solution.
- **Security vulnerabilities** — Email `security@acme-labs.io` directly.