namespace Kairos.Tests.UnitTests.Tests.Entities;
public class EventoEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidTitulo = "test";
        private const string ValidDescricao = "test";
        private const string ValidLocal = "test";
        private const int ValidTipoEvento = 1;
        private const int ValidUsuario = 1;
        private const EStatusAprovacao ValidStatusAprovacao =  EStatusAprovacao.Aprovado;
        private const string ValidImagemUrl = "test";
    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(InvalidNumberZero, ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIdIfIdIsNegative(int id, string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(id, titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </Titulo>
        [Theory]
        [InlineData(null, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData("", ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(" ", ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIfTituloIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </Descrição>
        [Theory]
        [InlineData(ValidTitulo, null, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, "", "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, " ", "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIfDescricaoIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </Local>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", null, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", "", ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", " ", ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIfLocalIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </TipoEvento>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, InvalidNumber, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, InvalidNumberZero, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIfTipoEventoIsNegativeOrZero(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </Usuario>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, InvalidNumber, ValidStatusAprovacao, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, InvalidNumberZero, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldFailIfUsuariosNegativeOrZero(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </Imagem>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, null)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, "")]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, " ")]
        public void Evento_ShouldFailIfImagemIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            });
        }
    #endregion

    #region </LongLenght>
        [Fact]
        public void Evento_ShouldFailIfIsHaveLongLenght()
        {
            var LongLenghtTitulo = new string('A', 108);
            var LongLenghtDescricao = new string('B', 2);
            var LongLenghtLocal = new string('C', 251);
            var LongLenghtImagem = new string('D', 2);
            var dataCadastro =  DateTime.UtcNow;
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(LongLenghtTitulo, LongLenghtDescricao, dataCadastro, dataCadastro, LongLenghtLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, LongLenghtImagem);
            });
        }
    #endregion

        #region </Criar>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidStatusAprovacao, ValidImagemUrl)]
        public void Evento_ShouldCreate(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, EStatusAprovacao statusAprovacao, string imagemUrl)
        {
            var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, statusAprovacao, imagemUrl);
            Assert.NotNull(acount);
        }
    #endregion

}
