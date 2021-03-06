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
    public partial class FrmFırmalar : Form
    {
        public FrmFırmalar()
        {
            InitializeComponent();
        }
        SQLclass SQL = new SQLclass();
        string tablo_adi = "TBL_FIRMALAR";

        public void listele()
        {

            gridControl1.DataSource = SQL.listele(tablo_adi);

        }
        private void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsektor.Text = "";
            txtyetkili.Text = "";
            txtyetkgorev.Text = "";
            txttc.Text = "";
            txttel1.Text = "";
            txttel2.Text = "";
            txttel3.Text = "";
            txtfax.Text = "";
            txtmail.Text = "";
            txtil.Text = "";
            txtilce.Text = "";
            txtvergid.Text = "";
            txtadres.Text = "";
            txtozelk1.Text = "";
            txtozelk2.Text = "";
            txtozelk3.Text = "";

        }
      private void satirdegistir()
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtid.Text = dr[0].ToString();
                txtad.Text = dr[1].ToString();
                txtsektor.Text = dr[2].ToString();
                txtyetkili.Text = dr[3].ToString();
                txtyetkgorev.Text = dr[4].ToString();
                txttc.Text = dr[5].ToString();
                txttel1.Text = dr[6].ToString();
                txttel2.Text = dr[7].ToString();
                txttel3.Text = dr[8].ToString();
                txtfax.Text = dr[9].ToString();
                txtmail.Text = dr[10].ToString();
                txtil.Text = dr[11].ToString();
                txtilce.Text = dr[12].ToString();
                txtvergid.Text = dr[13].ToString();
                txtadres.Text = dr[14].ToString();
                txtozelk1.Text = dr[15].ToString();
                txtozelk2.Text = dr[16].ToString();
                txtozelk3.Text = dr[17].ToString();
               
            }
            catch
            {

            }
        }
        private void FrmFırmalar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            satirdegistir();
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            satirdegistir();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SQL.Fırma_kayit_ekle(txtad.Text, txtsektor.Text, txtyetkili.Text, txtyetkgorev.Text, txttc.Text, txttel1.Text, txttel2.Text, txttel3.Text, txtfax.Text, txtmail.Text,txtil.Text,txtilce.Text,txtvergid.Text,txtadres.Text,txtozelk1.Text,txtozelk2.Text,txtozelk3.Text );
            MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı ?", "İnformation",
            MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();
            temizle();
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
                SQL.kayit_sil(id, tablo_adi);
                listele();
                temizle();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string id = dr[0].ToString();// dr["ID"].ToString();  
            SQL.Fırma_kayit_duzenle(id,txtad.Text, txtsektor.Text, txtyetkili.Text, txtyetkgorev.Text, txttc.Text, txttel1.Text, txttel2.Text, txttel3.Text, txtfax.Text, txtmail.Text,txtil.Text,txtilce.Text,txtvergid.Text,txtadres.Text,txtozelk1.Text,txtozelk2.Text,txtozelk3.Text);
            MessageBox.Show("Güncelleme İşemi Başarıyla Tamamlandı ?", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
