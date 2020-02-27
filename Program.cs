using System;


namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands commands = new Commands();
            Talk talk = new Talk();
            talk.Hello();
            commands.WaitToCommand();
        }
    }
}
