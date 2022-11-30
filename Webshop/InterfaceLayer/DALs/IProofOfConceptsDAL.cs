using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IProofOfConceptsDAL
{
    //Implementations below are used for Proof of Concept purposes only
    SampleDto? getSampleDataById(int id);

    public List<SampleDto> GetAllSamples();
}