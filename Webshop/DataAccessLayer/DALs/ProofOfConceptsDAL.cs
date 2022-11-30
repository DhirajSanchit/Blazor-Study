using System.Data.SqlClient;
using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAccessLayer.DALs;

public class ProofOfConceptsDAL : IProofOfConceptsDAL
{
    
    private readonly IDataAccess dataAccess;

    public ProofOfConceptsDAL(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public List<SampleDto> getSampleData()
    {
        try
        {
            return dataAccess.Query<SampleDto, dynamic>("SELECT * FROM Test", new { });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public SampleDto? getSampleDataById(int id)
    {
        try
        {
            return dataAccess.QueryFirstOrDefault<SampleDto, dynamic>("SELECT * FROM Test WHERE Id = @Id",
                new { Id = id });
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public List<SampleDto> GetAllSamples()
    {
        try
        {
            return dataAccess.Query<SampleDto, dynamic>("SELECT * FROM [Test]", new { });
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}