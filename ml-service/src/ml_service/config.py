import os
from functools import lru_cache
from pydantic_settings import BaseSettings, SettingsConfigDict


class Settings(BaseSettings):
    app_name: str = "Predictive Maintenance API"
    environment: str = "development"
    debug: bool = True
    log_level: str = "DEBUG"
    model_path: str = "artifacts/models"
    dataset_path: str = "datasets"
    model_config = SettingsConfigDict(
        env_file=os.getenv("ENV_FILE", ".env.development"),
        env_file_encoding="utf-8",
        case_sensitive=False,
        extra="ignore",
    )


@lru_cache
def get_settings() -> Settings:
    return Settings()
