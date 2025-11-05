namespace DotNet8.WebApi.Entities
{
    public class TreeImage
    {
        public int Id { get; set; }
        public string ImageBase64 { get; set; } = string.Empty;
        public int TreeId { get; set; }
    }
}
