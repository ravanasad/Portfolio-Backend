using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities.Files
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public SendingImageOwnerType Type { get; set; }
        public int OwnerId { get; set; } 

    }
}
