using System;
using System.IO;
using System.Windows.Forms;

namespace ContactManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                phoneBooksBindingSource.Filter = $"FullName '*{txtSearch.Text}*' or Mobile='{txtSearch.Text}'";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                database.ReadXml($"{Application.StartupPath}/data.dat");
        }

        private void phoneBooksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            phoneBooksBindingSource.EndEdit();
            database.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
