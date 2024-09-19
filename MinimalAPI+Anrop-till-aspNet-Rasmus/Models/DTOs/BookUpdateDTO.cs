namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs
{
    public class BookUpdateDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Publiced { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
    }
}
