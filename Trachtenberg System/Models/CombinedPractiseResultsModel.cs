using System.Text.Json;

namespace Trachtenberg_System.Models;

public class CombinedPractiseResultsModel
{
    public string Practise { get; set; }
    public ResultsModel ResultObj { get; set; }
}