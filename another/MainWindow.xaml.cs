using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace AudioPlayer
{
    public partial class MainWindow : Window
    {
        private AudioPlayer audioPlayer;
        private PlaylistManager playlistManager;

        public MainWindow()
        {
            InitializeComponent();
            audioPlayer = new AudioPlayer();
            playlistManager = new PlaylistManager(PlaylistListBox);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Stop();
        }

        private void LoadFilesButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> files = FileIO.OpenFiles();
            if (files.Count > 0)
            {
                audioPlayer.LoadPlaylist(files);
                playlistManager.LoadFiles(files);
            }
        }

        private void SavePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            FileIO.SavePlaylist(audioPlayer.GetPlaylist());
        }

        private void OpenPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> playlist = FileIO.OpenPlaylist();
            if (playlist.Count > 0)
            {
                audioPlayer.LoadPlaylist(playlist);
                playlistManager.ClearPlaylist();
                playlistManager.LoadFiles(playlist);
            }
        }

        private void PlaylistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            audioPlayer.PlaySelectedTrack(PlaylistListBox.SelectedIndex);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            playlistManager.RemoveTrack(PlaylistListBox.SelectedIndex);
            audioPlayer.RemoveTrack(PlaylistListBox.SelectedIndex);
        }

        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (audioPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan newPosition = TimeSpan.FromSeconds(TimelineSlider.Value);
                audioPlayer.Seek(newPosition);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();

            PlaylistListBox.Items.Clear();

            var searchResults = audioPlayer.GetPlaylist().Where(song => Path.GetFileName(song).ToLower().Contains(searchText)).ToList();

            foreach (string result in searchResults)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = Path.GetFileName(result);
                PlaylistListBox.Items.Add(item);
            }
        }
    }
}
