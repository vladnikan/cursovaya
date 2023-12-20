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
        private AudioPlayer audioPlayer;//объект для управления воспроизведением аудио
        private PlaylistManager playlistManager;//объект для управления списком воспроизведения
        //конструктор главного окна
        public MainWindow()
        {
            InitializeComponent();
            audioPlayer = new AudioPlayer();
            playlistManager = new PlaylistManager(PlaylistListBox);
        }
        //обработчик собыьтя нажатия кнопки play
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Play();
        }
        //обработчик события нажатия кнопки pause
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Pause();
        }
        //обработчик события нажатия кнопки stop
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Stop();
        }
        //обработчик события нажатия кнопки Load Files
        private void LoadFilesButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> files = FileIO.OpenFiles();
            if (files.Count > 0)
            {
                audioPlayer.LoadPlaylist(files);
                playlistManager.LoadFiles(files);
            }
        }
        //обработчик события нажатия кнопки Save Playlist для сохранения плейлиста
        private void SavePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            FileIO.SavePlaylist(audioPlayer.GetPlaylist());
        }
        //обработчик события нажатия кнопки Open Playlist для открытия плейлиста
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
        //обработчик события изменения выбранного элемента в списке воспроизведения
        private void PlaylistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            audioPlayer.PlaySelectedTrack(PlaylistListBox.SelectedIndex);
        }
        //обработчик события нажатия кнопки Remove для удаления песен
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            playlistManager.RemoveTrack(PlaylistListBox.SelectedIndex);
            audioPlayer.RemoveTrack(PlaylistListBox.SelectedIndex);
        }
        //обработчик события изменения значения ползунка таймлайна
        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (audioPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan newPosition = TimeSpan.FromSeconds(TimelineSlider.Value);
                audioPlayer.Seek(newPosition);
            }
        }
        //обработчик события изменения текста в поле поиска
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
