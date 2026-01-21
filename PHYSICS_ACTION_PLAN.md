# ?? Physics Foundation - Action Plan

**Current Time:** ~11:30 AM  
**Time Available Today:** 3-4 hours  
**Goal:** Fix physics foundation issues before Week 2

---

## ? What's Already Great

Your physics foundation is **85% complete** and well-architected:

```
PhysicsBody.cs ................. ?? 80% (needs formation detection & merge)
GravitySystem.cs ............... ? 100% (perfect)
NewtonianGravityCalculator.cs .. ? 100% (correct inverse-square + softening)
StabilityCalculator.cs ......... ? 100% (matches specs)
PhysicsConstants.cs ............ ? 100% (all values correct)
```

---

## ?? 3 Fixes Needed (2-3 hours total)

### **Fix 1: Star Formation Detection** ?? 30 min
**File:** `PhysicsBody.cs`  
**What:** Add enum StarType and CheckStarFormation() method  
**Why:** Puzzles need to detect when player forms a Red Dwarf

### **Fix 2: Simplify Density** ?? 15 min
**File:** `PhysicsBody.cs`  
**What:** Remove CalculateDensity(), make density Inspector-editable  
**Why:** Designers need manual control over mass AND density

### **Fix 3: Merge Mechanic** ?? 45 min
**File:** `PhysicsBody.cs`  
**What:** Add MergeWith(other) and CanMergeWith(other) methods  
**Why:** Core gameplay mechanic (long-press + drag to combine)

---

## ?? Your Next 3 Hours (Step-by-Step)

### **12:00 PM - 12:45 PM: Apply Fixes**

1. **Open PhysicsBody.cs** in your editor
2. **I'll provide exact code** to add (just copy-paste)
3. **Save and let Unity recompile**
4. **Check for errors** (should be none)

### **12:45 PM - 1:45 PM: Validate & Test**

1. **Open or create** `Test_FormationThresholds.unity`
2. **Add test objects:**
   - 8 spheres with PhysicsBody components
   - Set different mass/density values
3. **Hit Play** and watch console
4. **Verify** star types appear correctly
5. **Test merge** by dragging one body onto another

### **1:45 PM - 2:00 PM: Document Results**

1. **Take screenshots** of test results
2. **Update** `WEEK1_PROGRESS.md` with completion status
3. **Commit to Git:** "Physics foundation validated - all thresholds working"

---

## ?? Ready to Start?

**Option 1 (Recommended):** Say **"apply physics fixes"** and I'll:
- Update PhysicsBody.cs with all 3 fixes
- Create validation test scene setup instructions
- Provide commit message

**Option 2:** I can walk you through each fix one-by-one with explanations

**Option 3:** Just give me the green light and I'll do it all

---

## ?? Expected Outcome

By 2:00 PM today, you'll have:

? **Fully validated physics foundation**  
? **Star formation working** (Red Dwarf, Yellow, Blue, Black Hole)  
? **Merge mechanic implemented** (conservation of mass/momentum)  
? **Test scene proving everything works**  
? **Clean commit ready for Week 2**

**This unlocks Week 2:** Tomorrow you can start building the first playable puzzle with confidence that your physics is rock-solid.

---

## ?? Preview: What This Enables

Once these fixes are in, you'll be able to:

1. **Create first puzzle:** "Form a Red Dwarf by merging 3 mass units"
2. **Implement input:** Drag bodies, long-press to merge
3. **Detect success:** Check if `PhysicsBody.CurrentStarType == StarType.RedDwarf`
4. **Show feedback:** "Success! Red Dwarf formed!" UI

---

**What do you want to do?** (Pick one)

A) Apply all fixes automatically (fastest)  
B) Walk through each fix step-by-step (learning mode)  
C) Just fix the critical one (star formation) for now  
D) Something else (tell me what)
