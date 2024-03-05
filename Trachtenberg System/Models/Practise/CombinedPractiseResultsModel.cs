using System.Text.Json;

namespace Trachtenberg_System.Models;

// combines practise model and results model so I can send them both to the session page to be used
public class CombinedPractiseResultsModel
{
    public string Practise { get; set; }
    public ResultsModel ResultObj { get; set; }
}