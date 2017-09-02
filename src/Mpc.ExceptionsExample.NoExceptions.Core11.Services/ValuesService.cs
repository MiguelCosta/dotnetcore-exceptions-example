namespace Mpc.ExceptionsExample.NoExceptions.Core11.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValuesService : IValuesService
    {
        public ServiceResult<int> ProcessValues(IEnumerable<int> values)
        {
            var result = new ServiceResult<int>();

            if (values == null || !values.Any())
            {
                result.Messages.Add("Empty list");
                return result;
            }

            result.Result = values.Sum();
            return result;
        }
    }
}
