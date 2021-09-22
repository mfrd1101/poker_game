using System;

namespace game
{
    /// <summary>
    /// 牙签游戏结构体
    /// </summary>
    struct Structpick
    {
        /// <summary>
        /// 牙签总数
        /// </summary>
        public int allcnt;
        /// <summary>
        /// 牙签剩余总数
        /// </summary>
        public int allcnt_leftover;
        /// <summary>
        /// 牙签分成行数
        /// </summary>
        public int rowcnt;
        /// <summary>
        /// 当前行的牙签数
        /// </summary>
        public int[] row;
        /// <summary>
        /// 当前行的剩余牙签数
        /// </summary>
        public int[] row_leftover;
        /// <summary>
        /// 玩家人数
        /// </summary>
        public int person_cnt;
    }
    class Program
    {
        /// <summary>
        /// 牙签游戏对象
        /// </summary>
        private static Structpick sPick;
        /// <summary>
        /// 游戏自动模式用
        /// </summary>
        private static Random random = new Random();
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("取牙签游戏!\n");
                Console.WriteLine("是否制定规则？Y/N");
                if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                {
                    //1.定制游戏规则
                    CreateGame();
                }
                else
                {
                    //1.默认游戏规则
                    CreateGameDefault();
                }

                //2.开始游戏
                StartGame();

