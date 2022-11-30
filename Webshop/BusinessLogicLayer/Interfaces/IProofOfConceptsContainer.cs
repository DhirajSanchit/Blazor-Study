using BusinessLogicLayer.Classes;

namespace BusinessLogicLayer.Interfaces;

public interface IProofOfConceptsContainer
{
    List<SampleModel>? GetAllSampleDto();
    SampleModel? GetSampleDtoById(int id);

    List<SampleModel> GetAllSamples();
}