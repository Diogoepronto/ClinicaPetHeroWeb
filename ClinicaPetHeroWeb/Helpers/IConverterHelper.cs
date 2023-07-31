using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Models.Entities;

namespace ClinicaPetHeroWeb.Helpers
{
    public interface IConverterHelper
    {
        Animal ToAnimal(AnimalViewModel model, string animalImageUrl, bool isNew);

        AnimalViewModel ToAnimalViewModel(Animal animal);


        /// <summary>
        /// Convert an object of the class <see cref="PetOwnerViewModel"/> into an object of the class <see cref="PetOwner"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="profileImageUrl"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        PetOwner ToPetOwner(PetOwnerViewModel model, string profileImageUrl, bool isNew);

        /// <summary>
        /// Convert an object of the class <see cref="PetOwner"/> into an object of the class <see cref="PetOwnerViewModel"/>
        /// </summary>
        /// <param name="petOwner"></param>
        /// <returns></returns>
        PetOwnerViewModel ToPetOwnerViewModel(PetOwner petOwner);

        Veterinary ToVeterinary(VeterinaryViewModel model, string profileImageUrl, bool isNew);

        VeterinaryViewModel ToVeterinaryViewModel(Veterinary veterinary);

        Employee ToEmployee(EmployeeViewModel model, string profileImageUrl, bool isNew);

        EmployeeViewModel ToEmployeeViewModel(Employee employee);
    }
}
