﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca
{
    class Biblioteca
    {
        private SQLite banco;
        
        public Biblioteca()
        {
            banco = new SQLite();
        }

        public bool AdicionarLivro(Livro livro)
        {
            return banco.InserirLivro(livro.titulo, livro.autor, livro.editora, livro.publicado, livro.quantidade, livro.descricao, livro.capa);
        }

        public void RemoverLivro(Livro livro)
        {
            banco.ExcluirLivro(livro.id);
        }

        public DataTable ListarLivros(Livro livro, string pesquisa)
        {
            return banco.ProcurarLivro(livro.titulo, pesquisa);
        }
        public void EmprestarLivro(Emprestimo emprestimo, string[] livros)
        {
            banco.InserirEmprestimo(emprestimo.codigo, emprestimo.nomeCompleto, emprestimo.dataEmprestimo, emprestimo.dataDevolucao, livros);
        }

        public DataTable ListarEmprestimo(Emprestimo emprestimo, string pesquisa)
        {
            return banco.ProcurarEmprestimo(emprestimo.codigo, pesquisa);
        }

        public void DevolverLivro(Emprestimo emprestimo)
        {
            banco.InserirDevolucao(emprestimo.codigo);
        }
    }
}
