# ?? Week 2 - Day 1: First Playable Puzzle Setup

**Time:** 2 hours  
**Goal:** Build and test your first puzzle with win condition

---

## ? What You Now Have

1. **PhysicsBody.cs** - Star formation + merge mechanics ?
2. **InputManager.cs** - Drag, merge, nudge interactions ?
3. **StarFormationDetector.cs** - Detects star types ?
4. **PuzzleManager.cs** - Win/lose conditions ?

---

## ?? Quick Setup (30 minutes)

### Step 1: Create Test Puzzle Scene

1. **In Unity**, go to `File ? New Scene`
2. Save as `Assets/Scenes/Puzzle_01_RedDwarf.unity`
3. **Delete** default Main Camera and Directional Light

### Step 2: Add Camera

1. `GameObject ? Camera`
2. Position: `(0, 0, -10)`
3. Set `Projection ? Orthographic`
4. Set `Size ? 10`

### Step 3: Add Physics System

1. Create empty GameObject: `PhysicsSystem`
2. Add component: `GravitySystem`
3. **Assign PhysicsConstants:**
   - Look in `Assets/` for `PhysicsConstants` asset
   - If missing, create: `Assets ? Create ? Stellar Architect ? Physics Constants`
   - Drag onto `GravitySystem` component

### Step 4: Add Puzzle Manager

1. Create empty GameObject: `PuzzleManager`
2. Add components:
   - `PuzzleManager`
   - `StarFormationDetector`
3. **Set Puzzle Goal:**
   - Target Star Type: `RedDwarf`
   - Require Stability: `false` (for first puzzle)
   - Time Limit: `0` (no limit)

### Step 5: Add Input Manager

1. Create empty GameObject: `InputManager`
2. Add component: `InputManager`
3. **Assign settings:**
   - Merge Hold Time: `0.5`
   - Nudge Force: `0.2`
   - Max Drag Speed: `5.0`

### Step 6: Create Mass Units (3 bodies)

**Body 1:**
1. `GameObject ? 3D Object ? Sphere`
2. Name: `MassUnit_01`
3. Position: `(-3, 0, 0)`
4. Add component: `PhysicsBody`
5. **Set values:**
   - Mass: `0.2`
   - Density: `0.8`
   - Physics Constants: (same asset)
6. Add component: `PhysicsBodyAutoRegister`

**Body 2:**
1. Duplicate `MassUnit_01` (Ctrl+D)
2. Name: `MassUnit_02`
3. Position: `(0, 2, 0)`
4. **PhysicsBody values:**
   - Mass: `0.2`
   - Density: `0.7`

**Body 3:**
1. Duplicate `MassUnit_01` (Ctrl+D)
2. Name: `MassUnit_03`
3. Position: `(3, 0, 0)`
4. **PhysicsBody values:**
   - Mass: `0.15`
   - Density: `0.9`

---

## ?? Test the Puzzle (10 minutes)

### Expected Behavior:

1. **Hit Play**
2. **Drag** any mass unit (click + drag)
3. **Merge** two units:
   - Hold for 0.5s
   - Drag onto another unit
   - They should combine
4. **Keep merging** until you reach:
   - Total mass ? 0.5
   - Total density ? 2.0
5. **Win condition** triggers:
   - Console shows: "PUZZLE WON! Formed RedDwarf"
   - Top-left UI shows success

---

## ?? Troubleshooting

| Problem | Solution |
|---------|----------|
| Bodies don't move | Check InputManager is in scene |
| No merge happening | Check hold time (0.5s), try holding longer |
| No star formation | Check PhysicsConstants is assigned to ALL PhysicsBodies |
| Win doesn't trigger | Check PuzzleManager Target = RedDwarf, verify mass/density |
| Bodies fall down | Check GravitySystem is active, PhysicsBody has `useGravity = false` |

---

## ?? Win Condition Math

To form a **Red Dwarf**, you need:
- Mass ? 0.5
- Density ? 2.0

**Your 3 units:**
- Unit 1: 0.2 mass, 0.8 density
- Unit 2: 0.2 mass, 0.7 density
- Unit 3: 0.15 mass, 0.9 density

**After merging all 3:**
- Total mass: 0.2 + 0.2 + 0.15 = **0.55** ? (>= 0.5)
- Avg density: (0.8×0.2 + 0.7×0.2 + 0.9×0.15) / 0.55 = **0.79** ? (< 2.0)

**Issue:** Density too low! Need to adjust starting values.

**Fixed values:**
- Unit 1: 0.2 mass, **2.5** density
- Unit 2: 0.2 mass, **2.0** density
- Unit 3: 0.15 mass, **2.2** density

Now merged density = **2.24** ?

---

## ? Success Criteria

By end of Day 1, you should have:
- [x] Scene with 3 mass units
- [x] Drag mechanic working
- [x] Merge mechanic working
- [x] Win condition triggers when Red Dwarf forms
- [x] Console logs "PUZZLE WON!"
- [x] Can restart puzzle

---

## ?? Screenshot This!

When you win, take a screenshot showing:
1. Console with "PUZZLE WON!" message
2. Top-left UI showing success
3. The merged Red Dwarf body in scene

**Commit:** `git commit -m "First playable puzzle complete - Red Dwarf formation"`

---

## ?? Tomorrow (Day 2)

- Add UI feedback (success/fail popups)
- Create second puzzle (stable orbit)
- Add level progression
- Polish interactions

---

**READY?** Follow the steps above and let me know when you hit Play! ??
