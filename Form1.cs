using newBorn.SecondaryForms.AddCabinet;
using newBorn.SecondaryForms.AddRegistry;
using newBorn.SecondaryForms.AddResourceLocation;
using newBorn.Services;
using newBorn.View;

namespace newBorn
{
    public partial class Form1 : Form
    {
        private AddCabinetForm _addCabinetForm;
        private AddRegistryForm _addRegistryForm;
        private AddResourceLocationForm _addResourceLocationForm;
        private Tables _tables;
        private CabinetService _service;

        public Form1()
        {
            InitializeComponent();
            _addCabinetForm = new AddCabinetForm();
            _addRegistryForm = new AddRegistryForm();
            _addResourceLocationForm = new AddResourceLocationForm();
            _service = new CabinetService(_addCabinetForm, _addRegistryForm, _addResourceLocationForm);
            _addResourceLocationForm.Set(_service);
            _tables = new Tables(dataGridView1, dataGridView2, dataGridView3, _service);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _tables.Rebind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _addCabinetForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows[0].Index;
            _service.RemoveCabinet(index);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _tables.SetCabinetId(dataGridView1.Rows[e.RowIndex]);
            _tables.RebindResource();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _tables.SetRegistryId(dataGridView2.Rows[e.RowIndex]);
            _tables.RebindResource();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var index = dataGridView2.SelectedRows[0].Index;
            _service.DeleteRegistry(index);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _addRegistryForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _addResourceLocationForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var index = dataGridView3.SelectedRows[0].Index;
            _service.DeleteResource(index);
        }
    }
}