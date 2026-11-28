from collections.abc import AsyncGenerator
from contextlib import asynccontextmanager
from fastapi import FastAPI
from ml_service.api.router import api_router
from ml_service.config import get_settings
from ml_service.core.logging import configure_logging, get_logger
from ml_service.api.middleware import register_middlewares


@asynccontextmanager
async def lifespan(app: FastAPI) -> AsyncGenerator[None, None]:
    logger = get_logger(__name__)
    logger.info("Application starting")
    yield
    logger.info("Application shutting down")


def create_app() -> FastAPI:
    configure_logging()
    settings = get_settings()
    logger = get_logger(__name__)
    app = FastAPI(
        title=settings.app_name,
        description="API for Predictive Maintenance and Machine Learning.",
        version="0.1.0",
        debug=settings.debug,
        lifespan=lifespan,
    )
    register_middlewares(app)
    app.include_router(api_router)
    logger.info("Application configured | environment=%s", settings.environment)

    return app


app = create_app()
