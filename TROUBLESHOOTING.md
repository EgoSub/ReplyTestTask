# TypeScript Type Imports - Troubleshooting Guide

This guide helps you diagnose and fix common issues related to TypeScript type imports.

## Common Errors and Solutions

### Error 1: "'X' is a type and must be imported using a type-only import"

**Full Error Message:**
```
'BookingAccommodation' is a type and must be imported using a type-only import when 'verbatimModuleSyntax' is enabled.
```

**Cause:**
- Your `tsconfig.json` has `verbatimModuleSyntax: true`
- You're importing a type without the `type` keyword

**Solution:**
```typescript
// ❌ Before
import { BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ After
import { type BookingAccommodation } from '../offerData/bookingAccommodation';
```

---

### Error 2: "This import is only used as a type"

**Full Error Message:**
```
This import is only used as a type and must use 'import type' when 'importsNotUsedAsValues' is set to 'error'.
```

**Cause:**
- Your `tsconfig.json` has `importsNotUsedAsValues: "error"`
- You're importing something that's only used as a type

**Solution Option 1 (Recommended):**
```typescript
import { type BookingAccommodation } from '../offerData/bookingAccommodation';
```

**Solution Option 2:**
```typescript
import type { BookingAccommodation } from '../offerData/bookingAccommodation';
```

---

### Error 3: "Cannot use 'import type' with a value"

**Full Error Message:**
```
'createUser' is a value and cannot be imported using 'import type'.
```

**Cause:**
- You used `import type` on a value (function, class, etc.)

**Solution:**
```typescript
// ❌ Before
import type { createUser } from './userService';

// ✅ After - separate value from type
import { createUser } from './userService';
import { type User } from './userService';

// ✅ Or combine them
import { type User, createUser } from './userService';
```

---

### Error 4: "Re-exporting a type when 'isolatedModules' is enabled requires using 'export type'"

**Full Error Message:**
```
Re-exporting a type when 'isolatedModules' is enabled requires using 'export type'.
```

**Cause:**
- You're re-exporting a type without the `type` keyword
- `isolatedModules: true` in your config

**Solution:**
```typescript
// ❌ Before
export { BookingAccommodation } from './types';

// ✅ After
export { type BookingAccommodation } from './types';

// ✅ Or
export type { BookingAccommodation } from './types';
```

---

### Error 5: "Module has no exported member 'type'"

**Full Error Message:**
```
Module '"./types"' has no exported member 'type'.
```

**Cause:**
- Syntax error: `type` is in the wrong position

**Solution:**
```typescript
// ❌ Wrong
import { User type } from './types';

// ✅ Correct
import { type User } from './types';

// ❌ Wrong
import type User from './types';  // (for named exports)

// ✅ Correct
import type { User } from './types';
```

---

## Diagnostic Steps

### Step 1: Check Your TypeScript Version

```bash
npx tsc --version
```

**What to look for:**
- TypeScript 5.0+: Use `verbatimModuleSyntax`
- TypeScript 3.8-4.9: Use `importsNotUsedAsValues`
- TypeScript < 3.8: Type imports not supported

---

### Step 2: Check Your TypeScript Configuration

```bash
cat tsconfig.json
```

**Look for these settings:**
```json
{
  "compilerOptions": {
    "verbatimModuleSyntax": true,      // ⚠️ Requires type imports
    "importsNotUsedAsValues": "error", // ⚠️ Requires type imports
    "isolatedModules": true             // ⚠️ May require type imports
  }
}
```

---

### Step 3: Check What You're Importing

**To determine if something is a type or value:**

```typescript
// TYPE - Only used in type positions
import { type User } from './types';
const user: User = { name: 'John' };  // Type annotation only

// VALUE - Used at runtime
import { createUser } from './types';
const user = createUser();  // Function call at runtime

// BOTH
import { type User, createUser } from './types';
const user: User = createUser();
```

**Quick test:**
- If it's after a colon (`:`) → Type
- If it's used with `new`, called as function, or assigned → Value
- If it's in angle brackets (`<User>`) → Type

---

### Step 4: Validate Your Imports

Run TypeScript compiler in check mode:

```bash
npx tsc --noEmit
```

This will show all type-related errors without generating output files.

---

### Step 5: Auto-Fix with ESLint

If you have many imports to fix:

