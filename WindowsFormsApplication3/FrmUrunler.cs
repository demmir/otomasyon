using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SQLclass SQL = new SQLclass();
        string tablo_adi = "TBL_URUNLER";
        public void listele()
        {
         
          gridControl1.DataSource = SQL.listele(tablo_adi);
            
        }
       
        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Kaydı Silmek İstediğinize Emin misiniz ?", "Uyarı",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Soru == DialogResult.Yes)
            {

                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string id = dr[0].ToString();// dr["ID"].ToString();     
                SQL.kayit_sil(id,tablo_adi);
                listele();
                temizle();
            }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
           
        }

        private void satirdegistir()
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtid.Text = dr[0].ToString();
                txtad.Text = dr[1].ToString();
                txtmarka.Text = dr[2].ToString();
                txtmodel.Text = dr[3].ToString();
                txtyil.Text = dr[4].ToString();
                txtadet.Text = dr[5].ToString();
                txtalis.Text = dr[6].ToString();
                txtsatis.Text = dr[7].ToString();
                txtdetay.Text = dr[8].ToString();
            }
            catch
            {

            }
            
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SQL.Urun_kayit_ekle(txtad.Text,txtmarka.Text,txtmodel.Text,txtadet.Text,txtsatis.Text,txtalis.Text,txtyil.Text,txtdetay.Text);
            MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı ?", "İnformation",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();
            temizle();
        }

        private void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            txtadet.Text = "";
            txtsatis.Text = "";
            txtalis.Text = "";
            txtyil.Text = "";
            txtdetay.Text = "";
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            satirdegistir();
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            satirdegistir();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            //temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string id = dr[0].ToString();// dr["ID"].ToString();  
            SQL.Urun_kayit_duzenle(id, txtad.Text, txtmarka.Text, txtmodel.Text,txtyil.Text,txtadet.Text,txtalis.Text,txtsatis.Text, txtdetay.Text);
            MessageBox.Show("Güncelleme İşemi Başarıyla Tamamlandı ?", "İnformation",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
        
    }
}
