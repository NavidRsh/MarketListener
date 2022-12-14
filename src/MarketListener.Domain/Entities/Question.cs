namespace MarketListener.Domain.Entities;

using Bond.Domain.Commons;
using MarketListener.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Question : Entity<int>
{
    public string Title { get; set; } = default!; 
    public string Text { get; set; } = default!; 
    public QuestionType QuestionType { get; set; }
    public string Tag { get; set; } = default!; 

}
