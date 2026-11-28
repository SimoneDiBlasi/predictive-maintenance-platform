import { API_BASE_URL } from "./api";

export interface HealthResponse {
  status: string;
}

export async function getHealth(): Promise<HealthResponse> {
  const response = await fetch(`${API_BASE_URL}/health/live`);

  if (!response.ok) {
    throw new Error(
      `Health check failed with status ${response.status}`,
    );
  }

  return {
    status: response.status === 200 ? "healthy" : "unavailable",
  };
}
