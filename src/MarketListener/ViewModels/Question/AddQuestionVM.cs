namespace MarketListener.ViewModels.Question;

using MarketListener.Domain.Enums;

public class AddQuestionVM
{
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }
    public int CurrentUserId { get; set; }
}
