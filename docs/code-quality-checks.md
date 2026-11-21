# Code Quality Checks

## Purpose

This document describes how developers can verify formatting and code quality before opening a pull request.

Run the checks for the part of the repository that you changed. All commands below are intended to be executed locally; CI should run the same checks where practical.

## Prerequisites

Install the tools required by the component you are working on:

- .NET SDK compatible with the backend target framework.
- Python and the project's Python dependencies, including Ruff.
- Node.js and npm for the frontend.
- The frontend's project dependencies.

Use the versions documented by the repository and its tool-version files. Do not install arbitrary global versions when the project provides a pinned version.

## Backend — .NET / C#

Open PowerShell and move to the backend directory containing the solution:

```powershell
cd backend
```

Verify whitespace and formatting without changing files:

```powershell
dotnet format whitespace --verify-no-changes
```

Apply formatting:

```powershell
dotnet format whitespace
```

Run the test suite:

```powershell
dotnet test
```

If the solution is not in the current directory, pass its actual path to the `dotnet format` and `dotnet test` commands.

`dotnet format whitespace` checks and applies whitespace formatting. Roslyn analyzers and compiler diagnostics provide additional code-style and correctness checks; formatting verification alone is not a complete quality gate.

## Machine Learning Service — Python

Run these commands from the ML service directory, where the Python project configuration is located:

```powershell
cd ml-service
```

Check linting:

```powershell
ruff check .
```

Verify formatting without changing files:

```powershell
ruff format --check .
```

Apply automatic lint fixes where safe:

```powershell
ruff check . --fix
```

Apply formatting:

```powershell
ruff format .
```

Run tests:

```powershell
pytest
```

Ruff should be configured in the Python project configuration (for example, `pyproject.toml`). Keep its line length and formatting settings aligned with the conventions documented in [Code Style and EditorConfig](code-style-and-editorconfig.md).

## Frontend — React / TypeScript

Run these commands from the frontend directory:

```powershell
cd frontend
```

Verify formatting with Prettier:

```powershell
npx prettier --check .
```

Apply formatting:

```powershell
npx prettier --write .
```

Run ESLint:

```powershell
npx eslint .
```

Run the frontend test suite using the script defined in `package.json`. For example, if the project defines a `test` script:

```powershell
npm run test
```

Use the locally installed project tools through `npx` or npm scripts. Do not depend on a developer's globally installed Prettier or ESLint version.

Prettier and ESLint must be installed and configured in the frontend project before these checks can be considered part of the required workflow.

## Before opening a pull request

- [ ] The relevant formatter verification passes.
- [ ] The relevant linter passes.
- [ ] Automated tests pass.
- [ ] No generated build output, local dataset, model artifact, database file, or secret has been committed.
- [ ] Documentation and configuration examples are updated when behavior or developer workflows change.

## Pull request expectations

A pull request should:

1. Explain the problem and the proposed change.
2. Reference the related GitHub issue.
3. Include tests or explain why tests are not applicable.
4. Mention any configuration or documentation changes.
5. Report any checks that could not be run and explain why.

## Notes

The commands in this document describe the intended quality workflow. A command is only an enforced project check after its tool and configuration have been added to the relevant project. Keep the CI workflows aligned with these local instructions so contributors receive consistent results locally and in GitHub Actions.
