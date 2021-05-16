using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
    class SQLclass
    {
        SqlConnection conn = new SqlConnection("Data Source=GEFORCE\\SQLEXPRESS;Initial Catalog=Dbo_Ticari_Otomasyon;Integrated Security=True");
      
        public DataTable listele(string tablo_adi)            
        {
          
           
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from "+tablo_adi+"", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            tbl.Dispose();
            conn.Close();
            return tbl;
        }

        public DataTable Musteri_listele(string tablo_adi)
        {


            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select ID,AD,SOYAD,TELEFON,TELEFON2,MAIL from " + tablo_adi + "", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            tbl.Dispose();
            conn.Close();
            return tbl;
        }

        public DataTable Firmalar_listele(string tablo_adi2)
        {


            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select ID,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX from " + tablo_adi2 + "", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            tbl.Dispose();
            conn.Close();
            return tbl;
        }

       


        public void Urun_kayit_ekle(string adi,string markasi,string modeli,string yili,string adeti,string alis,string satis,string detayi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("insert into TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values ('" + adi + "','" + markasi + "','" + modeli + "','" + yili + "','" + adeti + "','" + alis + "','" +satis + "','" + detayi + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }
        public void Personel_kayit_ekle(string adi, string soyadi, string teli, string tc, string maili, string ili, string ilcesi, string adresi,string gorevi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("insert into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values ('" + adi + "','" + soyadi + "','" + teli + "','" + tc + "','" + maili + "','" + ili + "','" + ilcesi + "','" + adresi + "','" + gorevi + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Musteri_kayit_ekle(string adi, string soyadi, string teli1, string teli2, string tc, string maili, string ili, string ilcesi, string adresi, string vergi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("insert into TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAİRE) values ('" + adi + "','" + soyadi + "','" + teli1 + "','" + teli2 + "','" + tc + "','" + maili + "','" + ili + "','" + ilcesi + "','" + adresi + "','" + vergi + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }
        public void kayit_sil(string id,string tablo_adi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("delete from  "+tablo_adi+" where ID=('" + id + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Urun_kayit_duzenle(string id, string adi, string markasi, string modeli, string yili, string adeti, string alis, string satis, string detayi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("update TBL_URUNLER  set URUNAD='" + adi + "', MARKA='" + markasi + "',MODEL='" + modeli + "',YIL='" + yili + "',ADET='" + adeti + "',ALISFIYAT='" + alis + "',SATISFIYAT='" + satis + "',DETAY='" + detayi + "' where ID=('" + id + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Personel_kayit_duzenle(string id, string adi, string soyadi, string teli, string tc, string maili, string ili, string ilcesi, string adresi,string gorevi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("update TBL_PERSONELLER  set AD='" + adi + "', SOYAD='" + soyadi + "',TELEFON='" + teli + "',TC='" + tc + "',MAIL='" + maili + "',IL='" + ili + "',ILCE='" + ilcesi + "',ADRES='" + adresi + "',GOREV='" + gorevi + "' where ID=('" + id + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Musteri_kayit_duzenle(string id, string adi, string soyadi, string teli1, string teli2, string tc, string maili, string ili, string ilcesi, string adresi, string vergi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("update TBL_MUSTERILER  set AD='" + adi + "', SOYAD='" + soyadi + "',TELEFON='" + teli1 + "',TELEFON2='" + teli2 + "',TC='" + tc + "',MAIL='" + maili + "',IL='" + ili + "',ILCE='" + ilcesi + "',ADRES='" + adresi + "',VERGIDAİRE='" + vergi + "' where ID=('" + id + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Fırma_kayit_ekle(string adi, string sektörü, string yetkiliadi, string yetkilistatüsü, string yetkilitc, string teli1 , string teli2 , string teli3 , string faxı,string maili , string ili , string ilcesi ,string vergidairesi , string adresi ,string özelkodu1 , string özelkodu2 , string özelkodu3)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("insert into TBL_FIRMALAR(AD,SEKTOR,YETKILIADSOYAD,YETKILISTATU,YETKILITC,TELEFON1,TELEFON2,TELEFON3,FAX,MAIL,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values ('" + adi + "','" + sektörü + "','" + yetkiliadi + "','" + yetkilistatüsü + "','" + yetkilitc + "','" + teli1 + "','" + teli2 + "','" + teli3 + "','" + faxı + "','" + maili + "','" + ili + "','" + ilcesi + "','" + vergidairesi + "','" + adresi + "','" + özelkodu1 + "','" + özelkodu2 + "','" + özelkodu3 + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public void Fırma_kayit_duzenle(string id ,string adi, string sektörü, string yetkiliadi, string yetkilistatüsü, string yetkilitc, string teli1, string teli2, string teli3, string faxı, string maili, string ili, string ilcesi, string vergidairesi, string adresi, string özelkodu1, string özelkodu2, string özelkodu3)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("update TBL_FIRMALAR  set AD='" + adi + "', SEKTOR='" + sektörü + "',YETKILIADSOYAD='" + yetkiliadi + "',YETKILISTATU='" + yetkilistatüsü + "',YETKILITC='" + yetkilitc + "',TELEFON1='" + teli1 + "',TELEFON2='" + teli2 + "',TELEFON3='" + teli3 + "',FAX='" + faxı + "',MAIL='" + maili + "' ,IL='" + ili + "' ,ILCE='" + ilcesi + "',VERGIDAIRE='" + vergidairesi + "',ADRES='" + adresi + "',OZELKOD1='" + özelkodu1 + "',OZELKOD2='" + özelkodu2 + "',OZELKOD3='" + özelkodu3 + "'where ID=('" + id + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

    }
}
