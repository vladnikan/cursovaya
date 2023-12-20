using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AudioPlayer
{
    public class FileIO
    {
        //открытие файлов
        public static List<string> OpenFiles()
        {
            List<string> files = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav";

            if (openFileDialog.ShowDialog() == true)
            {
                files.AddRange(openFileDialog.FileNames);
            }

            return files;
        }
        //сохранение плейлиста
        public static void SavePlaylist(List<string> playlist)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Playlist Files|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, playlist);
                MessageBox.Show("Playlist successfully saved");
            }
        }
        //открытие плейлиста
        public static List<string> OpenPlaylist()
        {
            List<string> playlist = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Playlist Files|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                playlist.AddRange(File.ReadAllLines(openFileDialog.FileName));
            }

            return playlist;
        }
    }
}
