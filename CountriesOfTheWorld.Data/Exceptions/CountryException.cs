using System.Runtime.Serialization;

namespace CountriesOfTheWorld.Data.Exceptions
{
    [Serializable]
    public class CountryException : Exception
    {
        public CountryException()
        {
        }

        public CountryException(string message) : base(message)
        {
        }

        public CountryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CountryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}