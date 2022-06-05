using newBorn.Model;

namespace newBorn.SecondaryForms.AddCabinet
{
    public partial class AddCabinetForm : Form
    {
        public Action<Cabinet> OnNewCabinetAdd;

        public AddCabinetForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int result))
            {
                var cabinet = new Cabinet()
                {
                    Title = textBox1.Text,
                    ComputerCount = result
                };
                OnNewCabinetAdd.Invoke(cabinet);
            }
        }

        private void AddCabinetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
