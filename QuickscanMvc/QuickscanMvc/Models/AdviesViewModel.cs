namespace QuickscanMvc.Models
{
    public class AdviesViewModel
    {
        public int AdviesId { get; set; }
        public double AdviesScore { get; set; }
        public DateTime Datum { get; set; }
        public string Opmerking { get; set; }
        public double UitstralingScore { get; set; }
        public double BouwkundigestaatScore { get; set; }
        public double VeiligheidScore { get; set; }
        public double EnergieVerbruikScore { get; set; }
        public double OnderwijskundigeStaatScore { get; set; }
    }
}
