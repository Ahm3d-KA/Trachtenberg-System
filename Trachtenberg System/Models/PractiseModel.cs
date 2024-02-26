using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Trachtenberg_System.Models;

public class PractiseModel
{
    // tells json serializer function to convert the enum to a string when it is used
    [JsonConverter(typeof(StringEnumConverter))]  
    public OperationsEnum Operation { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))]  
    public DifficultyEnum Difficulty { get; set; }
    
    public LengthEnum Length { get; set; }
    
    public CustomPractiseStruct CustomPractise { get; set; }
}