using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using drms.Classes;

namespace drms
{
    public partial class MainWindow : Window
    {
        PlaybackControl playbackControl;

        public MainWindow()
        {
            InitializeComponent();

            LibraryParser lp = new LibraryParser(@"D:\Muzyka\Inne");

            TagLib.File file = TagLib.File.Create(@"D:\Muzyka\My Music\Enter Shikari\(2015) The Mindsweep\03. Anaesthetist.m4a");

            Playlist newPlaylist = new Playlist() { Name = "Test Playlist", MediaFileList = new List<MediaFile>() { new MediaFile() { 
                Artist = file.Tag.FirstAlbumArtist,
                Album = file.Tag.Album,
                Title = file.Tag.Title,
                Path = file.Name,
                Year = file.Tag.Year,
                Track = file.Tag.Track
            } } };

            //playbackControl = new PlaybackControl(newPlaylist);
            //playbackControl.Play();

            //this.Title = "drms " + file.Tag.Title;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (playbackControl != null) playbackControl.Dispose();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {

        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void expand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void progressBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backClick(object sender, RoutedEventArgs e)
        {

        }

        private void LoadArtist(object sender, RoutedEventArgs e)
        {

        }

        private void setTrack(object sender, RoutedEventArgs e)
        {

        }
    }
}
