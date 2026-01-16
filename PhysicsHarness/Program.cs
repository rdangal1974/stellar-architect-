using System;
using System.Collections.Generic;
using StellarArchitect.Physics;

/// <summary>
/// Physics Harness - Console application to validate formation logic
/// Runs all 16 unit tests and displays results
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("????????????????????????????????????????????????????????");
        Console.WriteLine("?  STELLAR ARCHITECT - PHYSICS HARNESS                 ?");
        Console.WriteLine("?  Formation Logic Validation                          ?");
        Console.WriteLine("????????????????????????????????????????????????????????");
        Console.WriteLine();

        var tests = new List<(string Name, Func<bool> Test)>
        {
            // Red Dwarf Tests
            ("Red Dwarf - At Exact Threshold (0.5, 2.0)", 
                () => FormationLogic.IsRedDwarfFormed(0.5f, 2.0f) == true),
            
            ("Red Dwarf - Above Threshold (0.6, 2.5)", 
                () => FormationLogic.IsRedDwarfFormed(0.6f, 2.5f) == true),
            
            ("Red Dwarf - Below Mass (0.4, 2.0)", 
                () => FormationLogic.IsRedDwarfFormed(0.4f, 2.0f) == false),
            
            ("Red Dwarf - Below Density (0.5, 1.9)", 
                () => FormationLogic.IsRedDwarfFormed(0.5f, 1.9f) == false),

            // Yellow Star Tests
            ("Yellow Star - At Exact Threshold (1.5, 3.5)", 
                () => FormationLogic.IsYellowStarFormed(1.5f, 3.5f) == true),
            
            ("Yellow Star - Above Threshold (1.6, 3.6)", 
                () => FormationLogic.IsYellowStarFormed(1.6f, 3.6f) == true),
            
            ("Yellow Star - Below Mass (1.4, 3.5)", 
                () => FormationLogic.IsYellowStarFormed(1.4f, 3.5f) == false),
            
            ("Yellow Star - Below Density (1.5, 3.4)", 
                () => FormationLogic.IsYellowStarFormed(1.5f, 3.4f) == false),

            // Blue Giant Tests
            ("Blue Giant - At Exact Threshold (4.0, 6.0)", 
                () => FormationLogic.IsBlueGiantFormed(4.0f, 6.0f) == true),
            
            ("Blue Giant - Above Threshold (4.5, 6.5)", 
                () => FormationLogic.IsBlueGiantFormed(4.5f, 6.5f) == true),
            
            ("Blue Giant - Below Mass (3.9, 6.0)", 
                () => FormationLogic.IsBlueGiantFormed(3.9f, 6.0f) == false),
            
            ("Blue Giant - Below Density (4.0, 5.9)", 
                () => FormationLogic.IsBlueGiantFormed(4.0f, 5.9f) == false),

            // Black Hole Tests
            ("Black Hole - At Exact Threshold (10.0, 15.0)", 
                () => FormationLogic.IsBlackHoleFormed(10.0f, 15.0f) == true),
            
            ("Black Hole - Above Threshold (10.5, 15.5)", 
                () => FormationLogic.IsBlackHoleFormed(10.5f, 15.5f) == true),
            
            ("Black Hole - Below Mass (9.9, 15.0)", 
                () => FormationLogic.IsBlackHoleFormed(9.9f, 15.0f) == false),
            
            ("Black Hole - Below Density (10.0, 14.9)", 
                () => FormationLogic.IsBlackHoleFormed(10.0f, 14.9f) == false),
        };

        int passed = 0;
        int failed = 0;

        Console.WriteLine($"Running {tests.Count} tests...\n");

        foreach (var (name, test) in tests)
        {
            try
            {
                bool result = test();
                if (result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"? PASS: {name}");
                    passed++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"? FAIL: {name}");
                    failed++;
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"? ERROR: {name} - {ex.Message}");
                Console.ResetColor();
                failed++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("????????????????????????????????????????????????????????");
        Console.WriteLine($"?  RESULTS: {passed} PASSED, {failed} FAILED                      ?");
        Console.WriteLine("????????????????????????????????????????????????????????");
        
        if (failed == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n? All physics formations validated successfully!");
            Console.ResetColor();
        }
    }
}
