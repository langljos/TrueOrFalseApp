using System.Collections.Generic;

namespace TrueOrFalseApp
{
    class QuizQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Image { get; set; }
        public List<Choice> Choices { get; private set; }
        public static List<QuizQuestion> Questions { private set; get; }
        public void SetChoices(Choice firstchoice, Choice secondChoice)
        {
            List<Choice> choices = new List<Choice>();
            choices.Add(firstchoice);
            choices.Add(secondChoice);
            Choices = choices;
        }
    }
}