using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;


namespace Helper
{
    class NetConnectors
    {
        public void FtpConnection() //Проверка соединения с FTP
        {
            Console.WriteLine("Введите адрес:");
            string url = Console.ReadLine();
            Console.WriteLine("Введите логин или оставьте пустым если авторизация не нужна");
            string user = Console.ReadLine();
            Console.WriteLine("Введите пароль или оставьте пустым если авторизация не нужна");
            string pass = Console.ReadLine();
        TRYSSL:
            Console.WriteLine("Использовать ssl? --- 1: Использовать, 0: Не использовать");
            bool ssl;

            string tryssl = Console.ReadLine();

            if (tryssl == "1")
                ssl = true;
            else if (tryssl == "0")
                ssl = false;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз");
                goto TRYSSL;
            }

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, pass);
                request.EnableSsl = ssl; // если используется ssl
                Console.WriteLine("Соединение установлено: " + request.GetResponse());
            }
            catch (WebException ex)
            {
                Console.WriteLine("ОШИБКА! " + ex);
            }
        }

        public void FtpDownload() // Загрузка файлов с FTP
        {

            
            Console.WriteLine("Ведите ардес FTP сервера. Пример: 'addres.net'");
            string FTPServer = Console.ReadLine();
            Console.WriteLine("Введите логин или оставьте пустым если авторизация не нужна");
            string user = Console.ReadLine();
            Console.WriteLine("Введите пароль или оставьте пустым если авторизация не нужна");
            string pass = Console.ReadLine();
        TRYSSL:
            Console.WriteLine("Использовать ssl? --- 1: Использовать, 0: Не использовать");
            bool ssl;

            string tryssl = Console.ReadLine();

            if (tryssl == "1")
                ssl = true;
            else if (tryssl == "0")
                ssl = false;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз");
                goto TRYSSL;
            }

            
            Console.WriteLine("Ведите путь. Пример: 'папка1/папка2'");
            string remotePath = Console.ReadLine();
            Console.WriteLine("Введите имя файла. Пример: 'file.txt'");
            string fileNameToDownload = Console.ReadLine();
            Console.WriteLine("Куда сохранить файл?. Пример: '/home/sergey'");
            string saveToLocalPath = Console.ReadLine();

            try
            {
                //Get FTP web resquest object.
                FtpWebRequest request = FtpWebRequest.Create(new Uri(@"ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload)) as FtpWebRequest;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.EnableSsl = ssl;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
                    request.Credentials = new NetworkCredential(user, pass);
 
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                Stream responseStream = response.GetResponseStream();
                FileStream outputStream = new FileStream(saveToLocalPath + "/" + fileNameToDownload, FileMode.Create);
 
                int bufferSize = 1024;
                int readCount;
                byte[] buffer = new byte[bufferSize];
 
                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }
                string statusDescription = response.StatusDescription;
                responseStream.Close();
                outputStream.Close();
                response.Close();
                Console.WriteLine(statusDescription);
            }
            catch (Exception e)
            {
                throw new Exception("Error downloading from URL " + "ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload, e);
            }
            
        }

    }
}






