using System.Diagnostics.CodeAnalysis;

//--------------------------------------------------------------------------------
// This file was generated from the Etla Services Ltd EtlaTool.BlackAndWhite template
// At 17/07/2023 13:47:44
//--------------------------------------------------------------------------------

namespace EtlaToolbeltPicker.EtlaToolbelt;

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

    /// <summary>If the supplied string is black then it is returned, otherwise the fallback is returned
    /// Note: 
    ///     This guarantees the returned string is not null 
    ///     But it dies not guarantee that the returned string is balck since the fallback can be white 
    /// </summary>
    /// <param name="str">The string to check</param>
    /// <param name="fallback">The fallback string to return if the string to be checked is white</param>
    /// <returns>The initial string if it is black; or the fallback string ithe initial string is white</returns>
    // This guarantees a non-null string is returned but does not guarantee that it will be Black
    public static string IfWhite(this string? str, string fallback) => str.IsBlack() ? str : fallback;

}
