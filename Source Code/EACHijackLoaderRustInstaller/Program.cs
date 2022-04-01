using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EACHijackLoaderRustInstaller
{
    class Program
    {
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        static void Main(string[] args)
        {
            string temp = @"C:\Temp";
            Directory.CreateDirectory(temp);
            if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Rust\UnityPlayer.dll"))
            {
                File.Copy(@"C:\Program Files (x86)\Steam\steamapps\common\Rust\UnityPlayer.dll", @"C:\Program Files (x86)\Steam\steamapps\common\Rust\oUnityPlayer.dll");
                File.Delete(@"C:\Program Files (x86)\Steam\steamapps\common\Rust\UnityPlayer.dll");
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("UnityPlayer.dll is Renamed on oUnityPlayer.dll in Rust Folder... Extracting Hijack Loader...\n");
            Thread.Sleep(2000);
            Extract("EACHijackLoaderRustInstaller", temp, "Resources", "UnityPlayer.dll");
            File.Copy(@"C:\Temp\UnityPlayer.dll", @"C:\Program Files (x86)\Steam\steamapps\common\Rust\UnityPlayer.dll");
            File.Delete(@"C:\Temp\UnityPlayer.dll");
            string certificate_eac = @"C:\Program Files (x86)\Steam\steamapps\common\Rust\EasyAntiCheat\Certificates\game.cer";
            if (File.Exists(certificate_eac))
            {
                File.Copy(certificate_eac, @"C:\Program Files (x86)\Steam\steamapps\common\Rust\EasyAntiCheat\Certificates\1234567.cer");
                File.Delete(certificate_eac);
            }
            Console.WriteLine("Certificate EAC is Succesfully Renamed...\n");
            Thread.Sleep(3500);
            Console.WriteLine("EAC is Successfully Bypassed... Now Run Rust in Steam and Enjoy to use this Hijack Loader");
            Thread.Sleep(4000);
            Console.WriteLine("This program made by BuzzerFelix, Hijack Loader made by Vorrick\n");
            Thread.Sleep(2400);
            Environment.Exit(44312);
        }
    }
}
