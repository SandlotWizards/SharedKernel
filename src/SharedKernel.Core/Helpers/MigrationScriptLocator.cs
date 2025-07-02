using ConnectionProfiler.Infrastructure.Constants;

namespace SandlotWizards.SharedKernel.Helpers
{
    /// <summary>
    /// Resolves the appropriate SQL script file path for a given migration class name.
    /// </summary>
    public static class MigrationScriptLocator
    {
        /// <summary>
        /// Resolves the absolute file path to the SQL script associated with a migration class.
        /// The expected file name pattern is '*_{className}.sql'.
        /// </summary>
        /// <param name="className">The name of the migration class.</param>
        /// <returns>The full path to the matching SQL script file.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the root directory cannot be determined.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the Scripts directory does not exist.</exception>
        /// <exception cref="FileNotFoundException">Thrown if no matching script file is found.</exception>
        public static string ResolveScriptPath(string className, string projectName)
        {
            var rootDir = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            if (rootDir == null)
                throw new InvalidOperationException("Could not determine project root directory.");

            var scriptsDir = Path.Combine(
                rootDir,
                projectName,
                "Persistence",
                "Migrations",
                "Scripts");

            if (!Directory.Exists(scriptsDir))
                throw new DirectoryNotFoundException($"Migration scripts directory not found: {scriptsDir}");

            var matchingFile = Directory.GetFiles(scriptsDir, $"*_{className}.sql").FirstOrDefault();

            if (string.IsNullOrEmpty(matchingFile))
                throw new FileNotFoundException($"No SQL script found matching *_{className}.sql in {scriptsDir}");

            return matchingFile;
        }
    }
}
