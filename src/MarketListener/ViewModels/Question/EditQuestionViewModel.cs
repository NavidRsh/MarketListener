using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketListener.ViewModels.Question
{
    public class EditQuestionViewModel
    {
        public QuestionInfo Question { get; set; }
        public IEnumerable<TagInfo> Tags { get; set; }
        public SelectList AllTags { get; set; }
    }

    public class QuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Text { get; set; } = default!;
        public QuestionType QuestionType { get; set; }
        public List<string> Tags { get; set; } = default!;
        public bool IsTimeLimited { get; set; }
        public int TimeLimitSeconds { get; set; }
        public int CurrentUserId { get; set; }
    }

    public class TagInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersianName { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
