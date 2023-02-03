using Alive.Enum;
using Alive.Models;

namespace Alive.IHelpers
{
    public interface IDropdownhelper
    {
        Task<List<CommonDropdown>> GetGenderDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetGenotypeDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetBloodGroupDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetPatientTypeDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<Country>> GetCountry();
        Task<List<CommonDropdown>> GetMilitaryServiceDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetMaritalStatusDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetSmokingHabitDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetAnyAddictionDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetSexuallyActiveDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetUnprotectedSexDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
        Task<List<CommonDropdown>> GetMSMDropdownByKey(AliveProjectEnums dropdownKey, bool deleteOption = false);
       
    }
}

