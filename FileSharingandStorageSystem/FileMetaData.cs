namespace FileSharingandStorageSystem
{
    public class FileMetaData
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; } // Size in bytes
        public DateTime UploadedAt { get; set; }
    }
}
