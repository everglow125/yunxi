using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FtpHelper
    {

        public static bool UploadFile(string source, string ftpUrl, string ftpUser, string ftpPwd)
        {
            bool result = true;
            try
            {
                FtpWebRequest request;
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUrl));
                request.Credentials = new NetworkCredential(ftpUser, ftpPwd);
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ContentLength = source.Length;
                int buffLength = 4096;
                byte[] buff = new byte[buffLength];
                int contentLen;
                using (var localFileStream = new FileInfo(source).OpenRead())
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
    }
}
