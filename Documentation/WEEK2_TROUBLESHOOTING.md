# Unity Troubleshooting Guide - Week 2
## Common Issues and Solutions

**Last Updated:** January 16, 2026  
**For:** Stellar Architect Unity Integration

---

## ?? **CRITICAL ISSUES**

### Issue: "Scripts Won't Compile"

**Symptoms:**
- Red errors in Unity Console
- Bottom-right shows "Compiling..." forever
- Menu items don't appear

**Solutions:**

#### Solution 1: Check Error Messages
```
1. Open Console tab (Window ? General ? Console)
2. Read the FIRST error (not all of them)
3. Double-click error to open script
4. Fix the issue (usually missing namespace or typo)
```

#### Solution 2: Verify All Files Exist
```
Check Assets/Scripts/Physics/ has:
- Config/PhysicsConstants.cs
- Core/IPhysicsBody.cs
- Core/IGravityCalculator.cs
- Core/IStabilityCalculator.cs
- Components/PhysicsBody.cs
- Components/PhysicsBodyAutoRegister.cs
- Components/PhysicsBodyTrail.cs
- Systems/GravitySystem.cs
- Systems/NewtonianGravityCalculator.cs
- Systems/StabilityCalculator.cs
- Editor/PhysicsSceneSetup.cs
- Debug/PhysicsDebugUI.cs

Total: 12 files
```

#### Solution 3: Reimport All
```
1. Right-click in Project window
2. Click "Reimport All"
3. Wait for Unity to finish
4. Check Console again
```

#### Solution 4: Restart Unity
```
1. File ? Save Project
2. File ? Exit
3. Reopen project in Unity Hub
```

#### Solution 5: Delete Library Folder (LAST RESORT)
```
1. Close Unity completely
2. Navigate to: C:\dev\steller\stellar-architect
3. Delete "Library" folder
4. Reopen project (Unity will regenerate)
```

---

### Issue: "Stellar Architect Menu Not Showing"

**Symptoms:**
- No "Stellar Architect" in Unity menu bar
- Can't create PhysicsConstants asset
- Menu commands missing

**Solutions:**

#### Solution 1: Wait for Compilation
```
1. Check bottom-right corner of Unity
2. If it says "Compiling...", wait
3. Menu appears after compilation finishes
```

#### Solution 2: Check Editor Script
```
1. Verify: Assets/Scripts/Physics/Editor/PhysicsSceneSetup.cs exists
2. Open the script
3. Check first line: namespace StellarArchitect.Physics.Editor
4. Check [MenuItem] attributes exist
```

#### Solution 3: Clear Script Cache
```
1. Close Unity
2. Delete: C:\dev\steller\stellar-architect\Library\ScriptAssemblies\
3. Reopen Unity
```

---

## ?? **COMMON ISSUES**

### Issue: "Bodies Don't Move When I Press Play"

**Symptoms:**
- Scene loads, no errors
- Stars just sit there (no movement)
- Debug UI might show "Bodies: 0"

**Solutions:**

#### Check 1: Verify Registration
```
Console should show:
"Registered body: Star 1 (Red Dwarf) (Total: 1)"
"Registered body: Star 2 (Yellow Star) (Total: 2)"

If not showing:
1. Select Star 1 in Hierarchy
2. Check Inspector for "Physics Body Auto Register" component
3. If missing, Add Component ? Physics Body Auto Register
4. Repeat for Star 2
```

#### Check 2: Verify GravitySystem Exists
```
1. Hierarchy ? Find "Physics Manager"
2. If not there, create it:
   - Menu: Stellar Architect ? Physics ? Create Test Scene
   OR
   - GameObject ? Create Empty
   - Rename: "Physics Manager"
   - Add Component ? Gravity System
```

#### Check 3: Check PhysicsConstants Assigned
```
1. Hierarchy ? Select "Physics Manager"
2. Inspector ? Gravity System component
3. "Physics Constants" field should reference:
   Assets/ScriptableObjects/Physics/DefaultPhysicsConstants.asset
4. If empty, drag asset to field
```

