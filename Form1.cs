﻿using System.Drawing;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
using System.Windows.Forms;

namespace prolab2_1
{
    public partial class HazineAvcisi : Form
    {
        SoundPlayer player = new SoundPlayer(Resources.Epic_Pirate_Adventure_Music_Treasure_Hunt);
        Random random = new Random();
        List<PictureBox> Dag = new List<PictureBox>();
        List<PictureBox> Kus = new List<PictureBox>();
        List<PictureBox> Ari = new List<PictureBox>();
        List<PictureBox> Agac = new List<PictureBox>();
        List<PictureBox> Duvar = new List<PictureBox>();
        List<PictureBox> Tas = new List<PictureBox>();
        List<PictureBox> engeller = new List<PictureBox>();
        List<PictureBox> sandiklar = new List<PictureBox>();
        private PictureBox hedefSandik;
        List<string> sandikOncelikSirasi = new List<string>();

        public HazineAvcisi()
        {
            InitializeComponent();

            ResimGrupla();
            SandikYerlestir(altinSandik);
            SandikYerlestir(gumusSandik);
            SandikYerlestir(bakirSandik);
            SandikYerlestir(zumrutSandik);
            ilkHareket();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CreateMap(int genislik, int yukseklik)
        {
            int kareBoyutu = 10;
            int haritaGenislik = genislik;
            int haritaYukseklik = yukseklik;

            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height); 

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                
                using (SolidBrush beyazFirca = new SolidBrush(Color.White))
                using (SolidBrush sariFirca = new SolidBrush(Color.Yellow))
                {
                    // İlk yarısı beyaz, ikinci yarısı sarı olan bir arka plan 
                    g.FillRectangle(beyazFirca, 0, 0, panel1.Width, panel1.Height / 2);
                    g.FillRectangle(sariFirca, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
                   
                    using (Pen pen = new Pen(Color.Black))
                    {
                        for (long i = 0; i < haritaGenislik; i++)
                        {
                            for (long j = 0; j < haritaYukseklik; j++)
                            {
                                Rectangle rect = new Rectangle((int)j * kareBoyutu, (int)i * kareBoyutu, kareBoyutu, kareBoyutu);
                                g.DrawRectangle(pen, rect);
                            }
                        }
                    }
                }
            }
          
            panel1.BackgroundImage = bitmap;
        }


        private void ResimGrupla()
        {


            Kus.Add(pictureBox1);
            Kus.Add(pictureBox2);
            Kus.Add(pictureBox3);
            Kus.Add(pictureBox4);
            Kus.Add(pictureBox5);

            Ari.Add(pictureBox6);
            Ari.Add(pictureBox7);
            Ari.Add(pictureBox8);
            Ari.Add(pictureBox9);
            Ari.Add(pictureBox10);

            Dag.Add(pictureBox11);
            Dag.Add(pictureBox12);
            Dag.Add(pictureBox13);
            Dag.Add(pictureBox14);
            Dag.Add(pictureBox15);

            Agac.Add(pictureBox16);
            Agac.Add(pictureBox17);
            Agac.Add(pictureBox18);
            Agac.Add(pictureBox19);
            Agac.Add(pictureBox20);

            Duvar.Add(pictureBox21);
            Duvar.Add(pictureBox22);
            Duvar.Add(pictureBox23);
            Duvar.Add(pictureBox24);
            Duvar.Add(pictureBox25);

            Tas.Add(pictureBox26);
            Tas.Add(pictureBox27);
            Tas.Add(pictureBox28);

            engeller.AddRange(Dag);
            engeller.AddRange(Kus);
            engeller.AddRange(Agac);
            engeller.AddRange(Ari);
            engeller.AddRange(Tas);
            engeller.AddRange(Duvar);


            ResimYerlestir(Dag);
            ResimYerlestir(Kus);
            ResimYerlestir(Ari);
            ResimYerlestir(Agac);
            ResimYerlestir(Duvar);
            ResimYerlestir(Tas);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void SandikYerlestir(PictureBox picturebox)
        {
            Lokasyon lokasyon = new Lokasyon();
            int x, y;
            bool cakisma;
            do
            {
                cakisma = false;
                x = 10 * random.Next(0, lokasyon.locx); 
                y = 10 * random.Next(0, lokasyon.locy); 

                // Diğer kontrol nesneleri ile çarpışma kontrolü
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is PictureBox && ctrl != picturebox)
                    {
                        if (Math.Abs(ctrl.Location.X - x) < picturebox.Width && Math.Abs(ctrl.Location.Y - y) < picturebox.Height)
                        {
                            cakisma = true;
                            break;
                        }
                    }
                }
            } while (cakisma);

