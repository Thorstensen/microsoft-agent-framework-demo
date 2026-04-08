# DocuBot

> AI-powered documentation Q&A — give developers instant answers from your own docs.

[![npm version](https://img.shields.io/npm/v/docubot.svg)](https://www.npmjs.com/package/docubot)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![CI](https://github.com/acme-labs/docubot/actions/workflows/ci.yml/badge.svg)](https://github.com/acme-labs/docubot/actions)

DocuBot is an open-source application that ingests your Markdown, MDX, and OpenAPI documentation and exposes a semantic search and Q&A interface powered by large language models. It is designed to be self-hosted, framework-agnostic, and easy to extend.

---

## Features

- **Semantic Q&A** — Natural language queries resolved against your own docs corpus.
- **Multi-source ingestion** — Supports local files, GitHub repositories, Notion, and Confluence.
- **Pluggable LLM backends** — Works with Anthropic Claude, OpenAI, Cohere, and local Ollama models.
- **Streaming responses** — Server-sent events for real-time answer delivery.
- **Source citations** — Every answer surfaces the originating doc section and page.
- **REST & WebSocket API** — Integrate DocuBot into any product surface.
- **Embeddable widget** — Drop a `<DocuBotWidget />` React component into any page in minutes.

---

## Quick Start

```bash
npm install -g @acme/docubot-cli
docubot init my-docs-project
cd my-docs-project
docubot ingest ./docs
docubot serve
```

Then open [http://localhost:3456](http://localhost:3456).

---

## Requirements

| Dependency | Version |
|---|---|
| Node.js | >= 18.0 |
| PostgreSQL (with pgvector) | >= 15 |
| Redis | >= 7.0 |

---

## Documentation

- [Quickstart Guide](./docs/quickstart.md)
- [API Reference](./docs/api-reference.md)
- [Configuration](./docs/configuration.md)
- [Deployment Guide](./docs/deployment.md)
- [Contributing](./CONTRIBUTING.md)

---

## License

MIT © 2025 Acme Labs