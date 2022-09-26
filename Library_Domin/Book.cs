namespace Library_Domin
{
    public class Book
    {
        public int id{ get; set; }

        public string name { get; set; }

        public string auther { get; set; }

        public double price { get; set; }

        public int copies { get; set; }

        public bool isDeleted { get; set; } = false;
    }
}