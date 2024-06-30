namespace appCRUD.Models
{
    public class employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Mail { get; set; }

        public DateOnly Hiring { get; set; }

        public bool IsActive { get; set; }
    }
}
