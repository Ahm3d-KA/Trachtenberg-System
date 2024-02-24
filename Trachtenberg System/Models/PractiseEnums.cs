namespace Trachtenberg_System.Models;

public enum PractiseEnum
// decides how many questions will be shown in the session
{
    Short = 5,
    Medium = 10,
    Long = 15,
    Marathon = 25
}

public enum DifficultyEnum
// this will decide the length of the numbers involved in the calculations
{
    Easy,
    Medium,
    Hard,
    Expert
}

public enum OperationsEnum
// which operations will be used in the practise session
{
    Addition,
    Multiplication,
    Subtraction,
    Division,
    Squaring,
    SquareRooting,
}