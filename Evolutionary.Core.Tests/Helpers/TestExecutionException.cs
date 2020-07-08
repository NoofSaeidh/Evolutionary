using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Tests.Helpers
{

    [Serializable]
    public class TestExecutionException : Exception
    {
        public TestExecutionException() : base("Error happened during test execution") { }
        public TestExecutionException(string message) : base(message) { }
        public TestExecutionException(string message, Exception inner) : base(message, inner) { }
        protected TestExecutionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class TestDataException : TestExecutionException
    {
        public TestDataException() : base("Wrong test data") { }
        public TestDataException(string message) : base(message) { }
        public TestDataException(string message, Exception inner) : base(message, inner) { }
        protected TestDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
