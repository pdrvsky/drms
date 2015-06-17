using System;

namespace drms.Classes
{
    [Serializable]
    public struct MediaFile
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public uint Year { get; set; }
        public uint Track { get; set; }
        public byte[] Artwork { get; set; }
    }
}
