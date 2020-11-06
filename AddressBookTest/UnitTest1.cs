using AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// UC16
        /// </summary>
        [TestMethod]
        public void CompareRetrievedDataFromDB()
        {
            ContactsDB expected = new ContactsDB()
            {
                first_name = "Rachit",
                last_name = "Rathi",
                city = "Juhu",
                phone = "123456789",
                B_Name = "Book1",
                B_Type = "Family"
            };
            
            var actual = AddressBookRepoDB.RetrieveData();

            Assert.AreEqual(expected.first_name, actual.first_name);
            Assert.AreEqual(expected.last_name, actual.last_name);
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.phone, actual.phone);
            Assert.AreEqual(expected.B_Name, actual.B_Name);
            Assert.AreEqual(expected.B_Type, actual.B_Type);

        }
        /// <summary>
        /// UC17 
        /// </summary>
        [TestMethod]
        public void CompareUpdatedDataFromDB()
        {
            string expected = "Karnataka";

            string actual = AddressBookRepoDB.UpdateDetailsInDB();

            Assert.AreEqual(expected, actual);
        }

    }
}
