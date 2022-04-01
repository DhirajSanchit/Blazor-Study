using DataLayer.Dtos;

namespace DataLayer.Interfaces
{
    public interface ITestDal
    {

        public IList<TestDto> GetAllTestData();
        
    }

}