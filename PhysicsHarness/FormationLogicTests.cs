using System;
using Xunit;
using StellarArchitect.Physics;

/// <summary>
/// Unit tests for Formation Logic
/// 16 total tests: 4 per star type
/// </summary>
public class FormationLogicTests
{
    // ========== RED DWARF TESTS (4 tests) ==========
    
    [Fact]
    public void RedDwarf_AtExactThreshold_ReturnsTrue()
    {
        // Exactly at threshold: mass 0.5, density 2.0
        Assert.True(FormationLogic.IsRedDwarfFormed(0.5f, 2.0f));
    }

    [Fact]
    public void RedDwarf_AboveThreshold_ReturnsTrue()
    {
        // Above threshold: mass 0.6, density 2.5
        Assert.True(FormationLogic.IsRedDwarfFormed(0.6f, 2.5f));
    }

    [Fact]
    public void RedDwarf_BelowMassThreshold_ReturnsFalse()
    {
        // Below mass threshold: mass 0.4, density 2.0
        Assert.False(FormationLogic.IsRedDwarfFormed(0.4f, 2.0f));
    }

    [Fact]
    public void RedDwarf_BelowDensityThreshold_ReturnsFalse()
    {
        // Below density threshold: mass 0.5, density 1.9
        Assert.False(FormationLogic.IsRedDwarfFormed(0.5f, 1.9f));
    }

    // ========== YELLOW STAR TESTS (4 tests) ==========

    [Fact]
    public void YellowStar_AtExactThreshold_ReturnsTrue()
    {
        // Exactly at threshold: mass 1.5, density 3.5
        Assert.True(FormationLogic.IsYellowStarFormed(1.5f, 3.5f));
    }

    [Fact]
    public void YellowStar_AboveThreshold_ReturnsTrue()
    {
        // Above threshold: mass 1.6, density 3.6
        Assert.True(FormationLogic.IsYellowStarFormed(1.6f, 3.6f));
    }

    [Fact]
    public void YellowStar_BelowMassThreshold_ReturnsFalse()
    {
        // Below mass threshold: mass 1.4, density 3.5
        Assert.False(FormationLogic.IsYellowStarFormed(1.4f, 3.5f));
    }

    [Fact]
    public void YellowStar_BelowDensityThreshold_ReturnsFalse()
    {
        // Below density threshold: mass 1.5, density 3.4
        Assert.False(FormationLogic.IsYellowStarFormed(1.5f, 3.4f));
    }

    // ========== BLUE GIANT TESTS (4 tests) ==========

    [Fact]
    public void BlueGiant_AtExactThreshold_ReturnsTrue()
    {
        // Exactly at threshold: mass 4.0, density 6.0
        Assert.True(FormationLogic.IsBlueGiantFormed(4.0f, 6.0f));
    }

    [Fact]
    public void BlueGiant_AboveThreshold_ReturnsTrue()
    {
        // Above threshold: mass 4.5, density 6.5
        Assert.True(FormationLogic.IsBlueGiantFormed(4.5f, 6.5f));
    }

    [Fact]
    public void BlueGiant_BelowMassThreshold_ReturnsFalse()
    {
        // Below mass threshold: mass 3.9, density 6.0
        Assert.False(FormationLogic.IsBlueGiantFormed(3.9f, 6.0f));
    }

    [Fact]
    public void BlueGiant_BelowDensityThreshold_ReturnsFalse()
    {
        // Below density threshold: mass 4.0, density 5.9
        Assert.False(FormationLogic.IsBlueGiantFormed(4.0f, 5.9f));
    }

    // ========== BLACK HOLE TESTS (4 tests) ==========

    [Fact]
    public void BlackHole_AtExactThreshold_ReturnsTrue()
    {
        // Exactly at threshold: mass 10.0, density 15.0
        Assert.True(FormationLogic.IsBlackHoleFormed(10.0f, 15.0f));
    }

    [Fact]
    public void BlackHole_AboveThreshold_ReturnsTrue()
    {
        // Above threshold: mass 10.5, density 15.5
        Assert.True(FormationLogic.IsBlackHoleFormed(10.5f, 15.5f));
    }

    [Fact]
    public void BlackHole_BelowMassThreshold_ReturnsFalse()
    {
        // Below mass threshold: mass 9.9, density 15.0
        Assert.False(FormationLogic.IsBlackHoleFormed(9.9f, 15.0f));
    }

    [Fact]
    public void BlackHole_BelowDensityThreshold_ReturnsFalse()
    {
        // Below density threshold: mass 10.0, density 14.9
        Assert.False(FormationLogic.IsBlackHoleFormed(10.0f, 14.9f));
    }
}
