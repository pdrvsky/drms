using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using drms.Classes;
using CSCore.Codecs;
using TagLib;

namespace drms
{
    class LibraryParser
    {
        private string savePath;

        public LibraryParser()
        {
            byte[] b1 = System.Text.Encoding.UTF8.GetBytes(@"D:\Muzyka\My Music");
            Console.WriteLine(b1.Length);
        }

        public LibraryParser(string path)
        {
            this.savePath = path;
            Task<List<MediaFile>>.Run(() => this.parseFiles()).ContinueWith((res) => this.saveData(res.Result));
        }

        private List<MediaFile> parseFiles()
        {
            if (savePath.Length == 0) return null;

            IEnumerable<string> trackFiles = Directory.EnumerateFiles(this.savePath, "*.*", SearchOption.AllDirectories).Where(w => PlaybackControl.SupportedExtensions.Any(w.ToLower().EndsWith));

            List<MediaFile> returnList = new List<MediaFile>();
            foreach (string filePath in trackFiles)
            {
                try
                {
                    TagLib.File file = TagLib.File.Create(filePath);
                    returnList.Add(new MediaFile()
                    {
                        Artist = file.Tag.FirstAlbumArtist,
                        Album = file.Tag.Album,
                        Title = file.Tag.Title,
                        Path = file.Name,
                        Year = file.Tag.Year,
                        Track = file.Tag.Track
                    });
                }
                catch (TagLib.CorruptFileException e)
                {
                    Console.Out.WriteLine(e.Message);
                }
            }

            return returnList;
        }

        private void saveData( List<MediaFile> input )
        {
            if (input != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] pathBytes = System.Text.Encoding.UTF8.GetBytes(this.savePath);
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Write(BitConverter.GetBytes(pathBytes.Length), 0, 4);
                    ms.Write(pathBytes, 0, pathBytes.Length);
                    Console.WriteLine( "MS Pos: " + ms.Position );

                    ms.Seek(0, SeekOrigin.Begin);
                    byte[] buffer = new byte[4];
                    ms.Read(buffer, 0, 4);
                    int stringLenght = BitConverter.ToInt32(buffer, 0);
                    Console.WriteLine( "String lenght: " + stringLenght );
                    buffer = new byte[stringLenght];
                    ms.Read(buffer, 0, stringLenght);
                    Console.WriteLine( "String itself: " + System.Text.Encoding.UTF8.GetString(buffer) );
                }
            }
        }
    }
}
