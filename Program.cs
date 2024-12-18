﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace Cadastro_de_Pessoas_HashCode;

class Program
{
    class Pessoa //Construtor
	{
		public string Nome{get; set;}
		public int Idade{get; set;}
		
		public Pessoa(string nome, int idade)
		{
			Nome = nome;
			Idade = idade;
		}
		public override bool Equals(object obj)
		{
			if(obj == null || GetType() != obj.GetType())
			{
				return false;
			}
				Pessoa outraPessoa = (Pessoa)obj;
				return(Nome == outraPessoa.Nome) && (Idade == outraPessoa.Idade);
			
		 }
		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + Nome.GetHashCode();
				hash = hash * 23 + Idade.GetHashCode();
				return hash;
			}
		}
	}
	public static void Main()
	{
		List<Pessoa>  pessoas = new List<Pessoa>();
		
		Console.WriteLine("Cadastro de Pessoas / Código Hash");
		bool continuar = true;
	
		while(continuar) 
		{
			Console.Clear();
			Console.WriteLine("1 - Cadastrar pessoas");
			Console.WriteLine("2 - Ver cadastros");
			Console.WriteLine("3 - excluir cadastros");
			Console.WriteLine("4 - Sair");
			
			string opcao = Console.ReadLine();
			
			switch(opcao)
			{
				case  "1":
					CadastrarPessoas(pessoas);
				break;
				case "2":
					VerCadastro(pessoas);
				break;	
				case "3":
					ExcluirCadastro(pessoas);
				 break;
				case "4":
					Console.WriteLine("Fim");
					Console.ReadKey();
				break;	
				default:
					Console.WriteLine("Está opção não existe!");
					Console.ReadKey();
				break;	
					
			}
					
		}
	}
		
		static void CadastrarPessoas(List<Pessoa> pessoas)
		{
			string Continuar = "S";
			Console.WriteLine("Fazer Cadastro: ");
			while(Continuar.ToUpper() == "S")
			{
			Console.Clear();
			Console.WriteLine("Digite o nome: ");
		    string Nome = Console.ReadLine();
				
				int idade;
				while(true)
				{
				Console.WriteLine("Digite a idade: ");
				if(int.TryParse(Console.ReadLine(), out idade) || idade >= 0)
				break;
				else
				Console.WriteLine("Opção invalida, digite novamente...");
				}			
		pessoas.Add(new Pessoa(Nome, idade));
		Console.WriteLine("Deseja continuar? (S = Sim), (N = Não)");
		Continuar = Console.ReadLine();
	    }
	}
			
		static void VerCadastro(List<Pessoa> pessoas)
			{
				Console.WriteLine("Pessoas Cadastradas: ");
				if(pessoas.Count == 0)
				{
				 Console.WriteLine("Nenhum cadastro");
				}
				
			    var PessoasCadastradas = pessoas.OrderBy(p => p.Nome).ToList();
				foreach(var pessoa in PessoasCadastradas)
				{
					Console.WriteLine("Nome: " + pessoa.Nome + " Idade: " + pessoa.Idade + " Código Hash: " + pessoa.GetHashCode());
				}	
					Console.WriteLine("Insira qualque tecla para sair: ");
					Console.ReadLine();
            }
		static void ExcluirCadastro(List<Pessoa> pessoas)
		{
			Console.Clear();
			if(pessoas.Count == 0)
			{
				Console.WriteLine("Não há registros para exclusão");
			}
			else
			{
				Console.WriteLine("Não há registro para exclusão: ");
				var pessoasOrdenadas = pessoas.OrderBy(p => p.Nome).ToList();
				for(int i = 0; i < pessoasOrdenadas.Count; i++)
				{
				Console.WriteLine( i+1 + " Nome: " + pessoasOrdenadas[i].Nome + " Idade: " + pessoasOrdenadas[i].Idade);
				}
					
				int indice;
				
				if(int.TryParse(Console.ReadLine(), out indice) && indice > 0 && indice <= pessoas.Count)
				{
					var pessoaExcluida = pessoas[indice - 1];
					pessoas.Remove(pessoaExcluida);
				}
					else
				{
					Console.WriteLine("Numero Invalido, nenhuma exclusão foi feita");
					
				}
				
				 Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
       			 Console.ReadLine();
			}
		}
    }

