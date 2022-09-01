// -----------------------------------------------------------------------
//  <copyright file="QuestionsViewModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.CustomControls;
using DemoApp.Models;
using DemoApp.Views;
using System.Windows.Input;
using Timer = System.Threading.Timer;

namespace DemoApp.ViewModels
{
    internal class QuestionsViewModel : BaseViewModel
    {
        private int sec = 30000; // half minutes
        private int period = 1000; //every 1 seconds
        private TimerCallback timerDelegate;
        private Timer _dispatcherTimer;
        private int correctCnt = 0, wrongCnt = 0;
        private const string correctAnsBtnColor = "#8db600";
        private const string wrongAnsBtnColor = "#e53733";
        private const string normalBtnColor = "#ed872d";
        private const string correctImg = "correct.png";
        private const string wrongImg = "wrong.png";
        private const string nextImg = "next.png";

        /// <summary>
        /// Gets or sets TestId
        /// </summary>
        private int testId;
        public int TestId
        {
            get { return testId; }
            set { SetProperty(ref testId, value); }
        }

        /// <summary>
        /// Gets or sets Question
        /// </summary>
        private string question;
        public string Question {
            get { return question; }
            set { SetProperty(ref question, value); }
        }

        /// <summary>
        /// Gets or sets Opt1
        /// </summary>
        private string opt1;
        public string Opt1 {
            get { return opt1; }
            set { SetProperty(ref opt1, value); }
        }

        /// <summary>
        /// Gets or sets Opt2
        /// </summary>
        private string opt2;
        public string Opt2
        {
            get { return opt2; }
            set { SetProperty(ref opt2, value); }
        }

        /// <summary>
        /// Gets or sets Opt3
        /// </summary>
        private string opt3;
        public string Opt3
        {
            get { return opt3; }
            set { SetProperty(ref opt3, value); }
        }

        /// <summary>
        /// Gets or sets Opt4
        /// </summary>
        private string opt4;
        public string Opt4
        {
            get { return opt4; }
            set { SetProperty(ref opt4, value); }
        }

        /// <summary>
        /// Gets or sets CorrectAns
        /// </summary>
        private string correctAns;
        public string CorrectAns
        {
            get { return correctAns; }
            set { SetProperty(ref correctAns, value); }
        }

        /// <summary>
        /// Gets or sets FrameBgColor
        /// </summary>
        private string frameBgColor;
        public string FrameBgColor
        {
            get { return frameBgColor; }
            set { SetProperty(ref frameBgColor, value); }
        }

        /// <summary>
        /// Gets or sets SelectedBtn
        /// </summary>
        private CustomImageButton selectedBtn;
        public CustomImageButton SelectedBtn
        {
            get { return selectedBtn; }
            set { SetProperty(ref selectedBtn, value); }
        }

        /// <summary>
        /// Gets or sets IsOptionSelectEnabled
        /// </summary>
        private bool isOptionSelectEnabled;
        public bool IsOptionSelectEnabled
        {
            get { return isOptionSelectEnabled; }
            set { SetProperty(ref isOptionSelectEnabled, value); }
        }

        /// <summary>
        /// Gets or sets QuesCnt
        /// </summary>
        private int quesCnt;
        public int QuesCnt
        {
            get { return quesCnt; }
            set { SetProperty(ref quesCnt, value); }
        }

        /// <summary>
        /// Gets Pos
        /// </summary>
        public int Pos
        {
            get { return quesCnt-1; }
        }

        /// <summary>
        /// Gets or sets CorrectCnt
        /// </summary>
        public int CorrectCnt
        {
            get { return correctCnt; }
            set { SetProperty(ref correctCnt, value); }
        }

        /// <summary>
        /// Gets or sets WrongCnt
        /// </summary>
        public int WrongCnt
        {
            get { return wrongCnt; }
            set { SetProperty(ref wrongCnt, value); }
        }

        /// <summary>
        /// Gets or sets QuesTime
        /// </summary>
        private int quesTime;
        public int QuesTime
        {
            get { return quesTime/1000; }
            set { SetProperty(ref quesTime, value); }
        }

        /// <summary>
        /// Option Selected command
        /// </summary>
        public ICommand OptionSelectedCommand { get; }

        /// <summary>
        /// Quit Button Clicked command
        /// </summary>
        public ICommand QuitBtnClickedCommand { get; }

        /// <summary>
        /// Next Button Clicked command
        /// </summary>
        public ICommand NextBtnClickedCommand { get; }

