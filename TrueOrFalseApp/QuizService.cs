using System.Collections.Generic;

namespace TrueOrFalseApp
{
    class QuizService
    {
        public string QuizName = "Phone Addiction Quiz";
        public List<QuizQuestion> Questions { private set; get; }

        public QuizService()
        {
            CreateQuestions();
        }
        private QuizQuestion CreateQuestion(int id, string question, Choice one, Choice two)
        {
            QuizQuestion quizQuestion = new QuizQuestion();
            quizQuestion.Id = id;
            quizQuestion.Question = question;
            quizQuestion.SetChoices(one, two);
            return quizQuestion;
        }
        private void CreateQuestions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            questions.Add(CreateQuestion(0, "Are you taking this quiz on your phone?",
                                         new Choice("Yes.", 1),
                                         new Choice("No.", 0)));
            questions.Add(CreateQuestion(1, "Do you keep your phone in arm's reach when you sleep?",
                                         new Choice("Yes.", 1),
                                         new Choice("No.", 0)));
            questions.Add(CreateQuestion(2, "Do you use your phone to check the time?",
                                         new Choice("Yes.", 1),
                                         new Choice("No.", 0)));
            questions.Add(CreateQuestion(3, "Have you ever checked your phone for the time and then gotten distracted and then forgotten what time is was, and so you had to check again?",
                                         new Choice("Yes.", 1),
                                         new Choice("No.", 0)));
            questions.Add(CreateQuestion(4, "Is your phone the first option source of entertainment when you're waiting for something in public?",
                                         new Choice("Yes.", 1),
                                         new Choice("No.", 0)));
            Questions = questions;
        }
    }
}