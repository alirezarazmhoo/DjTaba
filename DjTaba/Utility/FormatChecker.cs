using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Utility
{
	public static class FormatChecker
	{
        public static bool CheckFormat(IFormFile File)
        {
            if (!(string.Equals(File.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(File.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(File.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(File.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(File.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(File.ContentType, "image/png", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool CheckMusicFormat(IFormFile File)
        {
           string[] mediaExtensions = {
           "audio/WAV", "audio/MID", "audio/MIDI", "audio/WMA", "audio/MP3", "audio/OGG", "audio/RMA","audio/mpeg", //etc

            };
            return -1 != Array.IndexOf(mediaExtensions, File.ContentType);
        }
        public static bool CheckVideoFormat(IFormFile File)
        {
            string[] mediaExtensions = {
            ".AVI", ".MP4", ".DIVX", ".WMV" , ".mkv", 
            };
            return -1 != Array.IndexOf(mediaExtensions, File.ContentType);
        }
    }
}
