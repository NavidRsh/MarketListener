namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Answer : Entity<int>
{
    public string Text { get; set; } = default!;
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public bool IsRightAnswer { get; set; }
    public int Order { get; set; }
}
