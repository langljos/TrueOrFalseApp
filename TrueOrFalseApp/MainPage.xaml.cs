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
        private QuizService _quizService;
        private List<QuizQuestion> _questionList;
        private QuizQuestion _quizQuestion;
        private double _totalScore = 0;

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
        private void CompleteQuiz()
        {
            DetermineResults();

            trueButton.IsVisible = false;
            falseButton.IsVisible = false;
            startButton.IsVisible = true;
            Grid.SetRow(startButton, 1);
            startButton.Text = "Retake Quiz?";
        }
        private void StartQuiz(object sender, EventArgs args)
        {
            endResults.Text = "";
            endResults.IsVisible = false;
            _totalScore = 0;
            _quizQuestion = _questionList[0];
            SetBindingContext();

            trueButton.IsVisible = true;
            falseButton.IsVisible = true;
            questionArea.IsVisible = true;
            startButton.IsVisible = false;
        }
        private void ResponsePressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            CalculateScore(button);
            CheckNextQuestion();
        }

        private void SetBindingContext()
        {
            BindingContext = _questionList[_quizQuestion.Id];
        }

        private void AdvanceToNextItem()
        {
            _quizQuestion = _questionList[_quizQuestion.Id + 1];
            SetBindingContext();
        }

        private void CalculateScore(Button button)
        {
            if (button.StyleId == "trueButton")
            {
                _totalScore = _totalScore + _questionList[_quizQuestion.Id].Choices[0].Value;
            }
            else
            {
                _totalScore = _totalScore + _questionList[_quizQuestion.Id].Choices[1].Value;
            }
        }

        private void CheckNextQuestion()
        {
            if (_quizQuestion.Id < 4)
            {
                AdvanceToNextItem();
            } 
            else
            {
                CompleteQuiz();
            }
        }

        private void DetermineResults()
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
            questionArea.IsVisible = false;
            endResults.IsVisible = true;
            endResults.Text = $"Your score was {_totalScore} out of 5.\n{result}";
        }


        
    }
}
