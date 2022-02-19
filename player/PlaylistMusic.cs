using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace player
{
    public class PlaylistMusic
    {
        public string? FullPath { get; set; }
        public string? Name { get; set; }
        
        public PlaylistMusic(string path, string name)
        {
            FullPath = path;
            Name = name;
        }
    }
}
