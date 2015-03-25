using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;

namespace WallpaperChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            WallpaperStateResolver stateResolver = new WallpaperStateResolver();
            Uri nextImageUri = stateResolver.getWallpaperForMousePosition(Cursor.Position.X, Cursor.Position.Y);
            if (nextImageUri != null)
            {
                Wallpaper.Set(nextImageUri, Wallpaper.Style.Stretched);
            }
            do
            {
                try
                {
                    setWallpapersInLoop(nextImageUri, stateResolver);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska!");
                    Console.WriteLine(e.StackTrace);
                    Thread.Sleep(100);
                }
            }
            while (true);
            Console.ReadLine();
        }

        static void setWallpapersInLoop(Uri nextImageUri, WallpaperStateResolver stateResolver)
        {
            while (true)
            {
                Thread.Sleep(20);
                nextImageUri = stateResolver.getWallpaperForMousePosition(Cursor.Position.X, Cursor.Position.Y);
                if (nextImageUri != null)
                {
                    Wallpaper.Set(nextImageUri, Wallpaper.Style.Stretched);
                }
            }
        }
    }

    public sealed class WallpaperStateResolver
    {
        private int currentState;

        const String basePath = "d:\\Windows\\VisualStudio Projects\\WallpaperChanger\\Wallpapers\\";
        const String imgDoljeDesnoPath = "doljeDesno.png";          // 1 
        const String imgSrednjeDesnoPath = "srednjeDesno.png";      // 2
        const String imgGoreDesnoPath = "goreDesno.png";            // 3
        const String imgljevoDoljePath = "ljevoDolje.png";          // 4
        const String imgljevoSrednjePath = "ljevoSrednje.png";      // 5
        const String imgljevoGorePath = "ljevoGore.png";            // 6
        const String imgGoreGorePath = "goreGore.png";              // 7
        const String imgDoljeDOljePath = "doljeDolje.png";          // 8
        const String imgCentarPath = "centar.png";                  // 9
        const String imgKrizPath = "uKriz.png";                     // 10

        public WallpaperStateResolver()
        {
            this.currentState = -1;    
        }

        public Uri getWallpaperForMousePosition(int mouseX, int mouseY) 
        {
            String newImagePath = null;
            Uri newUri = null;

            if (mouseX < 10)        // DERP MODE !!!
            {
                // TODO
            }
            else if (mouseX < 430)      // ljevo
            {
                if (mouseY < 240)       // gore
                {
                    if (currentState != 6)
                    {
                        newImagePath = basePath + imgljevoGorePath;
                        currentState = 6;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (mouseY < 600)      // srednje
                {     
                    if(currentState != 5){
                        newImagePath = basePath + imgljevoSrednjePath;
                        currentState = 5;
                    }
                    else
                    {
                        return null;
                    }
                }
                else        // dolje
                {
                    if(currentState != 4){
                        newImagePath = basePath + imgljevoDoljePath;
                        currentState = 4;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else if (mouseX < 700)          // sredina
            {
                if (mouseY < 350)           // gore
                {
                    if(currentState != 7){
                        newImagePath = basePath + imgGoreGorePath;
                        currentState = 7;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (mouseY < 480)      // centar
                {
                    if(currentState != 9){
                        newImagePath = basePath + imgCentarPath;
                        currentState = 9;
                    }
                    else
                    {
                        return null;
                    }
                }
                else            // dolje
                {
                    if(currentState != 8){
                        newImagePath = basePath + imgDoljeDOljePath;
                        currentState = 8;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else if (mouseX < 920)
            {
                if (mouseY < 350)           // gore
                {
                    if(currentState != 7){
                        newImagePath = basePath + imgGoreGorePath;
                        currentState = 7;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (mouseY < 480)      // centar
                {
                    if(currentState != 10){
                        newImagePath = basePath + imgKrizPath;
                        currentState = 10;
                    }
                    else
                    {
                        return null;
                    }
                }
                else            // dolje
                {
                    if(currentState != 8){
                        newImagePath = basePath + imgDoljeDOljePath;
                        currentState = 8;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else if (mouseX < 1200)
            {
                if (mouseY < 350)           // gore
                {
                    if(currentState != 7){
                        newImagePath = basePath + imgGoreGorePath;
                        currentState = 7;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (mouseY < 480)      // centar
                {
                    if(currentState != 9){
                        newImagePath = basePath + imgCentarPath;
                        currentState = 9;
                    }
                    else
                    {
                        return null;
                    }
                }
                else            // dolje
                {
                    if(currentState != 8){
                        newImagePath = basePath + imgDoljeDOljePath;
                        currentState = 8;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else            // Desno
            {
                if (mouseY < 240)       // gore
                {
                    if(currentState != 3){
                        newImagePath = basePath + imgGoreDesnoPath;
                        currentState = 3;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (mouseY < 600)      // srednje
                {
                    if(currentState != 2){
                        newImagePath = basePath + imgSrednjeDesnoPath;
                        currentState = 2;
                    }
                    else
                    {
                        return null;
                    }
                }
                else        // dolje
                {
                    if(currentState != 1){
                        newImagePath = basePath + imgDoljeDesnoPath;
                        currentState = 1;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            if (newImagePath != null)
            {
                try
                {
                    newUri = new System.Uri(newImagePath);
                    return newUri;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Error creating new uri for path -> " + newImagePath);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    public sealed class Wallpaper
    {
        Wallpaper() { }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }

        public static void Set(Uri uri, Style style)
        {
            System.IO.Stream s = new System.Net.WebClient().OpenRead(uri.ToString());

            System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
