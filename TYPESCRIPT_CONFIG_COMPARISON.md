# TypeScript Configuration Comparison: Type Import Requirements

This document compares different TypeScript configurations and how they affect type import requirements.

## Configuration Scenarios

### Scenario A: Default TypeScript Configuration (No type keyword required)

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "commonjs",
    "strict": true
  }
}
```

**Code:**
```typescript
// ✅ This works - 'type' keyword is optional
import { BookingAccommodation } from '../offerData/bookingAccommodation';

const booking: BookingAccommodation = { /* ... */ };
```

**When to use:** Legacy projects, simple Node.js applications without bundlers.

---

### Scenario B: Isolated Modules (type keyword recommended but not enforced)

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "esnext",
    "isolatedModules": true,
    "strict": true
  }
}
```

**Code:**
```typescript
// ⚠️ This might work, but may cause issues with some transpilers
import { BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ This is safer
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

const booking: BookingAccommodation = { /* ... */ };
```

**When to use:** Projects using Babel, SWC, or esbuild as transpilers.

---

### Scenario C: Strict Import Checking (TypeScript 3.8 - 4.9)

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "esnext",
    "isolatedModules": true,
    "importsNotUsedAsValues": "error",
    "strict": true
  }
}
```

**Code:**
```typescript
// ❌ ERROR: 'BookingAccommodation' is a type and must be imported using a type-only import
import { BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ CORRECT
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

const booking: BookingAccommodation = { /* ... */ };
```

**When to use:** TypeScript 3.8 to 4.9 projects wanting strict type import checking.

---

### Scenario D: Modern TypeScript Configuration (TypeScript 5.0+)

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "esnext",
    "moduleResolution": "bundler",
    "verbatimModuleSyntax": true,
    "isolatedModules": true,
    "strict": true
  }
}
```

**Code:**
```typescript
// ❌ ERROR: Type-only import must use 'import type' or inline 'type' keyword
import { BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ CORRECT - Option 1 (Recommended)
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ CORRECT - Option 2
import type { BookingAccommodation } from '../offerData/bookingAccommodation';

const booking: BookingAccommodation = { /* ... */ };
```

**When to use:** New projects using TypeScript 5.0+, modern build tools (Vite, etc.).

---

### Scenario E: Playwright TypeScript Configuration

**playwright.config.ts** (implicit tsconfig):
```json
{
  "compilerOptions": {
    "target": "ESNext",
    "module": "commonjs",
    "moduleResolution": "node",
    "sourceMap": true,
    "verbatimModuleSyntax": true  // Often enabled by Playwright
  }
}
```

**Code:**
```typescript
import { test, expect } from '@playwright/test';
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

test('booking test', async ({ page }) => {
  const booking: BookingAccommodation = { /* ... */ };
  // Test implementation
});
```

**When to use:** Playwright test projects with TypeScript.

---

## Side-by-Side Comparison

| Feature | Default | isolatedModules | importsNotUsedAsValues | verbatimModuleSyntax |
|---------|---------|-----------------|------------------------|----------------------|
| TypeScript Version | Any | Any | 3.8+ | 5.0+ |
| Type keyword required? | No | Recommended | Yes (if "error") | Yes |
| Mixed imports allowed? | Yes | Yes | Yes | Yes |
| Transpiler compatible? | Maybe | Yes | Yes | Yes |
| Best for | Simple projects | Bundled projects | TS 3.8-4.9 strict | Modern TS 5.0+ |

## Why Same Code Works in Different Repos

The same TypeScript code may work in one repository but not another because:

### 1. Different TypeScript Versions

**Repo A (TypeScript 4.5):**
- Doesn't support `verbatimModuleSyntax`
- Uses `importsNotUsedAsValues: "remove"` (default)
- Type keyword is optional

**Repo B (TypeScript 5.2):**
- Supports `verbatimModuleSyntax: true`
- Type keyword is required

### 2. Different Build Tool Defaults

**Repo A (Webpack):**
```json
{
  "compilerOptions": {
    "module": "commonjs"
  }
}
```
- May not enforce type imports

**Repo B (Vite):**
```json
{
  "compilerOptions": {
    "module": "esnext",
    "verbatimModuleSyntax": true
  }
}
```
- Enforces type imports

### 3. Different Framework Scaffolding

**Repo A (Created with create-react-app):**
- Older default configuration
- `isolatedModules: true` but lenient

**Repo B (Created with Vite + Playwright):**
- Modern default configuration
- `verbatimModuleSyntax: true` enabled

### 4. Different Team Conventions

**Repo A:**
- Team prefers loose type checking
- No ESLint enforcement

**Repo B:**
- Team enforces strict type checking
- ESLint with `@typescript-eslint/consistent-type-imports`

## Migration Between Configurations

### Migrating from Lenient to Strict

**Step 1: Update TypeScript version (if needed)**
```bash
npm install typescript@latest --save-dev
```

**Step 2: Update tsconfig.json**
```json
{
  "compilerOptions": {
    // Add or update
    "verbatimModuleSyntax": true,
    "isolatedModules": true
  }
}
```

**Step 3: Fix imports automatically (with ESLint)**
```bash
npm install --save-dev @typescript-eslint/parser @typescript-eslint/eslint-plugin
npx eslint --fix .
```

**Step 4: Fix remaining imports manually**
```typescript
// Before
import { MyType } from './module';

// After
import { type MyType } from './module';
```

**Step 5: Verify build**
```bash
npx tsc --noEmit
```

## Recommendations

### For New Projects (TypeScript 5.0+)
```json
{
  "compilerOptions": {
    "verbatimModuleSyntax": true,
    "isolatedModules": true,
    "strict": true
  }
}
```

### For Existing Projects (TypeScript 3.8 - 4.9)
```json
{
  "compilerOptions": {
    "importsNotUsedAsValues": "error",
    "preserveValueImports": true,
    "isolatedModules": true,
    "strict": true
  }
}
```

### For Legacy Projects
```json
{
  "compilerOptions": {
    "strict": true,
    // Add gradually:
    // "isolatedModules": true
  }
}
```

## Quick Reference

**When you see this error:**
```
'X' is a type and must be imported using a type-only import when 'verbatimModuleSyntax' is enabled
```

**Fix it like this:**
```typescript
// Before (error)
import { X } from './module';

// After (fixed)
import { type X } from './module';
```

**When you see this error:**
```
This import is only used as a type and must use 'import type'
```

**You have two options:**
```typescript
// Option 1: Inline type (recommended)
import { type X } from './module';

// Option 2: import type statement
import type { X } from './module';
```
