
import { useEffect, useState } from "react";
import { getHealth } from "../../services/health";
import "./Home.less";

type ApiStatus = "loading" | "healthy" | "unavailable";

function Home() {
  const [apiStatus, setApiStatus] = useState<ApiStatus>("loading");

  useEffect(() => {
    let isMounted = true;

    async function checkApiHealth(): Promise<void> {
      try {
        const response = await getHealth();

        if (isMounted) {
          console.log("API health check response:", response);
          setApiStatus(
            response.status === "healthy" ? "healthy" : "unavailable",
          );
        }
      } catch {
        if (isMounted) {
          setApiStatus("unavailable");
        }
      }
    }

    void checkApiHealth();

    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <main className="home">
      <section className="home__content">
        <h1 className="home__title">
          Predictive Maintenance Platforms
        </h1>

        <p className="home__description">
          Machine Learning platform for predictive maintenance.
        </p>

        <div className={`home__status home__status--${apiStatus}`}>
          <span className="home__status-indicator" />

          <span>
            {apiStatus === "loading" && "Checking API connection..."}
            {apiStatus === "healthy" && "API connected"}
            {apiStatus === "unavailable" && "API unavailable"}
          </span>
        </div>
      </section>
    </main>
  );
}

export default Home;
