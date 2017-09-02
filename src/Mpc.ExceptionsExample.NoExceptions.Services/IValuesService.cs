using System.Collections.Generic;

namespace Mpc.ExceptionsExample.NoExceptions.Services
{
    public interface IValuesService
    {
        ServiceResult<int> ProcessValues(IEnumerable<int> values);
    }
}
