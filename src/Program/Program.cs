using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

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
            
            IPicture result3 = pipeSerial1.Send(picture);
            provider.SavePicture(result3, @"luke1.jpg");
            IPicture result2 = pipeSerial2.Send(picture);
            provider.SavePicture(result2, @"luke2.jpg");
            IPicture result1 = pipeNull.Send(picture);
            provider.SavePicture(result1, @"luke3.jpg");
            // Completar el de Twitter.
        }
    }
}
