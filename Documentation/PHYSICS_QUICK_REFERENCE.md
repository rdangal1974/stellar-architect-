# Physics System Quick Reference
## Stellar Architect - Developer Cheat Sheet

**Date:** January 16, 2026  
**Quick Access Guide for Daily Development**

---

## File Locations

```
Assets/Scripts/Physics/
??? Config/
?   ??? PhysicsConstants.cs          # ALL physics values here
??? Core/
?   ??? IPhysicsBody.cs              # Body abstraction
?   ??? IGravityCalculator.cs        # Gravity strategy interface
?   ??? IStabilityCalculator.cs      # Stability strategy interface
??? Components/
?   ??? PhysicsBody.cs               # Main physics component
?   ??? PhysicsBodyAutoRegister.cs   # Auto-registration helper
??? Systems/
    ??? GravitySystem.cs             # Central manager (Singleton)
    ??? NewtonianGravityCalculator.cs # Gravity implementation
    ??? StabilityCalculator.cs       # Stability implementation
```

---

## Common Tasks

### 1. Create a Physics Body (Unity Editor)

```
1. Create GameObject (Sphere recommended for visualization)
2. Add Component ? PhysicsBody
3. Add Component ? PhysicsBodyAutoRegister
4. Set mass (e.g., 0.5 for Red Dwarf)
5. Set scale (density auto-calculated)
6. Play scene ? Body participates in gravity
```

### 2. Create a Physics Body (Code)

```csharp
GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
star.name = "Red Dwarf";
star.transform.position = new Vector3(0, 0, 0);
star.transform.localScale = Vector3.one * 0.5f;

PhysicsBody body = star.AddComponent<PhysicsBody>();
body.Mass = 0.5f; // Red Dwarf threshold

star.AddComponent<PhysicsBodyAutoRegister>();
```

### 3. Apply Forces to a Body

```csharp
PhysicsBody body = GetComponent<PhysicsBody>();

// Apply nudge impulse
Vector3 direction = Vector3.right;
body.ApplyForce(direction * 0.2f); // 0.2 = nudge impulse
```

### 4. Check Stability

```csharp
// Check if body orbit is stable
bool stable = GravitySystem.Instance.IsBodyOrbitStable(body);

// Get system binding energy
float energy = GravitySystem.Instance.GetSystemBindingEnergy();
Debug.Log($"Binding Energy: {energy:F3}");

// Check if system is stable (E_bind > -0.8)
bool systemStable = GravitySystem.Instance.IsSystemStable();
```

### 5. Access Physics Constants

```csharp
// In Inspector: Create PhysicsConstants asset
// Right-click ? Create ? Stellar Architect ? Physics Constants

// In code: Access via GravitySystem or direct reference
float nudgeForce = physicsConstants.nudgeImpulse; // 0.2
float softeningLength = physicsConstants.softeningLength; // 2.0
```

---

## Physics Values Quick Reference

### Formation Thresholds
```csharp
Red Dwarf:    mass ? 0.5,  density ? 2.0 g/cm³
Yellow Star:  mass ? 1.5,  density ? 3.5 g/cm³
Blue Giant:   mass ? 4.0,  density ? 6.0 g/cm³
Black Hole:   mass ? 10.0, density ? 15.0 g/cm³
```

### Stability Metrics
```csharp
Binding energy formula: E_bind = -0.5 × M × G_scale × (M / R_softening)
Stability threshold: E_bind > -0.8 (stable)
Orbit stability: acceleration < 0.3 g_game over 10 frames
```

### Player Interaction
```csharp
Nudge impulse: 0.2 g_game
Merge long-press: 0.5 seconds
Shield hold: 1.0 seconds
```

### Gravity Settings
```csharp
Gravitational scale: 1.0 (dimensionless)
Softening length: 2.0 units
Max force: 10.0 g_game
```

---

## Code Patterns

### Accessing GravitySystem

```csharp
// Singleton access
GravitySystem gravity = GravitySystem.Instance;

// Check if exists
if (GravitySystem.Instance != null)
{
    // Safe to use
}
```

### Implementing Custom Gravity Algorithm

```csharp
public class MyGravityCalculator : IGravityCalculator
{
    public Vector3 CalculateGravitationalForce(IPhysicsBody b1, IPhysicsBody b2)
    {
        // Your custom gravity logic
        return Vector3.zero;
    }
    
    public Vector3 CalculateTotalGravity(IPhysicsBody body, IEnumerable<IPhysicsBody> others)
    {
        // Your custom logic
        return Vector3.zero;
    }
}

// Inject into GravitySystem (requires modification or property setter)
```

### Implementing Custom Stability Calculator

