
# Machine Learning Service

Python service responsible for Machine Learning preprocessing
and inference capabilities.

## Requirements

- Python 3.14
- uv

## Setup

Install project dependencies:

```powershell
uv sync
```

## Run locally

Start the FastAPI application:

```powershell
uv run uvicorn ml_service.main:app --reload --host 127.0.0.1 --port 8000
```

## API Documentation

Once the application is running:

- Swagger UI: http://127.0.0.1:8000/docs
- Health endpoint: http://127.0.0.1:8000/health

## Tests

Run automated tests:

```powershell
uv run pytest
```

## Code Quality

Run linting:

```powershell
uv run ruff check .
```

Format code:

```powershell
uv run ruff format .
```

Check formatting:

```powershell
uv run ruff format --check .
```
