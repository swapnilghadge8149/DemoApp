// -----------------------------------------------------------------------
//  <copyright file="TestListViewModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.Models;
using DemoApp.Views;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Input;

namespace DemoApp.ViewModels
{
    internal class TestListViewModel : BaseViewModel
    {
        private List<TestList> testList;

        /// <summary>
        /// Gets or sets TestList
        /// </summary>
        public List<TestList> TestList
        {
            get => testList;
            set{ SetProperty(ref testList, value);}
        }

        /// <summary>
        /// Test List Tap Command
        /// </summary>
        public ICommand TestListTapCommand
        {
            protected set;
            get;
        }

        /// <summary>
        /// TestListViewModel Constructor
        /// </summary>
        public TestListViewModel()
        {
            ShowTestList();
            TestListTapCommand = new Command(OnTestListTapped);
        }

        /// <summary>
        /// Parse local json file and show list of tests
        /// </summary>
        private void ShowTestList()
        {
            string jsonFileName = "TestList.json";
            var assembly = typeof(AppShell).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();
            var testData = JsonConvert.DeserializeObject<TestListModel>(jsonString);
            TestList = testData.testListResponse.testList;
        }

        /// <summary>
        /// Handle TestList Tapped event
        /// </summary>
        /// <param name="obj"></param>
        private async void OnTestListTapped(object obj)
        {
            var testItem = obj as TestList;
            await Shell.Current.Navigation.PushAsync(new QuestionsPage());
        }
    }
}
