using System;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace Helper
{
    class Talk
    {
        string[] jokequest = {"шутку", "шутка", "шутки", "шуточка", "шутейка", "пошути"};
        bool fitstime = false;
        public string Name = Environment.UserName.ToUpper();
        public void Hello()
        {
         //   Console.WriteLine("Привет я тестовый бот, а как зоут тебя?");
           // string Name = Console.ReadLine();
            Console.WriteLine("Привет " + Name + ". Жду от тебя комманд");
        }

       
    
        public void TalkWithUser()
        {
            if(fitstime == false)
                Console.WriteLine($"Отлично {Name}, о чем поговорим? \n");
            else
                {
                    Random rand = new Random();
                    int randomanswer = rand.Next(0,3);
                    if(randomanswer == 0)
                        Console.WriteLine("Чего ещё хочешь?");
                    else if( randomanswer == 1)
                        Console.WriteLine("Чего хочешь, хозяин?");
                    else
                        Console.WriteLine("Чего изволите?");
                }
            fitstime = true;
            
            
            string user_request = Console.ReadLine();
            user_request.ToLower();
            
            if (user_request.Contains("фильм") || user_request.Contains("фильма") || user_request.Contains("фильмы") || user_request.Contains("посмотреть") || user_request.Contains("кино"))
            {
                GENRE:
                if (user_request.Contains("ужасов") || user_request.Contains("ужасы"))
                {
                    Movies movies = new Movies();
                    string[] movie = File.ReadAllLines(movies.horrors_path);
                
                    for (int i = 0; i <= movie.Length; i++)
                    {  
                        Random rnd = new Random();
                        Console.WriteLine("Советую посмотреть фильм: " + movie[rnd.Next(0,movie.Length)] + "\n");
                        TalkWithUser();
                    }
                }
                else if (user_request.Contains("комедию") || user_request.Contains("комедия") || user_request.Contains("комедии"))
                {
                    Movies movies = new Movies();
                    string[] movie = File.ReadAllLines(movies.comedy_path);
                
                    for (int i = 0; i <= movie.Length; i++)
                    {  
                        Random rnd = new Random();
                        Console.WriteLine("Советую посмотреть фильм: " + movie[rnd.Next(0,movie.Length)] + "\n");
                        TalkWithUser();
                    }
                }
                else if (user_request.Contains("мультик") || user_request.Contains("мультфильм") || user_request.Contains("мультики") || user_request.Contains("мультфильмы"))
                {
                    Movies movies = new Movies();
                    string[] movie = File.ReadAllLines(movies.comedy_path);
                
                    for (int i = 0; i <= movie.Length; i++)
                    {  
                        Random rnd = new Random();
                        Console.WriteLine("Советую посмотреть фильм: " + movie[rnd.Next(0,movie.Length)] + "\n");
                        TalkWithUser();
                    }
                }
                else
                {
                    Console.WriteLine("Тебе посоветовать фильм?");
                    user_request = Console.ReadLine().ToLower();
                    if(user_request.Contains("да") || user_request.Contains("давай") || user_request.Contains("посоветуй") || user_request.Contains("советуй") || user_request.Contains("хорошо"))
                    {
                        Console.WriteLine("В каком жанре? \n");
                        user_request = Console.ReadLine().ToLower();
                        goto GENRE;
                    }
                    else
                    {
                        Console.WriteLine("Ну да ну да, пошел я нахер \n");
                        TalkWithUser();
                    }
                    
                }
                
            }

            if (user_request.Contains("поисковике") || user_request.Contains("гугле") || user_request.Contains("загугли") || user_request.Contains("гугли"))
            {
               Console.WriteLine("Чего тебе найти в интернете?");
               string google_request = Console.ReadLine();
               Process.Start($"https://www.google.com/search?sxsrf=ALeKk01V60omcfxVJKb_EtyBb66pQ7Yw9g%3A1582894987416&ei=iw9ZXrr6GPLFrgT17rzgDQ&q=%{user_request}&oq=%{user_request}&gs_l=psy-ab.12...0.0..1186...0.0..0.0.0.......0......gws-wiz.kR8rcv-JlnE&ved=0ahUKEwj668Orp_TnAhXyoosKHXU3D9wQ4dUDCAo.html");
               TalkWithUser();
            }

            for (int i = 0; i <= jokequest.Length; i++)
            {
                if(user_request.Contains(jokequest[i]))
                {
                    Jokes jokes = new Jokes();
                    Random rnd = new Random();
                    Console.WriteLine(jokes.JokesArray[rnd.Next(0,jokes.JokesArray.Length)]);
                    TalkWithUser();
                }
                else
                {
                    Console.WriteLine($"Извини {Name}, я пока то туповат и не понял тебя, поробуй ещё раз \n");
                    TalkWithUser();
                }
            }
{
            
}
        }
    }
}