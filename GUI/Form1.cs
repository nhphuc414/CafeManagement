using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void loadComboBox()
        {
            cboCategory.DataSource = BUS_Categories.Instance.loadCategories();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=BUS_Products.Instance.loadProducts();
            loadComboBox();
        }

        private void btnAddCates_Click(object sender, EventArgs e)
        {
            try
            {
                if (BUS_Categories.Instance.addCategory(txtCatesName.Text))
                {
                    MessageBox.Show("Add succesfull");
                    loadComboBox();
                }
                else MessageBox.Show("Something wrong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            double price = double.Parse(txtPrice.Text.Trim());
            int categoryId = (int)cboCategory.SelectedValue;
            try
            {
                if (BUS_Products.Instance.addProduct(productName, price, categoryId))
                {
                    MessageBox.Show("Add succesfull");
                    dataGridView1.DataSource = BUS_Products.Instance.loadProducts();
                }
                else MessageBox.Show("Something wrong");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
