using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
            // implemento envio de e-mail
        }

        public void Insere(Series objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Series RetornaPorID(int id)
        {
            return listaSeries[id];
        }
    }
}