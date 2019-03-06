using LibraryManager.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryManager.Test
{
    public class BaseTest
    {
        protected HttpRequestHandler httpRequestHandler;
        protected LibraryManagerSettings libraryManagerSettings;
        protected BookClient bookClient;

        [OneTimeSetUp]
        public void TestSetUp()
        {
            httpRequestHandler = new HttpRequestHandler();
            libraryManagerSettings = new LibraryManagerSettings();
            bookClient = new BookClient();
        }
    }
}
