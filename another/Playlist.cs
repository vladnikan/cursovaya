using System;
using System.Collections.Generic;

namespace AudioPlayer
{
    public class Playlist
    {
        private List<Song> songs;

        public Playlist()
        {
            songs = new List<Song>();
        }

        public List<Song> GetSongs()
        {
            return songs;
        }

        public void AddSong(string filePath)
        {
            Song newSong = new Song(filePath);
            songs.Add(newSong);
        }

        public void RemoveSong(int index)
        {
            if (index >= 0 && index < songs.Count)
            {
                songs.RemoveAt(index);
            }
        }

        public void EditSong(int index, string newTitle)
        {
            if (index >= 0 && index < songs.Count)
            {
                songs[index].SetTitle(newTitle);
            }
        }
    }
}
