using Alive.Enum;
using Alive.Models;

namespace Alive.IHelpers
{
    public interface IDropdownhelper
    {
        Task<List<CommonDropdown>> GetGenderDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<Country>> GetCountry();
    }
}

