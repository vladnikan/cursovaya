using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;


namespace AudioPlayer
{
    public class PlaylistManager
    {
        private ListBox playlistListBox;
        //конструктор менеджера плейлиста
        public PlaylistManager(ListBox listBox)
        {
            playlistListBox = listBox;
        }
        //загрузка файлов в список воспроизведения
        public void LoadFiles(List<string> files)
        {
            foreach (string fileName in files)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = Path.GetFileName(fileName);
                playlistListBox.Items.Add(item);
            }
        }
        //очистка плейлиста
        public void ClearPlaylist()
        {
            playlistListBox.Items.Clear();
        }
        //удаление трека из плейлиста по индексу
        public void RemoveTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                playlistListBox.Items.RemoveAt(selectedIndex);
            }
        }
    }
}
