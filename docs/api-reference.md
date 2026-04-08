# API Reference

Base URL: `http://localhost:3456/api/v1`

---

## Authentication

```http
Authorization: Bearer <YOUR_API_TOKEN>
```

---

## POST /query

| Field | Type | Required | Description |
|---|---|---|---|
| `question` | `string` | Yes | Max 1,000 characters. |
| `conversation_id` | `string` | No | Resume a prior session. |
| `top_k` | `integer` | No | Chunks to retrieve. Default: 5. |
| `stream` | `boolean` | No | Enable SSE streaming. |

```json
{
  "answer": "Rate limiting is configured via RATE_LIMIT_RPM...",
  "sources": [{ "page": "configuration.md", "section": "Rate Limiting", "line": 84, "score": 0.94 }],
  "model": "claude-sonnet-4-20250514",
  "latency_ms": 843
}
```

---

## POST /ingest

| Field | Type | Required | Description |
|---|---|---|---|
| `source` | `string` | Yes | URL or base64-encoded content. |
| `source_type` | `string` | Yes | `url`, `markdown`, `openapi` |

Returns `202 Accepted` with a `job_id`.

---

## GET /jobs/:job_id

Poll ingestion job status: `queued`, `running`, `completed`, `failed`.

---

## GET /health

```json
{ "status": "ok", "dependencies": { "postgres": "ok", "redis": "ok", "llm_backend": "ok" }, "version": "1.3.0" }
```

---

## Error Codes

| Status | Code | Description |
|---|---|---|
| 400 | INVALID_REQUEST | Malformed body |
| 401 | UNAUTHORIZED | Invalid token |
| 429 | RATE_LIMIT_EXCEEDED | Too many requests |
| 503 | LLM_UNAVAILABLE | LLM backend unreachable |