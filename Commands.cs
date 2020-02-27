using System;
using System.IO;
using Helper;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Helper
{
    class Commands
    {
        public void WaitToCommand() //Выбор комманды
        {
            Console.WriteLine("Жду ваших указаний. \n");
            string command = Console.ReadLine().ToLower();
            if (command == "-h" || command == "help")
                Help();
            else if (command == "exit" || command == "close")
                ExitApp();
            else if (command == "create file" || command == "create")
                CreateFile();
            else if (command == "ftp")
                FtpConnect();
            else if (command == "weather")
                GetWeather();
            else if (command.Contains("поговорим") || command.Contains("поговорить") || command.Contains("поговори"))
            {
                Talk talk = new Talk();
                talk.TalkWithUser();
            }
                
            else
            {
                Console.WriteLine("Я не понимаю вас, попробуйте выразиться понятнее или воспользуйтесь функцией 'help'");
                WaitToCommand();
            }
        }

        public void Help() //Вызов помощи
        {
            Help help = new Help();

            Console.WriteLine("Вот что я умею:");

            for (int i = 0; i< help.CommandList.Length; i++)
            {
                Console.WriteLine(help.CommandList[i]);
            }
            WaitToCommand();
        }

        public void CreateFile() //Создание файла
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            Console.WriteLine("Доступные диски");

            foreach (DriveInfo d in allDrives)

            {
                Console.WriteLine("Диск {0}", d.Name);
                Console.WriteLine("  Тип диска: {0}", d.DriveType);
            }

            Console.WriteLine("Укажите путь:");
            string path = Console.ReadLine();
            Console.WriteLine("Укажите имя файла:");
            string filename = Console.ReadLine();
            Console.WriteLine("Укажите расширение файла или оставьте пустым если указали его в имени:");
            string extention = Console.ReadLine();

            string fullpath_1 = path + filename;
            string fullpath_2 = path + filename + extention;

            if (extention == "")
            {
                using (FileStream fs = File.Create(fullpath_1))
                {
                    //byte[] info = new UTF8Encoding(true).GetBytes("Файл создан! " + fullpath_1);
                    //fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("Файл созлан " + fullpath_1);

            }
            else
            {
                using (FileStream fs = File.Create(fullpath_2))
                {
                    //byte[] info = new UTF8Encoding(true).GetBytes("Файл создан! " + fullpath_2);
                    //fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("Файл созлан " + fullpath_2);
            }
            
            WaitToCommand();
        }

        private void FtpConnect()
        {
            Console.WriteLine("Доступные действия, нажмите клавишу:");
            Console.WriteLine("1: Проверка соединения, 2: Загрузить файл на FTP сервер, Скачать файлы с FTP сервера");
            string ftp_commad = Console.ReadLine();
            NetConnectors net = new NetConnectors();

            if (ftp_commad == "1")
            {
                
                net.FtpConnection();
            }
            else if (ftp_commad == "3")
            {
                net.FtpDownload();
            }
            else if(ftp_commad == "exit")
            {
                WaitToCommand();
            }
            else
            {
                Console.WriteLine("Неизвестная комманда, попробуйте ещё раз или введите 'exit' - что-бы вернуться к главному меню");
            }
            
        }

        public void GetFileInfo()
        {
            string path = Path.GetTempFileName();
            var fi1 = new FileInfo(path);
            WaitToCommand();
        }

        public void GetWeather()
        {
            Console.WriteLine("Введи город");
            string city = Console.ReadLine();
            WeatherData weather = new WeatherData(city);
            weather.CheckWeather();

        }


        public void ExitApp() //Выход из приложения
        {
            Console.WriteLine("До свидания ");
            System.Environment.Exit(0);
        }
    }
}