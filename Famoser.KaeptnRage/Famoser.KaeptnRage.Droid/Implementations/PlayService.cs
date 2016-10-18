using System;
using Android.Content;
using Android.Media;
using Famoser.KaeptnRage.View.Services.Interfaces;
using Java.IO;
using Uri = Android.Net.Uri;

namespace Famoser.KaeptnRage.Droid.Implementations
{
    public class PlayService : IPlayService
    {
        public static Context Context;
        
        public void StartFilePlay(string fileName)
        {
            var file = Context.GetFileStreamPath(fileName);
            MediaPlayer mPlayer = MediaPlayer.Create(Context, Uri.FromFile(file));
            mPlayer.Start();
        }
    }
}