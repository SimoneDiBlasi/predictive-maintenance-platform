import logging
from time import perf_counter
from uuid import uuid4
from fastapi import FastAPI, Request, Response

logger = logging.getLogger(__name__)


def register_middlewares(app: FastAPI) -> None:
    @app.middleware("http")
    async def log_requests(request: Request, call_next) -> Response:
        request_id = str(uuid4())
        request.state.request_id = request_id

        start_time = perf_counter()

        try:
            response = await call_next(request)
            duration_ms = (perf_counter() - start_time) * 1000
            response.headers["X-Request-ID"] = request_id

            logger.info(
                "HTTP request completed | request_id=%s method=%s "
                "path=%s status_code=%s duration_ms=%.2f",
                request_id,
                request.method,
                request.url.path,
                response.status_code,
                duration_ms,
            )

            return response

        except Exception:
            duration_ms = (perf_counter() - start_time) * 1000

            logger.exception(
                "HTTP request failed | request_id=%s method=%s "
                "path=%s duration_ms=%.2f",
                request_id,
                request.method,
                request.url.path,
                duration_ms,
            )

            raise
