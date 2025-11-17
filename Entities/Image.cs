namespace DotNet8.WebApi.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int TreeId { get; set; }
        public string FileName { get; set; } = string.Empty;    
        public string ContentType { get; set; } = string.Empty;
        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}
