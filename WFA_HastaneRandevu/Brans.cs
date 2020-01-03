using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_HastaneRandevu
{
    public class Brans:HastaneBase
    {
        //public string BransAd { get; set; }
        public List<Doktor> Doktorlar { get; set; }

        //Polymorphism kullanmammızın sebebi; Brans isimli classı herhangi bir tool'a object olarak gönderdiğimizde hangi özelliği göstereceğini bilemez. Neticede içerisinde hem doktorlar hem de hastansebase classından gelen ad isimli property bulunmakta bu yüzcden Brans isimli classı çağırdığımız yerde doğrudan içerisinde tanımlı olan Ad isimli property'i ezmiş olduk.
        public override string ToString()
        {
            return Ad;
        }

    }
}
