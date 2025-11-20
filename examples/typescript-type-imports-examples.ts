// Example: Type-only imports in TypeScript
// This file demonstrates when and how to use the 'type' keyword in imports

// ============================================================================
// SCENARIO 1: Type-only import (used only for type annotation)
// ============================================================================

// ❌ WRONG - Without 'type' keyword (will cause error with verbatimModuleSyntax: true)
// import { BookingAccommodation } from '../offerData/bookingAccommodation';

// ✅ CORRECT - With 'type' keyword (inline style - RECOMMENDED)
import { type BookingAccommodation } from '../offerData/bookingAccommodation';

function processBooking(booking: BookingAccommodation): void {
  console.log('Processing booking:', booking);
}

// ============================================================================
// SCENARIO 2: Mixed imports (types and values from same module)
// ============================================================================

// ✅ CORRECT - Mix of type and value imports (inline style - RECOMMENDED)
import { 
  type User,           // Type-only import
  type UserRole,       // Type-only import
  createUser,          // Value import (function)
  UserService          // Value import (class)
} from '../services/userService';

const newUser: User = createUser('John Doe');
const service = new UserService();
const role: UserRole = 'admin';

// ============================================================================
// SCENARIO 3: Import type statement (all imports are types)
// ============================================================================

// ✅ CORRECT - When importing only types from a module
import type { 
  Product,
  ProductCategory,
  ProductPrice 
} from '../models/product';

let product: Product;
let category: ProductCategory;
let price: ProductPrice;

// ============================================================================
// SCENARIO 4: Value imports (no 'type' keyword needed)
// ============================================================================

// ✅ CORRECT - Regular imports for values
import { calculateTotal, validateEmail } from '../utils/helpers';
import { ApiClient } from '../api/client';
import * as constants from '../config/constants';

const total = calculateTotal([1, 2, 3]);
const isValid = validateEmail('test@example.com');
const client = new ApiClient();

// ============================================================================
// SCENARIO 5: Default imports
// ============================================================================

// Type-only default import
import type DefaultConfig from '../config/default';

// Value default import
import DefaultService from '../services/default';

// ============================================================================
// SCENARIO 6: Namespace imports
// ============================================================================

// Type-only namespace import
import type * as Models from '../models';

let userModel: Models.User;
let productModel: Models.Product;

// Value namespace import
import * as Utils from '../utils';

Utils.formatDate(new Date());

// ============================================================================
// SCENARIO 7: Re-exports with type
// ============================================================================

// When re-exporting types from another module
export { type BookingAccommodation } from '../offerData/bookingAccommodation';
export type { User, UserRole } from '../services/userService';

// ============================================================================
// BEST PRACTICES SUMMARY
// ============================================================================

/*
1. Use inline 'type' keyword for flexibility:
   import { type MyType, myFunction } from './module';

2. Use 'import type' when importing only types:
   import type { Type1, Type2 } from './module';

3. Don't use 'type' keyword for value imports:
   import { MyClass, myFunction } from './module';

4. Be consistent across your codebase - use ESLint to enforce:
   "@typescript-eslint/consistent-type-imports": ["error", {
     "prefer": "type-imports",
     "fixStyle": "inline-type-imports"
   }]
*/
