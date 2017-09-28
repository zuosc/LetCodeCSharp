using System;
using System.Collections.Generic;

namespace _535EncodeAndDecodeTinyURL
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             TinyURL is a URL shortening service where you enter a URL such as https://leetcode.com/problems/design-tinyurl 
             TinyURL 是一个缩短服务，当你输入一个Url时
             and it returns a short URL such as http://tinyurl.com/4e9iAk.
             它返回一个短的Url，如：
            Design the encode and decode methods for the TinyURL service. 
            设计TinyURL service的编码和解码方法
            There is no restriction on how your encode/decode algorithm should work. 
            编码/解码算法应该如何工作没有限制。
            You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
            您只需确保将URL编码为一个短的URL，并将该短的URL解码为原始URL。
             */

            var shorturl = Encode("/problems/design-tinyurl");
            Console.WriteLine($"shorturl:{shorturl}");
            var longurl = Decode(shorturl);
            Console.WriteLine($" longurl:{longurl}");
            Console.ReadKey();
        }

        private static readonly string DictStr = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Dictionary<string, string> Short2Long = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> Long2Short = new Dictionary<string, string>();

        // Encodes a URL to a shortened URL.
        //http://www.cnblogs.com/grandyang/p/6562209.html
        private static string Encode(string longUrl)
        {
            if (Long2Short.ContainsKey(longUrl))
            {
                return "http://tinyurl.com/" + Long2Short[longUrl];
            }
            var idx = 0;
            var randStr = new char[6];
            var ran = new Random();

            for (var i = 0; i < 6; ++i)
            {
                randStr[i] = (DictStr[ran.Next(0, 62)]);
            }
            var key = new string(randStr);
            while (Short2Long.ContainsKey(key))
            {
                randStr[idx] = DictStr[ran.Next(0, 62)];
                idx = (idx + 1) % 5;
            }
            Short2Long[key] = longUrl;
            Long2Short[longUrl] = key;
            return "http://tinyurl.com/" + key;
        }

        private static string Decode(string shortUrl)
        {
            var randStr = shortUrl.Substring(shortUrl.LastIndexOf('/') + 1);
            return Short2Long.ContainsKey(randStr) ? "http://tinyurl.com/" + Short2Long[randStr] : shortUrl;
        }
    }
}