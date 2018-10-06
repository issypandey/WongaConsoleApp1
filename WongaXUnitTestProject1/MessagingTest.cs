using System;
using Xunit;
using WongaConsoleApp1;

namespace WongaXUnitTestProject1
{
    public class MessagingTest
    {
        [Fact]
        public void PassName()
        {
            
            var expected = "Y";
            var Message = new Messaging();
            var response = Messaging.PublishMessage("Hello", "name");

            Assert.Equal(expected, response);

        }

        [Fact]
        public void PassBlankMessage()
        {

            var expected = "No Message Passed";
            var Message = new Messaging();
            var response = Messaging.PublishMessage("", "name");

            Assert.Equal(expected, response);

        }

        [Fact]
        public void PassBlankRouteKey()
        {

            var expected = "Route Key is null";
            var Message = new Messaging();
            var response = Messaging.PublishMessage("Ismaeel", "");

            Assert.Equal(expected, response);

        }
    }
}
