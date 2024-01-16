using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Student names 
//Jana Mahdi Aljehani 2109657
//Lama Turki Alharbi 2205773
//Mayar Hassan Alzibali 2205454
//Class Number AB
//Course Name :Programming II

namespace coffewshop
{
    public partial class Form1 : Form
    {
     
        string name;
        int price;
        int tot;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!(chkfrice.Checked || chkchi.Checked || chkfish.Checked || chktea.Checked || chkcoffee.Checked || chkcock.Checked))
            {
                MessageBox.Show("Please select at least one item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkfrice.Checked)
            {
                if (!CheckAndAddItem("Fried Rice", numericUpDown1, 100))
                {
                    return;
                }
            }
            if (chkchi.Checked)
            {
                if (!CheckAndAddItem("Chicken", numericUpDown2, 150))
                {
                    return;
                }
            }
            if (chkfish.Checked)
            {
                if (!CheckAndAddItem("Fish", numericUpDown3, 250))
                {
                    return;
                }
            }


            if (chktea.Checked)
            {
                if (!CheckAndAddItem("Tea", numericUpDown6, 35))
                {
                    return;
                }
            }

            if (chkcoffee.Checked)
            {
                if (!CheckAndAddItem("Coffee", numericUpDown5, 50))
                {
                    return;
                }
            }
            if (chkcock.Checked)
            {
                if (!CheckAndAddItem("Coca Cola", numericUpDown4, 70))
                {
                    return;
                }
            }

            UpdateTotal();
        }

        private bool CheckAndAddItem(string itemName, NumericUpDown numericUpDown, int price)
        {
            int qty = (int)numericUpDown.Value;
            if (qty <= 0)
            {
                MessageBox.Show($"Quantity for {itemName} should be greater than 0 and not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int tot = qty * price;
            this.dataGridView1.Rows.Add(itemName, price, qty, tot);

            return true;
        }

        private void UpdateTotal()
        {
            int sum = 0;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
            }

            textBox1.Text = sum.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            PrintBill();
        }


        private void ClearForm()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkbox)
                    checkbox.Checked = false;
                else if (control is NumericUpDown numericUpDown)
                    numericUpDown.Value = 0;
            }

            dataGridView1.Rows.Clear();
            textBox1.Clear();
        }


        private void PrintBill()
        {
            string billInfo = GetBillInfo();
            MessageBox.Show($"\n\n{billInfo}", "Bill Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetBillInfo()
        {
            string billInfo = "Bill Information:\n\n";

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                string itemName = dataGridView1.Rows[row].Cells[0].Value.ToString();
                int itemPrice = Convert.ToInt32(dataGridView1.Rows[row].Cells[1].Value);
                int itemQty = Convert.ToInt32(dataGridView1.Rows[row].Cells[2].Value);
                int itemTotal = Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);

                billInfo += $"{itemName} - Qty: {itemQty} - Price: {itemPrice} - Total: {itemTotal}\n";
            }

            billInfo += $"\nTotal Amount: {textBox1.Text}";

            return billInfo;
        }


    }


}