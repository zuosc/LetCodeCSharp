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





            Console.WriteLine("Hello World!");
        }

        private string dictStr = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Dictionary<string, string> short2long = new Dictionary<string, string>();
        private Dictionary<string, string> long2short = new Dictionary<string, string>();

        // Encodes a URL to a shortened URL.
        //http://www.cnblogs.com/grandyang/p/6562209.html
        private string Encode(string longUrl)
        {
            if (long2short.ContainsKey(longUrl))
            {
                return "http://tinyurl.com/" + long2short[longUrl];
            }
            int idx = 0;
            string randStr;
            for (int i = 0; i < 6; ++i)
            {
                randStr.push_back(dict[rand() % 62]);
            }
            while (short2long.ContainsKey(randStr))
            {
                randStr[idx] = dict[rand() % 62];
                idx = (idx + 1) % 5;
            }
            short2long[randStr] = longUrl;
            long2short[longUrl] = randStr;
            return "http://tinyurl.com/" + randStr;
        }
    }
}