```bash
# Install ESLint with TypeScript plugin
npm install --save-dev @typescript-eslint/parser @typescript-eslint/eslint-plugin

# Run auto-fix
npx eslint --fix .
```

---

## Debugging Tips

### Tip 1: Check Build Tool Configuration

Different build tools have different defaults:

**Vite:**
- Often sets `verbatimModuleSyntax: true` by default
- Check `vite.config.ts`

**Webpack:**
- Uses `ts-loader` or `babel-loader`
- Check `webpack.config.js` and loader options

**Next.js:**
- Has its own TypeScript configuration
- Check `next.config.js`

---

### Tip 2: Check Framework Configuration

**Playwright:**
```bash
# Check if Playwright has its own tsconfig
cat playwright.config.ts
```

**Jest:**
```bash
# Check Jest's TypeScript configuration
cat jest.config.js
# Look for 'preset: ts-jest' or similar
```

---

### Tip 3: Check for Multiple tsconfig Files

```bash
find . -name "tsconfig*.json" | grep -v node_modules
```

You might have:
- `tsconfig.json` (main config)
- `tsconfig.build.json` (build config)
- `tsconfig.test.json` (test config)

Different configs may have different settings!

---

### Tip 4: Check Inherited Configurations

```json
{
  "extends": "./tsconfig.base.json",  // ⚠️ Check base config too
  "compilerOptions": {
    // ...
  }
}
```

---

## Environment-Specific Issues

### Issue: Works locally but fails in CI

**Cause:** Different TypeScript versions or configurations

**Solution:**
```bash
# Lock TypeScript version
npm install --save-dev --save-exact typescript@5.2.2

# Check node_modules in CI
npm list typescript
```

---

### Issue: Works in one IDE but not another

**Cause:** IDEs may use different TypeScript versions

**Solution:**
- VS Code: Check workspace TypeScript version (bottom right corner)
- IntelliJ/WebStorm: Check TypeScript service version in settings
- Force IDE to use project TypeScript: Add to workspace settings

**VS Code (.vscode/settings.json):**
```json
{
  "typescript.tsdk": "node_modules/typescript/lib"
}
```

---

### Issue: Works in development but fails in build

**Cause:** Different configurations for dev vs build

**Solution:**
```bash
# Check both modes
npm run dev    # Development
npm run build  # Production

# Compare configurations
cat tsconfig.json
cat tsconfig.build.json  # If it exists
```

---

## Quick Fixes Checklist

When you encounter a type import error:

- [ ] **Check TypeScript version**: `npx tsc --version`
- [ ] **Check tsconfig.json**: Look for `verbatimModuleSyntax` or `importsNotUsedAsValues`
- [ ] **Identify if it's a type or value**: Look at how you're using the import
- [ ] **Apply the fix**:
  - Type only: `import { type X } from './module'`
  - Value only: `import { X } from './module'`
  - Both: `import { type X, Y } from './module'`
- [ ] **Test the fix**: `npx tsc --noEmit`
- [ ] **Consider auto-fixing**: Use ESLint if you have many errors

---

## Prevention

### For New Projects

Start with strict settings from day one:

```json
{
  "compilerOptions": {
    "verbatimModuleSyntax": true,
    "isolatedModules": true,
    "strict": true
  }
}
```

Add ESLint rule to enforce consistency:

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

---

### For Existing Projects

Migrate gradually:

1. **Week 1**: Add `isolatedModules: true`
2. **Week 2**: Add `verbatimModuleSyntax: true`
3. **Week 3**: Run ESLint auto-fix
4. **Week 4**: Fix remaining issues manually

---

## Getting Help

If you're still stuck:

1. **Check TypeScript documentation**: https://www.typescriptlang.org/docs/
2. **Check the full error message**: Sometimes there are helpful hints
3. **Search GitHub issues**: Your build tool or framework may have known issues
4. **Ask for help**: Include:
   - TypeScript version
   - Relevant tsconfig.json settings
   - Full error message
   - Code snippet

---

## Additional Resources

- [TypeScript Type Imports Guide](./TYPESCRIPT_TYPE_IMPORTS.md)
- [Configuration Comparison](./TYPESCRIPT_CONFIG_COMPARISON.md)
- [Quick Reference](./QUICK_REFERENCE.md)
- [Examples](./examples/)
