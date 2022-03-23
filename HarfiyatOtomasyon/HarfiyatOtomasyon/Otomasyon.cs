using System;
using System.Windows.Forms;
using System.Data.OleDb;
using HarfiyatOtomasyon.Controller;
using HarfiyatOtomasyon.Entities;
using HarfiyatOtomasyon.Model;

namespace HarfiyatOtomasyon
{
    public partial class Otomasyon : Form
    {
        IDataOperations dataOperations = new SqlServer();
        public Otomasyon()
        {
            InitializeComponent();
        }

        private void Otomasyon_Load(object sender, EventArgs e)
        {
            GetVehicle getVehicle = new GetVehicle();
            comboBox1.DataSource = getVehicle.GetAllVehicle();
            comboBox1.DisplayMember = "VehicleName";
            MusteriVeriListeleme();
        }
        private void btnCustomerADD_Click(object sender, EventArgs e)
        {
            string firstName, lastName, address, number, explanation = "";
            int vehicleID, drivingTime, status;
            DateTime dateOfStart, endDate;
            decimal payments;

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("İş Bitiş Tarihi Başlama Tarihinden Önce Olamaz...");
            }
            else
            {
                if (valueControl())
                {
                    DegerleriGetir(out vehicleID, out firstName, out lastName, out number, out address, out drivingTime, out dateOfStart, out endDate, out payments, out explanation);

                    DialogResult cevap = MessageBox.Show("Müsteri Eklensin mi?", "Müsteri ekleme mesajı", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        dataOperations.Add(vehicleID, firstName, lastName, number, address, drivingTime, dateOfStart, endDate, payments, explanation, 1);
                        MusteriVeriListeleme();
                        Clear();
                        MessageBox.Show("Musteri Bilgileri Eklendi");
                    }
                    else
                    {
                        MessageBox.Show("İşleminiz iptal edildi...");
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen müşteri bilgilerini tam olara giriniz...");
                }
            }
        }
        private void btnGuncelleme_Click(object sender, EventArgs e)
        {
            string firstName, lastName, address, number, explanation = "";
            int vehicleID, drivingTime, status;
            DateTime dateOfStart, endDate;
            decimal payments;
            if (textBox1.Text != "" && valueControl())
            {
                if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("İş Bitiş Tarihi Başlama Tarihinden Önce Olamaz...");
                }
                else
                {
                    int update = Int32.Parse(textBox1.Text);
                    DegerleriGetir(out vehicleID, out firstName, out lastName, out number, out address, out drivingTime, out dateOfStart, out endDate, out payments, out explanation);
                    DialogResult cevap = MessageBox.Show(firstName.ToUpper() + " " + "Adlı Müsteri Güncellensin mi?", "Müsteri Güncelleme Uyarı Mesajı",
                        MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        dataOperations.Update(update, vehicleID, firstName, lastName, number, address, drivingTime, dateOfStart, endDate, payments, explanation, 1);
                        MusteriVeriListeleme();
                        Clear();
                        MessageBox.Show("Güncelleme yapıldı");
                    }
                    else
                    {
                        MessageBox.Show("Güncellemeyi İptal Ettiniz");
                    }
                }


            }
            else
            {
                MessageBox.Show("Kullanıcı Secimi Yapmalısınız veya boş alan bulunuyor");
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult cevap = MessageBox.Show("Müsteri Silinsin mi?", "Müsteri Silme Uyarı Mesajı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    int deleteValue = DeleteDataValue();
                    dataOperations.Delete(deleteValue);
                    MusteriVeriListeleme();
                    Clear();
                    MessageBox.Show("Silindi");

                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edildi...");
                }

            }
            else
            {
                MessageBox.Show("Müsteri Seçilmedi");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()) - 1;
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
        
        private bool valueControl()
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox12.Text != "")
                return true;
            else
                return false;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\calc.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox11.Text;
            Search search = new Search();
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource = search.CustomerSearch(aranan, "name");
            }
            else if (radioButton2.Checked == true)
            {
                dataGridView1.DataSource = search.CustomerSearch(aranan, "number");
            }
            else if (radioButton3.Checked == true)
            {
                dataGridView1.DataSource = search.CustomerSearch(aranan, "adres");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lütfen Telefon Numarası giriniz...");
            }
          
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (radioButton2.Checked == true && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lütfen Telefon Numarası giriniz...");
            }
        }
        private int DeleteDataValue()
        {
            return Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);//seçim yapılan datayı return ediyoruz
        }
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox12.Clear();
            dateTimePicker1.Text = DateTime.Now.ToString();
            dateTimePicker2.Text = DateTime.Now.ToString();
            comboBox1.SelectedIndex = 0;

        }
        private void DegerleriGetir(out int vehicleID, out string firstName, out string lastName, out string number, out string address,
            out int drivingTime, out DateTime dateOfStart, out DateTime endDate, out decimal payments, out string explanation)
        {

            vehicleID = Convert.ToInt32(comboBox1.SelectedIndex.ToString()) + 1;
            firstName = textBox2.Text;
            lastName = textBox3.Text;
            number = textBox4.Text;
            address = textBox5.Text;
            drivingTime = Int32.Parse(textBox7.Text);
            dateOfStart = DateTime.Parse(dateTimePicker1.Text);
            endDate = DateTime.Parse(dateTimePicker2.Text);
            payments = Decimal.Parse(textBox12.Text);
            explanation = textBox8.Text;
        }
        private void MusteriVeriListeleme()
        {
            GetCustomer getCustomer = new GetCustomer();
            dataGridView1.DataSource = getCustomer.GetAll();
        }

        private void ToplamAracKullanımSaati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton2.Checked == true && char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Toplam Saati giriniz...");

            }
        }

        private void OdemeTutarı_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton2.Checked == true && char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Odeme Tutarı giriniz...");

            }
        }
    }
}
