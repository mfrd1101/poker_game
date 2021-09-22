using System;

namespace game
{
    /// <summary>
    /// ��ǩ��Ϸ�ṹ��
    /// </summary>
    struct Structpick
    {
        /// <summary>
        /// ��ǩ����
        /// </summary>
        public int allcnt;
        /// <summary>
        /// ��ǩʣ������
        /// </summary>
        public int allcnt_leftover;
        /// <summary>
        /// ��ǩ�ֳ�����
        /// </summary>
        public int rowcnt;
        /// <summary>
        /// ��ǰ�е���ǩ��
        /// </summary>
        public int[] row;
        /// <summary>
        /// ��ǰ�е�ʣ����ǩ��
        /// </summary>
        public int[] row_leftover;
        /// <summary>
        /// �������
        /// </summary>
        public int person_cnt;
    }
    class Program
    {
        /// <summary>
        /// ��ǩ��Ϸ����
        /// </summary>
        private static Structpick sPick;
        /// <summary>
        /// ��Ϸ�Զ�ģʽ��
        /// </summary>
        private static Random random = new Random();
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("ȡ��ǩ��Ϸ!\n");
                Console.WriteLine("�Ƿ��ƶ�����Y/N");
                if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                {
                    //1.������Ϸ����
                    CreateGame();
                }
                else
                {
                    //1.Ĭ����Ϸ����
                    CreateGameDefault();
                }

                //2.��ʼ��Ϸ
                StartGame();

