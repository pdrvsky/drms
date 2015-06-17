using System;
using System.Collections.Generic;
using System.Linq;

using CSCore;
using CSCore.SoundOut;
using CSCore.Codecs;
using CSCore.Streams.Effects;
using CSCore.Streams;

namespace drms.Classes
{
    class PlaybackControl
    {
        ISoundOut outDevice;
        Playlist playlist;

        #region Supported EXT
        public static readonly string[] SupportedExtensions = {
            ".mp3",
            ".mpeg3",
            ".wav",
            ".wave",
            ".flac",
            ".fla",
            ".aac",
            ".adt",
            ".adts",
            ".m2ts",
            ".mp2",
            ".m4a",
            ".m4v",
            ".mp4v",
            ".mp4",
            ".asf",
            ".wm",
            ".wmv",
            ".wma"
        };
        #endregion

        #region Public Methods

        public PlaybackControl( Playlist playlist )
        {
            this.playlist = playlist;
            setupOutDevice();
        }

        public void Dispose()
        {
            outDevice.Dispose();
        }

        //INTERFACE INTERACTION

        public void Play()
        {
            if (playlist.MediaFileList == null) return;

            this.play(playlist.MediaFileList.First().Path);
        }

        public void Play(int index)
        {

        }

        public void Pause()
        {

        }

        public void Next()
        {

        }

        public void Previous()
        {

        }

        #endregion

        #region Private Methods

        private void setupOutDevice()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                outDevice = new WasapiOut();
            else
                outDevice = new DirectSoundOut();
        }

        private void play( string path )
        {
            IWaveSource source;
            if (outDevice.PlaybackState == PlaybackState.Playing) outDevice.Stop();

            CSCore.Streams.Equalizer eq;
            source = CodecFactory.Instance.GetCodec(path);
            eq = Equalizer.Create10BandEqualizer(source);
            outDevice.Initialize(eq.ToWaveSource());
            outDevice.Play();

            eq.SampleFilters[0].SetGain(15);
            eq.SampleFilters[1].SetGain(10);
            eq.SampleFilters[2].SetGain(8);
            eq.SampleFilters[8].SetGain(8);
            eq.SampleFilters[9].SetGain(10);
        }

        #endregion

    }
}
