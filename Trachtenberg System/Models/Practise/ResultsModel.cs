using Trachtenberg_System.Models.Practise;

namespace Trachtenberg_System.Models;

// stores user results from the test
public class ResultsModel
{
    public int Result { get; set; }
    public int NumberOfQuestions { get; set; }
    public LengthEnum TestLength { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public int TimeTaken { get; set; }
    public int StandardisedScore { get; set; }
    public double Accuracy { get; set; }
    public bool HighScore { get; set; }
    public List<QuestionsWrongStruct> QuestionsWrong { get; set; }
    // public string UserId { get; set; }
}