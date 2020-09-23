using System.Text.RegularExpressions;
using BlackJack;
using Xunit;


namespace BlackJackTests
{
    public class CardTests
    {
        [Fact]
        public void FormatCardStringShould_ReturnCorrectStringPattern()
        {
            string cardStringPattern = @"^\[(\w+), (\w+)\]$";
            Card newCard = new Card(CardFace.Ace, Suit.Diamond, 1);
            bool isMatch = Regex.IsMatch(newCard.FormatCardString(), cardStringPattern);
            Assert.True(isMatch);
        }
        
        [Theory]
        [InlineData(CardFace.Ace, Suit.Diamond, "[Ace, Diamond]")]
        [InlineData(CardFace.Six, Suit.Heart, "[Six, Heart]")]
        [InlineData(CardFace.King, Suit.Spade, "[King, Spade]")]
        public void FormatCardStringShould_ReturnCorrectString(CardFace cardFace, Suit suit, string expectedResult)
        {
            Card newCard = new Card(cardFace, suit, 1);
            
            Assert.Equal(expectedResult, newCard.FormatCardString());
        }
        
    }
}