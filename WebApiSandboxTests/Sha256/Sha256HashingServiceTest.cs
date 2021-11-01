using System;
using NUnit.Framework;
using WebApiSandbox.Services;

namespace WebApiSandboxTests.Sha256
{
    public class Sha256HashingServiceTest
    {
        private Sha256HashingServiceInterface sut;
        
        [SetUp]
        public void Setup()
        {
            sut = new Sha256Sha256HashingService();
        }

        [Test]
        public void ItShouldReturnTheHashOfReceivedClearText()
        {
            // GIVEN
            var clearText = "Hello World";
            
            // WHEN
            var actualHash = sut.Hash(clearText);

            // THEN
            Assert.AreEqual("a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e", actualHash);
        }
        
        [Test]
        public void ItShouldThrowAnExceptionIfReceivedStringIsEmptyString()
        {
            // GIVEN
            var clearText = string.Empty;
            
            // WHEN + THEN
            Assert.That(() => sut.Hash(clearText), 
                Throws.TypeOf<ArgumentException>());
        }
        
        // TODO - now make this new test pass!
        
        // [Test]
        // public void ItShouldThrowAnExceptionIfReceivedStringIsAllWhiteSpace()
        // {
        //     // GIVEN
        //     var clearText = "   ";
        //     
        //     // WHEN + THEN
        //     Assert.That(() => sut.Hash(clearText), 
        //         Throws.TypeOf<ArgumentException>());
        // }
    }
}