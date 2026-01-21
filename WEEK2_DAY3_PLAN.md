# ?? Week 2 Day 3: Second Puzzle & Level Selection

**Status:** Week 2 Days 1-2 Complete ?  
**Time Needed:** 2-3 hours  
**Goal:** Build second puzzle (harder) + simple level selection

---

## ?? **Current Status:**

```
? Week 1: Physics Foundation
? Week 2 Day 1: First Puzzle (Red Dwarf)
? Week 2 Day 2: UI System (OnGUI)
? Week 2 Day 3: Second Puzzle + Level Selection (TODAY)
```

---

## ?? **What You'll Build Today:**

### **1. Second Puzzle: Yellow Star Formation (1.5 hours)**
- Harder than Red Dwarf
- Requires: mass ? 1.5, density ? 3.5
- 4 mass units instead of 3
- Introduces strategy: which units to merge first?

### **2. Simple Level Selection (1 hour)**
- Main menu scene
- 2 buttons: Puzzle 1, Puzzle 2
- Scene loading between puzzles
- Track which puzzles are unlocked

---

## ?? **PHASE 1: Build Second Puzzle Scene (1.5 hours)**

### **Step 1: Duplicate First Puzzle (10 min)**

**In Unity:**
1. **Project panel** ? Navigate to `Assets/Scenes`
2. **Right-click** on `Puzzle_01_RedDwarf.unity`
3. **Duplicate** (Ctrl+D)
4. **Rename** to: `Puzzle_02_YellowStar.unity`
5. **Double-click** to open it

---

### **Step 2: Update PuzzleManager Goal (5 min)**

**In the new scene:**
1. **Select `PuzzleManager`** in Hierarchy
2. **Inspector** ? Find `Puzzle Manager` component
3. **Change settings:**
   - Target Star Type: `YellowStar` (instead of RedDwarf)
   - Keep Require Stability: `false`
   - Keep Time Limit: `0`

---

### **Step 3: Add Fourth Mass Unit (10 min)**

**Create 4th sphere:**
1. **Select `MassUnit_03`** in Hierarchy
2. **Duplicate** (Ctrl+D) ? Rename to `MassUnit_04`
3. **Inspector** ? Transform ? Position: `(0, -2, 0)`
4. **PhysicsBody component:**
   - Mass: `0.3`
   - Density: `3.0`

**Update existing mass units for harder puzzle:**
- **MassUnit_01:** Mass: `0.4`, Density: `3.2`
- **MassUnit_02:** Mass: `0.5`, Density: `3.5`
- **MassUnit_03:** Mass: `0.3`, Density: `3.8`
- **MassUnit_04:** Mass: `0.3`, Density: `3.0` (already set)

**Math Check:**
- Total mass: 0.4 + 0.5 + 0.3 + 0.3 = **1.5** ?
- Avg density: **~3.5** ?
- **Yellow Star formed!**

---

### **Step 4: Test Puzzle 2 (10 min)**

1. **Hit Play**
2. **Merge all 4 spheres**
3. **Verify:**
   - Goal shows "Form a YellowStar"
   - Win message appears after merging all 4
   - Restart button works
4. **Stop Play mode**

---

## ?? **PHASE 2: Build Level Selection Menu (1 hour)**

### **Step 1: Create Main Menu Scene (10 min)**

**In Unity:**
1. **File** ? **New Scene**
2. **Save As:** `Assets/Scenes/MainMenu.unity`
3. **Delete** default Main Camera and Directional Light

---

### **Step 2: Add Camera (5 min)**

1. **GameObject** ? **Camera**
2. **Position:** (0, 0, -10)
3. **Projection:** Orthographic
4. **Size:** 10
5. **Background:** Black (or any color you like)

---

### **Step 3: Create Level Selection Script (15 min)**

**I'll create this for you - it will:**
- Show 2 buttons (Puzzle 1, Puzzle 2)
- Load puzzle scenes when clicked
- Simple, clean UI using OnGUI

---

### **Step 4: Add to Main Menu Scene (10 min)**

1. **Create empty GameObject:** `MenuManager`
2. **Add Component:** `MenuUI` (script I'll create)
3. **Hit Play** to see menu

---

### **Step 5: Update Build Settings (10 min)**

**So scenes can load each other:**
1. **File** ? **Build Settings**
2. **Click "Add Open Scenes"** (with MainMenu open)
3. **Open Puzzle_01_RedDwarf** ? **Add Open Scenes**
4. **Open Puzzle_02_YellowStar** ? **Add Open Scenes**
5. **Close Build Settings**

**Your Build Settings should show:**
```
0: MainMenu
1: Puzzle_01_RedDwarf
2: Puzzle_02_YellowStar
```

---

### **Step 6: Test Full Flow (10 min)**

1. **Open MainMenu scene**
2. **Hit Play**
3. **Click "Puzzle 1"** ? Should load Red Dwarf puzzle
4. **Win puzzle** ? Restart or quit
5. **Repeat for Puzzle 2**

---

## ?? **What I'll Create for You:**

### **1. MenuUI.cs**
- Simple OnGUI menu
- 2 buttons for puzzles
- Title screen
- Scene loading

### **2. Updated PuzzleUI.cs**
- Add "Back to Menu" button
- Return to main menu after win

---

## ? **Success Criteria (End of Day 3):**

By end of today, you'll have:
- ? Two working puzzles (Red Dwarf + Yellow Star)
- ? Main menu with level selection
- ? Scene transitions working
- ? Complete gameplay loop: Menu ? Puzzle ? Win ? Menu

---

## ?? **Quick Reference:**

### **Puzzle 1: Red Dwarf**
- 3 mass units
- Total: mass 0.55, density 2.24
- Easy difficulty

### **Puzzle 2: Yellow Star**
- 4 mass units
- Total: mass 1.5, density 3.5
- Medium difficulty

---

## ?? **Ready to Start?**

**Say:** "Start Phase 1" and I'll create the MenuUI script and help you build Puzzle 2!

Or **say:** "Just give me the scripts" and I'll create both scripts right now, then you can follow the steps above.

---

## ?? **Time Breakdown:**

```
Phase 1: Second Puzzle        1.5 hours
  - Duplicate scene           10 min
  - Update settings           5 min
  - Add 4th unit             10 min
  - Adjust mass/density      15 min
  - Test                     10 min
  - Polish                   40 min

Phase 2: Level Selection      1 hour
  - Create menu scene        10 min
  - Add camera              5 min
  - Create script           15 min
  - Setup menu              10 min
  - Build settings          10 min
  - Test full loop          10 min

Total: 2.5 hours
```

---

**Which approach do you prefer?**
- **A)** "Start Phase 1" - I guide you step-by-step
- **B)** "Give me scripts" - I create MenuUI.cs and updated PuzzleUI.cs now
- **C)** "Show me quick version" - Fastest path to get it working

**Reply A, B, or C!** ??
