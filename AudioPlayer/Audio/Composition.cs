using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Audio
{
    public class Composition
    {
        public Composition(string path)
        {
            FilePath = path;
        }

        public string FilePath { get; }

        public string Name => Path.GetFileNameWithoutExtension(FilePath);
    }
}
