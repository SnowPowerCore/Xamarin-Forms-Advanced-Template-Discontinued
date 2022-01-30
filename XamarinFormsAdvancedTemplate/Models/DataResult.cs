namespace XamarinFormsAdvancedTemplate.Models
{
    public class DataResult<T> where T : class, new()
    {
        private string DataError { get; set; }

        private int DataTotalCount { get; set; }

        public T Data { get; private set; }

        public DataResult(T data = default, int dataTotalCount = 0, string dataError = "")
        {
            Data = data;
            DataTotalCount = dataTotalCount;
            DataError = dataError;
        }

        /// <summary>
        /// Retrieves data (default, if doesn't exist) or error code, if no data
        /// </summary>
        /// <param name="data">Data to be retrieved</param>
        /// <param name="dataTotalCount">Data total count to be retrieved</param>
        /// <returns>Internal error code, used to identify what's happened if no data exists</returns>
        public string GetDataOrErrorCode(out T data, out int dataTotalCount)
        {
            data = Data;
            dataTotalCount = DataTotalCount;
            return DataError;
        }
    }
}