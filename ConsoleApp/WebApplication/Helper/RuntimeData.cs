using System.Collections.Generic;
using Domain;

namespace WebApplication.Helper
{
    public static class RuntimeData
    {
        internal static GameSettings GameSettings { get; set; } = default!;

        internal static List<(string name, string time)> GamesExternal { get; set; } = default!;

        internal static bool WasPlayerFirst { get; set; } = default!;


    }
}