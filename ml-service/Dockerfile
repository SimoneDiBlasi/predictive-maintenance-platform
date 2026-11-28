
FROM python:3.14-slim

WORKDIR /app


COPY --from=ghcr.io/astral-sh/uv:latest /uv /uvx /bin/


COPY pyproject.toml uv.lock README.md ./


COPY src ./src


RUN uv sync --locked --no-dev

# Run FastAPI
CMD ["uv", "run", "--no-sync", "uvicorn", "ml_service.main:app", "--host", "0.0.0.0", "--port", "8000"]
