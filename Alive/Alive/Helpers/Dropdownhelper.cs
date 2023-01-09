using Alive.data;
using Alive.Enum;
using Alive.IHelpers;
using Alive.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Alive.Helpers
{
    public class Dropdownhelper: IDropdownhelper
    {
        private readonly AppDbContext _context;

        public Dropdownhelper(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonDropdown>> GetGenderDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false)
        {

            var common = new CommonDropdown()
            {
                Id = 0,
                Name = "-- Select your gender--"
            };
            var dropdowns = await _context.CommonDropdowns.Where(s => s.Deleted == deleteOption && s.DropdownKey == (int)dropdownKey).OrderBy(s => s.Name).ToListAsync();
            dropdowns.Insert(0, common);

            return dropdowns;
        }
        public class DropdownEnumModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public async Task<List<CommonDropdown>> GetDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false)
        {

            var common = new CommonDropdown()
            {
                Id = 0,
                Name = "-- Select --"
            };
            var dropdowns = await _context.CommonDropdowns.Where(s => s.Deleted == deleteOption && s.DropdownKey == (int)dropdownKey).OrderBy(s => s.Name).ToListAsync();
            dropdowns.Insert(0, common);

            return dropdowns;
        }
        public async Task<List<Country>> GetCountry()
        {

            var common = new Country()
            {
                Id = 0,
                Name = "-- Select your country --"
            };
            var country = await _context.Country.Where(d => !d.Deleted && d.Id != 0).OrderBy(s => s.Id).ToListAsync();
            country.Insert(0, common);

            return country;
        }
     

        public async Task<List<State>> GetState()
        {
            var common = new State()
            {
                Id = 0,
                Name = "-- Select --"

            };
            var selectedBranches = await _context.State.OrderBy(x => x.Name).Where(x => x.Active && !x.Deleted).ToListAsync();
            if (selectedBranches != null)
            {
                selectedBranches.Insert(0, common);
                return selectedBranches;
            }
            return null;
        }

    }
}
