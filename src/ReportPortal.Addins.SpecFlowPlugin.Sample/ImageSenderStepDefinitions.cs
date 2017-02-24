using NUnit.Framework;
using ReportPortal.Addins.SpecFlowPlugin.Sample.Properties;
using ReportPortal.Client.Models;
using ReportPortal.Client.Requests;
using ReportPortal.Shared;
using System;
using System.Drawing;
using TechTalk.SpecFlow;

namespace ReportPortal.Addins.SpecFlowPlugin.Sample
{
    [Binding]
    public class ImageSenderStepDefinitions
    {
        private bool happy;

        [Given(@"I have pug happy image")]
        public void GivenIHavePugHappyImage()
        {
            Assert.IsNotNull(Resources.lucky);
        }

        [When(@"pug was happy")]
        public void WhenPugWasHappy()
        {
            happy = true;
        }

        [Then(@"I send image to RP")]
        public void ThenISendImageToRP()
        {
            byte[] image = getImageFromResources(happy);
            Bridge.Service.AddLogItem(new AddLogItemRequest
            {
                TestItemId = Bridge.Context.TestId,
                Text = happy ? "Pug happy" : "Pug unhappy",
                Time = DateTime.UtcNow,
                Attach = new Attach("Image", "image/jpeg", image),
                Level = LogLevel.Info
            });
        }

        [Given(@"I have pug unhappy image")]
        public void GivenIHavePugUnhappyImage()
        {
            Assert.IsNotNull(Resources.unlucky);
        }

        [When(@"pug was unhappy")]
        public void WhenPugWasUnhappy()
        {
            happy = false;
        }

        private byte[] getImageFromResources(bool happy)
        {
            var image = happy ? Resources.lucky : Resources.unlucky;
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }
    }
}
