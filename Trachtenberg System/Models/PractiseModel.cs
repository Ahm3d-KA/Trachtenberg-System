namespace Trachtenberg_System.Models;

public class PractiseModel
{
    public OperationsEnum Operation { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public LengthEnum Length { get; set; }
    public CustomPractiseStruct CustomPractise { get; set; }
}