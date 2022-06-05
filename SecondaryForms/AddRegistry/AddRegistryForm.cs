using newBorn.Model;

namespace newBorn.SecondaryForms.AddRegistry
{
    public partial class AddRegistryForm : Form
    {
        public Action<Registry> OnRegistryAdd;
        public AddRegistryForm()
        {
            InitializeComponent();
        }

        private void AddRegitryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int result))
            {
                var registry = new Registry()
                {
                    Title = textBox1.Text,
                    Capacity = result,
                    Function = textBox3.Text
                };

                OnRegistryAdd.Invoke(registry);
            }
        }
    }
}
