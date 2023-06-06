namespace CrudOperation1.Models
{
    public class TblUserRegistration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        /*public tblState RefStateId { get; set; }
        public tblCity RefCityId { get; set; }*/
    }
}
