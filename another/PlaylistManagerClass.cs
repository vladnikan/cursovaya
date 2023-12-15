using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace AudioPlayer
{
    public class PlaylistManager
    {
        private ListBox playlistListBox;

        public PlaylistManager(ListBox listBox)
        {
            playlistListBox = listBox;
        }

        public void LoadFiles(List<string> files)
        {
            foreach (string fileName in files)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = Path.GetFileName(fileName);
                playlistListBox.Items.Add(item);
            }
        }

        public void ClearPlaylist()
        {
            playlistListBox.Items.Clear();
        }

        public void RemoveTrack(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                playlistListBox.Items.RemoveAt(selectedIndex);
            }
        }
    }
}
