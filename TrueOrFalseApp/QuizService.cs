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
        private QuizQuestion CreateQuestion(int id, string question, string image, Choice one, Choice two)
        {
            QuizQuestion quizQuestion = new QuizQuestion();
            quizQuestion.Id = id;
            quizQuestion.Question = question;
            quizQuestion.Image = image;
            quizQuestion.SetChoices(one, two);
            return quizQuestion;
        }
        private void CreateQuestions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            questions.Add(CreateQuestion(
                0, 
                "Are you taking this quiz on your phone?",              
                "first.jpeg",                    
                new Choice("Sure am", 1),
                new Choice("No way", 0)
                ));

            questions.Add(CreateQuestion(
                1, 
                "Do you keep your phone in arm's reach when you sleep?",
                "second.jpeg",
                new Choice("Who doesn't?", 1),
                new Choice("Nope", 0)
                ));

            questions.Add(CreateQuestion(
                2, 
                "Do you use your phone to check the time?",
                "third.jpeg",  
                new Choice("All the time", 1),
                new Choice("Never", 0)
                ));

            questions.Add(CreateQuestion(
                3, 
                "Have you ever gotten distracted whilst checking your phone?",
                "fourth.jpeg",   
                new Choice("Who hasn't?", 1),  
                new Choice("What's that?", 0)
                ));

            questions.Add(CreateQuestion(
                4, 
                "Is your phone the first option source of entertainment when you're waiting for something in public?",
                "fifth.jpeg",                   
                new Choice("Always", 1),                  
                new Choice("Boring!", 0)
                ));

            Questions = questions;
        }
    }
}