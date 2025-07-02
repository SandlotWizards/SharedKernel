namespace SandlotWizards.ActionLogger.Interfaces.Windows
{
    public interface IDeveloperFileSystemService : IUtilitityFileSystemService
    {
        string GetDeveloperRootPath(string rootOverride = default!);
        string LocateDeveloperSolutionPath(string solution, string rootOverride = default!);
        string LocateDeveloperDotNetRoot(string solution, string rootOverride = default!);
        string LocateDeveloperProjectPath(string solution, string project, string rootOverride = default!);
        string GetArchitectureDocsPath(string rootOverride = default!);
    }
}
