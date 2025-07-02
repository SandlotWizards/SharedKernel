namespace SandlotWizards.SharedKernel.Interfaces.Windows
{
    public interface IFileStoreFileSystemService : IUtilitityFileSystemService
    {
        string GetFileStoreRoot();
        string LocateFileStoreFolder(string folderName);
        string LocateFileStoreFile(string folderName, string fileName);
    }
}
