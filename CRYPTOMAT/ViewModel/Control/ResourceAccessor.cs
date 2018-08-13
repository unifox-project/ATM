using System;
using System.IO;
using System.Reflection;

namespace CRYPTOMAT
{
    internal static class ResourceAccessor
    {
        public static Uri Get(string respurcePath)
        {
            var uri = string.Format(
                "pack://application:,,,/{0};component/{1}"
                , Assembly.GetExecutingAssembly().GetName().Name
                , respurcePath
            );
            return new Uri(uri);
        }

        public static byte[] GetRespurceBytes(string respurcePath)
        {
            //"WpfSafeMat.Resources.Test_zip.dataside.zip"
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(respurcePath))
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}