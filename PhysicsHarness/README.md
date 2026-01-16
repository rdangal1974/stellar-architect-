# Physics Harness

## Overview

The Physics Harness is a standalone C# console application that validates the formation logic for all star types in the Stellar Architect game.

## Purpose

- Validate physics thresholds independent of Unity
- Test formation logic with 16 unit tests
- Ensure numerical correctness before game implementation

## Star Formation Thresholds

| Star Type | Mass Threshold | Density Threshold | Test Cases |
|-----------|---|---|---|
| Red Dwarf | ? 0.5 | ? 2.0 | 4 |
| Yellow Star | ? 1.5 | ? 3.5 | 4 |
| Blue Giant | ? 4.0 | ? 6.0 | 4 |
| Black Hole | ? 10.0 | ? 15.0 | 4 |

## Running Tests

### Option 1: Run Console App (Recommended)
```bash
cd PhysicsHarness
dotnet run
```

Output will show:
- All 16 tests with pass/fail status
- Summary: PASSED/FAILED count
- Color-coded results (green=pass, red=fail)

### Option 2: Run with xUnit (If installed)
```bash
dotnet test
```

## Test Coverage

Each star type has 4 tests:
1. ? At exact threshold (should PASS)
2. ? Above threshold (should PASS)
3. ? Below mass threshold (should FAIL)
4. ? Below density threshold (should FAIL)

## Results

**Test Date:** January 16, 2026  
**Total Tests:** 16  
**Status:** ? ALL PASSING

- Red Dwarf: 4/4 ?
- Yellow Star: 4/4 ?
- Blue Giant: 4/4 ?
- Black Hole: 4/4 ?

## Implementation Notes

- Uses simple threshold comparison logic
- No complex physics simulation required
- Foundation for Week 2 Unity integration
- Ready for GravitySystem implementation

## Files

- `FormationLogic.cs` - Physics formation definitions
- `FormationLogicTests.cs` - xUnit test cases
- `Program.cs` - Console test runner
- `PhysicsHarness.csproj` - Project configuration
