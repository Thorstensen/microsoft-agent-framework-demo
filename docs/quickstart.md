# Quickstart Guide

Get DocuBot running locally in under five minutes.

---

## Prerequisites

- Node.js 18 or later
- Docker and Docker Compose
- An Anthropic API key

---

## Step 1 — Install the CLI

```bash
npm install -g @acme/docubot-cli
docubot --version
```

## Step 2 — Initialize a project

```bash
docubot init my-docs-bot
cd my-docs-bot
```

## Step 3 — Configure your environment

```bash
cp .env.example .env
```

```dotenv
ANTHROPIC_API_KEY=sk-ant-...
DATABASE_URL=postgresql://docubot:docubot@localhost:5432/docubot
REDIS_URL=redis://localhost:6379
```

## Step 4 — Start infrastructure

```bash
docker compose up -d
```

## Step 5 — Ingest your docs

```bash
docubot ingest ./docs
```

## Step 6 — Start the server

```bash
docubot serve
```

## Step 7 — Ask your first question

```bash
curl -X POST http://localhost:3456/api/v1/query \
  -H "Content-Type: application/json" \
  -d '{"question": "How do I configure rate limiting?"}'
```