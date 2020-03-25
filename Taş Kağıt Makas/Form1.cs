using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taş_Kağıt_Makas
{
    public partial class Form1 : Form
    {
        #region Tanımlamalar

        Random r = new Random(); // rasgetgele sayı üretim için

        int otomatik, skor1=0, skor2=0; /* otomatik pc nin rastgele seçtiği sayıyı tutacak.
                                     * skor1 senin skorunu skor2 pc nin skorunu tutacak. */

        int tur; //  oynanmak istenen  tur sayısını tutacak

        int sayac = 0; // o an oynanan tur sayısını tutacak

        #endregion

        #region Metodlar


        public void panelrenklendir(Panel x, Panel y, Panel z)
        {
            x.BackColor = Color.Yellow;
            y.BackColor = SystemColors.Highlight;
            z.BackColor = SystemColors.Highlight;
        }

        public void skor()
        {
            if (skor1 == skor2)
                MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Berabere kaldınız");
            else if (skor1 > skor2)
                MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Kazandın mübarek olsun.");
            else if (skor1 < skor2)
                MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Olmadı hacı bir dahaki sefere artık.");
        
        }

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // oyun ilk açıldığında;

            /* oyunu ilk çalıştığında tur seçimi yapılana kadar ekranda oyuna ait
             * hiç bir nesne olmasını istemiyoruz ve bu yüzden grouboxların visible 
             * yani görünürlük özelliklerini false yaptık */

            #region groubbox görünmez

            groupBox1.Visible = false; 
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            #endregion
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* comboboxta seçim yapıldığı anda yapılacak işlemler */

            tur = int.Parse(comboBox1.SelectedItem.ToString()); // seçilen değeri tur değişkenine atadık.  

            groupBox4.Visible = false;

            #region grroubboxgörünür

            // oyun nesnelerini görünür hale getirdik.

            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;

            #endregion
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // taş butonuna tıklandığında

            #region if 1

            if (sayac < tur) /* ilk başta sayacı 0 dan başlattığım için küçük dedim
                              * sayacı 1 den başlatsa idim <= yapmam gerekirdi. */
            {
                #region panelrengi

                //tıklanan butonun arkaplandaki panelini siyah yaparak seçimimizi belirgin hale getirdik.

                panelrenklendir(panel1, panel2, panel3);
               
                #endregion

                sayac++; // oynan tur sayısını tutan sayacı bir artırdık.

                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.

                #region if 2
                if (otomatik == 0) // bilgisayarın seçtiği sayı 0 ise bu taş nesnesine denk geliyor.
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "İki seçimde aynı";
                }

                else if (otomatik == 1) // bilgisayarın seçtiği sayı 1 ise bu  kağıt nesnesine denk geliyor.
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "Kağıt taşı alır :(";
                    skor2++;
                    label5.Text = skor2.ToString();


                }

                else if (otomatik == 2) // bilgisayarın seçtiği sayı 2 ise bu makas nesnesine denk geliyor.
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = "Taş Makası Kırar";
                    skor1++;
                    label4.Text = skor1.ToString();

                }

                #endregion
            }
            #endregion

            

            else /* sayaç tur sayısından büyük olursa çalışacak kodlar.
                  * karşılaştırmaları yapıp oyun sonucunu bir messagebox ile
                  * ekranda gösteren kodlar. */
            {
                skor();
            }

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // kağıt tuşuna tıklandığında

            #region if 1

            if (sayac < tur)
            {
                panelrenklendir(panel2, panel1, panel3);

                sayac++;
                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.

                #region if 2
                if (otomatik == 0)
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "Kağıt Taşı sarar";
                    skor1++;
                    label4.Text = skor1.ToString();
                }

                else if (otomatik == 1)
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "iki seçimde aynı";
                }

                else if (otomatik == 2)
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = "Makas Kağıdı Keser";
                    skor2++;
                    label5.Text = skor2.ToString();

                }

                #endregion
            }
            #endregion
 
            else
            {
                skor();
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // makas tuşuna tıklandığında

            #region if 1
            if (sayac < tur)
            {
                panelrenklendir(panel3, panel2, panel1);
                sayac++;
                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.

                #region if 2

                if (otomatik == 0)
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "Taş Makasın Kırar";
                    skor2++;
                    label5.Text = skor2.ToString();
                }

                else if (otomatik == 1)
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "Makas Kağıdı Keser";
                    skor1++;
                    label4.Text = skor1.ToString();
                }

                else if (otomatik == 2)
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = "İki seçimde aynı";
                }

                #endregion
            }
            #endregion

            else
            {
                skor();
            }
            
        }
    }
}
