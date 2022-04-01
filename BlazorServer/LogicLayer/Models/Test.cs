using DataLayer.Dtos;

namespace LogicLayer.Models
{
    public class Test
    {
        public int Id { get; set;}
        public string Value { get; set; }

        public Test(TestDto dto)
        {
            Id = dto.id;
            Value = dto.value;
        }
        

        public Test(int id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}