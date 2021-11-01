using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
    public class TiposAportesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.TiposAportes.Any(t => t.TipoAporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static TiposAportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposAportes tiposAporte;

            try
            {
                tiposAporte = contexto.TiposAportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tiposAporte;
        }
        public static bool Guardar(TiposAportes tipoAporte)
        {
            if (!Existe(tipoAporte.TipoAporteId))
            {
                return Insertar(tipoAporte);
            }
            else
            {
                return Modificar(tipoAporte);
            }
        }
        private static bool Insertar(TiposAportes tipoAporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.TiposAportes.Add(tipoAporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Modificar(TiposAportes tipoAporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tipoAporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var tipoAporte = contexto.TiposAportes.Find(id);

                if (tipoAporte != null)
                {
                    contexto.TiposAportes.Remove(tipoAporte);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static List<TiposAportes> GetTiposAportes()
        {
            List<TiposAportes> lista = new List<TiposAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposAportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TiposAportes> GetList(Expression<Func<TiposAportes, bool>> criterio)
        {
            List<TiposAportes> lista = new List<TiposAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposAportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
