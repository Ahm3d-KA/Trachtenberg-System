namespace Trachtenberg_System.Models;

public class PractiseModel
{
    public OperationsEnum Operation { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public PractiseEnum Length { get; set; }
    public CustomPractiseStruct CustomPractise { get; set; }
}