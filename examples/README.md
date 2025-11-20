# TypeScript Type Imports - Examples

This directory contains example configurations and code demonstrating TypeScript type-only imports.

## Files in this Directory

### 1. `tsconfig.example.json`
A complete example TypeScript configuration file with:
- `verbatimModuleSyntax: true` for modern TypeScript 5.0+ projects
- Alternative legacy options commented for older versions
- Strict type checking enabled
- All necessary compiler options explained

**How to use:**
- Copy this file to your project root as `tsconfig.json`
- Uncomment the legacy options if using TypeScript < 5.0
- Adjust `include` and `exclude` paths as needed

### 2. `.eslintrc.example.json`
An ESLint configuration that enforces consistent type imports with:
- `@typescript-eslint/consistent-type-imports` rule
- Inline type import style (recommended)
- Auto-fix capability

**How to use:**
- Copy this file to your project root as `.eslintrc.json`
- Install dependencies: `npm install --save-dev @typescript-eslint/parser @typescript-eslint/eslint-plugin`
- Run: `npx eslint --fix .` to automatically fix type imports

### 3. `typescript-type-imports-examples.ts`
Comprehensive code examples showing:
- Type-only imports (correct and incorrect)
- Mixed imports (types and values)
- Different import styles
- Re-exports
- Best practices

**How to use:**
- Review this file to understand different scenarios
- Use the patterns in your own code
- Reference the comments for explanations

## Quick Start

### For a New Typescript 5.0+ Project

1. Copy the configuration:
```bash
cp examples/tsconfig.example.json tsconfig.json
cp examples/.eslintrc.example.json .eslintrc.json
```

2. Install ESLint dependencies:
```bash
npm install --save-dev @typescript-eslint/parser @typescript-eslint/eslint-plugin eslint
```

3. Verify your setup:
```bash
npx tsc --noEmit
npx eslint --fix .
```

### For Migrating an Existing Project

1. Review your current `tsconfig.json`:
```bash
cat tsconfig.json
```

2. Compare with `tsconfig.example.json` to see recommended settings

3. Gradually add strict settings:
   - First: `isolatedModules: true`
   - Then: `verbatimModuleSyntax: true`
   - Finally: Run ESLint to auto-fix imports

4. Fix any remaining issues manually using the examples

## Testing the Examples

While these are example files and not meant to be compiled directly, you can:

1. Create a test TypeScript project:
```bash
mkdir test-project
cd test-project
npm init -y
npm install typescript @types/node
```

2. Copy the example config:
```bash
cp ../tsconfig.example.json ./tsconfig.json
```

3. Create actual module files to import from

4. Test the import patterns from `typescript-type-imports-examples.ts`

## Common Issues and Solutions

### Issue: "Cannot find module"
**Solution:** Make sure the module paths in examples match your project structure

### Issue: ESLint not fixing imports
**Solution:** 
- Ensure TypeScript parser is configured
- Check that the project path is set in parserOptions
- Run with `--debug` flag to see what's happening

### Issue: Type imports still causing errors
**Solution:**
- Check TypeScript version: `npx tsc --version`
- Verify `verbatimModuleSyntax` is in your config
- Ensure you're using inline `type` keyword syntax

## Additional Resources

- [Main TypeScript Type Imports Guide](../TYPESCRIPT_TYPE_IMPORTS.md)
- [Configuration Comparison](../TYPESCRIPT_CONFIG_COMPARISON.md)
- [Quick Reference Cheat Sheet](../QUICK_REFERENCE.md)

## Contributing

If you have additional examples or configurations that would be helpful, please feel free to add them to this directory.
