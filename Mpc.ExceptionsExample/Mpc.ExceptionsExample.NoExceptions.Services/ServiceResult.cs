namespace Mpc.ExceptionsExample.NoExceptions.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceResult<T>
    {
        public IList<string> Messages { get; set; } = new List<string>();

        public T Result { get; set; }

        public bool Success
        {
            get
            {
                return !Messages.Any();
            }
        }
    }
}
