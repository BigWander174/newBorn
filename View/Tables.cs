using newBorn.Services;

namespace newBorn.View
{
    internal class Tables
    {
        private DataGridView _cabinets;
        private DataGridView _registry;
        private DataGridView _resourceLocation;

        private CabinetService _service;

        private int _cabinetId = -1;
        private int _registryId = -1;

        public Tables(DataGridView cabinets, 
            DataGridView registry, DataGridView resourceLocation, CabinetService cabinetService)
        {
            _cabinets = cabinets;
            _registry = registry;
            _resourceLocation = resourceLocation;
            _service = cabinetService;
            _service.Update += Rebind;
        }

        public void Rebind()
        {
            _cabinets.DataSource = _service.Cabinets;
            _registry.DataSource = _service.Registries;

            //            if (_cabinetId != -1 && _registryId != -1)
            //            {
            //                _resourceLocation.DataSource = _service.ResourceLocations.Where(element => element.CabinetID == _cabinetId
            //&& element.RegistryID == _registryId).ToList();
            //            }

            _resourceLocation.DataSource = _service.ResourceLocations;
        }

        public void SetCabinetId(DataGridViewRow row)
        {
            _cabinetId = Convert.ToInt32(row.Cells[0].Value);
        }

        public void SetRegistryId(DataGridViewRow row)
        {
            _registryId = Convert.ToInt32(row.Cells[0].Value);
        }

        internal void RebindResource()
        {
            //                _resourceLocation.DataSource = _service.ResourceLocations.Where(element => element.CabinetID == _cabinetId
            //&& element.RegistryID == _registryId).ToList();
            _resourceLocation.DataSource = _service.ResourceLocations;
        }
    }
}
