namespace AudioPlayer.Audio
{
    /// <summary>
    /// Represents track object
    /// </summary>
    public class Composition
    {
        /// <summary>
        /// Creates track object in located path
        /// </summary>
        /// <param name="path"></param>
        public Composition(string path)
        {
            FilePath = path;
        }

        /// <summary>
        /// Audio file path
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Name of audio file
        /// </summary>
        public string Name => Path.GetFileNameWithoutExtension(FilePath);
    }
}
