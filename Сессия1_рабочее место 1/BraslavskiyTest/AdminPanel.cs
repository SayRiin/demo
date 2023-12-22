using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BraslavskiyTest
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void propertiesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.propertiesBindingSource.EndEdit();

            try {
                this.tableAdapterManager.UpdateAll(this.braslavskiy_agentDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка.");
            }

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "braslavskiy_agentDataSet.Properties". При необходимости она может быть перемещена или удалена.
            this.propertiesTableAdapter.Fill(this.braslavskiy_agentDataSet.Properties);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            propertiesBindingSource.Filter = $"address LIKE '%{textBox1.Text}%'";
        }
    }
}
