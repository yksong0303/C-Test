using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connection
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string constring = "datasource = localhost;port=3306;username=root;password=1234";

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = "update test1.edata set username='" + this.textBox_id.Text + "', password='" + this.textBox_pwd.Text + "' where username='" + this.textBox_id.Text + "'";

            MySqlConnection conDatBase = new MySqlConnection(constring);
            MySqlCommand cmDatabase = new MySqlCommand(query, conDatBase);
            try
            {
                conDatBase.Open();
                if (cmDatabase.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("수정완료, 다시 로그인해주세요");
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                   
                }else
                {
                    MessageBox.Show("찾을 수 없는 계정정보입니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            
            string query = "delete from test1.edata where username='" + this.textBox_id.Text + "' and password='" + this.textBox_pwd.Text + "'";

            MySqlConnection conDatBase = new MySqlConnection(constring);
            MySqlCommand cmDatabase = new MySqlCommand(query, conDatBase);
            try
            {
                conDatBase.Open();
                if (cmDatabase.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("삭제완료");

                }
                else
                {
                    MessageBox.Show("삭제할 계정 정보를 입력해주세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmDataBase = new MySqlCommand("select * from test1.edata", conDataBase);

            try
            {
                MySqlDataAdapter sbs = new MySqlDataAdapter();
                sbs.SelectCommand = cmDataBase;
                DataTable dbtable = new DataTable();
                sbs.Fill(dbtable);
                BindingSource dbSource = new BindingSource();
                dbSource.DataSource = dbtable;
                dataGridView1.DataSource = dbSource;
                sbs.Update(dbtable);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox_id.Text = row.Cells["username"].Value.ToString();
                textBox_pwd.Text = row.Cells["password"].Value.ToString();
            }
        }
    }
}
