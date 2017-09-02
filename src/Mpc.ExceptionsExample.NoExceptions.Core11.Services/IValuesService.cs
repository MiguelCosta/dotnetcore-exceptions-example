using System.Collections.Generic;

namespace Mpc.ExceptionsExample.NoExceptions.Core11.Services
{
    public interface IValuesService
    {
        ServiceResult<int> ProcessValues(IEnumerable<int> values);
    }
}
