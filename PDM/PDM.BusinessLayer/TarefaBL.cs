﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataAcess;
using PDM.DataObjects;

namespace PDM.BusinessLayer
{
    public class TarefaBL
    {
        TarefaDA tda = new TarefaDA();
        
        public List<Tarefa> buscaTarefasProjeto(int numero, bool filtraEtapa, string etapa)
        {
            List<Tarefa> lista = new List<Tarefa>();
            lista = tda.buscaTarefasProjeto(numero, filtraEtapa, etapa);
            return lista;
        }
        public Tarefa buscaTarefa(int id)
        {
            Tarefa t = new Tarefa();
            t = tda.buscaTarefa(id);
            return t;
        }        
        public bool cadastraTarefa(Tarefa t)
        {
            bool foi = tda.cadastraTarefa(t);
            return foi;
        }
        public bool editaTarefa(Tarefa t)
        {
            bool foi = tda.editaTarefa(t);
            return foi;
        }
        public bool excluiTarefa(int id)
        {
            bool foi = tda.excluiTarefa(id);
            return foi;
        }
        public List<Tarefa> buscaTarefasUsuario(string email)
        {
            List<Tarefa> lista = new List<Tarefa>();
            TarefaDA tda = new TarefaDA();
            lista = tda.buscaTarefasUsuario(email);
            return lista;
        }
        public bool adicionarItem(ItemTarefa i)
        {
            bool foi = tda.adicionarItem(i);
            return foi;
        }
        public bool removerItem(int id)
        {
            bool foi = tda.removerItem(id);
            return foi;
        }
        public int contaTarefasUsuario(string email)
        {
            int n = tda.contaTarefasUsuario(email);
            return n;
        }
        public List<ItemTarefa> buscaItensTarefa(int id)
        {
            List<ItemTarefa> listaItens = new List<ItemTarefa>();
            listaItens = tda.buscaItensTarefa(id);
            return listaItens;
        }
        public bool mudaStatusTarefa(int status, int id)
        {
            bool foi = tda.mudaStatusTarefa(status, id);
            return foi;
        }
        public int contaTarefasProjeto(int id)
        {
            int qnt = tda.contaTarefasProjeto(id);
            return qnt;
        }
        public int contaTarefaFinalizadasProjeto(int id)
        {
            int qnt = tda.contaTarefaFinalizadasProjeto(id);
            return qnt;
        }
        public int contaTarefasEmpresa(int idEmpresa, string where)
        {
            int qnt = tda.contaTarefasEmpresa(idEmpresa, where);
            return qnt;
        }
    }
}
