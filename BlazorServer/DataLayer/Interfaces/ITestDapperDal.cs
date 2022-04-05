using DataLayer.Dtos;

namespace DataLayer.Interfaces
{
    public interface ITestDapperDal
    {

        public List<TestDto> GetAllTestData();
        
    }

}