﻿using System.Collections.Generic;

namespace GringottsBank.Infrastructure.Http
{
    /// <summary>
    ///     Abstract class for all response objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponseObjectSuccess<T> : HttpResponseObject<T>
        where T : class
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 1;

        /// <summary>
        ///     Empty constructor
        /// </summary>
        public HttpResponseObjectSuccess()
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="item"></param>
        public HttpResponseObjectSuccess(T item)
            : base(item)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="items"></param>
        public HttpResponseObjectSuccess(IEnumerable<T> items)
            : base(items)
        {
        }
    }
}
