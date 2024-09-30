using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial2 = new PipeSerial(new FilterNegative(), pipeNull);
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGreyscale(), pipeSerial2);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            TwitterImage twitter = new TwitterImage();
            
            
            IPicture result3 = pipeSerial1.Send(picture);
            provider.SavePicture(result3, @"luke3.jpg");
            Console.WriteLine(twitter.PublishToTwitter("equipo5N1foto3", @"luke3.jpg"));
            IPicture result2 = pipeSerial2.Send(picture);
            provider.SavePicture(result2, @"luke2.jpg");
            Console.WriteLine(twitter.PublishToTwitter("equipo5N1foto2", @"luke2.jpg"));
            IPicture result1 = pipeNull.Send(picture);
            provider.SavePicture(result1, @"luke1.jpg");
            Console.WriteLine(twitter.PublishToTwitter("equipo5N1foto1", @"luke1.jpg"));
            Console.WriteLine(provider.GetPicture(@"luke.jpg"));
            // Completar el de Twitter.
        }
    }
}
