// -----------------------------------------------------------------------
//  <copyright file="TestListModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DemoApp.Models
{
    public class TestListModel
    {
        /// <summary>
        /// Gets or sets testListResponse
        /// </summary>
        public TestListResponse testListResponse { get; set; }
    }

    public class TestList
    {
        /// <summary>
        /// Gets or sets test_id
        /// </summary>
        public string test_id { get; set; }

        /// <summary>
        /// Gets or sets test_name
        /// </summary>
        public string test_name { get; set; }
    }

    public class TestListResponse
    {
        /// <summary>
        /// Gets or sets status_code
        /// </summary>
        public string status_code { get; set; }

        /// <summary>
        /// Gets or sets testList
        /// </summary>
        public List<TestList> testList { get; set; }
    }
}
