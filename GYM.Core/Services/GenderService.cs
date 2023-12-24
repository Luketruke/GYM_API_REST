using GYM.Core.Enumerators;
using GYM.Core.Interfaces.Services;

namespace GYM.Core.Services
{
    public class GenderService : IGenderService
    {
        public GenderEnum GetGender(string genderName)
        {
            if (Enum.TryParse<GenderEnum>(genderName, out var gender))
            {
                return gender;
            }
            else
            {
                throw new ArgumentException("Not valid gender", nameof(genderName));
            }
        }

        public List<string> GetGenders()
        {
            return Enum.GetNames(typeof(GenderEnum)).ToList();
        }
    }
}