                Console.Read();
            }
            catch 
            {
                Console.WriteLine("您的输入不正确，请注意输入数字！系统错误需要重新运行程序！");
                System.Threading.Thread.Sleep(5000);
            }

        }

        /// <summary>
        /// 默认游戏规则
        /// </summary>
        static void CreateGameDefault()
        {

            sPick.row = new int[10];

            //将15根牙签
            //分成三行
            sPick.allcnt = 15;
            sPick.rowcnt = 3;
            //每行自上而下（其实方向不限）分别是3、5、7根
            sPick.row[0] = 3;
            sPick.row[1] = 5;
            sPick.row[2] = 7;

            //默认两名玩家
            sPick.person_cnt = 2;

            Console.WriteLine("默认游戏规则已经制定！\n");
           
        }

        /// <summary>
        /// 定制游戏规则
        /// </summary>
        static void CreateGame()
        {
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※游戏规则制定※※※※※※※※※※※※※※※");
            sPick.row = new int[10];
            //1.游戏规则制定
            int num;
            Console.WriteLine("请先输入牙签的总量为:");
            num = Int32.Parse(Console.ReadLine());
            while (num <= 0)
            {
                Console.WriteLine("必须大于0,请重新输入:");
                num = Int32.Parse(Console.ReadLine());
            }


            sPick.allcnt = num;
            Console.WriteLine("牙签的总量为:{0:D} ", sPick.allcnt);

            Console.WriteLine("请先输入牙签摆几行:");
            num = Int32.Parse(Console.ReadLine());
            while (num <= 0 || num > 10 || num > sPick.allcnt)
            {
                if (num > sPick.allcnt)
                {
                    Console.WriteLine("必须在1～{0:D}行以内,请重新输入:", sPick.allcnt);
                }
                else
                {
                    Console.WriteLine("必须在1～10行以内,请重新输入:");
                }

                num = Int32.Parse(Console.ReadLine());
            }
            sPick.rowcnt = num;

            int index = 0;
            //行摆时候剩余牙签数量
            sPick.allcnt_leftover = sPick.allcnt;
            while (index < sPick.rowcnt)
            {

                if (index == sPick.rowcnt - 1)
                {
                    sPick.row[index] = sPick.allcnt_leftover;
                    sPick.allcnt_leftover = 0;
                    Console.WriteLine("最后第{0:D}行摆根牙签数量:", index + 1);
                    Console.WriteLine("{0:D}", sPick.row[index]);
                    break;
                }
                Console.WriteLine("请先输入第{0:D}行摆几根牙签:", index + 1);
                num = Int32.Parse(Console.ReadLine());

                while (num <= 0 || num > sPick.allcnt_leftover - (sPick.rowcnt - index) + 1)
                {
                    Console.WriteLine("必须在1～{0:D}根以内,请重新输入:", sPick.allcnt_leftover - (sPick.rowcnt - index) + 1);
                    num = Int32.Parse(Console.ReadLine());
                }
                sPick.row[index] = num;
                sPick.allcnt_leftover = sPick.allcnt_leftover - num;
                index = index + 1;
            }

            Console.WriteLine("请先输入玩家数量:");
            num = Int32.Parse(Console.ReadLine());
            while (num < 2 || num > 5 )
            {
                Console.WriteLine("必须在2～5玩家以内,请重新输入:");
                num = Int32.Parse(Console.ReadLine());
            }
            sPick.person_cnt  = num;

            Console.WriteLine("※※※※※※※※※※※※※※※※※游戏规则制定结束※※※※※※※※※※※※※※※\n\n");
            System.Threading.Thread.Sleep(3000);

        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        static void StartGame()
        {
            //2.开始游戏
            bool isAuto = false;
            Console.WriteLine("是否自动游戏测试？Y/N");
            if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
            {
                isAuto = true;
            }

            //游戏规则说明

            Console.WriteLine("※※※※※※※※※※※※※※※※※游戏规则说明※※※※※※※※※※※※※※※※※");
            Console.WriteLine("将{0:D}根牙签 ", sPick.allcnt);
            Console.WriteLine("分成{0:D}行 ", sPick.rowcnt);
            int index = 0;
            while (index < sPick.rowcnt)
            {
                Console.WriteLine("第{0:D}行放 {1:D}根牙签 ", index + 1, sPick.row[index]);
                index = index + 1;
            }
            Console.WriteLine("安排{0:D}个玩家，每人可以在一轮内，在任意行拿任意根牙签，但不能跨行。", sPick.person_cnt);
            Console.WriteLine("★注意：拿最后一根牙签的人即为输家！！！");
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n\n");
           
            if (isAuto == true )
            {
                System.Threading.Thread.Sleep(5000);

                Console.WriteLine("现在是自动模式(测试用)!\n");
                StartGameAuto();
                Console.WriteLine("游戏结束！");
            }
            else
            {
                Console.WriteLine("现在是手动模式(玩家版)!\n");
                StartGameHand();
                Console.WriteLine("游戏结束！");
            }
        }

        /// <summary>
        /// 手动模式
        /// </summary>
        static void StartGameHand()
        {
            //1.游戏规则制定
            int num;

            Console.WriteLine("现在{0:D}位玩家开始游戏了!\n", sPick.person_cnt);

            //剩余牙签数量初始化
            sPick.allcnt_leftover = sPick.allcnt;

            //行剩余牙签数量初始化
            sPick.row_leftover = new int[sPick.row.Length];
            sPick.row.CopyTo(sPick.row_leftover, 0);

            //当前指定行
            int row_num = 0;

            
            while (sPick.allcnt_leftover > 0)
            {
                int person_index = 0;
                while (person_index < sPick.person_cnt)
                {
                    Console.WriteLine("玩家{0:D} 开始取牙签！", person_index + 1);
                    Console.WriteLine("玩家{0:D} 请输入取第几行牙签:", person_index + 1);
                    num = Int32.Parse(Console.ReadLine());
                    while (num <= 0 || num > sPick.rowcnt)
                    {
                        Console.WriteLine("必须在1～{0:D}行以内,请重新输入:", sPick.rowcnt);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    while (sPick.row_leftover[num - 1] <= 0)
                    {
                        Console.WriteLine("当前第{0:D}行已经没有牙签了，请重新输入第几行:", num);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    row_num = num - 1;
                    Console.WriteLine("玩家{0:D} 请输入取几根牙签:", person_index + 1);
                    num = Int32.Parse(Console.ReadLine());
                    while (num <= 0 || num > sPick.row_leftover[row_num])
                    {
                        Console.WriteLine("必须在1～{0:D}根以内,请重新输入:", sPick.row_leftover[row_num]);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    sPick.row_leftover[row_num] = sPick.row_leftover[row_num] - num;
                    sPick.allcnt_leftover = sPick.allcnt_leftover - num;

                    if (sPick.allcnt_leftover <= 0)
                    {
                        Console.WriteLine("\n※※※※※※※※※※※※※※※※※※※游戏结束※※※※※※※※※※※※※※※※※");
                        Console.WriteLine("玩家{0:D}   运气不佳(+﹏+) ，您拿到最后一根牙签，游戏结束!!!\n", person_index + 1);
                        Console.WriteLine("※※※※※※※※※※※※※※※※※※※游戏结束※※※※※※※※※※※※※※※※※\n");
                        Console.WriteLine("再来一盘？Y/N");
                        if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                        {
                            StartGame();
                        }
                        return ;
                    }
                    else
                    {  //每一个玩家结束后换行
                        Console.WriteLine("\n");
                    }

                    person_index = person_index + 1;

                }


            }
        }

            static void StartGameAuto()
            {

                //1.游戏规则制定
                int num;

                Console.WriteLine("现在{0:D}位玩家开始游戏了!\n", sPick.person_cnt);

                //行摆时候剩余牙签数量
                sPick.allcnt_leftover = sPick.allcnt;
                sPick.row_leftover = new int[sPick.row.Length];
                sPick.row.CopyTo(sPick.row_leftover, 0);
                int row_num = 0;
                while (sPick.allcnt_leftover > 0)
                {
                    int person_index = 0;
                    while (person_index < sPick.person_cnt)
                    {
                        Console.WriteLine("玩家{0:D} 开始取牙签！", person_index + 1);
                        Console.WriteLine("玩家{0:D} 请输入取第几行牙签:", person_index + 1);
                        num = GetNumber(sPick.rowcnt);
                        while (num <= 0 || num > sPick.rowcnt)
                        {
                            num = GetNumber(sPick.rowcnt);
                        }
                        while (sPick.row_leftover[num - 1] <= 0)
                        {
                            num = GetNumber(sPick.rowcnt);
                        }
                        Console.WriteLine("{0:D}", num);
                        row_num = num - 1;
                        Console.WriteLine("玩家{0:D} 请输入取几根牙签:", person_index + 1);
                        num = GetNumber(sPick.row_leftover[row_num]);
                        while (num <= 0 || num > sPick.row_leftover[row_num])
                        {
                            num = GetNumber(sPick.row_leftover[row_num]);
                        }
                        Console.WriteLine("{0:D}", num);

                        sPick.row_leftover[row_num] = sPick.row_leftover[row_num] - num;
                        sPick.allcnt_leftover = sPick.allcnt_leftover - num;


                        if (sPick.allcnt_leftover <= 0)
                        {
                            Console.WriteLine("\n※※※※※※※※※※※※※※※※※※※游戏结束※※※※※※※※※※※※※※※※※");
                            Console.WriteLine("玩家{0:D}   运气不佳(+﹏+) ，您拿到最后一根牙签，游戏结束!!!\n", person_index + 1);
                            Console.WriteLine("※※※※※※※※※※※※※※※※※※※游戏结束※※※※※※※※※※※※※※※※※\n");
                            Console.WriteLine("再来一盘？Y/N");
                            if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                            {
                                StartGame();
                            }
                            return;
                        }
                        else
                        {  //每一个玩家结束后换行
                            Console.WriteLine("\n");
                        }

                        person_index = person_index + 1;

                    }


                }
            }

            static int GetNumber(int max_number)
            {
                return random.Next(1, max_number + 1);

            }



           
    }
}
