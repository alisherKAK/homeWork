﻿using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SaveModelsInDataBase
    {
        public static void SaveBand(Band band)
        {
            using(var context = new MusicContext())
            {
                if(context.Bands.Where(searchBand => searchBand.Name == band.Name).ToList().Count == Constants.NULL)
                {
                    context.Bands.Add(band);
                    context.SaveChanges();
                }
            }
        }

        public static void SaveMusic(Music music)
        {
            using(var context = new MusicContext())
            {
                if(context.Musics.Where(searchMusic => 
                searchMusic.Name == music.Name && searchMusic.Lyrics == music.Lyrics && searchMusic.Band == music.Band).ToList().Count == Constants.NULL)
                {
                    context.Musics.Add(music);
                    context.SaveChanges();
                }
            }
        }
    }
}