            picturebox.Location = new Point(x, y);
            panel1.Controls.Add(picturebox);
            sandiklar.Add(picturebox);
        }
        public void ResimYerlestir(List<PictureBox> resimler)
        {
            Lokasyon lokasyon = new Lokasyon();

        start:

            foreach (PictureBox pictureBox in resimler)
            {
                int x, y;
                bool Cakisma;

                do
                {
                    Cakisma = false;
                    x = 10 * random.Next(0, lokasyon.locx);
                    y = 10 * random.Next(0, lokasyon.locy);

                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is PictureBox && ctrl != pictureBox)
                        {
                            if (Math.Abs(ctrl.Location.X - x) < 60 && Math.Abs(ctrl.Location.Y - y) < 60)
                            {
                                Cakisma = true;
                                break;
                            }
                        }
                    }

                } while (Cakisma);

                pictureBox.Location = new Point(x, y);

                int agacBoyut = (random.Next(4) + 1) * 10;
                int tasBoyut = (random.Next(2) + 1) * 10;

                SbtEngel tas = new SbtEngel(tasBoyut, tasBoyut);
                SbtEngel kistasi = new SbtEngel(tasBoyut, tasBoyut);
                SbtEngel agac = new SbtEngel(agacBoyut, agacBoyut);
                SbtEngel kisagaci = new SbtEngel(agacBoyut, agacBoyut);
                SbtEngel dag = new SbtEngel(60, 60);
                SbtEngel duvar = new SbtEngel(50, 50);
                HrktEngel ari = new HrktEngel(30, 30);
                HrktEngel kus = new HrktEngel(20, 20);


