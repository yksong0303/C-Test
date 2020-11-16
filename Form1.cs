using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from test1.edata where username='" + this.textBox_username.Text + "'" +
                    "and password = '" + this.textBox_password.Text + "'";
            string constring = "datasource=localhost;port=3306;username=root;password=1234";
            if (this.textBox_username.Text == null || this.textBox_username.Text == "")
            {
                MessageBox.Show("아이디를 입력해 주세요");
                return;
            }
            else if (this.textBox_password.Text == null || this.textBox_password.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해 주세요");
                return;
            }
            else
            {
                try
                {
                    MySqlConnection conDatBase = new MySqlConnection(constring);
                    MySqlCommand selectCommand = new MySqlCommand(query, conDatBase);
                    MySqlDataReader myReader;
                    conDatBase.Open();
                    myReader = selectCommand.ExecuteReader();
                    int count = 0;

                    while (myReader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("로그인 성공");
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("중복됨");
                    }
                    else
                    {
                        MessageBox.Show("로그인 실패");
                    }

                    conDatBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string constring = "datasource = localhost;port=3306;username=root;password=1234";
            string query = "insert into test1.edata(username,password) value('" + this.textBox_username.Text + "','" + this.textBox_password.Text + "')";

            if (this.textBox_username.Text==null|| this.textBox_username.Text=="")
            {
                MessageBox.Show("아이디를 입력해 주세요");
                return;
            }else if(this.textBox_password.Text ==null || this.textBox_password.Text==""){
                MessageBox.Show("비밀번호를 입력해 주세요");
                return;
            }
            else
            {
                MySqlConnection conDatBase = new MySqlConnection(constring);
                MySqlCommand cmDatabase = new MySqlCommand(query, conDatBase);
                MySqlDataReader myReader;
                try
                {
                    conDatBase.Open();
                    myReader = cmDatabase.ExecuteReader();
                    MessageBox.Show("회원가입완료");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
