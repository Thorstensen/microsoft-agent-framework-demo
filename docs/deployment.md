# Deployment Guide

---

## Production Checklist

- [ ] Set `SESSION_SECRET` (`openssl rand -hex 32`)
- [ ] Set `HOST=0.0.0.0` behind a reverse proxy
- [ ] Set `CORS_ORIGINS` to your frontend domain
- [ ] Enable `RATE_LIMIT_RPM`
- [ ] Configure TLS at the load balancer
- [ ] Set up PostgreSQL backups

---

## Docker Compose

```bash
docker compose -f docker-compose.prod.yml up -d
```

---

## Nginx Reverse Proxy

```nginx
server {
    listen 443 ssl;
    server_name docs-bot.example.com;
    location / {
        proxy_pass http://127.0.0.1:3456;
        proxy_buffering off;  /* required for SSE */
        proxy_cache off;
    }
}
```

---

## Kubernetes (Helm)

```bash
helm repo add acme https://charts.acme-labs.io
helm install docubot acme/docubot \
  --set llm.backend=anthropic \
  --set secrets.anthropicApiKey=$ANTHROPIC_API_KEY \
  --set ingress.host=docs-bot.example.com
```

---

## Scaling

| Component | Strategy |
|---|---|
| `docubot-api` | Stateless — scale horizontally |
| `docubot-worker` | Scale independently via Redis queue |
| PostgreSQL | Use managed service (RDS, Supabase) |
| Redis | Use Redis Cluster or ElastiCache |

---

## Prometheus Metrics (`GET /metrics`)

| Metric | Type | Description |
|---|---|---|
| `docubot_queries_total` | Counter | Total queries |
| `docubot_query_latency_seconds` | Histogram | Query latency |
| `docubot_llm_tokens_total` | Counter | LLM tokens consumed |
| `docubot_cache_hits_total` | Counter | Semantic cache hits |