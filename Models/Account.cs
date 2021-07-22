using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurtAdamSaldırısı.Models
{
    public class Account //kendi kullandığımız karakterin sınıfı 
    { //özellikleri barındırır 
        public string UserName { get; set; } //kullanıcıadı
        public string race { get; set; } //ırk

        public string branch { get; set; } //branş 

        public string weapon { get; set; } //silah 

        public int damage { get; set; } //saldırma 

        Random random = new Random(); //random metodu branş özelliğinin aldığı karakterin verdiği hasarı belirlemek için 

        public void Attack() //vurma metodu
        {//her saldırıda damage = 0 olmalı 
            damage = 0;

            /* saldırma kriterleri 
             insan ise +5 
             canavar ise +10 
             savascı ise 40 
            sura  30-50 arasında
             ninja  ise 10-70 
             şaman ise 5-60 vursun 
            */
            if (race=="İnsan")
            {
                damage += 5;
            }
            else
            {
                damage += 10;
            }
            switch (branch) //branş seçimi neyse öyle hasar versin
            {
                case "Savascı":
                    damage += 40;
                    break;
                case "Sura":
                    damage += random.Next(30, 51); //sura rastge bu aralıkta bir damage sahip 
                    break;
                case "Ninja":
                    damage += random.Next(10,70);
                    break;
                case "Şaman":
                    damage += random.Next(5, 60);
                    break;
            
            }
        }

    }
}
