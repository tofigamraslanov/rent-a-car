namespace Application.Features.Models.Dtos;

public class ModelListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string BrandName { get; set; } = null!;
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; } = null!;
}