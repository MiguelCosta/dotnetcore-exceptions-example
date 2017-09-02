namespace Mpc.ExceptionsExample.WithExceptions.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ValuesService : IValuesService
    {
        public int ProcessValues(IEnumerable<int> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentException("Empty list", nameof(values));
            }

            var result = values.Sum();

            return result;
        }
    }
}
