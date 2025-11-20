# TypeScript Type Imports - Quick Reference Cheat Sheet

## TL;DR - The Answer

**Q: Why do I need to add `type` in imports now?**

**A:** It depends on your `tsconfig.json` settings. If you have:
- `verbatimModuleSyntax: true` (TypeScript 5.0+), OR
- `importsNotUsedAsValues: "error"` (TypeScript 3.8-4.9)

Then you MUST use the `type` keyword for type-only imports.

---

## Quick Fixes

### Error: "must be imported using a type-only import"

```typescript
// ❌ Before
import { MyType } from './module';

// ✅ After
import { type MyType } from './module';
```

### Error: "This import is only used as a type"

```typescript
// ✅ Option 1 (Recommended)
import { type MyType } from './module';

// ✅ Option 2
import type { MyType } from './module';
```

---

## Common Scenarios

### 1. Type Only
```typescript
import { type User } from './types';

const user: User = { name: 'John' };
```

### 2. Mixed (Type + Value)
```typescript
import { type User, createUser } from './userService';

const user: User = createUser();
```

### 3. Multiple Types
```typescript
import { type User, type Role, type Permission } from './types';
```

### 4. All Types from Module
```typescript
import type { User, Role, Permission } from './types';
```

---

## Configuration Quick Check

### Check your TypeScript version
```bash
npx tsc --version
```

### Check your tsconfig.json
```bash
cat tsconfig.json | grep -E "(verbatimModuleSyntax|importsNotUsedAsValues|isolatedModules)"
```

---

## Key Configuration Options

| Option | Version | Effect |
|--------|---------|--------|
| `verbatimModuleSyntax: true` | TS 5.0+ | Requires `type` keyword |
| `importsNotUsedAsValues: "error"` | TS 3.8+ | Requires `type` keyword |
| `isolatedModules: true` | Any | Recommended with bundlers |

---

## Auto-Fix with ESLint

### Install ESLint
```bash
npm install --save-dev @typescript-eslint/parser @typescript-eslint/eslint-plugin
```

### Add to .eslintrc.json
```json
{
  "rules": {
    "@typescript-eslint/consistent-type-imports": [
      "error",
      {
        "prefer": "type-imports",
        "fixStyle": "inline-type-imports"
      }
    ]
  }
}
```

### Run auto-fix
```bash
npx eslint --fix .
```

---

## When Type Keyword is NOT Needed

```typescript
// ✅ Value imports - NO 'type' keyword
import { myFunction } from './utils';
import MyClass from './MyClass';
import * as helpers from './helpers';
```

---

## Re-exports

```typescript
// Type re-export
export { type User } from './types';

// Value re-export
export { createUser } from './userService';
```

---

## Common Mistakes

### ❌ Don't do this
```typescript
// Wrong: 'type' with value import
import { type createUser } from './userService';

// Wrong: No 'type' when needed
import { User } from './types';  // If verbatimModuleSyntax: true
```

### ✅ Do this
```typescript
// Correct: 'type' with types only
import { type User } from './types';

// Correct: No 'type' with values
import { createUser } from './userService';

// Correct: Mixed
import { type User, createUser } from './userService';
```

---

## Different Repos, Different Rules

Why it works in Repo A but not Repo B:

| Aspect | Repo A | Repo B |
|--------|--------|--------|
| TS Version | 4.5 | 5.2 |
| Config | Default | `verbatimModuleSyntax: true` |
| Build Tool | Webpack | Vite |
| Type Required? | ❌ No | ✅ Yes |

---

## Resources

For detailed information, see:
- [TYPESCRIPT_TYPE_IMPORTS.md](./TYPESCRIPT_TYPE_IMPORTS.md) - Full guide
- [TYPESCRIPT_CONFIG_COMPARISON.md](./TYPESCRIPT_CONFIG_COMPARISON.md) - Config comparison
- [examples/](./examples/) - Code examples and configs
