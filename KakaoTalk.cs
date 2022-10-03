using log4net;
using System;


namespace KakaoTalk
{
 
    public class Bank
    {
        private readonly int mb_account;  //계좌번호
        private readonly int mb_userInfo; //주민등록번호
        private readonly int mb_password; //계좌비밀번호
        private readonly int mb_cardInfo; //카드번호
        public int mb_balance;               //잔액

        public Bank()
        {
            Random rand = new Random();
            mb_userInfo = rand.Next(100, 1000);
            mb_password = rand.Next(100000, 1000000);
            mb_account = rand.Next(100, 1000);
            mb_cardInfo = rand.Next(100, 1000);
            mb_balance = 1000000;
        }
        public void showInfo()
        {
            Console.WriteLine("계좌번호 : {0}\n주민등록번호 : {1}\n" +
                "계좌비밀번호 : {2}\n카드번호 : {3}\n계좌잔액 : {4}", mb_account, mb_userInfo, mb_password, mb_cardInfo, mb_balance);
        }
        public int showAccount()
        {
            return mb_account;
        }
    }

    public class kakao : Bank
    {
        public int mk_userEmail;         //계정 이메일
        public int mk_userPassword;      //계정 비밀번호
        public int mk_address;           //계정 주소
        public int mk_balance;              //잔액

        public void showKakao()
        {
            Console.WriteLine("계정 이메일 : {0}\n계정 비밀번호 : {1}\n" +
                "계정주소 : {2}\n잔액: {3}", mk_userEmail, mk_userPassword, mk_address, mk_balance);
            
        }
        public void Remmitance(int cash)
        {                
            if (cash > base.mb_balance)
            {
                Console.WriteLine("은행 계좌 잔액 부족입니다");
                return;
            }

            if (cash>this.mk_balance) {
                Charge(cash);
                this.mk_balance -= cash;
                inputPwd();
            }
            else
            { 
                this.mk_balance -= cash;
                inputPwd();
            }
        }

        public void Charge(int cash)
        {
            this.mb_balance -= cash * 2;
            this.mk_balance += cash * 2;
        }
        public int Howmuch()
        {
            return mk_balance;
        }

            
        public void LeaveMessage(string message)
        {

            if (this.mk_balance.ToString().Length>0)
            {
                Console.Write("┌--");
                for(int i=0;i< this.mk_balance.ToString().Length; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("--┐");
                Console.Write("|  ", message, "  |");
            }
            Console.WriteLine("|  잔액 : {0}  |", this.mk_balance);
            if (this.mk_balance.ToString().Length > 0)
            {
                Console.Write("└--");
                for (int i = 0; i < this.mk_balance.ToString().Length; i++)
                {
                    Console.Write("-");
                }
                Console.Write("--┘");
            }
        }

        public bool inputPwd()
        {                
            Console.Write("간편 비밀번호 6자리 : ");
            string password = Console.ReadLine();
            if (this.mk_userPassword == Convert.ToInt32(password))
            {
                return true;
            }
            else
                Console.WriteLine("잘못된 번호입니다.");
                return false;
        }

        class KakaoBank
        {
            private readonly string mkb_account;  //계좌번호
            private readonly string mkb_userInfo; //주민등록번호
            private readonly string mkb_password; //계좌비밀번호
            private readonly string mkb_cardInfo; //카드번호
            public int mkb_balance;               //잔액
        }
    }
 
    public class UserInterfae :kakao
    {
        public string mu_nickname;

        public UserInterfae(string unique) 
        {

            Random rand = new Random();
            mk_userPassword = rand.Next(100000, 1000000);
            mk_userEmail = rand.Next(100000, 1000000);
            mk_address = rand.Next(100000, 1000000);         
            mk_balance = 0;
        }
        
        public int inputAmount()
        {
            Console.Write("금액을 입력하세요 : ");
            string remmit = Console.ReadLine();
            int cash =Convert.ToInt32(remmit);
            return cash;
        }

        public void Remmitance()
        {              
                int cash = inputAmount();
                base.Remmitance(cash);
                string message = "송금을 했어요 " + cash.ToString() + "원";
                Message(message);           
        }

        public void Request()
        {
                int reqCash = inputAmount();
                Console.WriteLine("계좌정보도 보낼래요 Y/N");
                string select = Console.ReadLine().ToUpper();
                if (select == "Y")
                {
                    Message("송금을 요청했어요" + "\n계좌 정보: " + showAccount() + "\n요청 금액: " + reqCash + "원");
                    return;
                }
                else
                {
                    Message("송금을 요청했어요" + "\n요청 금액: " + reqCash + "원");
                    return;
                }
        }

        public void Calculate(int size)
        {
            int Cash = inputAmount();
            int calCash = Cash / (size-1);
            Console.WriteLine("계좌정보도 보낼래요 Y/N");
            string select = Console.ReadLine().ToUpper();
            if (select == "Y")
            {
                Message("송금을 요청했어요" + "\n계좌 정보: " + showAccount() + "\n요청 금액: " + calCash + "원");
                return;
            }
            else
            {
                Message("송금을 요청했어요" + "\n요청 금액: " + calCash + "원");
                return;
            }
        }

        public void Message(string message)
        {

                Console.Write("┌--");
                for (int i = 0; i < message.Length; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("--┐");
                Console.WriteLine("|  "+message+"  |");

                Console.Write("└--");
                for (int i = 0; i < message.Length; i++)
                {
                    Console.Write("-");
                }
                Console.Write("--┘");
            }
        }
    }

