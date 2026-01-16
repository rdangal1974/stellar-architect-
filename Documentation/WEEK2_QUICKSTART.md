# Week 2 Quick Start Guide
## Get Up and Running in 10 Minutes

**Status:** ? Ready to Start  
**Prerequisites:** Week 1 Complete (9 physics scripts created)

---

## ?? **10-Minute Setup (Do This First)**

### **Step 1: Open Unity Project (2 min)**

```bash
cd C:\dev\steller\stellar-architect
# Open in Unity 2022.3 LTS or later
# Wait for scripts to compile
```

**Expected:** No compilation errors in Console

---

### **Step 2: Create PhysicsConstants Asset (2 min)**

1. In Unity, click menu: **`Stellar Architect ? Physics ? Create Physics Constants Asset`**
2. Asset created at: `Assets/ScriptableObjects/Physics/DefaultPhysicsConstants.asset`
3. Select the asset and review values in Inspector

**Default Values (from architecture):**
```
Gravitational Scale: 1.0
Softening Length: 2.0
Max Force: 10.0
Stability Threshold: -0.8
```

? **Checkpoint:** PhysicsConstants asset exists

---

### **Step 3: Create Test Scene (3 min)**

1. In Unity, click menu: **`Stellar Architect ? Physics ? Create Test Scene (2 Bodies)`**
2. Scene automatically creates:
   - Physics Manager (with GravitySystem)
   - Star 1 (Red Dwarf) at origin
   - Star 2 (Yellow Star) at (5, 0, 0)
   - Camera positioned at (0, 10, -10)

? **Checkpoint:** Scene Hierarchy shows:
- Physics Manager
- Star 1 (Red Dwarf)
- Star 2 (Yellow Star)
- Main Camera

---

### **Step 4: Add Debug UI (1 min)**

1. Select **Main Camera** in Hierarchy
2. Add Component ? **Physics Debug UI**
3. Enable all display options in Inspector

? **Checkpoint:** Camera has PhysicsDebugUI component

---

### **Step 5: Press Play! (2 min)**

1. **Press Play button** (or F5)
2. **Watch the magic happen:**
   - Stars should gravitate toward each other
   - Console shows: "Registered body: Star 1..."
   - Debug UI (top-left) shows:
     - Bodies: 2
     - System Stable: YES/NO
     - Binding Energy: [value]
     - FPS: [value]

3. **Enable Gizmos** (Scene view):
   - Click "Gizmos" button in Scene view toolbar
   - You should see:
     - Cyan lines: Velocity vectors
     - Yellow lines: Acceleration vectors
     - Green lines: Gravity connections (if enabled in GravitySystem)

? **Checkpoint:** Bodies are moving toward each other due to gravity

---

## ? **Success Indicators**

If everything is working, you should see:

### Console Output:
```
GravitySystem initialized with Newtonian gravity and stability calculations.
Registered body: Star 1 (Red Dwarf) (Total: 1)
Registered body: Star 2 (Yellow Star) (Total: 2)
```

### Debug UI (Top-Left):
```
=== STELLAR ARCHITECT - PHYSICS DEBUG ===
Bodies: 2
System Stable: YES ?
Binding Energy: -0.234
FPS: 60.0
Press 'H' to toggle this UI
```

### Scene View:
- Stars moving toward each other
- Velocity vectors (cyan) pointing toward center
- Acceleration vectors (yellow) pointing toward other body

---

## ?? **Troubleshooting**

### Problem: "Scripts don't compile"
**Solution:**
1. Check Console for errors
2. Verify all 9 scripts from Week 1 exist in `Assets/Scripts/Physics/`
3. Right-click in Project ? Reimport All

### Problem: "Menu items not showing"
**Solution:**
1. Check `Assets/Scripts/Physics/Editor/PhysicsSceneSetup.cs` exists
2. Wait for Unity to recompile scripts
3. Restart Unity if needed

### Problem: "Bodies don't move"
**Solution:**
1. Check Console for "Registered body" messages
2. Verify GravitySystem exists in Hierarchy
3. Select GravitySystem ? Check if PhysicsConstants is assigned
4. Ensure PhysicsBodyAutoRegister is on each body

### Problem: "No debug UI visible"
**Solution:**
1. Check Camera has PhysicsDebugUI component
2. Verify "Show Debug UI" is enabled
3. Press 'H' key to toggle visibility

### Problem: "Bodies fly away too fast"
**Solution:**
1. Select PhysicsConstants asset
2. Reduce "Gravitational Scale" (try 0.5)
3. Increase "Softening Length" (try 3.0)

---

## ?? **Controls**

| Key | Action |
|-----|--------|
| **H** | Toggle debug UI |
| **Spacebar** | Pause/Resume (Unity default) |
| **Gizmos button** | Toggle Gizmos in Scene view |

---

## ?? **Next Steps (After 10 Minutes)**

Once you have the basic scene working:

### Thursday Afternoon Tasks:
1. **Create Binary Orbit Scene**
   - Menu: `Stellar Architect ? Physics ? Create Test Scene (Binary System)`
   - Watch stars orbit each other

2. **Add Trail Renderers**
   - Select a star
   - Add Component ? **Physics Body Trail**
   - Enable trail and adjust settings

3. **Test Three-Body Problem**
   - Menu: `Stellar Architect ? Physics ? Create Test Scene (3 Bodies)`
   - Observe chaotic behavior

4. **Experiment with Values**
   - Select PhysicsConstants
   - Tweak Gravitational Scale (0.5 - 2.0)
   - Tweak Softening Length (1.0 - 5.0)
   - Observe changes in real-time

---

## ?? **Verification Checklist**

Before proceeding to Day 2, verify:

- [ ] Unity project opens without errors
- [ ] PhysicsConstants asset exists
- [ ] Test scene has Physics Manager
- [ ] Test scene has 2 stars
- [ ] Press Play: bodies move toward each other
- [ ] Debug UI shows correct info
- [ ] Console shows registration messages
- [ ] Gizmos show velocity/acceleration vectors
- [ ] No red errors in Console

**All checked?** ? You're ready for Week 2! ??

---

## ?? **Today's Goal**

By end of Thursday, you should have:
- ? 2-body scene working
- ? Binary orbit scene working
- ? 3-body scene created
- ? Trail renderers added
- ? Screenshots of working physics

**Time Budget:** 5 hours  
**Current Progress:** 10 minutes (setup) ?

---

## ?? **Need Help?**

### Documentation References:
- **Architecture:** `Documentation/physics_architecture.md`
- **Quick Reference:** `Documentation/PHYSICS_QUICK_REFERENCE.md`
- **Week 2 Tracker:** `Documentation/WEEK2_PROGRESS_TRACKER.md`

### Common Issues:
- See "Troubleshooting" section in `PHYSICS_QUICK_REFERENCE.md`
- Check Unity Console for error messages
- Verify all Week 1 scripts compiled successfully

---

**?? You're all set! Press Play and watch the physics in action! ??**

**Next Document:** `WEEK2_PROGRESS_TRACKER.md` (track your daily progress)

**Last Updated:** January 16, 2026
