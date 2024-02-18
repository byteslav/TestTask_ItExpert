namespace TestTask.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(int code, string value)
        {
            Code = code;
            Value = value;
        }

        public int Code { get; set; }
        public string Value { get; set; }
    }
}
