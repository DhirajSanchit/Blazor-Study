using System.Data.SqlClient;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;

namespace BusinessLogicLayer.Containers;

public class ProofOfConceptsContainer : IProofOfConceptsContainer
{
    private IProofOfConceptsDAL _dal;

    public ProofOfConceptsContainer(IProofOfConceptsDAL dal)
    {
        _dal = dal;
    }

    /// <summary>
    /// Ignore methods and usages below, they are just for testing purposes. Not part of the actual code.
    /// No need to review them, Questions will be ignored. They will be moved tot their own class, interface and DAL. 
    /// </summary>
    public SampleModel? GetSampleDtoById(int id)
    {
        SampleModel sampleData;
        try
        {
            sampleData = new SampleModel(_dal.getSampleDataById(id));
        }
        catch (NullReferenceException exception)
        {
            Console.WriteLine(exception.Message);
            return sampleData = null;
        }
        catch (SqlException exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }

        return sampleData;
    }

    public List<SampleModel> GetAllSamples()
    {
        var sampleData = new List<SampleModel>();
        try
        {
            var dataset = _dal.GetAllSamples();
            foreach (var row in dataset)
            {
                sampleData.Add(new SampleModel(row));
            }

            return sampleData;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }


    public List<SampleModel> GetAllSampleDto()
    {
        List<SampleModel> sampleData = new List<SampleModel>();
        try
        {
            var dataset = _dal.GetAllSamples();
            foreach (var row in dataset)
            {
                sampleData.Add(new SampleModel(row));
            }

            return sampleData;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}