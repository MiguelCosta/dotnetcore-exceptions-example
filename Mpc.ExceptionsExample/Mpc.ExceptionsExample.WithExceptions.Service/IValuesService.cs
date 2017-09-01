namespace Mpc.ExceptionsExample.WithExceptions.Service
{
    using System.Collections.Generic;

    public interface IValuesService
    {
        int ProcessValues(IEnumerable<int> values);
    }
}
