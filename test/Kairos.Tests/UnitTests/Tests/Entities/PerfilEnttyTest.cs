namespace Kairos.Tests.UnitTests.Tests.Entities;
public class PerfilEnttyTest
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
        public void Perfil_ShouldFailIdIfIdIsNegative(int id, string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PerfilEntity(id, nome);
            });
        }
    #endregion

    #region </Nome>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Perfil_ShouldFailIfNameIsNullOrEmptyOrWhiteSpace(string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PerfilEntity(nome);
            });
        }
    #endregion

    #region </LongLenght>
        [Fact]
        public void Perfil_ShouldFailIfIsHaveLongLenght()
        {
            var LongLenght = new string('B', 51);
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PerfilEntity(LongLenght);
            });
        }
    #endregion

    #region </Criar>
        [Theory]
        [InlineData(ValidName)]
        public void Perfil_ShouldCreate(string nome)
        {
            var count = new PerfilEntity(nome);
            Assert.NotNull(count);
        }
    #endregion
}
