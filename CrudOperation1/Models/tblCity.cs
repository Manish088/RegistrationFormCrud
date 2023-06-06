namespace CrudOperation1.Models
{
    public class tblCity
    {
        public int CityId { get; set; }
        public tblState ReCStateId { get; set; }
        public string CityName { get; set; }
    }
}
