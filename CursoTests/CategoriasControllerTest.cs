using CursoMVC.Models;
using CursoMVCAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CursoTests
{
    public class CategoriasControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { id = 6, Descricao = "Musica" };

            _mockContext.Setup(x => x.Categorias).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.Categorias.FindAsync(6)).ReturnsAsync(_categoria);

            _mockContext.Setup(x => x.SetModified(_categoria));
            _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(6);
        }

        [Fact]
        public async Task GetCategoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.GetCategoria(6);
            _mockSet.Verify(x => x.FindAsync(6), Times.Once());
        }


        [Fact]
        public async Task PutCategoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.PutCategoria(6, _categoria);
            _mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task PostCategoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.PostCategoria(_categoria);

            _mockSet.Verify(x => x.Add(_categoria), Times.Once);
            _mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task DeleteCategoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.DeleteCategoria(6);

            _mockSet.Verify(x => x.FindAsync(6), Times.Once);
            _mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }








    }
}

