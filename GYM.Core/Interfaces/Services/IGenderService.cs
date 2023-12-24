using GYM.Core.Enumerators;

namespace GYM.Core.Interfaces.Services
{
    public interface IGenderService
    {
        GenderEnum GetGender(string genderName);
        List<string> GetGenders();
    }
}