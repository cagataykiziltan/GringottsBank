using System.Collections.Generic;

namespace GringottsBank.Infrastructure.Http
{
    /// <summary>
    ///     Abstract class for all response objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponseObject<T> : HttpObject<T>
        where T : class
    {
        public int Size { get; set; } = 0;
        public int Status { get; set; } = 200;
        public string Message { get; set; } = "OK";

        /// <summary>
        ///     Empty constructor
        /// </summary>
        public HttpResponseObject()
        {
        }
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="item"></param>
        public HttpResponseObject(T item)
            : base(item)
        {
            Size = 1;
        }
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="items"></param>
        public HttpResponseObject(IEnumerable<T> items)
            : base(items)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsOK()
        {
            return 200 == Status;
        }
    }
}