        /// <summary>
        /// Temporary List of questions for demo
        /// </summary>
        private List<QuestionsModel> questionsList = new()
        {
          new QuestionsModel
          {   
              TestId=1, 
              QuesId=1, 
              Ques="Which of the following option leads to the portability and security of Java?",
              Option1 = "Bytecode is executed by JVM",
              Option2 = "The applet makes the Java code secure and portable",
              Option3 = "Use of exception handling",
              Option4 = "Dynamic binding between objects",
              CorrectAns = "Bytecode is executed by the JVM"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=2,
              Ques="Which of the following is not a Java features?",
              Option1 = "Architecture Neutral",
              Option2 = "Object-oriented",
              Option3 = "Dynamic",
              Option4 = "Use of pointers",
              CorrectAns = "Use of pointers"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=3,
              Ques="The \u0021 article referred to as a",
              Option1 = "Unicode escape sequence",
              Option2 = "Octal escape",
              Option3 = "Hexadecimal",
              Option4 = "Line feed",
              CorrectAns = "Unicode escape sequence"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=4,
              Ques="Multiple inheritance means,",
              Option1 = "one class inheriting from more super classes",
              Option2 = "more classes inheriting from one super class",
              Option3 = "more classes inheriting from more super classes",
              Option4 = "None of the above",
              CorrectAns = "one class inheriting from more super classes"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=4,
              Ques="Which statement is not true in java language?",
              Option1 = "A public member of a class can be accessed in all the packages",
              Option2 = "A private member of a class cannot be accessed by the methods of the same class",
              Option3 = "A private member of a class cannot be accessed from its derived class",
              Option4 = "A protected member of a class can be accessed from its derived class",
              CorrectAns = "A private member of a class cannot be accessed by the methods of the same class"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=5,
              Ques=" _____ is used to find and fix bugs in the Java programs.",
              Option1 = "JVM",
              Option2 = "JRE",
              Option3 = "JDK",
              Option4 = "JDB",
              CorrectAns = "JDB"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=6,
              Ques="Which of the following is a valid declaration of a char?",
              Option1 = "char ch = '\\utea';",
              Option2 = "char ca = 'tea';",
              Option3 = "char cr = \u0223;",
              Option4 = "char cc = '\\itea';",
              CorrectAns = "char ch = '\\utea';"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=7,
              Ques="What is the return type of the hashCode() method in the Object class?",
              Option1 = "Object",
              Option2 = "int",
              Option3 = "long",
              Option4 = "void",
              CorrectAns = "int"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=8,
              Ques="Which of the following is a valid long literal?",
              Option1 = "ABH8097",
              Option2 = "L990023",
              Option3 = "904423",
              Option4 = "0xnf029L",
              CorrectAns = "0xnf029L"
          },
          new QuestionsModel
          {
              TestId=1,
              QuesId=9,
              Ques="What does the expression float a = 35 / 0 return?",
              Option1 = "0",
              Option2 = "Not a Number",
              Option3 = "Infinity",
              Option4 = "Run time exception",
              CorrectAns = "Infinity"
          }

        };

        /// <summary>
        /// QuestionsViewModel Constructor
        /// </summary>
        public QuestionsViewModel()
        {
            ShuffleQuestions();
            OnNextBtnClicked();
            IsOptionSelectEnabled = true;
            OptionSelectedCommand = new Command(OnOptionClicked);
            NextBtnClickedCommand = new Command(OnNextBtnClicked);
            QuitBtnClickedCommand = new Command(OnQuitBtnClicked);
            FrameBgColor = normalBtnColor;
        }

        /// <summary>
        /// Set Question Answers
        /// </summary>
        /// <param name="pos">Position</param>
        private void SetQuesAnswer(int pos)
        {         
            QuestionsModel questionsModel = questionsList[pos];
            TestId = questionsModel.TestId;
            Question = questionsModel.Ques;
            CorrectAns = questionsModel.CorrectAns;
            Opt1 = questionsModel.Option1;
            Opt2 = questionsModel.Option2;
            Opt3 = questionsModel.Option3;
            Opt4 = questionsModel.Option4;
        }

        /// <summary>
        /// Gets fired when user clicked on option
        /// </summary>
        /// <param name="obj"></param>
        private void OnOptionClicked(object obj)
        {
            if (IsOptionSelectEnabled)
            {
                var OptBtn = obj as CustomImageButton;
                selectedBtn = OptBtn;
                IsOptionSelectEnabled = false;
                ChangeButtonColor(OptBtn);
            }
        }

        /// <summary>
        /// Gets fired when user click on next button
        /// </summary>
        private async void OnNextBtnClicked()
        {
            sec = 30000;
            QuesTime = sec;
            _dispatcherTimer?.Dispose();
            _dispatcherTimer = null;
            timerDelegate = null;
            IsOptionSelectEnabled = true;
            QuesCnt++;
            if (QuesCnt <= questionsList.Count)
            {
                SetQuesAnswer(Pos);
                timerDelegate = new TimerCallback(Tick);
                _dispatcherTimer = new Timer(timerDelegate, null, period, period);
                if (selectedBtn != null)
                {
                    selectedBtn.FrameBackgroundColor = normalBtnColor;
                    selectedBtn.LeftImage = nextImg;
                }
            }
            else
            {
                QuesCnt = 0;
                await Shell.Current.Navigation.PushModalAsync(new ShowTestScorePage(CorrectCnt));
            }
        }

        /// <summary>
        /// Gets fired when user clicks on quit button
        /// </summary>
        private async void OnQuitBtnClicked()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        /// <summary>
        /// Change button color
        /// </summary>
        /// <param name="customImageButton">custom button</param>
        private void ChangeButtonColor(CustomImageButton customImageButton)
        {
            var selectedOption = customImageButton.Text;
            if (selectedOption.Equals(CorrectAns))
            {
                CorrectCnt++;
                customImageButton.FrameBackgroundColor = correctAnsBtnColor;
                customImageButton.LeftImage = correctImg;
            }
            else
            {
                WrongCnt++;
                customImageButton.FrameBackgroundColor = wrongAnsBtnColor;
                customImageButton.LeftImage = wrongImg;
            }
        }

        /// <summary>
        /// Shuffle questions
        /// </summary>
        private void ShuffleQuestions()
        {
            var rnd = new Random();
            questionsList = questionsList.OrderBy(item => rnd.Next()).ToList();
        }

        /// <summary>
        /// Timer tick after certain time
        /// </summary>
        /// <param name="state"></param>
        private void Tick(object state)
        {
            Application.Current?.Dispatcher.Dispatch(() =>
            {
                sec -= period;
                QuesTime = sec;
                if (sec < 0)
                {
                    _dispatcherTimer?.DisposeAsync();
                    _dispatcherTimer = null;
                    OnNextBtnClicked();
                    return;
                }
            });
        }
    }
}
