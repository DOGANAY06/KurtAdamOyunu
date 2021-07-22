using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurtAdamSaldırısı.Models
{
        public class Enemy //düşmanın sınıfı 
        {
            public int damage { get; set; } //saldırma 
            Random random = new Random(); //random olarak belirlenen hasar değeri özelliği 

        public void EnemyAttack() //bu metot sayesinde hasar değeri belirlenir
            { 
                for (int i = 0; i < 5; i++)
                { 
                    damage = 0; //her vuruşta hasar değeri düşer
                    damage += random.Next(20, 30);

                }
            }
    }
}
