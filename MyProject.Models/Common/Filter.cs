namespace MyProject.Models.Common
{
    /// <summary>
    /// Class parameter to map the result set from the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Filter<T>
    {
        /// <summary>
        /// HttpCode of reponse
        /// </summary>        
        public int Skip { get; set; }
        /// <summary>
        /// Any exception from the database, if this do not ocurr then it will return null
        /// </summary>
        public int Limit { get; set; }

        public string SortProperty { get; set; }

        public string TypeSort { get; set; }

        public string Search { get; set; }

        /// <summary>
        /// Mapped data from the database
        /// </summary>
        public T Data { get; set; }

        public Filter()
        {
            Skip = 0;
            Limit = 0;
            Search = "";
        }

    }

}
