using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Util
{
    public static string ColorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    public static Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    public static class FileIO
    {
        public static void WriteData(string strData, string fileName, bool isNewCreate = false, string forder = "/save/", bool isOpen = true)
        {
            string path = /*Application.dataPath +*/ forder;
            string filePath = path + fileName;
            if (!isNewCreate)
            {
                filePath = GetUniqueFileNameWithPath(path, fileName);
            }


            FileStream f = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(f, System.Text.Encoding.UTF8);
            writer.WriteLine(strData);
            writer.Close();

            if (isOpen)
            {
                Process.Start(path);
            }
        }

        public static string ReadData(string fileName, string forder = "/save/")
        {
            string path = /*Application.dataPath +*/ forder;
            string filePath = path + fileName;

            if (!File.Exists(filePath)) return null;

            FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(f, System.Text.Encoding.UTF8);

            string str = reader.ReadToEnd();
            reader.Close();

            return str;
        }

        public static void CopyWritePng(Texture2D tex, string fileName, string forder = "/save/", bool isOpen = true)
        {
            if (tex == null) return;
            Texture2D newTex = CopyTexture2D(tex);
            WritePng(newTex, fileName, forder, isOpen);
            Object.DestroyImmediate(newTex);
        }

        public static Texture2D CopyTexture2D(Texture2D target)
        {
            Texture2D tex = new Texture2D(target.width, target.height, target.format, false);
            tex.LoadRawTextureData(target.GetRawTextureData());
            tex.Apply();
            return tex;
        }

        public static void WritePng(Texture2D tex, string fileName, string forder = "/save/", bool isOpen = true)
        {
            string path = /*Application.dataPath +*/ forder;
            //string filePath = GetUniqueFileNameWithPath(path, fileName);

            byte[] bytes = tex.EncodeToPNG();
            File.WriteAllBytes(path + "/" + fileName, bytes);
        }

        public static string GetUniqueFileNameWithPath(string dirPath, string fileN)
        {
            string fileName = fileN;

            int indexOfDot = fileName.LastIndexOf(".");
            string strName = fileName.Substring(0, indexOfDot);
            string strExt = fileName.Substring(indexOfDot + 1);

            bool bExist = true;
            int fileCount = 0;

            while (bExist)
            {
                if (File.Exists(Path.Combine(dirPath, fileName)))
                {
                    fileCount++;
                    fileName = strName + "(" + fileCount + ")." + strExt;
                }
                else
                {
                    bExist = false;
                }
            }
            return Path.Combine(dirPath, fileName);
        }
    }
}
