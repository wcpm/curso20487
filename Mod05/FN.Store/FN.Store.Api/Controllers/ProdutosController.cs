using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FN.Store.Api.Controllers
{
    // herdar de api controller
    public class ProdutosController: ApiController
    {
        private readonly IProdutoRepository _prodRepo;
        //injecao dependencia
        public ProdutosController(IProdutoRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public IEnumerable<Produto> Get()
        {
            return _prodRepo.Obter();
        }

    }
}