namespace ProductClientHub_Communication.Response;

public class ResponseClientJson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<ResponseShortProductJson> Products { get; set; } = [];
}
