using System;

namespace ConsoleApplication
{
    public class PrimeNumberGenerator
    {
        public void Run()
        {
            Int32 noi = -1;
            if(Int32.TryParse(Console.ReadLine(),out noi))
            {
                string[] inputs = new string[noi];
                for(int i=0;i<noi;i++)
                {
                    inputs[i] = Console.ReadLine();
                }

                for(int i=0;i<noi;i++)
                {
                    string[] startAndEnd = inputs[i].Split(' ');
                    Int32 startNum = -1;
                    Int32 endNum = -1;
                    if(Int32.TryParse(startAndEnd[0],out startNum) && Int32.TryParse(startAndEnd[1],out endNum))
                    {
                        for(int j=startNum ;j<=endNum;j++)
                        {
                            if(CheckPrime2(j))
                                Console.WriteLine(j);
                        }
                    }

                    Console.WriteLine("\r\n");
                }
            }
        }

        public bool CheckPrime(Int32 num)
        {
            if(num==1)
                return false;
            for(int i=num-1;i>1;i--)
            {
                if(num%i==0)
                    return false;
            }

            return true;
        }

        public bool CheckPrime1(Int32 num)
        {
            if(num ==1)
                return false;
            else if(num == 2)
                return true;
            else if(num ==3)
                return true;
            else if(num %2==0)
                return false;
            else if(num %3==0)
                return false;
            else
            {
                int i = 5;
                int w = 2;
                while (i*i<=num)
                {
                    if(num%i==0)
                        return false;

                    i+= w;
                    w = 6-w;
                }

            }

            return true;

        }

        public bool CheckPrime2(Int32 num)
        {
            if(num ==1)
                return false;
            else if(num == 2)
                return true;
            else if(num ==3)
                return true;
            else if(num %2==0)
                return false;
            else if(num %3==0)
                return false;
            else
            {
                int temp = (int)Math.Sqrt(num);
                while (temp>3)
                {
                    if(num%temp==0)
                        return false;

                    temp--;
                }

            }

            return true;
        }


    }
}