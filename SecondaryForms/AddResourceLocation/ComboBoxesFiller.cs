using newBorn.Model;
using newBorn.Services;

namespace newBorn.SecondaryForms.AddResourceLocation
{
    internal class ComboBoxesFiller
    {
        private ComboBox _registries;
        private ComboBox _cabinets;

        private CabinetService _service;

        public ComboBoxesFiller(ComboBox registries, ComboBox cabinets, CabinetService service)
        {
            _registries = registries;
            _cabinets = cabinets;
            _service = service;
            _service.Update += Fill;
        }

        public void Fill()
        {
            _registries.Items.Clear();
            _cabinets.Items.Clear();
            _registries.Items.AddRange(_service.Registries.Select(element => (object)element.ID).ToArray());
            _cabinets.Items.AddRange(_service.Cabinets.Select(element => (object)element.ID).ToArray());
        }
    }
}
