using newBorn.Services;
using newBorn.Model;

namespace newBorn.SecondaryForms.AddResourceLocation
{
    public partial class AddResourceLocationForm : Form
    {
        private ComboBoxesFiller _filler;

        public Action<ResourceLocation> OnResourceLocationAdd;

        public AddResourceLocationForm()
        {
            InitializeComponent();
        }

        private void AddResourceLocationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resource = new ResourceLocation()
            {
                RegistryID = Convert.ToInt32(comboBox1.Text),
                CabinetID = Convert.ToInt32(comboBox2.Text),
                DownloadDate = textBox1.Text
            };

            OnResourceLocationAdd.Invoke(resource);
        }

        internal void Set(CabinetService service)
        {
            _filler = new ComboBoxesFiller(comboBox1, comboBox2, service);
            _filler.Fill();
        }
    }
}
