# Code Style and EditorConfig

## Purpose

The repository uses a root-level `.editorconfig` to keep basic editor behavior consistent across development environments and technologies.

EditorConfig standardizes settings such as:

- Character encoding.
- Line endings.
- Final newline at the end of files.
- Trailing whitespace.
- Indentation.

Language-specific analyzers and formatters are responsible for additional style rules. EditorConfig does not replace those tools.

## Repository-wide conventions

| Setting | Convention |
|---|---|
| Character encoding | UTF-8 |
| Line endings | LF |
| Final newline | Required |
| Trailing whitespace | Removed, except in Markdown |
| Indentation | Spaces by default |

## Language conventions

| File type | Indentation | Additional guidance |
|---|---:|---|
| C# | 4 spaces | Follow .NET and Roslyn code-style conventions |
| Python | 4 spaces | Follow PEP 8; target an 88-character line length when configured in Ruff |
| JavaScript / TypeScript / React | 2 spaces | Use the project's Prettier configuration |
| JSON / JSONC | 2 spaces | Keep files consistently formatted |
| YAML | 2 spaces | Do not use tabs for indentation |
| SQL | 4 spaces | Keep queries readable and consistently structured |
| XML / HTML / CSS / SCSS | 2 spaces | Follow the applicable formatter |
| Markdown | 2 spaces | Preserve intentional trailing spaces used for Markdown line breaks |
| Shell scripts | 2 spaces | Use LF line endings |
| TOML | 2 spaces | Keep configuration files consistent |

## C# conventions

C# formatting and code-style rules are defined through `.editorconfig` and enforced with .NET tooling.

The project should consistently use:

- Four spaces for indentation.
- Braces for control-flow statements.
- File-scoped namespaces where appropriate.
- `I`-prefixed interface names.
- Sorted `using` directives.
- Roslyn/.NET analyzer diagnostics.

Run the .NET formatting verification described in [Code Quality Checks](code-quality-checks.md).

## Python conventions

Python code follows PEP 8 conventions:

- Four spaces for indentation.
- No tab indentation.
- An 88-character line-length target when configured in Ruff.
- Consistent formatting and linting through Ruff.

The line-length setting must also be configured in the Python tool configuration (for example, `pyproject.toml`); the EditorConfig `max_line_length` property alone does not configure Ruff.

## Frontend conventions

JavaScript, TypeScript, and React files use two spaces for indentation.

Prettier is the formatter and ESLint is the linter. Their configuration files are the source of truth for rules that EditorConfig cannot express, such as import ordering, React-specific rules, and TypeScript lint rules.

## Markdown conventions

Markdown files use two spaces for indentation. Trailing whitespace is preserved because some Markdown renderers use two trailing spaces to represent a line break.

## Important

A text editor may read `.editorconfig` automatically, but not every EditorConfig property is supported by every editor. Install EditorConfig support in your IDE when necessary.

Do not add conflicting formatting rules to IDE-specific settings. If a formatter configuration conflicts with `.editorconfig`, resolve the conflict in the shared project configuration rather than relying on an individual developer's local setup.
