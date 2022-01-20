
using System.Collections.Generic;


namespace GringottsBank.Infrastructure.Http
{
    /// <summary>
    ///     Abstract class for request objects 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpRequestObject<T> : HttpObject<T>
        where T : class
    {
        /// <summary>
        ///     Empty constructor
        /// </summary>
        public HttpRequestObject()
        {
        }
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="item"></param>
        public HttpRequestObject(T item)
            : base(item)
        {
        }
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="items"></param>
        public HttpRequestObject(IEnumerable<T> items)
            : base(items)
        {
        }
    }
}
