using System.ComponentModel;

namespace Alive.Enum
{
    public enum AliveProjectEnums
    {
        [Description("For returning the user gender")]
        GenderDropdownKey = 1,
        [Description("For returning the user Blood Group")]
        BloodGroupDropdownKey,
        [Description("For returning the user Genotype")]
       GenotypeDropdownKey,
        [Description("For returning the user Patient Type")]
        PatientTypeDropdownKey,
        [Description("For returning the user Marital Status")]
        MaritalStatusDropdownKey,
        [Description("For returning knowing if the user has a Military service history")]
        MilitaryServiceDropdownKey,
        [Description("For returning the user Sexual Activity")]
        SexuallyActiveDropdownKey,
        [Description("For returning the user sexual status")]
        UnprotectedSexDropdownKey,
        [Description("For returning the user sexuality")]
        MSMDropdownKey,
        [Description("For returning the user smoking habit")]
        SmokingHabitDropdownKey,
        [Description("For returning the user addictions")]
        AnyAddictionDropdownKey,
    }
}

