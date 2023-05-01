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

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Right || e.Direction == SwipeDirection.Left)
            {
                CalculateScoreSwipe(e.Direction.ToString());
                CheckNextQuestion();
            }
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

            imageSpot.IsVisible = false;
            trueButton.IsVisible = false;
            falseButton.IsVisible = false;
            startButton.IsVisible = true;
            Grid.SetRow(startButton, 1);
            startButton.Text = "Retake Quiz?";
            swipeContainer.IsEnabled = false;
        }
        private void StartQuiz(object sender, EventArgs args)
        {
            startButton.IsVisible = false;
            endResults.Text = "";
            endResults.IsVisible = false;
            _totalScore = 0;
            _quizQuestion = _questionList[0];
            SetBindingContext();

            imageSpot.IsVisible = true;
            trueButton.IsVisible = true;
            falseButton.IsVisible = true;
            questionArea.IsVisible = true;
            
            swipeContainer.IsEnabled = true;
        }
        private void ResponsePressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            CalculateScoreButton(button);
            CheckNextQuestion();
        }

        private void SetBindingContext()
        {
            BindingContext = _questionList[_quizQuestion.Id];
            Console.WriteLine(_quizQuestion.Image);
        }

        private void AdvanceToNextItem()
        {
            _quizQuestion = _questionList[_quizQuestion.Id + 1];
            SetBindingContext();
        }

        private void CalculateScoreButton(Button button)
        {
            if (button != null)
            {
                if (button.StyleId == "trueButton")
                {
                    _totalScore = _totalScore + _questionList[_quizQuestion.Id].Choices[0].Value;
                }
                else if (button.StyleId == "falseButton")
                {
                    _totalScore = _totalScore + _questionList[_quizQuestion.Id].Choices[1].Value;
                }
            }
              
        }

        private void CalculateScoreSwipe(string direction)
        {
            if (direction == "Right")
            {
                _totalScore = _totalScore + _questionList[_quizQuestion.Id].Choices[0].Value;
            }
            else if (direction == "Left")
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

        private void falseButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
