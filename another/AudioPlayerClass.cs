using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualBasic;


namespace AudioPlayer
{
    public class AudioPlayer
    {
        private MediaPlayer audioPlayer;
        private List<string> playlist;

        public AudioPlayer() //конструктор проигрывателя аудио
        {
            audioPlayer = new MediaPlayer();
            playlist = new List<string>();
        }
        //получение продолжительности текущего трека
        public Duration NaturalDuration
        {
            get { return audioPlayer.NaturalDuration; }
        }
        //воспроизведение треков из списка
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
        //пауза воиспризведения
        public void Pause()
        {
            audioPlayer.Pause();
        }
        //остановка воиспроизведения
        public void Stop()
        {
            audioPlayer.Stop();
            audioPlayer.Close();
            audioPlayer = new MediaPlayer();
        }
        //загрузка плейлиста
        public void LoadPlaylist(List<string> files)
        {
            playlist.AddRange(files);
        }
        //воспроизведение выбранного трека по индексу
        public void PlaySelectedTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                audioPlayer.Open(new Uri(playlist[selectedIndex]));
                audioPlayer.Play();
            }
        }
        //получение плейлиста
        public List<string> GetPlaylist()
        {
            return playlist;
        }
        //удаление трека из плейлиста по индексу
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
        // Перемотка песни 
        public void Seek(TimeSpan position)
        {
            audioPlayer.Position = position;
        }
    }
}
