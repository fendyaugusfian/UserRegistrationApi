using Xunit;
using UserRegistrationApi.Models;
using System;

namespace UserRegistrationTests.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void User_ValidateIdentityNumber_Valid()
        {
            // Arrange
            var user = new User { IdentityNumber = "1234567890123456" };

            // Act
            var isValid = ValidateIdentityNumber(user);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void User_ValidateIdentityNumber_Invalid()
        {
            // Arrange
            var user = new User { IdentityNumber = "1234567890" };

            // Act
            var isValid = ValidateIdentityNumber(user);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void User_ValidateEmail_Valid()
        {
            // Arrange
            var user = new User { Email = "test@example.com" };

            // Act
            var isValid = ValidateEmail(user);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void User_ValidateEmail_Invalid()
        {
            // Arrange
            var user = new User { Email = "invalid-email" };

            // Act
            var isValid = ValidateEmail(user);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void User_ValidateDateOfBirth_Valid()
        {
            // Arrange
            var user = new User { DateOfBirth = new DateTime(1990, 1, 1) };

            // Act
            var isValid = ValidateDateOfBirth(user);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void User_ValidateDateOfBirth_Invalid()
        {
            // Arrange
            var user = new User { DateOfBirth = DateTime.MinValue }; // Example of an invalid date

            // Act
            var isValid = ValidateDateOfBirth(user);

            // Assert
            Assert.False(isValid);
        }

        private bool ValidateIdentityNumber(User user)
        {
            // Validate IdentityNumber
            bool isIdentityNumberValid = user.IdentityNumber != null && user.IdentityNumber.Length == 16;

            // Return validations
            return isIdentityNumberValid;
        }
        private bool ValidateEmail(User user)
        {

           // Validate Email format
           bool isEmailValid = IsValidEmail(user.Email);

           // Return validations
           return isEmailValid;
        }

        private bool ValidateDateOfBirth(User user)
        {
            // Validate DateOfBirth as a valid DateTime
            bool isDateOfBirthValid = user.DateOfBirth != default(DateTime);

            // Return validations
            return isDateOfBirthValid;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