                Console.Read();
            }
            catch 
            {
                Console.WriteLine("�������벻��ȷ����ע���������֣�ϵͳ������Ҫ�������г���");
                System.Threading.Thread.Sleep(5000);
            }

        }

        /// <summary>
        /// Ĭ����Ϸ����
        /// </summary>
        static void CreateGameDefault()
        {

            sPick.row = new int[10];

            //��15����ǩ
            //�ֳ�����
            sPick.allcnt = 15;
            sPick.rowcnt = 3;
            //ÿ�����϶��£���ʵ�����ޣ��ֱ���3��5��7��
            sPick.row[0] = 3;
            sPick.row[1] = 5;
            sPick.row[2] = 7;

            //Ĭ���������
            sPick.person_cnt = 2;

            Console.WriteLine("Ĭ����Ϸ�����Ѿ��ƶ���\n");
           
        }

        /// <summary>
        /// ������Ϸ����
        /// </summary>
        static void CreateGame()
        {
            Console.WriteLine("����������������������������������������Ϸ�����ƶ�������������������������������");
            sPick.row = new int[10];
            //1.��Ϸ�����ƶ�
            int num;
            Console.WriteLine("����������ǩ������Ϊ:");
            num = Int32.Parse(Console.ReadLine());
            while (num <= 0)
            {
                Console.WriteLine("�������0,����������:");
                num = Int32.Parse(Console.ReadLine());
            }


            sPick.allcnt = num;
            Console.WriteLine("��ǩ������Ϊ:{0:D} ", sPick.allcnt);

            Console.WriteLine("����������ǩ�ڼ���:");
            num = Int32.Parse(Console.ReadLine());
            while (num <= 0 || num > 10 || num > sPick.allcnt)
            {
                if (num > sPick.allcnt)
                {
                    Console.WriteLine("������1��{0:D}������,����������:", sPick.allcnt);
                }
                else
                {
                    Console.WriteLine("������1��10������,����������:");
                }

                num = Int32.Parse(Console.ReadLine());
            }
            sPick.rowcnt = num;

            int index = 0;
            //�а�ʱ��ʣ����ǩ����
            sPick.allcnt_leftover = sPick.allcnt;
            while (index < sPick.rowcnt)
            {

                if (index == sPick.rowcnt - 1)
                {
                    sPick.row[index] = sPick.allcnt_leftover;
                    sPick.allcnt_leftover = 0;
                    Console.WriteLine("����{0:D}�аڸ���ǩ����:", index + 1);
                    Console.WriteLine("{0:D}", sPick.row[index]);
                    break;
                }
                Console.WriteLine("���������{0:D}�аڼ�����ǩ:", index + 1);
                num = Int32.Parse(Console.ReadLine());

                while (num <= 0 || num > sPick.allcnt_leftover - (sPick.rowcnt - index) + 1)
                {
                    Console.WriteLine("������1��{0:D}������,����������:", sPick.allcnt_leftover - (sPick.rowcnt - index) + 1);
                    num = Int32.Parse(Console.ReadLine());
                }
                sPick.row[index] = num;
                sPick.allcnt_leftover = sPick.allcnt_leftover - num;
                index = index + 1;
            }

            Console.WriteLine("���������������:");
            num = Int32.Parse(Console.ReadLine());
            while (num < 2 || num > 5 )
            {
                Console.WriteLine("������2��5�������,����������:");
                num = Int32.Parse(Console.ReadLine());
            }
            sPick.person_cnt  = num;

            Console.WriteLine("������������������������������������Ϸ�����ƶ�����������������������������������\n\n");
            System.Threading.Thread.Sleep(3000);

        }

        /// <summary>
        /// ��ʼ��Ϸ
        /// </summary>
        static void StartGame()
        {
            //2.��ʼ��Ϸ
            bool isAuto = false;
            Console.WriteLine("�Ƿ��Զ���Ϸ���ԣ�Y/N");
            if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
            {
                isAuto = true;
            }

            //��Ϸ����˵��

            Console.WriteLine("������������������������������������Ϸ����˵������������������������������������");
            Console.WriteLine("��{0:D}����ǩ ", sPick.allcnt);
            Console.WriteLine("�ֳ�{0:D}�� ", sPick.rowcnt);
            int index = 0;
            while (index < sPick.rowcnt)
            {
                Console.WriteLine("��{0:D}�з� {1:D}����ǩ ", index + 1, sPick.row[index]);
                index = index + 1;
            }
            Console.WriteLine("����{0:D}����ң�ÿ�˿�����һ���ڣ������������������ǩ�������ܿ��С�", sPick.person_cnt);
            Console.WriteLine("��ע�⣺�����һ����ǩ���˼�Ϊ��ң�����");
            Console.WriteLine("��������������������������������������������������������������������������������\n\n");
           
            if (isAuto == true )
            {
                System.Threading.Thread.Sleep(5000);

                Console.WriteLine("�������Զ�ģʽ(������)!\n");
                StartGameAuto();
                Console.WriteLine("��Ϸ������");
            }
            else
            {
                Console.WriteLine("�������ֶ�ģʽ(��Ұ�)!\n");
                StartGameHand();
                Console.WriteLine("��Ϸ������");
            }
        }

        /// <summary>
        /// �ֶ�ģʽ
        /// </summary>
        static void StartGameHand()
        {
            //1.��Ϸ�����ƶ�
            int num;

            Console.WriteLine("����{0:D}λ��ҿ�ʼ��Ϸ��!\n", sPick.person_cnt);

            //ʣ����ǩ������ʼ��
            sPick.allcnt_leftover = sPick.allcnt;

            //��ʣ����ǩ������ʼ��
            sPick.row_leftover = new int[sPick.row.Length];
            sPick.row.CopyTo(sPick.row_leftover, 0);

            //��ǰָ����
            int row_num = 0;

            
            while (sPick.allcnt_leftover > 0)
            {
                int person_index = 0;
                while (person_index < sPick.person_cnt)
                {
                    Console.WriteLine("���{0:D} ��ʼȡ��ǩ��", person_index + 1);
                    Console.WriteLine("���{0:D} ������ȡ�ڼ�����ǩ:", person_index + 1);
                    num = Int32.Parse(Console.ReadLine());
                    while (num <= 0 || num > sPick.rowcnt)
                    {
                        Console.WriteLine("������1��{0:D}������,����������:", sPick.rowcnt);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    while (sPick.row_leftover[num - 1] <= 0)
                    {
                        Console.WriteLine("��ǰ��{0:D}���Ѿ�û����ǩ�ˣ�����������ڼ���:", num);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    row_num = num - 1;
                    Console.WriteLine("���{0:D} ������ȡ������ǩ:", person_index + 1);
                    num = Int32.Parse(Console.ReadLine());
                    while (num <= 0 || num > sPick.row_leftover[row_num])
                    {
                        Console.WriteLine("������1��{0:D}������,����������:", sPick.row_leftover[row_num]);
                        num = Int32.Parse(Console.ReadLine());
                    }
                    sPick.row_leftover[row_num] = sPick.row_leftover[row_num] - num;
                    sPick.allcnt_leftover = sPick.allcnt_leftover - num;

                    if (sPick.allcnt_leftover <= 0)
                    {
                        Console.WriteLine("\n����������������������������������������Ϸ��������������������������������������");
                        Console.WriteLine("���{0:D}   ��������(+�n+) �����õ����һ����ǩ����Ϸ����!!!\n", person_index + 1);
                        Console.WriteLine("����������������������������������������Ϸ��������������������������������������\n");
                        Console.WriteLine("����һ�̣�Y/N");
                        if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                        {
                            StartGame();
                        }
                        return ;
                    }
                    else
                    {  //ÿһ����ҽ�������
                        Console.WriteLine("\n");
                    }

                    person_index = person_index + 1;

                }


            }
        }

            static void StartGameAuto()
            {

                //1.��Ϸ�����ƶ�
                int num;

                Console.WriteLine("����{0:D}λ��ҿ�ʼ��Ϸ��!\n", sPick.person_cnt);

                //�а�ʱ��ʣ����ǩ����
                sPick.allcnt_leftover = sPick.allcnt;
                sPick.row_leftover = new int[sPick.row.Length];
                sPick.row.CopyTo(sPick.row_leftover, 0);
                int row_num = 0;
                while (sPick.allcnt_leftover > 0)
                {
                    int person_index = 0;
                    while (person_index < sPick.person_cnt)
                    {
                        Console.WriteLine("���{0:D} ��ʼȡ��ǩ��", person_index + 1);
                        Console.WriteLine("���{0:D} ������ȡ�ڼ�����ǩ:", person_index + 1);
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
                        Console.WriteLine("���{0:D} ������ȡ������ǩ:", person_index + 1);
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
                            Console.WriteLine("\n����������������������������������������Ϸ��������������������������������������");
                            Console.WriteLine("���{0:D}   ��������(+�n+) �����õ����һ����ǩ����Ϸ����!!!\n", person_index + 1);
                            Console.WriteLine("����������������������������������������Ϸ��������������������������������������\n");
                            Console.WriteLine("����һ�̣�Y/N");
                            if ("Y".Equals(Console.ReadLine().ToUpper().PadLeft(1)))
                            {
                                StartGame();
                            }
                            return;
                        }
                        else
                        {  //ÿһ����ҽ�������
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
