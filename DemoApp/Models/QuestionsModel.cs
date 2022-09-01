// -----------------------------------------------------------------------
//  <copyright file="QuestionsModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DemoApp.Models
{
    public class QuestionsModel
    {
        /// <summary>
        /// Gets or sets TestId
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// Gets or sets QuesId
        /// </summary>
        public int QuesId { get; set; }

        /// <summary>
        /// Gets or sets Ques
        /// </summary>
        public string Ques { get; set; }

        /// <summary>
        /// Gets or sets Option1
        /// </summary>
        public string Option1 { get; set; }

        /// <summary>
        /// Gets or sets Option2
        /// </summary>
        public string Option2 { get; set; }

        /// <summary>
        /// Gets or sets Option3
        /// </summary>
        public string Option3 { get; set; }

        /// <summary>
        /// Gets or sets Option4
        /// </summary>
        public string Option4 { get; set; }

        /// <summary>
        /// Gets or sets CorrectAns
        /// </summary>
        public string CorrectAns { get; set; }
    }
}