                if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Dag")
                {
                    pictureBox.Size = new Size(dag.X, dag.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Kus")
                {
                    pictureBox.Size = new Size(kus.X, kus.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Ari")
                {
                    pictureBox.Size = new Size(ari.X, ari.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Agac")
                {
                    pictureBox.Size = new Size(agac.X, agac.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "kisAgaci")
                {
                    if (pictureBox.Location.Y > panel1.Height / 2)
                    {
                        goto start;
                    }
                    pictureBox.Size = new Size(kisagaci.X, kisagaci.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Duvar")
                {
                    pictureBox.Size = new Size(duvar.X, duvar.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "Tas")
                {
                    pictureBox.Size = new Size(tas.X, tas.Y);
                }
                else if (pictureBox.Tag != null && pictureBox.Tag.ToString() == "kisTasi")
                {
                    if (pictureBox.Location.Y > panel1.Height / 2)
                    {
                        goto start;
                    }
                    pictureBox.Size = new Size(kistasi.X, kistasi.Y);
                }

                panel1.Controls.Add(pictureBox);
            }
        }

        private void ilkHareket()
        {
            foreach (PictureBox kus in Kus)
            {
                kus.Location = new Point(kus.Location.X, kus.Location.Y - 40);

            }
            foreach (PictureBox ari in Ari)
            {
                ari.Location = new Point(ari.Location.X - 30, ari.Location.Y);
            }
            karakterYerlestirme();

        }

        private int hareketMiktariAri = 70;
        private int hareketMiktariKus = 90; 
        private bool yukariYon = true; 
        private bool sagasola = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox kus in Kus)
            {
                int baslangicKonumu = kus.Location.Y;

                int yon = yukariYon ? -1 : 1;

                int yeniKonum = baslangicKonumu + (yon * hareketMiktariKus);

                if (yeniKonum >= 0 && yeniKonum <= panel1.Height - kus.Height)
                {
                    kus.Location = new Point(kus.Location.X, yeniKonum);
                }

                yukariYon = !yukariYon;
            }

            foreach (PictureBox ari in Ari)
            {
                int baslangicKonumu = ari.Location.X;
               
                int yon = sagasola ? -1 : 1;
              
                int yeniKonum = baslangicKonumu + (yon * hareketMiktariAri);
      
                if (yeniKonum >= 0 && yeniKonum <= panel1.Width - ari.Width)
                {
                    ari.Location = new Point(yeniKonum, ari.Location.Y);
                }

                // Yönü değiştir
                sagasola = !sagasola;
            }

            // Eğer hedef sandık null ise veya karakter hedef sandığa ulaştıysa yeni bir hedef belirle
            if (hedefSandik == null || karakter.Location == hedefSandik.Location)
            {
                BelirleHedefSandik();
            }
           
            Point hedefKonum = hedefSandik.Location;
            Point karakterKonumu = karakter.Location;
            List<Point> yol = AStar(karakterKonumu, hedefKonum);

            if (yol != null && yol.Count > 0)
            {
                Point yeniKonum1 = yol[0];
                karakter.Location = yeniKonum1;
            }
            if (karakter.Location == hedefSandik.Location)
            {

                Karakter karakter1 = new Karakter(12081, "Namik");
                sandikSirasi.Visible = true;

                string sandikIsmi = hedefSandik.Name;
                string eskiMetin = sandikSirasi.Text;
                string yeniMetin = eskiMetin + Environment.NewLine + karakter1.id + " " + karakter1.ad + " " + sandikIsmi + " " + hedefSandik.Location + " konumunda bulundu!";

                sandikSirasi.Text = yeniMetin;
                hedefSandik.Visible = false;
            }

        }
      
        private void BelirleHedefSandik()
        {
            
            if (sandiklar.Count == 0)
            {
                sandikOncelikSirasi.Insert(0, altinSandik.Name);
                sandikOncelikSirasi.Insert(1, gumusSandik.Name);
                sandikOncelikSirasi.Insert(2, zumrutSandik.Name);
                sandikOncelikSirasi.Insert(3, bakirSandik.Name);
                
                StringBuilder sb = new StringBuilder();

                
                foreach (string sandikIsim in sandikOncelikSirasi)
                {
                    sb.AppendLine(sandikIsim + " bulundu");
                }

                sandikOncelik.Visible = true;
                //Birleşik metin
                sandikOncelik.Text = sb.ToString();
                timer1.Stop();
                player.Stop();
                return;
            }
           
            Point karakterKonumu = karakter.Location;
           
            double enKisaMesafe = double.MaxValue;
            foreach (PictureBox sandik in sandiklar)
            {
                double mesafe = MesafeyiHesapla(karakterKonumu, sandik.Location);
                if (mesafe < enKisaMesafe)
                {
                    enKisaMesafe = mesafe;
                    hedefSandik = sandik;
                }
            }
            
            sandiklar.Remove(hedefSandik);
        }
       
        private double MesafeyiHesapla(Point nokta1, Point nokta2)
        {
            int dx = nokta2.X - nokta1.X;
            int dy = nokta2.Y - nokta1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private List<Point> AStar(Point baslangic, Point hedef)
        {
            HashSet<Point> kapalıListe = new HashSet<Point>();
            HashSet<Point> acikListe = new HashSet<Point>();
            Dictionary<Point, Point> oncekiNoktalar = new Dictionary<Point, Point>();
            Dictionary<Point, int> gMesafeleri = new Dictionary<Point, int>();
            Dictionary<Point, int> fMesafeleri = new Dictionary<Point, int>();

            acikListe.Add(baslangic);
            gMesafeleri[baslangic] = 0;
            fMesafeleri[baslangic] = ManhattenMesafe(baslangic, hedef);

            while (acikListe.Count > 0)
            {
                Point mevcutNokta = acikListe.OrderBy(n => fMesafeleri[n]).First();

                if (mevcutNokta == hedef)
                {
                    return YoluOlustur(oncekiNoktalar, hedef);
                }

                acikListe.Remove(mevcutNokta);
                kapalıListe.Add(mevcutNokta);

                foreach (Point komsu in Komsular(mevcutNokta))
                {
                    if (kapalıListe.Contains(komsu))
                    {
                        continue;
                    }

                    int olasiG = gMesafeleri[mevcutNokta] + 1;

                    if (!acikListe.Contains(komsu))
                    {
                        acikListe.Add(komsu);
                    }
                    else if (olasiG >= gMesafeleri[komsu])
                    {
                        continue;
                    }

                    oncekiNoktalar[komsu] = mevcutNokta;
                    gMesafeleri[komsu] = olasiG;
                    fMesafeleri[komsu] = olasiG + ManhattenMesafe(komsu, hedef);
                }
            }

            return null;
        }

        
        private int ManhattenMesafe(Point nokta1, Point nokta2)
        {
            return Math.Abs(nokta1.X - nokta2.X) + Math.Abs(nokta1.Y - nokta2.Y);
        }

        // Bir noktanın komşularını döndüren metot
        private List<Point> Komsular(Point nokta)
        {
            List<Point> komsular = new List<Point>();

            
            komsular.Add(new Point(nokta.X + 10, nokta.Y)); 
            komsular.Add(new Point(nokta.X - 10, nokta.Y)); 
            komsular.Add(new Point(nokta.X, nokta.Y + 10)); 
            komsular.Add(new Point(nokta.X, nokta.Y - 10)); 

            return komsular;
        }

        
        private List<Point> YoluOlustur(Dictionary<Point, Point> oncekiNoktalar, Point hedef)
        {
            List<Point> yol = new List<Point>();
            Point gecerliNokta = hedef;

            while (oncekiNoktalar.ContainsKey(gecerliNokta))
            {
                yol.Insert(0, gecerliNokta);
                gecerliNokta = oncekiNoktalar[gecerliNokta];
            }

            return yol;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SisUygula();
        }

        public void karakterYerlestirme()
        {
            Lokasyon lokasyon = new Lokasyon();


            int x, y;
            bool cakisma;
            do
            {
                cakisma = false;
                x = 10 * random.Next(0, lokasyon.locx);
                y = 10 * random.Next(0, lokasyon.locy);

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is PictureBox && ctrl != karakter)
                    {
                        if (Math.Abs(ctrl.Location.X - x) < 60 && Math.Abs(ctrl.Location.Y - y) < 60)
                        {
                            cakisma = true;
                            break;
                        }
                    }
                }
            } while (cakisma);


            karakter.Location = new Point(x, y);
            panel1.Controls.Add(karakter);

        }

        private void baslatButonu_Click(object sender, EventArgs e)
        {
            player.Play();
            timer1.Interval = 10; 
            timer1.Tick += timer1_Tick; 
            timer1.Start(); 
            timer2.Interval = 10;
            timer2.Tick += timer2_Tick;
            timer2.Start();

        }
        private Color sisRenk = Color.FromArgb(128, Color.Gray);
        private Bitmap fogOfWarBitmap; 
        private HashSet<Point> exploredPoints = new HashSet<Point>(); 
        private int karakterEtkiAlani = 70; 

        public void SisUygula()
        {
            if (fogOfWarBitmap == null)
            {
                // Arka plan bitmap'ini oluşturun ve varsayılan renk ile doldurun
                fogOfWarBitmap = new Bitmap(panel1.Width, panel1.Height);
                using (Graphics g = Graphics.FromImage(fogOfWarBitmap))
                {
                    g.Clear(sisRenk);
                }
            }

            
            using (Graphics g = Graphics.FromImage(fogOfWarBitmap))
            {
                g.Clear(sisRenk);
            }


            
            int karakterX = karakter.Location.X;
            int karakterY = karakter.Location.Y;

            // Karakterin etki alanını keşfet
            for (int i = karakterX - karakterEtkiAlani; i <= karakterX + karakterEtkiAlani; i++)
            {


                for (int j = karakterY - karakterEtkiAlani; j <= karakterY + karakterEtkiAlani; j++)
                {
                    int x = Math.Max(0, Math.Min(panel1.Width - 1, i));
                    int y = Math.Max(0, Math.Min(panel1.Height - 1, j));
                    exploredPoints.Add(new Point(x, y));
                }
                karakterX = karakter.Location.X;
                karakterY = karakter.Location.Y;
            }

            // sisleri temizle
            for (int i = karakterX - karakterEtkiAlani; i <= karakterX + karakterEtkiAlani; i++)
            {
                for (int j = karakterY - karakterEtkiAlani; j <= karakterY + karakterEtkiAlani; j++)
                {
                    int x = Math.Max(0, Math.Min(panel1.Width - 1, i));
                    int y = Math.Max(0, Math.Min(panel1.Height - 1, j));
                    fogOfWarBitmap.SetPixel(x, y, Color.Transparent);
                }
            }

            // Daha önce keşfedilen noktaların sisini açın
            foreach (Point exploredPoint in exploredPoints)
            {
                fogOfWarBitmap.SetPixel(exploredPoint.X, exploredPoint.Y, Color.Transparent);
            }
            
            panel1.CreateGraphics().DrawImage(fogOfWarBitmap, 0, 0);

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void karakter_Click(object sender, EventArgs e)
        {

        }
    }
}