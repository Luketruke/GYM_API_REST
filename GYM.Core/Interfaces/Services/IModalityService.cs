using GYM.Core.Enumerators;

namespace GYM.Core.Interfaces.Services
{
    public interface IModalityService
    {
        List<string> GetModalities();
        ModalityEnum GetModality(string modalityName);
    }
}