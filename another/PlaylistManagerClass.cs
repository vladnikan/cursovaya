using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace AudioPlayer
{
    public class PlaylistManager
    {
        private ListBox playlistListBox;
        private Playlist songPlaylist;
        // Конструктор менеджера плейлиста
        public PlaylistManager(ListBox listBox, Playlist playlist)
        {
            playlistListBox = listBox;
            this.songPlaylist = playlist;
        }

        // Загрузка файлов в список воспроизведения
        public void LoadFiles(List<string> files)
        {
            foreach (string fileName in files)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = Path.GetFileName(fileName);
                playlistListBox.Items.Add(item);
            }
        }

        // Очистка плейлиста
        public void ClearPlaylist()
        {
            playlistListBox.Items.Clear();
        }

        // Удаление трека из плейлиста по индексу
        public void RemoveTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                playlistListBox.Items.RemoveAt(selectedIndex);
            }
        }

        // Редактирование трека в плейлисте
        public void EditTrack(int selectedIndex, string newTitle)
        {
            if (selectedIndex != -1)
            {
                songPlaylist.EditSong(selectedIndex, newTitle); // Используется метод EditSong из Playlist
                playlistListBox.Items[selectedIndex] = newTitle;
            }
        }
    }
}
