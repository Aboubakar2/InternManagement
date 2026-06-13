namespace InterManagement.Application.Features.InternFiles.DTOs
{
    public class InternFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public DateTime ImportedAt { get; set; }

        // infos relation
        public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;
    }
}