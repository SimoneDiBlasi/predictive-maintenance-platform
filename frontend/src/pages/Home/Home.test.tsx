import { render, screen } from "@testing-library/react";
import { describe, expect, it } from "vitest";

import Home from "./Home";

describe("Home page", () => {
  it("should display the application name", () => {
    render(<Home />);

    expect(
      screen.getByRole("heading", {
        name: "Predictive Maintenance Platform",
      }),
    ).toBeInTheDocument();
  });
});