#### Check 4: Verify Bodies Have Mass
```
1. Select Star 1 in Hierarchy
2. Inspector ? Physics Body component
3. Mass should be > 0 (e.g., 0.5)
4. If 0, set to 0.5
```

---

### Issue: "Bodies Fly Away Too Fast"

**Symptoms:**
- Stars zoom past each other
- Movement too fast to see
- Bodies disappear off-screen

**Solutions:**

#### Solution 1: Reduce Gravity
```
1. Project ? Assets/ScriptableObjects/Physics/DefaultPhysicsConstants
2. Click asset
3. Inspector ? Gravitational Scale: Change to 0.5 (from 1.0)
4. Press Play again
```

#### Solution 2: Increase Softening
```
1. Same PhysicsConstants asset
2. Softening Length: Change to 3.0 (from 2.0)
3. This prevents extreme forces at close range
```

#### Solution 3: Reduce Initial Velocities
```
1. Select Star 1 ? Inspector ? Physics Body
2. Velocity should be (0, 0, 0) initially
3. If not, set to zero
```

---

### Issue: "Bodies Collide and Stick Together"

**Symptoms:**
- Stars touch and stop moving
- Physics stops working after collision

**Solutions:**

#### Solution 1: This is Expected (For Now)
```
Unity's default colliders will stop bodies.
In Week 2 Saturday, we'll implement:
- Drag mechanic (move bodies)
- Merge mechanic (combine masses)

For now, restart scene (Stop ? Play again)
```

#### Solution 2: Disable Colliders Temporarily
```
1. Select Star 1 ? Inspector
2. Find "Sphere Collider" component
3. Uncheck the checkbox to disable
4. Repeat for Star 2
5. Bodies will pass through each other
```

---

### Issue: "Debug UI Not Visible"

**Symptoms:**
- Press Play, no UI in Game view
- Can't see body count or stability info

**Solutions:**

#### Solution 1: Check Component Added
```
1. Hierarchy ? Select Main Camera
2. Inspector ? Should have "Physics Debug UI" component
3. If not, Add Component ? Physics Debug UI
```

#### Solution 2: Check UI Enabled
```
1. Camera selected
2. Physics Debug UI component
3. "Show Debug UI" checkbox should be ?
4. All sub-options should be ?
```

#### Solution 3: Toggle with 'H' Key
```
1. Click Game view tab
2. Press 'H' key
3. UI should toggle on/off
```

#### Solution 4: Check Game View Size
```
1. Click "Game" tab
2. Make sure window is large enough (not tiny)
3. UI appears in top-left corner
```

---

### Issue: "Gizmos Not Showing"

**Symptoms:**
- Can't see velocity/acceleration vectors
- No cyan or yellow lines

**Solutions:**

#### Solution 1: Enable Gizmos
```
1. Click "Scene" view tab (not Game)
2. Top-right toolbar: Click "Gizmos" button
3. Should be highlighted when on
```

#### Solution 2: Check Gizmo Settings
```
1. Click Gizmos dropdown (arrow next to button)
2. Scroll down to script icons
3. Make sure "PhysicsBody" is checked
```

#### Solution 3: Zoom In
```
1. Vectors might be too small to see from far away
2. In Scene view: Scroll mouse wheel to zoom in
3. OR: Select a star and press 'F' to focus
```

---

## ?? **PERFORMANCE ISSUES**

### Issue: "Low FPS (< 30)"

**Symptoms:**
- Debug UI shows FPS below 30
- Scene is laggy
- Bodies move in slow motion or jerky

**Solutions:**

#### Solution 1: Check Body Count
```
Debug UI should show "Bodies: 2" or "Bodies: 3"
If showing more than 50:
1. You created too many bodies
2. Delete extras from Hierarchy
```

#### Solution 2: Reduce Quality Settings
```
1. Edit ? Project Settings ? Quality
2. Change preset to "Low"
3. Disable shadows temporarily
```

#### Solution 3: Close Other Applications
```
1. Close web browsers, Discord, etc.
2. Free up RAM and CPU
3. Unity needs resources
```

