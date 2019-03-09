using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public sealed class GetBookStepDefinition
    {
        [StepDefinition(@"book is requested (.*)")]
        public void GivenBookIsRequested(int id)
        {
            BaseHook.result = BaseHook.bookClient.GetBook(id);
        }
    }
}
