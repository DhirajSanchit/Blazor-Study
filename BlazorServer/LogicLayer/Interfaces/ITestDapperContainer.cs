using LogicLayer.Models;

namespace LogicLayer.Interfaces
{

    //TODO: TO BE REVISED
    public interface ITestDapperContainer
    {
        IList<Test> Dt { get; set; }
        public IList<Test> GetAll();
    }
}
