namespace InGame.BestPractice.Web
{
    public static class ConstHelper
    {
        /// <summary>
        /// Remaps international characters to ascii compatible ones
        /// based of: https://meta.stackexchange.com/questions/7435/non-us-ascii-characters-dropped-from-full-profile-url/7696#7696
        /// </summary>
        /// <param name="c">Charcter to remap</param>
        /// <returns>Remapped character</returns>
        public static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }

            if ("èéêëę".Contains(s))
            {
                return "e";
            }

            if ("ìíîïı".Contains(s))
            {
                return "i";
            }

            if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }

            if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }

            if ("çćčĉ".Contains(s))
            {
                return "c";
            }

            if ("żźž".Contains(s))
            {
                return "z";
            }

            if ("śşšŝ".Contains(s))
            {
                return "s";
            }

            if ("ñń".Contains(s))
            {
                return "n";
            }

            if ("ýÿ".Contains(s))
            {
                return "y";
            }

            if ("ğĝ".Contains(s))
            {
                return "g";
            }

            if (c == 'ř')
            {
                return "r";
            }

            if (c == 'ł')
            {
                return "l";
            }

            if (c == 'đ')
            {
                return "d";
            }

            if (c == 'ß')
            {
                return "ss";
            }

            if (c == 'þ')
            {
                return "th";
            }

            if (c == 'ĥ')
            {
                return "h";
            }

            if (c == 'ĵ')
            {
                return "j";
            }
            // Turkish Characters
            if (c == 'ş')
            {
                return "s";
            }
            if (c == 'ğ')
            {
                return "g";
            }
            if (c == 'ç')
            {
                return "c";
            }
            if (c == 'ö')
            {
                return "o";
            }
            if (c == 'ü')
            {
                return "u";
            }
            if (c == 'ı')
            {
                return "i";
            }

            return "";
        }
    }
}