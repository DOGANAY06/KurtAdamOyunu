using KurtAdamSaldırısı.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurtAdamSaldırısı
{
    public partial class Savas : Form
    {
        public Savas()
        {
            InitializeComponent();
        }

        
        Models.Account account = new Models.Account(); //kullanıcı sınıfımız 
        Enemy dusman = new Enemy();  //düşmanın sınıfı
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //burada textbox ve combobox girilen verileri account nesnemizin özelliklerine get ettik
            account.UserName = username.Text;
            account.race = cmdIrk.SelectedItem.ToString(); //hangi ırk secildiyse combobaxta
            account.branch = cmdBranş.SelectedItem.ToString(); //hangi branş secildiyse combobaxta
            account.weapon = TxtSilah.Text;
            SecimOldu(false); //karakter secildiyse 
            SecilYapıldı(true); //kullanıcı ve kurt gelir 

        }
        public void SecimOldu(bool durum)
        { //kullanıcı bilgileri alındı durumlar kapanır görünürlük
            username.Enabled = durum;
            cmdIrk.Enabled = durum;
            cmdBranş.Enabled = durum;
            TxtSilah.Enabled = durum;
            btnSelect.Enabled = durum;
        }
        public void SecilYapıldı(bool isVisible) //kullanıcı bilgilerini girdi diğerleri kapandı savaş başlasın 
        { //burada kurtun canını kurtun resmini kendi canımızı ve kendi karakterimizi 
            //görünür yaptık
            lblHelth.Visible = pictureBox1.Visible
             = btnAttack.Visible = lblmyhealth.Visible = pictureBox2.Visible
                = isVisible    ;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {//her saldır buttonuna tıklandığında 1 tane kullanıcı 
            //1 tane düşman vuruş yapıcak hangisinin toplamı =>100 eşitse o kazanır 
            account.Attack();
            lblHelth.Width -= account.damage; //accountun vurduğu hasar kadar düsmana zarar veriyoruz
            MessageBox.Show("Düşmana " + account.damage + "kadar hasar verildi");
            dusman.EnemyAttack(); //düsmanın atağı gelir biz atak yaptıktan sonra 
            lblmyhealth.Width -= dusman.damage; //düsmanın atağı damage değeri kadar bizim canımızı düşürür
            MessageBox.Show("Düşma size hasar verdi = " + dusman.damage);
            if (lblHelth.Width <= 0)
            {
                MessageBox.Show("Düşmanı Yendiniz");
                pictureBox1.Visible = false; //kurt kaybolur
            }
            if (lblmyhealth.Width <= 0) //bizim canımız 0 a küçük eşit ve azsa yeniliriz
            {
                MessageBox.Show("Kazanan Kurt düşman");
                pictureBox2.Visible = false; //kullanıcı kaybolur
            }
        }
    }
}
