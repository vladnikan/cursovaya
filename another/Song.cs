namespace AudioPlayer
{
    public class Song
    {
        private string filePath;
        private string title;

        public Song(string filePath)
        {
            this.filePath = filePath;
            title = System.IO.Path.GetFileNameWithoutExtension(filePath);
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string newTitle)
        {
            title = newTitle;
        }
    }
}
