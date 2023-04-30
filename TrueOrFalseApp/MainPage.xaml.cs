using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrueOrFalseApp
{
    public partial class MainPage : ContentPage
    {
        private  QuizService _quizService;
        private List<QuizQuestion> _questionList;
        private QuizQuestion _quizQuestion;
        private double _totalScore = 0;
        private Choice _choiceYes;
        private Choice _choiceNo;

        public MainPage()
        {
            InitializeComponent();
            InitializeQuiz();
        }

        public void InitializeQuiz()
        {
            _quizService = new QuizService();
            quizName.Text = _quizService.QuizName;
            _questionList = _quizService.Questions;
        }

        private void StartQuiz(object sender, EventArgs args)
        {
            _totalScore = 0;
            _quizQuestion = _questionList[0];
            // startButton.Text = "Start Quiz.";  useless at the moment
            trueButton.IsVisible = true;
            falseButton.IsVisible = true;
            questionArea.IsVisible = true;
            //imageSpot.IsVisible = true;
            startButton.IsVisible = false;
            MakeQuestion();
        }
        private void ResponsePressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.StyleId == "trueButton")
            {
                _totalScore = _totalScore + _choiceYes.Value;
            }
            else
            {
                _totalScore = _totalScore + _choiceNo.Value;
            }

            _quizQuestion = _questionList[_quizQuestion.Id + 1];

            CheckNextQuestion();
        }

        private void CheckNextQuestion()
        {
            if (_quizQuestion.Id < 4)
            {
                MakeQuestion();
            }
            else
            {
                CompleteQuiz();
            }
        }
        private void MakeQuestion()
        {
            var question = _questionList[_quizQuestion.Id];
            // var id = question.Id; useless at the moment
            var text = question.Question;
            _choiceYes = question.Choices[0];
            _choiceNo = question.Choices[1];

            questionArea.Text = text;
            trueButton.Text = _choiceYes.Option;
            falseButton.Text = _choiceNo.Option;
        }

        private void CompleteQuiz()
        {
            string result;
            if (_totalScore > 3)
            {
                result = "You may be addicted to your phone.";
            }
            else
            {
                result = "You are probably not addicted to your phone.";
            }


            questionArea.Text = $"Your score was {_totalScore} out of 5.\n{result}";

            trueButton.IsVisible = false;
            falseButton.IsVisible = false;
            startButton.IsVisible = true;
            Grid.SetRow(startButton, 1);
            startButton.Text = "Retake Quiz?";
        }
    }
}
