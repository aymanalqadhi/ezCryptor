using System.IO;

namespace ezCryptor.Utils
{
    /// <summary>
    /// A Static utilities class for 
    /// tweaking filenames
    /// </summary>
    public static class FileName
    {
        /// <summary>
        /// Removes the extension from a filename
        /// </summary>
        /// <param name="fileName">The filename to strip the extension from</param>
        /// <returns></returns>
        public static string RemoveExtension(string fileName)
            => Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));

        /// <summary>
        /// Gets an unused name for files
        /// </summary>
        /// <param name="fileName">The filename to generate an unused name for</param>
        /// <returns></returns>
        public static string GetUnusedFileName(string fileName)
        {
            if (!File.Exists(fileName)) return fileName;

            FileInfo info;
            int num = 0;

            do
            {
                info = new FileInfo($"{Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName))} ({++num}){Path.GetExtension(fileName)}");
            } while (info.Exists);

            return info.FullName;
        }
    }
}
