using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DVLD_Project.Properties;
using System.Drawing;

namespace DVLD_Project.Golbal_Functions
{
    internal class clsUtil
    {
        //This class is used for storing the items for the combo box 
        public class FilterdItemsCB
        {
            public string Name { get; set; }
            public string ColumnName { get; set; }
            public string PlaceHolderText {  get; set; }
            public Image TextBoxIcon { get; set; }


            public FilterdItemsCB(string name, string columnName,string placetext , Image image )
            {
                Name = name;
                ColumnName = columnName;
                PlaceHolderText = placetext;
                TextBoxIcon = image;
            }
        }
        private static string GenerateNewGuid()
        {
            //Generate New Guid
            return Guid.NewGuid().ToString();
        }

        private static string ReplaceFileNameWithGuid(string SourceFile)
        {

            FileInfo file = new FileInfo(SourceFile);
            return GenerateNewGuid() + file.Extension;
        }


        private static bool CheckFolderIfDoesNotExist(string DestenationFolder)
        {

            //Check if the folder does not exits , so we create a new folder
            if (!Directory.Exists(DestenationFolder))
            {
                try
                {
                    Directory.CreateDirectory(DestenationFolder);
                    return true;
                }

                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CopyFilePathToNewDestination(ref string SourceFile)
        {
            //Make the new destination folder
            string DestinationFolder = "D:\\Abdo\\DVLD Project\\DVLD_Images";


            if (!CheckFolderIfDoesNotExist(DestinationFolder))

            {
                return false;
            }

            //Make the new desitinaion file with the generated guid
            string DestinationFile = Path.Combine(DestinationFolder, ReplaceFileNameWithGuid(SourceFile));

            try
            {
                File.Copy(SourceFile, DestinationFile);
            }

            catch
            {
                return false;
            }

            SourceFile = DestinationFile;

            return true;


        }

        private static bool CheckFileIfExist(string FileName)
        {
            if (!File.Exists(FileName))
            {
                try
                {
                    File.Create("CurrentUser.txt");
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            return true;
        }


        public static string[] ReadOneLineFromFile(string FileName)
        {


            if (CheckFileIfExist(FileName))
            {

                using (StreamReader Reader = new StreamReader(FileName))
                {
                    string line;
                   if((line = Reader.ReadLine()) != null)
                    {
                        string [] LineInfo = line.Split('|');
                        return LineInfo;
                    }
                    else
                    {
                        return null;
                    }


                }

            }
            else
                return null;
        }

        public static bool WriteInFile(string FileName, string FileText)
        {
            if (CheckFileIfExist(FileName))
            {
                try
                {
                    File.WriteAllText(FileName, FileText);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;

        }


        public static bool DeleteFileContent(string FileName)
        {
            if (CheckFileIfExist(FileName))
            {
                try
                {
                    File.WriteAllText(FileName, "");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;

        }
    }
}
