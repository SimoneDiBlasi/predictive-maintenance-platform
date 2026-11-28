from fastapi.testclient import TestClient

from ml_service.main import app

client = TestClient(app)


def test_health_endpoint_returns_success() -> None:
    response = client.get("/health")

    assert response.status_code == 200
    assert response.json() == {"status": "healthy"}
    assert "X-Request-ID" in response.headers
