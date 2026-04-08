# Changelog

All notable changes to DocuBot are documented here.

---

## [Unreleased]

### Added
- Confluence Cloud connector (OAuth 2.0)
- Streaming WebSocket support for the embedded widget

---

## [1.3.0] — 2025-03-12

### Added
- Notion connector via OAuth 2.0
- `POST /api/v1/conversations` endpoint for multi-turn sessions

### Changed
- Switched default embedding model to `claude-embed-v1`
- Increased default chunk size from 512 to 768 tokens

### Fixed
- Race condition causing duplicate chunks on re-ingestion (#214)
- Widget white flash in dark mode (#198)

---

## [1.2.0] — 2025-01-14

### Added
- `GET /api/v1/health` endpoint
- `--dry-run` flag for `docubot ingest`
- Optional rate-limiting middleware

### Deprecated
- `GET /api/v1/search` — use `POST /api/v1/query` instead (removed in v2.0)

---

## [1.1.0] — 2024-11-05

### Added
- GitHub connector
- MDX and reStructuredText support

---

## [1.0.0] — 2024-09-18

Initial stable release.