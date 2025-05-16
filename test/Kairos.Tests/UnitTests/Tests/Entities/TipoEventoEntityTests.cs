namespace Kairos.Tests.UnitTests.Tests.Entities;
public class TipoEventoEntityTests
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidName = "test";
    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidName)]
        [InlineData(InvalidNumberZero, ValidName)]
        public void TipoEvento_ShouldFailIdIfIdIsNegative(int id, string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new TipoEventoEntity(id, nome);
            });
        }
    #endregion

    #region </Nome>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void TipoEvento_ShouldFailIfNameIsNullOrEmptyOrWhiteSpace(string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new TipoEventoEntity(nome);
            });
        }
    #endregion

    #region </LongLenght>
        [Fact]
        public void TipoEvento_ShouldFailIfIsHaveLongLenght()
        {
            var LongLenght = new string('B', 51);
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new TipoEventoEntity(LongLenght);
            });
        }
    #endregion

    #region </Criar>
        [Theory]
        [InlineData(ValidName)]
        public void TipoEvento_ShouldCreate(string nome)
        {
            var count = new TipoEventoEntity(nome);
            Assert.NotNull(count);
        }
    #endregion
}
