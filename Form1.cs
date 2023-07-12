using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Game
{



    //----------------------------Classes--------------------------------






    public class CACtor
    {
        public int XD, YD;
        public Bitmap im;
        public int XS, YS;
    }
    public class Soldier
    {
        public int X, Y;
        public int iCurrFrame;
        public List<Bitmap> imgS = new List<Bitmap>();
    }
    public class Ground
    {
        public int X, Y;
        public Bitmap imgG;
    }
    public class Ladder
    {
        public int X, Y;
        public Bitmap imgL;
    }
    public class Enemy2
    {
        public int X, Y;
        public int iCurrFrame;
        public List<Bitmap> imgEnmy2 = new List<Bitmap>();
       
    }
    public class Coin
    {
        public int X, Y;
        public Bitmap imgCoin;
    }
    public class Line2
    {
        public int X1, Y1, X2, Y2;
    }
    public class Line
    {
        public int X1, Y1, X2, Y2;
    }
    public class Bullet
    {
        public int X, Y;
        public int iCurrFrame;
        public Bitmap imgB;
    }
    public class Key
    {
        public int X, Y;
        public Bitmap imgK;
    }














    public partial class Form1 : Form
    {
        List<CACtor> LActs = new List<CACtor>();
        List<Ground> LActsG = new List<Ground>();
        List<Line> LActsL = new List<Line>();
        List<Soldier> LActsS = new List<Soldier>();
        List<Key> LActsK = new List<Key>();
        List<Coin> LActsCoin = new List<Coin>();
        List<Ground> LActsG2 = new List<Ground>();
        List<Bullet> LActsB = new List<Bullet>();
        List<Line2> LActsL2 = new List<Line2>();
        List<Ladder> LActsLder = new List<Ladder>();
        List<Enemy2> LActsEnmy2 = new List<Enemy2>();
        bool flag1 = false;
        bool flagE = false;
        bool flag2 = false;
        bool flagC1 = false;
        bool flagCoin = false;
        bool flagC2 = false;
        bool flagE2 = false;
        bool flagBul = false;
        bool flagCheck_Key = false;
        bool flagBul2 = false;
        bool flagBul3 = false;
        bool flagBul4 = false;
        bool flagBul5 = false;
        int frameS = 1, frameJ = 7;
        int ctTick_Shoot = 0;
        int y1 = 5;
        int v1;
        bool flag3 = false;
        int frameEnmy2 = 1;
        int x1 = 0;
        int x3 = 0;
        int oldB;
        int oldB2;
        int oldB3;
        int oldB4;
        int oldB5;
        int oldB6;
        int x2 = 5;
        int y2 = 5;
        int ctR = 0;
        int ctR2 = 0;
        bool flag4 = false;
        int ctHit2 = 0;
        int ctHitD = 0;
        int ctR3 = 0;
        bool flagR = false;
        int xEnmy3 = 0;
        int xEnmy4= 0;
        Random RR = new Random();

        int yL = 0;
        Bitmap off;
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseMove += Form1_MouseMove;
            this.WindowState = FormWindowState.Maximized;
            t.Start();
            t.Tick += T_Tick;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = LActsS[0].X.ToString() + "," + LActsS[0].Y.ToString();
            ;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:

                    break;
                case Keys.A:

                    break;
                case Keys.D:


                    break;
                case Keys.S:

                    break;
                case Keys.E:
                    frameS = 1;
                    flagC1 = false;
                    break;
                case Keys.C:
                    frameS = 1;
                    flagC2 = false;
                    flag3 = false;
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                   
                    frameS++;
                    if (frameS >= 7)
                    {
                        frameS = 1;
                    }
                    if (LActsS[0].X + 40 >= LActsLder[0].X && LActsS[0].X <= LActsLder[0].X + LActsLder[0].imgL.Width - 54 && LActsS[0].Y >= LActsG2[0].Y - 150)
                    {
                        LActsS[0].Y -= 10;
                    
                    }
                    break;
                case Keys.D:
                    frameS++;
                    LActs[0].XS++;
                    if (LActs[0].XS == (LActs[0].im.Width / 4))
                    {
                        LActs[0].XS = 0;
                    }
                    for (int j = 0; j < LActsG.Count; j++)
                    {
                        LActsG[j].X--;
                    }
                    if (LActsCoin.Count != 0)
                    {
                        LActsCoin[0].X++;
                    }
                    if (LActsK.Count != 0)
                    {
                        LActsK[0].X++;
                    }
                    if (frameS >= 7)
                    {
                        frameS = 1;
                    }
                    LActsS[0].X += 10;
                    break;
                    
                case Keys.A:
                    frameS++;
                    LActs[0].XS--;
                    if (LActs[0].XS == (LActs[0].im.Width / 4))
                    {
                        LActs[0].XS = 0;
                    }
                    for (int j = 0; j < LActsG.Count; j++)
                    {
                        LActsG[j].X--;
                    }
                    if (LActsCoin.Count != 0)
                    {
                        LActsCoin[0].X++;
                    }
                    if (LActsK.Count != 0)
                    {
                        LActsK[0].X++;
                    }
                    if (frameS >= 7)
                    {
                        frameS = 1;
                    }
                    LActsS[0].X -= 10;
                    break;
                case Keys.E:
                    flag3 = true;
                    frameS = 12;
                    flag4 = true;
                    flagC1 = true;
                    break;
                case Keys.Space:
                    flag1 = true;
                    frameJ = 8;

                    frameJ = 8;
                    break;
                case Keys.S:
                    frameS++;
                    if (LActsS[0].Y <= LActsLder[0].Y - 100)
                    {
                        LActsS[0].Y += 10;
                    
                    }
                    if (frameS == 7)
                    {
                        frameS = 1;
                    }
                    break;

































            }



        

        }

        Bitmap MyBK = new Bitmap("Background.jpg");
        int j4;


        //-Lists-------------------------------------------------------------------------------------------------------
   



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubbleBuffer(e.Graphics);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if (flagR == false)
            {
                ctR = RR.Next(2, 60);
                flagR = true;
                if (ctR2 > 0)
                {
                    if (LActsL2.Count != 0)
                    {
                        for (int i = 0; i < LActsL2.Count; i++)
                        {
                            LActsL2.RemoveAt(i);
                        }
                    }
                }
            }
            if (flag3 == true)
            {
                Create_Bullet();
                flag3 = false;
            }

            if (ctTick_Shoot % ctR == 0 && flagR == true)
            {
                if (LActsL2.Count == 0)
                {
                    Enemy_Shoot();
                }
                ctR2++;
                flagR = false;
            }
            if (flag1 == true)
            {
                LActsS[0].Y -= y1;
                if (flag2 == false)
                {
                    LActs[0].YS++;
                }
                frameJ++;
                if (frameJ >= 9)
                {
                    frameJ = 9;
                }
                if (y1 >= 15 && flag2 == false)
                {
                    flag2 = true;
                    y1 = 0;
                }
                if (flag2 == true)
                {
                    LActsS[0].Y += y2;
                    if (flag2 == true)
                    {
                        LActs[0].YS--;
                    }


                    frameJ = 11;
                    if (y2 >= 15)
                    {
                        flag2 = false;
                        flag1 = false;

                        y2 = 0;
                    }
                }
                if (flag2 == false)
                {
                    y1++;
                }
                else
                {
                    y2++;
                }
            }
            if (flag4 == true)
            {
                Move_Bullet();
            }
            if (LActsS[0].X <= 890 && LActsS[0].X >= 750)
            {
                if (LActsS[0].Y == 359)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        LActsS[0].Y++;

                        if (LActsS[0].Y == 799)
                        {
                            break;
                        }
                    }
                }

            }
            Move_Enemy();
            Check_Coin();
            ctTick_Shoot++;

            DrawDubbleBuffer(this.CreateGraphics());
        }
        void DrawDubbleBuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            for (int i = 0; i < LActs.Count; i++)
            {
                Rectangle rcDest = new Rectangle(LActs[i].XD, LActs[i].YD, ClientSize.Width, ClientSize.Height);
                Rectangle rcSrc = new Rectangle(LActs[i].XS, LActs[i].YS, j4 / 2, LActs[i].im.Height);
                g.DrawImage(LActs[i].im,
                             rcDest, rcSrc,
                             GraphicsUnit.Pixel
                             );

            }
            for (int i = 0; i < LActsLder.Count; i++)
            {
                g.DrawImage(LActsLder[i].imgL, LActsLder[i].X, LActsLder[i].Y);
            }
            for (int i = 0; i < LActsG.Count; i++)
            {
                g.DrawImage(LActsG[i].imgG, LActsG[i].X, LActsG[i].Y);
            }
            for (int i = 0; i < LActsG2.Count; i++)
            {
                g.DrawImage(LActsG2[i].imgG, LActsG2[i].X, LActsG2[i].Y);
            }
            for (int i = 0; i < LActsEnmy2.Count; i++)
            {
                g.DrawImage(LActsEnmy2[i].imgEnmy2[LActsEnmy2[i].iCurrFrame], LActsEnmy2[i].X, LActsEnmy2[i].Y);
            }
            if (flag1 == false)
            {
                for (int i = 0; i < LActsS.Count; i++)
                {
                    LActsS[i].iCurrFrame = frameS;
                        g.DrawImage(LActsS[i].imgS[LActsS[i].iCurrFrame], LActsS[i].X, LActsS[i].Y);
                }
            }
            for (int i = 0; i < LActsB.Count; i++)
            {
                g.DrawImage(LActsB[i].imgB, LActsB[i].X, LActsB[i].Y);
            }
            for (int i = 0; i < LActsCoin.Count; i++)
            {
                g.DrawImage(LActsCoin[i].imgCoin, LActsCoin[i].X, LActsCoin[i].Y);
            }

            for (int i = 0; i < LActsL2.Count; i++)
            {
                g.DrawLine(new Pen(Color.Red, 3), LActsL2[i].X1, LActsL2[i].Y1, LActsL2[i].X2, LActsL2[i].Y2);
            }
            if (flag1 == true)
            {
                for (int j = 0; j < LActsS.Count; j++)
                {
                    LActsS[j].iCurrFrame = frameJ;
                    g.DrawImage(LActsS[j].imgS[LActsS[j].iCurrFrame], LActsS[j].X, LActsS[j].Y);
                }
            }
            for (int i = 0; i < LActsL.Count; i++)
            {
                g.DrawLine(new Pen(Color.Black, 6), LActsL[i].X1, LActsL[i].Y1, LActsL[i].X2, LActsL[i].Y2);
            }

        }
    

        void Create_Blocks()
        {
            //normal ground
            for (int i = 0; i < 100; i++)
            {
                
                {
                    Ground pnn = new Ground();
                    pnn.imgG = new Bitmap("B1.bmp");
                    pnn.X = x1;
                    pnn.Y = ClientSize.Height - pnn.imgG.Height - 10;
                    LActsG.Add(pnn);
                    x1 += pnn.imgG.Width;
                }
            }
        }
        void Check_Coin()
        {
            if (LActsCoin.Count != 0)
            {
                if (LActsS[0].X + 20 >= LActsCoin[0].X && LActsS[0].Y <= LActsCoin[0].Y && flagCoin == false)
                {
                    flagCoin = true;
                 
                    LActsCoin.RemoveAt(0);
                }
            }
        }
        void Move_Enemy()
        {
            for (int i = 0; i < LActsEnmy2.Count; i++)
            {
                if (xEnmy3 >= 27 && flagE2 == false)
                {
                    xEnmy3 = 0;
                    xEnmy4 = 0;
                    flagE2 = true;
                }
                else
                {
                    if (flagE2 == false)
                    {
                        LActsEnmy2[i].X += xEnmy3;
                       
                        if (LActsEnmy2[0].iCurrFrame >= 7)
                        {
                            LActsEnmy2[0].iCurrFrame = 0;
                        }
                        else
                        {
                            LActsEnmy2[0].iCurrFrame++;
                        }
                    }
                    xEnmy3++;
                }
                if (flagE2 == true)
                {
                    if (xEnmy4 >= 27)
                    {
                        xEnmy4 = 0;
                        flagE2 = false;
                        xEnmy3 = 0;
                    }
                    else
                    {
                        if (flagE2 == true)
                        {
                            LActsEnmy2[i].X -= xEnmy4;
                            if (LActsEnmy2[0].iCurrFrame >= 7)
                            {
                                LActsEnmy2[0].iCurrFrame = 0;
                            }
                            else
                            {
                                LActsEnmy2[0].iCurrFrame++;
                            }
                         
                            xEnmy4++;
                        }
                    }
                }






            }
        }
            void Enemy_Shoot()
        { 
            for (int i = 0; i < LActsEnmy2.Count; i++)
            {
                Line2 pnn = new Line2();
                pnn.X1 = LActsEnmy2[i].X;
                pnn.X2 = 0;
                pnn.Y1 = LActsEnmy2[i].Y + 35;
                pnn.Y2 = LActsEnmy2[i].Y + 35;
                LActsL2.Add(pnn);
            }
        }
        void Create_Soldier()
        {
            Soldier pnn = new Soldier();
            pnn.X = LActsG[0].X;
            pnn.Y = LActsG[0].Y - 160;
            for (int i = 1; i <= 7; i++)
            {
                Bitmap img = new Bitmap("0" + (i) + ".jpg");
                img.MakeTransparent(img.GetPixel(0, 0));
                img.SetResolution(400, 400);
                pnn.imgS.Add(img);
            }
            LActsS.Add(pnn);
        }
        void Create_Bullet()
        {
            Bullet pnn = new Bullet();
            v1 = RR.Next(1, 3);
            if (flagC1 == true && flagC2 == true)
            {
                pnn.X = LActsS[0].X + 80;
                pnn.Y = LActsS[0].Y + 34;
                frameS = 13;
            }
            else
            {
                pnn.X = LActsS[0].X + 80;
                pnn.Y = LActsS[0].Y + 34;
            }
            if (v1 == 1)
            {
                Bitmap img = new Bitmap("Fire22" + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                img.SetResolution(400, 400);
                pnn.imgB = img;
            }
            if (v1 == 2)
            {
                Bitmap img = new Bitmap("Fire33" + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                img.SetResolution(400, 400);
                pnn.imgB = img;
            }
            LActsB.Add(pnn);
        }
        void Move_Bullet()
        {
            for (int i = 0; i < LActsB.Count; i++)
            {
                LActsB[i].X += 30;
                if (LActsB[i].X >= ClientSize.Width)
                {
                    LActsB.RemoveAt(i);
                }
                oldB4 = i;
                oldB6 = i;
                for (int k = 0; k < LActsEnmy2.Count; k++)
                {
                    if (i >= 0 && LActsB.Count != 0)
                    {
                        if (LActsB[i].X >= ClientSize.Width - 10)
                        {
                            LActsB.RemoveAt(i);
                        }
                        if (LActsB[i].X >= LActsEnmy2[k].X && LActsB[i].Y - 100 <= LActsEnmy2[k].Y)
                        {
                            ctHit2++;
                            if (ctHit2 >= 1 && flagBul2 == false)
                            {

                                oldB2 = i;
                                flagBul2 = true;
                            }
                            if (oldB2 != i)
                            {
                                if (ctHit2 >= 2 && flagBul2 == true && flagBul3 == false && LActsB[i].X >= LActsEnmy2[k].X && LActsB[i].Y - 100 <= LActsEnmy2[k].Y)
                                {

                                    oldB3 = i;
                                    flagBul3 = true;
                                }
                            }
                            if (oldB4 != oldB3 && oldB4 != oldB2)
                            {
                                if (ctHit2 >= 3 && flagBul3 == true && flagBul4 == false && LActsB[i].X >= LActsEnmy2[k].X && LActsB[i].Y - 100 <= LActsEnmy2[k].Y)
                                {

                                    oldB5 = i;
                                    flagBul4 = true;
                                }
                            }
                            if (oldB6 != oldB5 && oldB6 != oldB3 && oldB6 != oldB2 && oldB6 != oldB)
                            {
                                if (ctHit2 >= 4 && flagBul4 == true && flagBul5 == false && LActsB[i].X >= LActsEnmy2[k].X && LActsB[i].Y - 100 <= LActsEnmy2[k].Y)
                                {

                                    if (LActsEnmy2.Count != 0)
                                    {

                                          Create_Coin();

                                        LActsEnmy2.RemoveAt(k);
                                        //  ctHit = 0;
                                        flagBul5 = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
                void Create_Enemy2()
        {
            Enemy2 pnn = new Enemy2();
            pnn.X = LActsG2[11].X + 90;
            for (int i = 1; i <= 8; i++)
            {
                Bitmap imgEnmy2 = new Bitmap("w" + (i) + ".bmp");
                imgEnmy2.MakeTransparent(imgEnmy2.GetPixel(0, 0));
                imgEnmy2.SetResolution(600, 600);
                pnn.imgEnmy2.Add(imgEnmy2);
            }
            pnn.iCurrFrame = frameEnmy2;
            pnn.Y = LActsG2[0].Y - pnn.imgEnmy2[0].Height + 400;
            LActsEnmy2.Add(pnn);
        }
        void Create_Ladder()
        {
            for (int j = 0; j < 14; j++)
            {
                Ladder pnn = new Ladder();
                pnn.X = LActsG[50].X;
                pnn.imgL = new Bitmap("L1.bmp");
                pnn.imgL.MakeTransparent(pnn.imgL.GetPixel(0, 0));

                pnn.Y = LActsG[0].Y - pnn.imgL.Height - yL;
                LActsLder.Add(pnn);
                yL += pnn.imgL.Height;
            }
        }
        void Create_Coin()
        {
            Coin pnn = new Coin();
            pnn.X = LActsEnmy2[0].X;
            pnn.imgCoin = new Bitmap("c4" + ".bmp");
            pnn.Y = LActsEnmy2[0].Y + LActsEnmy2[0].imgEnmy2[1].Height - pnn.imgCoin.Height;
            pnn.imgCoin.MakeTransparent(pnn.imgCoin.GetPixel(0, 0));
            LActsCoin.Add(pnn);
        }
        void Create_Blocks2()
        {
            for (int i = 0; i < 60; i++)
            {
                Ground pnn = new Ground();
                pnn.X = (ClientSize.Width) /2 + x2;
                pnn.Y = ClientSize.Height / 2;
                pnn.imgG = new Bitmap("BB1.bmp");
                LActsG2.Add(pnn);
                x2 += pnn.imgG.Width;
            }
            for (int i = 0; i < 25; i++)
            {
                Ground pnn = new Ground();
                pnn.X = 0 + x3;
                pnn.Y = ClientSize.Height / 2;
                pnn.imgG = new Bitmap("BB1.bmp");
                LActsG2.Add(pnn);
                x3 += pnn.imgG.Width;
            }










        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            MyBK.MakeTransparent(Color.White);
            CACtor pnn = new CACtor();
            pnn.XD = 0;
            pnn.YD = 0;
            pnn.XS = 0;
            pnn.im = new Bitmap("Background.jpg");
            pnn.YS = 0;
            LActs.Add(pnn);
            j4 = LActs[0].im.Width;
            Create_Blocks();
            Create_Soldier();
            Create_Ladder();
            Create_Blocks2();
            Create_Enemy2();
            Create_Bullet();
            
        }
    }
}
