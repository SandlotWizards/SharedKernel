namespace SandlotWizards.SharedKernel.Interfaces.Windows
{
    public interface IDeploymentFileSystemService : IUtilitityFileSystemService
    {
        string LocateDeploymentRepoPath(string environment, string profile = default!);
        string LocateDeploymentRepoPath(string environment, string solution, string profile = default!);
        string LocateDeploymentRepoPath(string environment, string solution, string project, string profile = default!);
    }
}
