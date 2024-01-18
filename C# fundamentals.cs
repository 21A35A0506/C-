using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataBindingValidationExample
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource;

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
            InitializeBindings();
        }

        private void InitializeData()
        {
        
            var dataSource = new DataSource
            {
                Name = "John Doe",
                Age = 25
            };
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;
        }

        private void InitializeBindings()
        {

            textBoxName.DataBindings.Add("Text", bindingSource, "Name");
            textBoxAge.DataBindings.Add("Text", bindingSource, "Age");
            textBoxName.Validating += TextBoxName_Validating;
            textBoxAge.Validating += TextBoxAge_Validating;
        }

        private void TextBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxAge_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(textBoxAge.Text, out _))
            {
                e.Cancel = true;
                MessageBox.Show("Age must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Name: {textBoxName.Text}\nAge: {textBoxAge.Text}", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class DataSource
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