```csharp
public class MyStabilityCalculator : IStabilityCalculator
{
    public float CalculateBindingEnergy(IEnumerable<IPhysicsBody> bodies)
    {
        // Your custom logic
        return 0f;
    }
    
    public bool IsSystemStable(IEnumerable<IPhysicsBody> bodies)
    {
        // Your custom logic
        return true;
    }
    
    public bool IsOrbitStable(IPhysicsBody body, IEnumerable<IPhysicsBody> others, int frames)
    {
        // Your custom logic
        return true;
    }
}
```

---

## Debug Visualization

### Enable Debug Drawing

```csharp
// In GravitySystem Inspector:
- Draw Gravity Lines: true (shows connections between bodies)
- Log Stability Warnings: true (console warnings for unstable systems)

// In PhysicsBody (Gizmos):
- Cyan line: Velocity vector
- Yellow line: Acceleration vector
```

### Performance Profiling

```csharp
// In Unity:
1. Window ? Analysis ? Profiler
2. Play scene
3. Look for "GravitySystem.UpdatePhysics"
4. Target: < 10ms for 50 bodies
```

---

## Troubleshooting

### Bodies Don't Move
- ? Check if GravitySystem exists in scene
- ? Check if PhysicsBodyAutoRegister is attached
- ? Check if bodies are registered (Console: "Registered body: ...")
- ? Verify mass > 0

### Bodies Explode/Fly Away
- ? Check softening length (should be 2.0)
- ? Check max force clamp (should be 10.0)
- ? Check initial velocities (should be near zero for static start)

### System Always Unstable
- ? Check binding energy (E_bind should be close to 0 for marginal stability)
- ? Verify stability threshold (-0.8)
- ? Ensure bodies are close enough (not scattered)

### Performance Issues
- ? Check body count (O(n²) algorithm, > 50 bodies may lag)
- ? Profile with Unity Profiler
- ? Consider reducing FixedUpdate rate (Edit ? Project Settings ? Time)

---

## Testing Checklist

### Before Committing Changes
- [ ] All 16 PhysicsHarness tests still pass (`dotnet run`)
- [ ] No compiler errors in Unity
- [ ] Test scene runs without crashes
- [ ] Performance < 10ms per frame (Profiler)
- [ ] No console errors/warnings

### Before Merging to Main
- [ ] Code review (self or peer)
- [ ] SOLID principles maintained
- [ ] Documentation updated
- [ ] Integration tests pass

---

## Formulas Reference

### Gravity Force
```
F = G × (m1 × m2) / (r² + ?²)^(3/2)

Where:
- G = gravitationalScale (1.0)
- m1, m2 = masses
- r = distance between bodies
- ? = softeningLength (2.0)
```

### Binding Energy
```
E_bind = -0.5 × M_total × G × (M_total / R_mean)

Where:
- M_total = sum of all masses
- G = gravitationalScale
- R_mean = mean distance from center of mass
```

### Semi-Implicit Euler Integration
```
v(t+?t) = v(t) + a(t) × ?t    # Update velocity first
p(t+?t) = p(t) + v(t+?t) × ?t # Then update position
```

---

## Git Workflow

### Committing Physics Changes

```bash
# Stage files
git add Assets/Scripts/Physics/

# Commit with descriptive message
git commit -m "feat(physics): Add relativity correction for black holes"

# Push to remote
git push origin main
```

### Branch for Experimental Features

```bash
# Create feature branch
git checkout -b feature/relativistic-gravity

# Make changes, commit
git add .
git commit -m "wip: Relativistic gravity calculator"

# Merge back when ready
git checkout main
git merge feature/relativistic-gravity
```

---

## Contact & Support

### Documentation
- Full architecture: `Documentation/physics_architecture.md`
- Week 1 summary: `Documentation/WEEK1_SUMMARY.md`
- This cheat sheet: `Documentation/PHYSICS_QUICK_REFERENCE.md`

### Resources
- Unity Physics: https://docs.unity3d.com/Manual/PhysicsSection.html
- SOLID Principles: Clean Architecture by Robert C. Martin
- N-body simulation: https://en.wikipedia.org/wiki/N-body_simulation

---

## Next Steps (Week 2)

### Immediate Tasks
1. Create test scene with 2-3 bodies
2. Verify gravity calculations visually
3. Profile performance
4. Add particle effects for visualization

### Future Enhancements
- [ ] Barnes-Hut algorithm (O(n log n))
- [ ] Relativistic corrections for black holes
- [ ] GPU acceleration (compute shaders)
- [ ] Spatial partitioning (octree)

---

**Last Updated:** January 16, 2026  
**Version:** 1.0  
**Status:** Production-Ready ?
