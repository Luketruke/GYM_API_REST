using GYM.Core.Enumerators;
using GYM.Core.Interfaces.Services;

namespace GYM.Core.Services
{
    public class ModalityService : IModalityService
    {
        public ModalityEnum GetModality(string modalityName)
        {
            if (Enum.TryParse<ModalityEnum>(modalityName, out var modality))
            {
                return modality;
            }
            else
            {
                throw new ArgumentException("Not valid modality", nameof(modalityName));
            }
        }

        public List<string> GetModalities()
        {
            return Enum.GetNames(typeof(ModalityEnum)).ToList();
        }
    }
}
