using System;
using log4net;
using log4net.Config;
using KakaoTalk;

namespace ConsoleApp1
{
    public partial class UserInterface
    {
        public void SelectWhatCanIDo()
        {
            Console.WriteLine("선택하세요 : ");
            
            switch (sel)
            {
                case 1: this.Remmitance();
                    return;
            }
        }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            UserInterfae user1 = new UserInterfae("1");            
            UserInterfae user2 = new UserInterfae("2");
            UserInterfae user3 = new UserInterfae("3");
            UserInterfae user4 = new UserInterfae("4");
            UserInterfae user5 = new UserInterfae("5");
            UserInterfae user6 = new UserInterfae("6");



            UserInterfae[] DoseM= { user1, user2, user3, user4, user5, user6 };

            user1.showKakao();
           
        }
    }
}
