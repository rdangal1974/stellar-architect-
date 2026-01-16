# Week 2 Thursday - Unity Setup Checklist
## Real-Time Progress Tracker

**Date:** January 16, 2026  
**Time Started:** ___:___ AM/PM  

---

## ? Phase 1: Unity Opens (5 minutes)

**?? DETAILED INSTRUCTIONS:** See `Documentation/HOW_TO_OPEN_UNITY.md` for step-by-step guide

### Quick Steps:
- [ ] Unity Hub opened
- [ ] Project added to Unity Hub (`C:\dev\steller\stellar-architect`)
- [ ] Unity 2022.3 LTS selected
- [ ] Project opened (wait for loading...)
- [ ] Scripts compiling...
- [ ] Console shows compilation progress
- [ ] **CRITICAL:** Console shows "0 errors" ?

**If you see compilation errors:**
1. Read the error message carefully
2. Check which script has the error
3. Make sure all 12 scripts exist in `Assets/Scripts/Physics/`
4. Try: Assets ? Reimport All

**Need help opening Unity?** 
? See: `Documentation/HOW_TO_OPEN_UNITY.md` (detailed step-by-step with screenshots)

**Time Completed:** ___:___ AM/PM

---

## ? Phase 2: Verify Scripts Compiled (2 minutes)

- [ ] Unity Console tab visible
- [ ] No red error messages
- [ ] Bottom-right shows "Ready" (not "Compiling...")
- [ ] Project window shows `Assets/Scripts/Physics/` folder structure:
  - [ ] Config/
  - [ ] Core/
  - [ ] Components/
  - [ ] Systems/
  - [ ] Editor/
  - [ ] Debug/

**Screenshot Checkpoint:** Take a screenshot of Unity with no errors

**Time Completed:** ___:___ AM/PM

---

## ? Phase 3: Create PhysicsConstants Asset (2 minutes)

- [ ] In Unity menu bar, look for **"Stellar Architect"** menu
- [ ] Click: **Stellar Architect ? Physics ? Create Physics Constants Asset**
- [ ] Console shows: "? PhysicsConstants asset created at: Assets/ScriptableObjects/Physics/DefaultPhysicsConstants.asset"
- [ ] Project window: Navigate to `Assets/ScriptableObjects/Physics/`
- [ ] See: `DefaultPhysicsConstants.asset` ?
- [ ] Click the asset, Inspector shows:
  - [ ] Gravitational Scale: 1
  - [ ] Softening Length: 2
  - [ ] Max Force: 10
  - [ ] Stability Threshold: -0.8

**If menu doesn't exist:**
1. Check Console for script errors
2. Wait for Unity to finish compiling
3. Try: Assets ? Reimport All
4. Restart Unity if needed

**Screenshot Checkpoint:** Screenshot of PhysicsConstants in Inspector

**Time Completed:** ___:___ AM/PM

---

## ? Phase 4: Create Test Scene (3 minutes)

- [ ] Unity menu: **Stellar Architect ? Physics ? Create Test Scene (2 Bodies)**
- [ ] Console shows: "? Two-body test scene created! Press Play to test gravity."
- [ ] Hierarchy window shows:
  - [ ] Physics Manager
  - [ ] Star 1 (Red Dwarf)
  - [ ] Star 2 (Yellow Star)
  - [ ] Main Camera
- [ ] Scene view shows:
  - [ ] Two spheres visible (one red, one yellow)
  - [ ] Stars are separated (not overlapping)
  - [ ] Camera can see both stars

**Save the scene:**
- [ ] File ? Save As...
- [ ] Name: `TestScene_TwoBody`
- [ ] Location: `Assets/Scenes/`
- [ ] Click Save

**Screenshot Checkpoint:** Scene view showing both stars

**Time Completed:** ___:___ AM/PM

---

## ? Phase 5: Add Debug UI (1 minute)

- [ ] Hierarchy: Click **Main Camera**
- [ ] Inspector: Click **Add Component**
- [ ] Search: "Physics Debug UI"
- [ ] Click **Physics Debug UI** to add
- [ ] Inspector shows PhysicsDebugUI component:
  - [ ] Show Debug UI: ? (checked)
  - [ ] Show Body Info: ? (checked)
  - [ ] Show Stability Info: ? (checked)
  - [ ] Show Performance Info: ? (checked)

**Checkpoint:** Main Camera has PhysicsDebugUI component attached

**Time Completed:** ___:___ AM/PM

---

## ? Phase 6: PRESS PLAY! (2 minutes)

### Before Playing:
- [ ] Save scene (Ctrl+S)
- [ ] Scene view shows both stars clearly
- [ ] Hierarchy shows all 4 objects

### Press Play:
- [ ] Click **Play button** (??) at top center
- [ ] OR press: **F5** / **Ctrl+P**
- [ ] Unity enters Play Mode (scene view tints blue)

### Watch for Success Indicators:

