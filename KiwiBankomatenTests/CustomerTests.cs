using Microsoft.VisualStudio.TestTools.UnitTesting;
using KiwiBankomaten;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace KiwiBankomatenTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TransferMoney_Send10DollarsToAccountWithSEK_ExpectCorrectConversion()
        {
            //Arrange
            Customer testCustomer = DataBase.CustomerDict.Single(x => x.Key == 1).Value;
            BankAccount checkAccount = testCustomer.BankAccounts.Values.FirstOrDefault(b => b.AccountNumber == 40448654);

            //Act
            decimal initValue = checkAccount.Amount;
            testCustomer.TransferMoney(40448654, 40448656, 10);
            decimal newValue = checkAccount.Amount;
            decimal difference = newValue - initValue;
            decimal expected = DataBase.ExchangeRates.FirstOrDefault(e => e.Key == "USD").Value * 10;

            //Assert
            Assert.AreEqual(expected, difference);
            
        }

        [TestMethod]
        public void TransferMoney_Send10SEKToAccountWithSEK_ExpectCorrectTransferAmount()
        {
            //Arrange
            Customer testCustomer = DataBase.CustomerDict.Single(x => x.Key == 1).Value;
            BankAccount checkAccount = testCustomer.BankAccounts.Values.FirstOrDefault(b => b.AccountNumber == 40448654);

            //Act
            decimal initValue = checkAccount.Amount;
            testCustomer.TransferMoney(40448654, 40448653, 10);
            decimal newValue = checkAccount.Amount;
            decimal difference = newValue - initValue;
            decimal expected = 10;

            //Assert
            Assert.AreEqual(expected, difference);

        }

        [TestMethod]
        public void TransferMoney_Send10SEKToNonExistingAccount_ExpectNoChangeInAccount()
        {
            //Arrange
            Customer testCustomer = DataBase.CustomerDict.Single(x => x.Key == 1).Value;
            BankAccount checkAccount = testCustomer.BankAccounts.Values.FirstOrDefault(b => b.AccountNumber == 40448654);

            //Act
            decimal initValue = checkAccount.Amount;
            testCustomer.TransferMoney(40448654, 4255634, 10);
            decimal newValue = checkAccount.Amount;
            decimal difference = newValue - initValue;
            decimal expected = 0;

            //Assert
            Assert.AreEqual(expected, difference);
        }
    }
}
