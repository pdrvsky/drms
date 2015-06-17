using System.Collections.Generic;

namespace drms.Classes
{
    struct Playlist
    {
        public string Name { get; set; }
        public List<MediaFile> MediaFileList { get; set; }
    }
}
