using ezCryptor.Algorithms;
using ezCryptor.Utils;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ezCryptor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var algo = new AesAlgorithm();
            //var from = File.OpenRead("test.wmv");
            //var to = File.Create("test.wmv.eze");

            //algo.Initialize().Wait();

            //var dirctor = new CryptoDirector(algo, from, to, RedirectionMode.Encrypt, 1024 * 1024);
            //dirctor.Key = Hash.SHA256(Encoding.ASCII.GetBytes("12345678"));
            //dirctor.IV = new byte[16];
            //Task.Run(async delegate
            //{
            //    try
            //    {
            //        while (await dirctor.ProcessChunk(p => Console.Write("\r[+] Current Progress: {0:0.00}%", p))) ;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}).Wait();

            //from.Close(); to.Close();
            //Console.Read();
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
