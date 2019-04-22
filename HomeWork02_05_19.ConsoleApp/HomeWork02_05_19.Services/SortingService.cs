using HomeWork02_05_19.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SortingService
    {
        public static List<Music> SortMusicDescendingRating(List<Music> musics)
        {
            return musics.OrderByDescending(music => music.Rating).ToList();
        }

        public static List<Music> SortMusicAscendingRating(List<Music> musics)
        {
            return musics.OrderBy(music => music.Rating).ToList();
        }
    }
}
