using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DynamicDropdownExample
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _client;
        public Form1()
        {
            InitializeComponent();
            _client = new HttpClient();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.Enabled = false;
            comboBox1.DropDownWidth = comboBox1.Width * 3;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is PostalAddress selectedAddress)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add(selectedAddress.PostalCode);
                comboBox1.Text = selectedAddress.PostalCode;

                txtAddress.Text = selectedAddress.Address;

            }
        }





        // Mock API call. Replace with your real API call.
        private async Task<List<PostalAddress>> FetchPostalCodes(string input)
        {
            await Task.Delay(500); // Simulate network delay
            return new List<PostalAddress>
        {
            new PostalAddress { PostalCode = $"{input}1", Address = "Example Address 1 Example Address 1 Example Address 1 Example Address 1" +  $"{input}1"},
            new PostalAddress { PostalCode = $"{input}2", Address = "Example Address 2 Example Address 2 Example Address 2 Example Address 2 " +  $"{input}2"},
            new PostalAddress { PostalCode = $"{input}3", Address = "Example Address 3Example Address 3Example Address 3Example Address 3Example Address 3" +  $"{input}3"},
            new PostalAddress { PostalCode = $"{input}4", Address = "Example Address 4Example Address 4" +  $"{input}4"},
            new PostalAddress { PostalCode = $"{input}5", Address = "Example Address 5" +  $"{input}5"}

        };

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
            {
                label2.Text = "";
                string input = textBox1.Text;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    var results = await FetchPostalCodes(input);

                    comboBox1.Items.Clear();
                    foreach (var item in results)
                    {
                        comboBox1.Items.Add(item);
                    }
                    comboBox1.DroppedDown = true;
                }
                groupBox1.Visible = false;
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Warning: Lookup required minimum 4 digit of postal code ";
                textBox1.Focus();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            textBox1.Focus();
        }
    }
}