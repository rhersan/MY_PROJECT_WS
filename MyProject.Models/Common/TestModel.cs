using System.Collections.Generic;

namespace MyProject.Models.Common
{
    /// <summary>
    /// Model for the test service endpoint
    /// </summary>
    public class TestModel
    {
        /// <summary>
        /// number of active billable accounts/users
        /// </summary>
        public int Active { get; set; }
        /// <summary>
        /// detail of each active billable account/user
        /// </summary>
        public List<TestDetail> Details { get; set; }
    }
    /// <summary>
    /// detail for each active billable account/user
    /// </summary>
    public class TestDetail
    {
        /// <summary>
        /// record Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name of record
        /// </summary>
        public string Name { get; set; }
    }
}
