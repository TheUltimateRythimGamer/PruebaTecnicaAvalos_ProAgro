using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface ILocationService
    {
        Task<bool> Guardar(string locationId, Location location);
        ICollection<Location> GetLocations();

        Location GetLocation(string locationId);
    }
}
