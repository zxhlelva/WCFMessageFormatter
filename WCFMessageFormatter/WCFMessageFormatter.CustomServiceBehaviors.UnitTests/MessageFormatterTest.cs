using WCFMessageFormatter.CustomServiceBehaviors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WCFMessageFormatter.Contracts.DataContracts;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace WCFMessageFormatter.CustomServiceBehaviors.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for MessageFormatterTest and is intended
    ///to contain all MessageFormatterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageFormatterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SerializeReply
        ///</summary>
        [TestMethod()]
        public void SerializeReplyTest()
        {
            Organizitions organizitions = new Organizitions()
            {
                ReponseLink = "http://test",
                Organizition = new List<string>()
                {
                    "Organizition1",
                    "Organizition2"
                }
            };
            MessageFormatter target = new MessageFormatter(); // TODO: Initialize to an appropriate value
            MessageVersion messageVersion = null; // TODO: Initialize to an appropriate value
            object[] parameters = null; // TODO: Initialize to an appropriate value
            object result = organizitions; // TODO: Initialize to an appropriate value
            Message expected = null; // TODO: Initialize to an appropriate value
            Message actual;
            actual = target.SerializeReply(messageVersion, parameters, result);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ApplyDispatchBehavior
        ///</summary>
        [TestMethod()]
        public void ApplyDispatchBehaviorTest()
        {
            MessageFormatter target = new MessageFormatter(); // TODO: Initialize to an appropriate value
            ServiceEndpoint endpoint = null; // TODO: Initialize to an appropriate value
            EndpointDispatcher endpointDispatcher = null; // TODO: Initialize to an appropriate value
            target.ApplyDispatchBehavior(endpoint, endpointDispatcher);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
