using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Microsoft.VisualBasic;

namespace AudioPlayer
{ 
    public partial class MainWindow : Window
    {

        private AudioPlayer audioPlayer;//объект для управления воспроизведением аудио
        private PlaylistManager playlistManager;//объект для управления списком воспроизведения
        private Playlist playlist;
        //конструктор главного окна
        public MainWindow()
        {
            InitializeComponent();
            audioPlayer = new AudioPlayer();
            Playlist playlist = new Playlist(); // Добавлено создание объекта Playlist
            playlistManager = new PlaylistManager(PlaylistListBox, playlist);
            Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (audioPlayer.GetPlaylist().Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("You have not saved your playlist. Do you want to save your changes?", "Warning", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    FileIO.SavePlaylist(audioPlayer.GetPlaylist()); // Сохранение плейлиста при закрытии
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true; // Отмена закрытия окна
                }
            }
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
            List<string> currentPlaylist = audioPlayer.GetPlaylist();
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
                audioPlayer.Stop();
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
            audioPlayer.Stop();
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

            if (searchResults.Count == 0)
            {
                PlaylistListBox.Items.Add("No songs with this title were found.");
            }
            else
            {
                foreach (string result in searchResults)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = Path.GetFileName(result);
                    PlaylistListBox.Items.Add(item);
                }
            }
        }
        //обработчик кнопки EditButton, она нужна для изменения названия песни, добавленной в плейлист
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = PlaylistListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                string newTitle = Interaction.InputBox("Enter the new title:", "Edit Track", "");
                audioPlayer.GetPlaylist()[selectedIndex] = newTitle;
                playlistManager.EditTrack(selectedIndex, newTitle);
            }
            else
            {
                // Если песня не выбрана, то выводится сообщение об ошибке
                MessageBox.Show("Select a song to edit.");
            }
        }
    }
}
