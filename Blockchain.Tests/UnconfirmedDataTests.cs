using NUnit.Framework;

namespace Blockchain.Tests
{
    [TestFixture]
    class UnconfirmedDataTests
    {
        [Test]
        public void Test_get_data_to_return_the_same_value_as_the_added_one()
        {
            var unconfirmedData = new UnconfirmedDataFifo();
            var data = "ThisIsData";

            unconfirmedData.AddData(data);
            var result = unconfirmedData.GetData();

            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public void Test_get_data_with_an_empty_pile_to_return_null()
        {
            var unconfirmedData = new UnconfirmedDataFifo();

            var result = unconfirmedData.GetData();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_get_data_to_respect_the_order_of_insertion()
        {
            var unconfirmedData = new UnconfirmedDataFifo();
            var data1 = "First";
            var data2 = "Second";

            unconfirmedData.AddData(data1);
            unconfirmedData.AddData(data2);

            var result1 = unconfirmedData.GetData();
            var result2 = unconfirmedData.GetData();
            var result3 = unconfirmedData.GetData();

            Assert.That(result1, Is.EqualTo(data1));
            Assert.That(result2, Is.EqualTo(data2));
            Assert.That(result3, Is.Null);
        }
    }
}
