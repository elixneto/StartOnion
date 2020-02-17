using StartOnion.CrossCutting.Security.CryptoHelpers;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Seguranca.Criptografia
{
    public class CriptografiaScryptTeste
    {
        const string TextoLoremIpsum = "Lorem ipsum velit quam facilisis felis habitasse, eros non ullamcorper consequat imperdiet, primis bibendum etiam ultrices vehicula. varius quam ornare cubilia mattis nunc aenean ut malesuada class tortor praesent, nisl sed placerat morbi auctor amet per ornare imperdiet. feugiat ultrices sed integer amet nunc conubia sodales morbi, primis ad rhoncus eget iaculis lectus aptent velit, elementum habitant quisque ante elementum orci commodo. imperdiet sapien rhoncus mauris ultrices inceptos class leo, libero ipsum convallis cras dolor dictum. viverra neque sapien taciti aenean consectetur quisque rutrum, euismod aenean cras rhoncus platea vulputate scelerisque, nostra odio dui sem tempus consequat";

        [Fact]
        public void DeveCriptografarUmaSenhaCorretamenteUtilizandoScrypt()
        {
            var senha = "sneha123";
            var salt = "bG9naW4=";

            var hashEsperado = ScryptHelper.CryptPassword(senha, salt);

            Assert.True(ScryptHelper.ValidatePassword(senha, salt, hashEsperado));
        }

        [Fact]
        public void DeveCriptografarUmTextoCorretamenteUtilizandoScrypt()
        {
            var hashEsperado = ScryptHelper.CryptText(TextoLoremIpsum);

            Assert.True(ScryptHelper.ValidateText(TextoLoremIpsum, hashEsperado));
        }

        [Theory]
        [InlineData("p@ssw0rd001MinhaSuperSenha2020;Ipul")]
        [InlineData("s3nh@001")]
        [InlineData("123456")]
        public void DeveCriptografarUmaSenhaComOTamanhoCorreto(string senha)
        {
            var hash = ScryptHelper.CryptPassword(senha, "bG9naW4=");

            Assert.Equal(103, hash.Length);
        }

        [Fact]
        public void DeveCriptografarUmTextoComOTamanhoCorreto()
        {
            var hash = ScryptHelper.CryptText(TextoLoremIpsum);

            Assert.Equal(103, hash.Length);
        }
    }
}
