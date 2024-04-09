using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class CategoriaBW: ICategoriaBW
    {
        private ICategoriaDA _categoriaDA;
        public CategoriaBW(ICategoriaDA categoriaDA)
        {
            _categoriaDA = categoriaDA;
        }

        public async Task<Guid> AgregarCategoria(Categoria categoria)
        {
            return await _categoriaDA.AgregarCategoria(categoria);
        }

        public async Task<Guid> EliminarCategoria(Guid id)
        {
            return await _categoriaDA.EliminarCategoria(id);
        }

        public async Task<Guid> ModificarCategoria(Guid id, Categoria categoria)
        {
            return await _categoriaDA.ModificarCategoria(id, categoria);
        }

        public async Task<Categoria> ObtenerCategoriaPorId(Guid id)
        {
            return await _categoriaDA.ObtenerCategoriaPorId(id);
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasCategorias()
        {
            return await _categoriaDA.ObtenerTodasCategorias();
        }
    }
}
