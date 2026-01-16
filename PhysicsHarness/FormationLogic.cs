/// <summary>
/// Physics Formation Logic - Defines thresholds for star formation
/// Based on mass and density specifications
/// </summary>
public class FormationLogic
{
    // Red Dwarf: Smallest, most stable stars
    public static bool IsRedDwarfFormed(float mass, float density)
        => mass >= 0.5f && density >= 2.0f;

    // Yellow Star: Medium-sized, balanced stars (like our sun)
    public static bool IsYellowStarFormed(float mass, float density)
        => mass >= 1.5f && density >= 3.5f;

    // Blue Giant: Large, hot, short-lived stars
    public static bool IsBlueGiantFormed(float mass, float density)
        => mass >= 4.0f && density >= 6.0f;

    // Black Hole: Extreme density, gravitational singularity
    public static bool IsBlackHoleFormed(float mass, float density)
        => mass >= 10.0f && density >= 15.0f;
}
