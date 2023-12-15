﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace AudioPlayer
{
    public class AudioPlayer
    {
        private MediaPlayer audioPlayer;
        private List<string> playlist;

        public AudioPlayer()
        {
            audioPlayer = new MediaPlayer();
            playlist = new List<string>();
        }

        public Duration NaturalDuration
        {
            get { return audioPlayer.NaturalDuration; }
        }

        public void Play()
        {
            if (playlist.Count > 0)
            {
                if (audioPlayer.Source == null)
                {
                    audioPlayer.Open(new Uri(playlist[0]));
                }
                audioPlayer.Play();
            }
        }

        public void Pause()
        {
            audioPlayer.Pause();
        }

        public void Stop()
        {
            audioPlayer.Stop();
            audioPlayer.Close();
            audioPlayer = new MediaPlayer();
        }

        public void LoadPlaylist(List<string> files)
        {
            playlist.AddRange(files);
        }

        public void PlaySelectedTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                audioPlayer.Open(new Uri(playlist[selectedIndex]));
                audioPlayer.Play();
            }
        }

        public List<string> GetPlaylist()
        {
            return playlist;
        }

        public void RemoveTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                if (audioPlayer.Source != null && audioPlayer.Source.LocalPath == playlist[selectedIndex])
                {
                    audioPlayer.Stop();
                    audioPlayer.Close();
                    audioPlayer = new MediaPlayer();
                }
                playlist.RemoveAt(selectedIndex);
            }
        }

        public void Seek(TimeSpan position)
        {
            audioPlayer.Position = position;
        }
    }
}