**Console Messages (within 1 second):**
- [ ] "GravitySystem initialized with Newtonian gravity and stability calculations."
- [ ] "Registered body: Star 1 (Red Dwarf) (Total: 1)"
- [ ] "Registered body: Star 2 (Yellow Star) (Total: 2)"

**Game View (top-left corner):**
- [ ] Debug UI visible
- [ ] Shows: "=== STELLAR ARCHITECT - PHYSICS DEBUG ==="
- [ ] Bodies: 2
- [ ] System Stable: YES ? (or NO ?)
- [ ] Binding Energy: [some number]
- [ ] FPS: ~60

**Scene View - Physics in Action:**
- [ ] Stars are MOVING toward each other! ??
- [ ] Movement is smooth (not jerky)
- [ ] Stars accelerate as they get closer

### Enable Gizmos (in Scene view):
- [ ] Click "Gizmos" button in Scene view toolbar
- [ ] You should see:
  - [ ] **Cyan lines** from stars (velocity vectors)
  - [ ] **Yellow lines** from stars (acceleration vectors)
  - [ ] Lines point toward the other star

**?? SUCCESS CHECKPOINT: If stars are moving toward each other, YOU DID IT! ??**

**Screenshot Checkpoint:** 
- Take screenshot of Game view with debug UI
- Take screenshot of Scene view with velocity vectors

**Time Completed:** ___:___ AM/PM

---

## ? Phase 7: Stop and Verify (1 minute)

- [ ] Press **Stop button** (?) to exit Play Mode
- [ ] Scene resets to original positions (stars apart again)
- [ ] No errors in Console
- [ ] Scene still saved

**Test Again:**
- [ ] Press Play again
- [ ] Verify stars still move toward each other
- [ ] Press Stop

**Checkpoint:** Physics is reproducible and working consistently

**Time Completed:** ___:___ AM/PM

---

## ?? Phase 1 Complete!

### What You Accomplished:
? Unity project opened successfully  
? All scripts compiled with no errors  
? PhysicsConstants asset created  
? First test scene created  
? Debug UI functional  
? **PHYSICS WORKING!** - Stars attract due to gravity  

### Statistics:
- **Time Taken:** ___ minutes (target: 15 minutes)
- **Errors Encountered:** ___ (target: 0)
- **Screenshots Taken:** ___ (target: 3-4)

---

## ?? Screenshot Collection

Save these for documentation:
1. [ ] Unity with no compilation errors
2. [ ] PhysicsConstants asset in Inspector
3. [ ] Scene view with both stars
4. [ ] Game view with debug UI
5. [ ] Scene view with velocity Gizmos

---

## ?? Troubleshooting Log

**If you encountered any issues, document them here:**

### Issue #1:
- **Problem:** ________________________________________________
- **Solution:** ________________________________________________
- **Time Lost:** ___ minutes

### Issue #2:
- **Problem:** ________________________________________________
- **Solution:** ________________________________________________
- **Time Lost:** ___ minutes

---

## ?? Next Steps (Thursday Afternoon)

Now that basic physics is working, you can:

1. **Create Binary Orbit Scene** (30 min)
   - Menu: Stellar Architect ? Physics ? Create Test Scene (Binary System)
   - Watch stars orbit each other instead of colliding

2. **Add Trail Renderers** (20 min)
   - Select Star 1 in Hierarchy
   - Add Component ? Physics Body Trail
   - Repeat for Star 2
   - See orbital paths visualized

3. **Create Three-Body Scene** (20 min)
   - Menu: Stellar Architect ? Physics ? Create Test Scene (3 Bodies)
   - Observe chaotic three-body problem

4. **Experiment with Physics Values** (30 min)
   - Select PhysicsConstants asset
   - Try different Gravitational Scale values (0.5, 1.0, 2.0)
   - Try different Softening Length values (1.0, 2.0, 5.0)
   - Observe how physics changes

5. **Take Break & Document** (30 min)
   - Organize screenshots
   - Update WEEK2_PROGRESS_TRACKER.md
   - Git commit progress

**Total Thursday Time:** ~2.5 hours remaining after this setup

---

## ?? Thursday End-of-Day Goals

By end of today (5 hours total):
- [x] Basic 2-body scene working ? (DONE!)
- [ ] Binary orbit scene working
- [ ] 3-body scene created
- [ ] Trail renderers added
- [ ] Screenshots and documentation
- [ ] Git commit: "feat(unity): Week 2 Day 1 complete"

---

**?? CONGRATULATIONS! You've completed Phase 1 of Week 2! ??**

**Current Status:** Physics is working in Unity! ?  
**Next Task:** Create binary orbit scene  
**Feeling:** Hopefully excited! ??

---

**Save This File:** `Documentation/WEEK2_DAY1_CHECKLIST.md`  
**Update As You Go:** Check off items as you complete them  
**Share Success:** Take screenshots to remember this moment!
