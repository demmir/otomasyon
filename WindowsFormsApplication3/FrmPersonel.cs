using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;

namespace WindowsFormsApplication3
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SQLclass SQL = new SQLclass();
        string tablo_adi="TBL_PERSONELLER";

        public void listele()
        {

            gridControl1.DataSource = SQL.listele(tablo_adi);

        }

        private void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txttel.Text = "";
            txttc.Text = "";
            txtmail.Text = "";
            txtil.Text = "";
            txtilce.Text = "";
            txtadres.Text = "";
            txtgorev.Text = "";

        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
           
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SQL.Personel_kayit_ekle(txtad.Text,txtsoyad.Text,txttel.Text,txttc.Text,txtmail.Text,txtil.Text,txtilce.Text,txtadres.Text,txtgorev.Text );
            MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı ?", "İnformation",
            MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = XtraMessageBox.Show("Kaydı Silmek İstediğinize Emin misiniz ?", "Uyarı",
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

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string id = dr[0].ToString();// dr["ID"].ToString();  
            SQL.Personel_kayit_duzenle(id, txtad.Text, txtsoyad.Text, txttel.Text, txttc.Text, txtmail.Text, txtil.Text, txtilce.Text, txtadres.Text, txtgorev.Text);
            MessageBox.Show("Güncelleme İşemi Başarıyla Tamamlandı ?", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }


        private void satirdegistir()
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtid.Text = dr[0].ToString();
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                txttel.Text = dr[3].ToString();
                txttc.Text = dr[4].ToString();
                txtmail.Text = dr[5].ToString();
                txtil.Text = dr[6].ToString();
                txtilce.Text = dr[7].ToString();
                txtadres.Text = dr[8].ToString();
                txtgorev.Text = dr[9].ToString();
            }
            catch
            {

            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            satirdegistir();
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            satirdegistir();
        }
    }
}
