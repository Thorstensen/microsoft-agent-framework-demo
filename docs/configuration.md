# Configuration

---

## Required Environment Variables

| Variable | Description |
|---|---|
| `DATABASE_URL` | PostgreSQL connection string (pgvector required) |
| `REDIS_URL` | Redis connection string |
| `LLM_BACKEND` | `anthropic`, `openai`, `cohere`, or `ollama` |
| `ANTHROPIC_API_KEY` | Required when `LLM_BACKEND=anthropic` |

---

## Optional Environment Variables

| Variable | Default | Description |
|---|---|---|
| `PORT` | `3456` | HTTP server port |
| `HOST` | `127.0.0.1` | Bind address |
| `LOG_LEVEL` | `info` | `debug`, `info`, `warn`, `error` |
| `CHUNK_SIZE` | `768` | Target tokens per chunk |
| `RATE_LIMIT_RPM` | disabled | Max requests/min per token |
| `CORS_ORIGINS` | `*` | Allowed CORS origins |
| `SESSION_SECRET` | generated | Set explicitly in production |

---

## docubot.config.ts

```typescript
import { defineConfig } from "@acme/docubot";

export default defineConfig({
  ingestion: { chunkSize: 768, chunkOverlap: 128 },
  retrieval: { topK: 5, minScore: 0.75 },
  llm: {
    backend: "anthropic",
    model: "claude-sonnet-4-20250514",
    systemPrompt: "You are a helpful documentation assistant.",
    maxOutputTokens: 1024,
  },
  connectors: {
    github: { repos: ["acme-labs/platform-docs"], branch: "main", glob: "docs/**/*.md" },
  },
});
```