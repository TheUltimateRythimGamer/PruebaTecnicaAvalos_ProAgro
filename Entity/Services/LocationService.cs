using Data;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public class LocationService : ILocationService
    {
        private DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public Location GetLocation(string locationId)
        {
            return _context.Locations.Where(x => x.Id == locationId).FirstOrDefault();
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public async Task<bool> Guardar(string locationId, Location location)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Location locationDb = await _context.Locations.Where(x => x.Id == locationId).FirstOrDefaultAsync();

                    if (locationDb == null)
                        await _context.Locations.AddAsync(location);
                    else
                    {
                        locationDb.RutaImagen = location.RutaImagen;
                        locationDb.Raking = location.Raking;
                        locationDb.Nombre = location.Nombre;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
