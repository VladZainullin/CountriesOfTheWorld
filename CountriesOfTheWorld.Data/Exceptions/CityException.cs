using System.Runtime.Serialization;

namespace CountriesOfTheWorld.Data.Exceptions
{
    [Serializable]
    public class CityException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CityException()
        {
        }

        public CityException(string message) : base(message)
        {
        }

        public CityException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}