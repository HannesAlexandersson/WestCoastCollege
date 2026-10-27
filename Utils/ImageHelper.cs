using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace Client.Helpers;

public static class ImageHelper // resuable component that can turn any url based image even vector based images to bitmaps
{
    public static async Task<Bitmap> ImageFromUrl(string url)
    {
        try
        {
            Uri uri = new(url);
            using HttpClient client = new(); ;
            var data = await client.GetByteArrayAsync(url); // gets an byte array
            return new Bitmap(new MemoryStream(data)); // memorystream är en ström av data i minnet på datorn, dvs man använder ram minnet. Vi skickar in en lsita med data som görs om till en ström som blir till en data ström i minnet. och sedan skapaar en bitmap av detta.
        }
        catch (HttpRequestException ex)
        {

            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
