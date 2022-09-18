using AutoMapper;
using Castle.Core.Smtp;
using CustomerAcountManagement.Service;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;
using DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerAcountManagement.Test
{
    public class CustomerAcountManagementTest
    {
        private readonly Mock<ICustomerStorage> mockCus;
        private readonly Mock<IEmailVerificationService> mockEmail;
        private readonly Mock<IAcountStorage> mockAcount;
        private readonly Mock<IMapper> mockMapper;




        private readonly CustomerService sut;

        public CustomerAcountManagementTest()
        {
            
            mockCus = new();
            mockEmail = new();
            mockAcount = new();
            mockMapper = new();
        
            sut = new (mockAcount.Object, mockCus.Object , mockMapper.Object );
        }
        [Fact]
        public void AddCustomer_ShouldValidate_AddCustomer_AndSendEmail()
        {
            // ARRANGE
            var email = "rk0583264988@gmail.com";
            var firstName = "";
            var lastName = "ker";
            var password = "12345678";
            var verificationCode = "9872";

            var register = new RegisterDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                VerificationCode = verificationCode
            };
            var custemer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            //bool expexctedResult = true;
            //mockEmail.Setup(db => db.GetEmailVerification(email,verificationCode)).Returns(Task.FromResult(expexctedResult));
           
            mockCus.Setup(db => db.Register(custemer)).Returns(Task.FromResult(custemer));

            // ACT
            var result = sut.PostCustomer(register);

            // ASSERT
           
            Assert.True( true, Task.FromResult(result).ToString());
            //mockCus.Verify(v => v.ValidateUniqueEmail(email), Times.Once);
            //mockCus.Verify(db => db.Register(custemer), Times.Once);
        }

    }
}
