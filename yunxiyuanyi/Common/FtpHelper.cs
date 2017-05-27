using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FTPConfig
    {
        public string URI { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

    }

    public class FTPFile
    {
        public string Name { get; set; }
        public FTPFileType Type { get; set; }
        public string Parent { get; set; }

        public bool IsScaned { get; set; }
    }

    public enum FTPFileType
    {
        File = 1,
        Folder = 2
    }

    public class FtpHelper
    {

        private static FTPConfig GetConfig()
        {
            FTPConfig result = new FTPConfig();
            result.URI = "ftp://192.168.22.233";
            result.Account = "Administrator";
            result.Password = "!QA2ws3ed";
            return result;
        }
        public static bool UploadFile(string sourceFileFullName, string targetFileName)
        {
            FTPConfig result = GetConfig();
            return UploadFile(sourceFileFullName, targetFileName, result);
        }

        public static bool UploadFile(string sourceFileFullName, string targetFileName, FTPConfig config)
        {
            bool result = true;
            try
            {
                FtpWebRequest request;
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(config.URI + "/" + targetFileName));
                request.Credentials = new NetworkCredential(config.Account, config.Password);
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ContentLength = sourceFileFullName.Length;
                int buffLength = 4096;
                byte[] buff = new byte[buffLength];
                int contentLen;
                using (var localFileStream = new FileInfo(sourceFileFullName).OpenRead())
                {
                    using (var requestStream = request.GetRequestStream())
                    {
                        contentLen = localFileStream.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            requestStream.Write(buff, 0, contentLen);
                            contentLen = localFileStream.Read(buff, 0, buffLength);
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool Download(string localFolder, string fileName)
        {
            FTPConfig result = GetConfig();
            return Download(localFolder, fileName, result);
        }

        public static bool Download(string localFolder, string fileName, FTPConfig config)
        {
            bool result = true;
            FtpWebRequest reqFTP;
            try
            {
                using (FileStream outputStream = new FileStream(localFolder + "\\" + fileName, FileMode.Create))
                {

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(config.URI + "/" + fileName));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(config.Account, config.Password);
                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        using (Stream ftpStream = response.GetResponseStream())
                        {
                            long cl = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[bufferSize];
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public static bool Delete(string fileName)
        {
            FTPConfig result = GetConfig();
            return Delete(fileName, result);
        }
        public static bool Delete(string fileName, FTPConfig config)
        {
            bool result = true;
            try
            {
                string uri = config.URI + "/" + fileName;
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                request.Credentials = new NetworkCredential(config.Account, config.Password);
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                string responsResult;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    long size = response.ContentLength;
                    using (Stream datastream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(datastream))
                        {
                            responsResult = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public static List<string> GetListDirectoryDetails()
        {
            FTPConfig result = GetConfig();
            return GetListDirectoryDetails(result);
        }
        public static List<string> GetListDirectoryDetails(FTPConfig config)
        {

            try
            {
                List<string> result = new List<string>();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(config.URI));
                ftp.Credentials = new NetworkCredential(config.Account, config.Password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                using (WebResponse response = ftp.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Add(line);
                            line = reader.ReadLine();
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void GetListDirectory(List<FTPFile> list, string folder = "")
        {
            FTPConfig result = GetConfig();
            GetListDirectory(result, list, folder);
        }
        public static void GetListDirectory(FTPConfig config, List<FTPFile> list, string folder)
        {

            try
            {
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(config.URI + "/" + folder));
                ftp.Credentials = new NetworkCredential(config.Account, config.Password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                using (WebResponse response = ftp.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            FTPFile item = new FTPFile();
                            item.Name = line;
                            item.Parent = folder;
                            item.IsScaned = false;
                            item.Type = line.IndexOf(".") > 0 ? FTPFileType.File : FTPFileType.Folder;
                            list.Add(item);
                            line = reader.ReadLine();
                        }
                    }
                }
                var childs = list.Where(x => x.Parent == folder).ToList();
                foreach (var item in childs)
                {
                    if (!item.IsScaned && item.Type == FTPFileType.Folder)
                    {
                        GetListDirectory(config, list, folder + "/" + item.Name);
                        item.IsScaned = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static bool CreateFolder(string folder)
        {
            FTPConfig result = GetConfig();
            return CreateFolder(folder, result);
        }

        public static bool CreateFolder(string folder, FTPConfig config)
        {
            bool result = true;
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(config.URI + "/" + folder));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(config.Account, config.Password);
                using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                using (Stream ftpStream = response.GetResponseStream()) { }
            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;
        }

        public static string[] GetDirectoryList()
        {
            var drectory = GetListDirectoryDetails();
            string m = string.Empty;
            foreach (string str in drectory)
            {
                if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {
                    m += str.Substring(54).Trim() + "\n";
                }
            }
            char[] n = new char[] { '\n' };
            return m.Split(n);
        }


        public static bool FolderIsExists(string folder)
        {
            string[] dirList = GetDirectoryList();
            foreach (string str in dirList)
            {
                if (str.Trim() == folder.Trim())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
