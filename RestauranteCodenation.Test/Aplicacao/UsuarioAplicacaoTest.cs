using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using RestauranteCodenation.Application.App;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestauranteCodenation.Test.Aplicacao
{    
    public class UsuarioAplicacaoTest
    {
        Mock<IOptions<Token>> mockToken;
        public UsuarioAplicacaoTest()
        {
            mockToken = new Mock<IOptions<Token>>();            
            mockToken.Setup(x => x.Value)
                .Returns(new Token()
                {
                    Secret = "FeitoParaOsAluninhosDaThamy",
                    ExpiracaoHoras = 1,
                    Emissor = "RestauranteCodenation",
                    ValidoEm = "http://localhost:52813"
                });
        }

        [Fact]
        public async void IncluirUsuario()
        {
            var mockRepo = new Mock<IUsuarioRepositorio>();
            mockRepo.Setup(x => x.Incluir("thamy", "thamy@gmail.com", "1234"))
                .Returns(Task.FromResult(true));
           
            var usuarioAplicacao = new UsuarioAplicacao(mockRepo.Object, mockToken.Object);
            var retorno = await usuarioAplicacao.Incluir(new UsuarioViewModel()
            {
                Nome = "thamy",
                Email = "thamy@gmail.com",
                Senha = "1234"
            });

            Assert.True(retorno);
        }

        [Fact]
        public void VerificarSeGerouToken()
        {
            var mockRepo = new Mock<IUsuarioRepositorio>();
            mockRepo.Setup(x => x.Login("thamy@gmail.com", "1234"))
                .Returns(Task.FromResult(new IdentityUser()));

            var usuarioAplicacao = new UsuarioAplicacao(mockRepo.Object, mockToken.Object);
            var retorno = usuarioAplicacao.Login(new LoginViewModel() 
            { 
                Email = "thamy@gmail.com", 
                Senha = "1234" 
            });

            Assert.NotNull(retorno);
        }

        [Fact]
        public void VerificarSeEmailPreenchidoParaReenvioDeSenha()
        {
            Assert.Equal(1, 2);
        }

        [Fact]
        public void VerificarSeSenhaJaFoiTrocadaRecentementeAntesDoReenvioDeSenha()
        {
            Assert.Equal(1, 2);
        }
    }
}
