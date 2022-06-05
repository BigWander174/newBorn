using newBorn.Contexts;
using newBorn.Model;
using newBorn.SecondaryForms.AddCabinet;
using newBorn.SecondaryForms.AddRegistry;
using newBorn.SecondaryForms.AddResourceLocation;

namespace newBorn.Services
{
    public class CabinetService
    {
        private CabinetContext _context;

        public Action Update;

        public CabinetService(AddCabinetForm addCabinetForm, AddRegistryForm addRegistryForm, 
            AddResourceLocationForm addResourceLocationForm)
        {
            _context = new CabinetContext();
            addCabinetForm.OnNewCabinetAdd += Add;
            addRegistryForm.OnRegistryAdd += Add;
            addResourceLocationForm.OnResourceLocationAdd += Add;
            Update += SaveChanges;
        }

        public List<Cabinet> Cabinets => _context.Cabinets.ToList();
        public List<Registry> Registries => _context.Registries.ToList();
        public List<ResourceLocation> ResourceLocations => _context.ResourceLocations.ToList();

        public void Add(Cabinet cabinet)
        {
            var cabinetWithTheSameName = _context.Cabinets.ToList().FirstOrDefault(element => element.Title == cabinet.Title);

            if (cabinetWithTheSameName == null)
            {
                _context.Cabinets.Add(cabinet);
                Update.Invoke();
            }
        }

        public void Add(Registry registry)
        {
            var registrywithTheSameName = _context.Registries.ToList().FirstOrDefault(element => element.Title == registry.Title);

            if (registrywithTheSameName == null)
            {
                _context.Registries.Add(registry);
                Update.Invoke();
            }
        }

        public void Add(ResourceLocation resourceLocation)
        {
            _context.ResourceLocations.Add(resourceLocation);
            Update.Invoke();
        }

        internal void DeleteRegistry(int id)
        {
            var resources = _context.ResourceLocations.ToList().Where(element => element.RegistryID == id);
            _context.ResourceLocations.RemoveRange(resources);
            _context.Registries.Remove(_context.Registries.ToList()[id]);
            Update.Invoke();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void RemoveCabinet(int index)
        {
            var elementToDelete = _context.Cabinets.ToList()[index];
            var resources = _context.ResourceLocations.ToList().Where(element => element.CabinetID == elementToDelete.ID);
            _context.ResourceLocations.RemoveRange(resources);
            _context.Cabinets.Remove(elementToDelete);
            Update.Invoke();
        }

        internal void DeleteResource(int index)
        {
            var elementToDelete = _context.ResourceLocations.ToList()[index];
            _context.ResourceLocations.Remove(elementToDelete);
            Update.Invoke();
        }
    }
}
