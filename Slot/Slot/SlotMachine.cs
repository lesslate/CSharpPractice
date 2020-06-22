using System;
using System.Collections.Generic;
using System.Text;

namespace Slot
{
    class SlotMachine
    {
        private int[,] slot = new int[3, 3];
        private Dictionary<int, string> slotNames = new Dictionary<int, string>()
        {
            {0, "        " },
            {1, "   bar  " },
            {2, "  초록7 " },
            {4, "  분홍7 " },
            {7, "  wild "  }
        };

        // 배율
        private const float barMulti = 0.55f;
        private const float greenSevenMulti = 1.66f;
        private const float sevenMulti = 5.55f;

        private const string blank = "        ";
        private const string bar = "   bar  ";
        private const string greenSeven = "  초록7 ";
        private const string pinkSeven = "  분홍7 ";
        private const string wild = "  wild  ";



        public void RollingSlot()
        {
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                int rand = rnd.Next(1, 3); //1,2 생성

                if (rand == 1) // 2칸 채우기
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 1)
                        {
                            slot[j, i] = 0;
                        }
                        else
                        {
                            slot[j, i] = WhichSlot();
                        }
                    }
                }
                else // 중앙 채우기
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 1)
                        {
                            slot[j, i] = WhichSlot();
                        }
                        else
                        {
                            slot[j, i] = 0;
                        }
                    }
                }
            }
        }

        private int WhichSlot() // 채워질 슬롯 반환 함수
        {
            int whatSlot = 0;
            Random rnd = new Random();
            int rand = (rnd.Next(1, 11));
            if (rand <= 6)     // 60%
            {
                whatSlot = 1;
            }
            else if (rand <= 8) // 20%
            {
                whatSlot = 2;
            }
            else if (rand <= 9) // 10%
            {
                whatSlot = 4;
            }
            else             // 10%
            {
                whatSlot = 7;
            }

            return whatSlot;

        }

        public void PrintSlot() // 슬롯 출력 함수
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(slotNames[slot[i, j]] + "  │");

                }
                Console.WriteLine();
                Console.Write("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                Console.WriteLine();
            }
        }

        public void CheckSlot()
        {
            CheckWin(slot[0, 0] & slot[0, 1] & slot[0, 2]);
            CheckWin(slot[0, 0] & slot[1, 1] & slot[0, 2]);
            CheckWin(slot[0, 0] & slot[1, 1] & slot[2, 2]);

            CheckWin(slot[1, 0] & slot[1, 1] & slot[1, 2]);
            CheckWin(slot[1, 0] & slot[0, 1] & slot[1, 2]);
            CheckWin(slot[1, 0] & slot[2, 1] & slot[1, 2]);

            CheckWin(slot[2, 0] & slot[2, 1] & slot[2, 2]);
            CheckWin(slot[2, 0] & slot[1, 1] & slot[0, 2]);
            CheckWin(slot[2, 0] & slot[1, 1] & slot[2, 2]);
        }

        private void CheckWin(int num)
        {
            if (num == 1)
            {
                Console.Write("Bar당첨  ");
            }
            else if (num == 2)
            {
                Console.Write("초록7 당첨  ");
            }
            else if (num == 4)
            {
                Console.Write("분홍7 당첨  ");
            }
        }
    }
}