---

## ?? **MINOR ISSUES**

### Issue: "Console Spam (Too Many Messages)"

**Solution:**
```
1. Console tab ? Right-click
2. "Clear"
3. OR: Click trash can icon
4. Messages will re-appear as needed
```

### Issue: "Scene Too Dark to See Stars"

**Solution:**
```
1. Hierarchy ? Create ? Light ? Directional Light
2. Rotate light to point at scene
OR
1. Select stars
2. Materials should have emission (glow)
3. Increase emission color brightness
```

### Issue: "Camera Too Far/Close"

**Solution:**
```
1. Hierarchy ? Select Main Camera
2. Scene view ? Position camera where you want
3. GameObject ? Align With View
OR
1. Inspector ? Transform ? Position: (0, 10, -10)
2. Rotation: (30, 0, 0)
```

---

## ?? **VERIFICATION COMMANDS**

### Verify All Scripts Exist
```powershell
Get-ChildItem -Path "Assets\Scripts\Physics" -Recurse -Filter "*.cs" | Measure-Object
# Should show: Count: 12
```

### Verify PhysicsHarness Tests
```powershell
cd PhysicsHarness
dotnet run
# Should show: 16 PASSED, 0 FAILED
```

### Check Unity Project Structure
```
Assets/
??? Scenes/
??? Scripts/
?   ??? Physics/ (12 files)
??? ScriptableObjects/
    ??? Physics/
        ??? DefaultPhysicsConstants.asset
```

---

## ?? **Still Stuck?**

### Before Asking for Help:

1. **Read Console Errors Carefully**
   - First error is usually the real problem
   - Subsequent errors often caused by first one

2. **Check This Troubleshooting Guide**
   - Use Ctrl+F to search for your issue

3. **Verify File Structure**
   - All 12 scripts exist
   - PhysicsConstants asset created

4. **Try the Nuclear Option**
   - Delete Library folder
   - Reimport All
   - Restart Unity

### If Still Broken:

1. **Document the Issue:**
   - What were you doing?
   - What error message (exact text)?
   - Screenshot of Console
   - Screenshot of Inspector

2. **Check Documentation:**
   - `Documentation/physics_architecture.md`
   - `Documentation/PHYSICS_QUICK_REFERENCE.md`

3. **Rollback Git (Last Resort):**
   ```bash
   git status
   git log --oneline -5
   # If you broke something:
   git reset --hard HEAD
   ```

---

## ? **Quick Fixes Checklist**

Before diving deep, try these in order:

- [ ] Wait for "Compiling..." to finish
- [ ] Check Console for red errors
- [ ] Verify all 12 scripts exist
- [ ] Assets ? Reimport All
- [ ] Restart Unity
- [ ] Check Git status (did you modify files accidentally?)
- [ ] Re-run PhysicsHarness tests (dotnet run)
- [ ] Delete Library folder (last resort)

---

## ?? **Expected Behavior (Working System)**

When everything works correctly:

### Console Output (Play Mode):
```
GravitySystem initialized with Newtonian gravity and stability calculations.
Registered body: Star 1 (Red Dwarf) (Total: 1)
Registered body: Star 2 (Yellow Star) (Total: 2)
```

### Debug UI (Game View):
```
=== STELLAR ARCHITECT - PHYSICS DEBUG ===
Bodies: 2
System Stable: YES ? (or NO ?)
Binding Energy: -0.234 (some number)
FPS: 60.0 (or close)
Press 'H' to toggle this UI
```

### Scene View (Gizmos On):
- Two spheres visible (red and yellow)
- Cyan lines (velocity) pointing toward each other
- Yellow lines (acceleration) pointing toward each other
- Stars gradually move closer together

### Behavior:
- Stars accelerate toward each other
- Movement smooth, not jerky
- FPS stays above 30
- No errors in Console

---

**?? If You See All of That: It's Working! ??**

**Save This File:** Keep for reference during Week 2  
**Last Updated:** January 16, 2026
