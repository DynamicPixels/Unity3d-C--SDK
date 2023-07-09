
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using DynamicPixelsInitializer;
using models.dto;
using models.inputs;
using UnityEngine;

namespace Tests.Runtime
{
    public class AuthTest
    {
        [Test]
        public async void Test_LoginWithEmail()
        {
            // init DynamicPixels Plugin
            var instance = new DynamicPixelsInitializer.DynamicPixelsInitializer();
            instance.OnEnable();

            Debug.Log("Logging in: ");
            var result = await DynamicPixels.Authentication.LoginWithEmail(new LoginWithEmailParams
            {
                email = "rastegar.parya3@gmail.com",
                password = "alonecat3132121"
            });
            
            Debug.Log("Token:" + result.Token);
           
            Assert.That(result.Token, !Is.Empty);
        }
        
        [Test]
        public async void Test_LoginAsGuest()
        {
            // init DynamicPixels Plugin
            var instance = new DynamicPixelsInitializer.DynamicPixelsInitializer();
            instance.OnEnable();

            Debug.Log("Logging in: ");
            var result = await DynamicPixels.Authentication.LoginAsGuest(new LoginAsGuestParams()
            {
               
            });
            
            Debug.Log("Token:" + result.Token);
           
            Assert.That(result.Token, !Is.Empty);
        }
        
        [Test]
        public async void Test_LoginWithToken()
        {
            // init DynamicPixels Plugin
            var instance = new DynamicPixelsInitializer.DynamicPixelsInitializer();
            instance.OnEnable();

            Debug.Log("Logging in: ");
            await DynamicPixels.Authentication.LoginWithToken(new LoginWithTokenParams()
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiNCIsImdhbWUiOiI2NDQ3ZDE5ODA2M2U5MjVhZmZjNThlNDIiLCJuYmYiOjE2ODMzMjM5MzMsImV4cCI6MTY4NjAwMjMzMywiaWF0IjoxNjgzMzIzOTMzfQ.fbW2yhzp0jeiZov1uMadbRlV5IpPq2CGRry7g8ycLo8",
            });
        }
    }
}