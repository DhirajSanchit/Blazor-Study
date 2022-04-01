using DataLayer.Dtos;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Containers
{

    public class TestDapperContainer : ITestDapperContainer
    {
        public IList<Test> Dt { get; set; }

        private  ITestDal _itd;

        public TestDapperContainer(ITestDal itd)
        {
            _itd = itd;
        }

        public IList<Test> GetAll()
        {
            Dt = new List<Test>();
            IList<TestDto> dataset = _itd.GetAllTestData();
            foreach (TestDto dto in dataset)
            {
                Dt.Add(new Test(dto));
            }

            return Dt;
        }
    }
}


 