using System.Diagnostics.CodeAnalysis;

//--------------------------------------------------------------------------------
// This file was generated from the Etla Services Ltd EtlaTool.BlackAndWhite template
// At 17/07/2023 13:47:44
//--------------------------------------------------------------------------------

namespace EtlaToolPicker.EtlaToolbelt;

/// <summary>Extension classes that allow slighty more readable tests for whether strings have printable characters</summary>
public static class BlackAndWhite
{
    /// <summary>Checks if the candidate string contains any non-white-space characters
    /// Replaces:
    ///     !string.IsNullOrWhiteSpace(candidate)
    /// with something I find more readable:
    ///     candiate.IsBlack()
    /// </summary>
    /// <param name="candidate">The string to check</param>
    /// <returns>True if the candidate is not a null, is not empty and contains any characters other than white space, false otherwise</returns>
    public static bool IsBlack([NotNullWhen(true)] this string? candidate) => !string.IsNullOrWhiteSpace(candidate);

    /// <summary>Checks if the candidate string is null or contains only non-white-space characters if any
    /// Replaces:
    ///     string.IsNullOrWhiteSpace(candidate)
    /// with something I find more readable:
    ///     candiate.IsWhite()
    /// </summary>
    /// <param name="candidate">The string to check</param>
    /// <returns>True if the candidate is null or empty or contains only white space</returns>
    public static bool IsWhite([NotNullWhen(false)] this string? candidate) => string.IsNullOrWhiteSpace(candidate);

    /// <summary> Returns either the candidate, or the fallback if the candidate is white (i.e. is null or has no non-white-space characters)
    /// Note: 
    /// The fallback cannot be null but can be white
    /// </summary>
    /// <param name="candidate"></param>
    /// <param name="fallback"></param>
    /// <returns>The candidate, or the fallback if the candidate is white</returns>
    public static string IfWhite(this string? candidate, string fallback) 
    { 
        return candidate.IsBlack() ? candidate : fallback; 
    }

}
