# TypeScript Type-Only Imports: Understanding the `type` Keyword

## Overview

In TypeScript, you may need to use the `type` keyword when importing types, like this:

```typescript
import { type BookingAccommodation } from '../offerData/bookingAccommodation';
```

Instead of the regular import:

```typescript
import { BookingAccommodation } from '../offerData/bookingAccommodation';
```

## Why Is This Required?

The requirement to use `type` in imports depends on specific **TypeScript compiler configuration options**. This is not a universal requirement, which is why the same code might work in one repository but not another.

## TypeScript Compiler Options That Control This Behavior

### 1. `importsNotUsedAsValues` (Deprecated in TS 5.0+)

This option controls how TypeScript handles imports that are only used as types:

```json
{
  "compilerOptions": {
    "importsNotUsedAsValues": "error"
  }
}
```

**Values:**
- `"remove"` (default): Removes imports that are only used as types
- `"preserve"`: Keeps all imports, even if only used as types
- `"error"`: Requires you to explicitly mark type-only imports with the `type` keyword

### 2. `verbatimModuleSyntax` (TypeScript 5.0+)

This is the modern replacement for `importsNotUsedAsValues` and `preserveValueImports`:

```json
{
  "compilerOptions": {
    "verbatimModuleSyntax": true
  }
}
```

When enabled, TypeScript requires:
- Type-only imports to use `import type` or `import { type ... }`
- Type-only exports to use `export type`

This ensures that the emitted JavaScript exactly matches your import/export syntax, which is important for:
- Better tree-shaking
- Avoiding runtime errors with circular dependencies
- Ensuring compatibility with bundlers and transpilers

### 3. `isolatedModules`

When using transpilers like Babel, esbuild, or SWC:

```json
{
  "compilerOptions": {
    "isolatedModules": true
  }
}
```

This option requires type-only imports to be clearly marked, as these transpilers process files in isolation and can't determine what's a type vs. a value across files.

## When Do You Need the `type` Keyword?

You need to use the `type` keyword when:

1. **Your tsconfig.json has strict import settings:**
   - `importsNotUsedAsValues: "error"`
   - `verbatimModuleSyntax: true`
   - `isolatedModules: true` (with certain configurations)

2. **You're importing something used only as a type:**
   ```typescript
   // Used only as a type annotation
   import { type BookingAccommodation } from '../offerData/bookingAccommodation';
   
   function processBooking(booking: BookingAccommodation) {
     // ...
   }
   ```

3. **You're using a transpiler that requires it:**
   - Babel
   - esbuild
   - SWC
   - Vite

## Syntax Options

### Option 1: Inline `type` keyword (Recommended)

```typescript
import { type BookingAccommodation, createBooking } from '../offerData/bookingAccommodation';
```

This allows you to import types and values from the same module.

### Option 2: `import type` statement

```typescript
import type { BookingAccommodation } from '../offerData/bookingAccommodation';
```

This imports **only** types from the module. You cannot import values this way.

## Why Different Repos Have Different Requirements

The same code might work in one repository but not another due to:

1. **Different TypeScript versions:**
   - Older versions (< 3.8) don't support `import type`
   - Newer versions (5.0+) deprecate some options in favor of `verbatimModuleSyntax`

2. **Different tsconfig.json settings:**
   - One repo might have `verbatimModuleSyntax: true`
   - Another repo might use the default settings

3. **Different build tools:**
   - Webpack might handle imports differently than Vite
   - Babel configuration can enforce type-only imports

4. **Framework-specific configurations:**
   - Playwright, Jest, or other testing frameworks might have different TypeScript configurations
   - Framework scaffolding tools might set different defaults

## Best Practices

1. **Always check tsconfig.json:**
   ```bash
   cat tsconfig.json
   # or
   cat playwright.config.ts
   ```

2. **Use inline `type` keyword for flexibility:**
   ```typescript
   import { type MyType, myFunction } from './module';
   ```

3. **Enable strict mode for consistency:**
   ```json
   {
     "compilerOptions": {
       "verbatimModuleSyntax": true,
       "isolatedModules": true
     }
   }
   ```

4. **Use ESLint rules to enforce consistency:**
   ```json
   {
     "rules": {
       "@typescript-eslint/consistent-type-imports": ["error", {
         "prefer": "type-imports",
         "fixStyle": "inline-type-imports"
       }]
     }
   }
   ```

## Migration Guide

If you need to migrate an existing project:

1. **Check your TypeScript version:**
   ```bash
   npx tsc --version
   ```

2. **Review your tsconfig.json:**
   Look for `importsNotUsedAsValues`, `verbatimModuleSyntax`, or `isolatedModules`

3. **Use automatic fixing (if using ESLint):**
   ```bash
   npx eslint --fix .
   ```

4. **Manual conversion:**
   - Find imports that are only used as types
   - Add the `type` keyword: `import { type MyType } from './module'`

5. **Test your build:**
   ```bash
   npm run build
   # or
   npx tsc --noEmit
   ```

## Example: Playwright TypeScript Project

In a Playwright TypeScript project, you might have:

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ESNext",
    "module": "commonjs",
    "moduleResolution": "node",
    "sourceMap": true,
    "strict": true,
    "verbatimModuleSyntax": true,  // This requires type-only imports
    "isolatedModules": true
  }
}
```

**Before (causes error):**
```typescript
import { BookingAccommodation } from '../offerData/bookingAccommodation';

test('booking test', async ({ page }) => {
  const booking: BookingAccommodation = { /* ... */ };
});
```

**After (correct):**
```typescript
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

test('booking test', async ({ page }) => {
  const booking: BookingAccommodation = { /* ... */ };
});
```

## Conclusion

The requirement to use the `type` keyword in imports is **configuration-dependent**, not a TypeScript requirement. It depends on:

- Your TypeScript compiler options in `tsconfig.json`
- Your build tool configuration
- Your framework's default settings

To ensure consistency across projects, always check the TypeScript configuration and consider enabling `verbatimModuleSyntax` for modern TypeScript projects (5.0+) or setting appropriate `importsNotUsedAsValues` options for older versions.
