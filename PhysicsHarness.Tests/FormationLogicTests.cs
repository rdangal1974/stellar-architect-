namespace StellarArchitect.Physics.Tests;

using Xunit;
using StellarArchitect.Physics;

/// <summary>
/// Unit tests for Formation Logic
/// 16 total tests: 4 per star type
/// Separated into dedicated test project following .NET best practices
/// </summary>
public class FormationLogicTests
{
    // ========== RED DWARF TESTS (4 tests) ==========
    
    [Fact]
    public void RedDwarf_AtExactThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsRedDwarfFormed(mass: 0.5f, density: 2.0f);
        
        // Assert
        Assert.True(result, "Red Dwarf should form at exact threshold (0.5, 2.0)");
    }

    [Fact]
    public void RedDwarf_AboveThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsRedDwarfFormed(mass: 0.6f, density: 2.5f);
        
        // Assert
        Assert.True(result, "Red Dwarf should form above threshold (0.6, 2.5)");
    }

    [Fact]
    public void RedDwarf_BelowMassThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsRedDwarfFormed(mass: 0.4f, density: 2.0f);
        
        // Assert
        Assert.False(result, "Red Dwarf should NOT form below mass threshold (0.4, 2.0)");
    }

    [Fact]
    public void RedDwarf_BelowDensityThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsRedDwarfFormed(mass: 0.5f, density: 1.9f);
        
        // Assert
        Assert.False(result, "Red Dwarf should NOT form below density threshold (0.5, 1.9)");
    }

    // ========== YELLOW STAR TESTS (4 tests) ==========

    [Fact]
    public void YellowStar_AtExactThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsYellowStarFormed(mass: 1.5f, density: 3.5f);
        
        // Assert
        Assert.True(result, "Yellow Star should form at exact threshold (1.5, 3.5)");
    }

    [Fact]
    public void YellowStar_AboveThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsYellowStarFormed(mass: 1.6f, density: 3.6f);
        
        // Assert
        Assert.True(result, "Yellow Star should form above threshold (1.6, 3.6)");
    }

    [Fact]
    public void YellowStar_BelowMassThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsYellowStarFormed(mass: 1.4f, density: 3.5f);
        
        // Assert
        Assert.False(result, "Yellow Star should NOT form below mass threshold (1.4, 3.5)");
    }

    [Fact]
    public void YellowStar_BelowDensityThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsYellowStarFormed(mass: 1.5f, density: 3.4f);
        
        // Assert
        Assert.False(result, "Yellow Star should NOT form below density threshold (1.5, 3.4)");
    }

    // ========== BLUE GIANT TESTS (4 tests) ==========

    [Fact]
    public void BlueGiant_AtExactThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlueGiantFormed(mass: 4.0f, density: 6.0f);
        
        // Assert
        Assert.True(result, "Blue Giant should form at exact threshold (4.0, 6.0)");
    }

    [Fact]
    public void BlueGiant_AboveThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlueGiantFormed(mass: 4.5f, density: 6.5f);
        
        // Assert
        Assert.True(result, "Blue Giant should form above threshold (4.5, 6.5)");
    }

    [Fact]
    public void BlueGiant_BelowMassThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlueGiantFormed(mass: 3.9f, density: 6.0f);
        
        // Assert
        Assert.False(result, "Blue Giant should NOT form below mass threshold (3.9, 6.0)");
    }

    [Fact]
    public void BlueGiant_BelowDensityThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlueGiantFormed(mass: 4.0f, density: 5.9f);
        
        // Assert
        Assert.False(result, "Blue Giant should NOT form below density threshold (4.0, 5.9)");
    }

    // ========== BLACK HOLE TESTS (4 tests) ==========

    [Fact]
    public void BlackHole_AtExactThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlackHoleFormed(mass: 10.0f, density: 15.0f);
        
        // Assert
        Assert.True(result, "Black Hole should form at exact threshold (10.0, 15.0)");
    }

    [Fact]
    public void BlackHole_AboveThreshold_ReturnsTrue()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlackHoleFormed(mass: 10.5f, density: 15.5f);
        
        // Assert
        Assert.True(result, "Black Hole should form above threshold (10.5, 15.5)");
    }

    [Fact]
    public void BlackHole_BelowMassThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlackHoleFormed(mass: 9.9f, density: 15.0f);
        
        // Assert
        Assert.False(result, "Black Hole should NOT form below mass threshold (9.9, 15.0)");
    }

    [Fact]
    public void BlackHole_BelowDensityThreshold_ReturnsFalse()
    {
        // Arrange & Act
        var result = FormationLogic.IsBlackHoleFormed(mass: 10.0f, density: 14.9f);
        
        // Assert
        Assert.False(result, "Black Hole should NOT form below density threshold (10.0, 14.9)");
    }
}
