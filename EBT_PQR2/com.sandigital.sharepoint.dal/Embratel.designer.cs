﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.dal
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Embratel")]
	public partial class _EmbratelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public _EmbratelDataContext() : 
				base("Data Source=Localhost;Initial Catalog=Embratel;Integrated Security=True", mappingSource)
		{
			OnCreated();
		}
		
		public _EmbratelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _EmbratelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _EmbratelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _EmbratelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Funcionario> Funcionario
		{
			get
			{
				return this.GetTable<Funcionario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Funcionario")]
	public partial class Funcionario
	{
		
		private string _Empresa;
		
		private string _MATRICULA;
		
		private string _NomeLogin;
		
		private string _Nome;
		
		private System.Nullable<System.DateTime> _Nascimento;
		
		private string _Departamento;
		
		private string _NomeDiretoria;
		
		private string _NomeGerencia;
		
		private string _LogradouroComercial;
		
		private string _CidadeComercial;
		
		private string _UFComercial;
		
		private string _CEPComercial;
		
		private string _TelefoneCelular;
		
		private string _TelefoneComercial;
		
		private string _Unidade;
		
		private string _NivelHierarquico;
		
		private string _Predio;
		
		private string _CategoriaFuncionario;
		
		private string _Cidade;
		
		private string _Banco;
		
		private string _NomeBanco;
		
		private System.Nullable<int> _Cargo;
		
		private string _EnderecoComercial;
		
		private string _EMAIL;
		
		private string _DescricaoCargo;
		
		private System.Nullable<char> _Sexo;
		
		private string _NOME_FONETICO;
		
		private string _WSS_ID;
		
		private string _WSS_APELIDO;
		
		private string _WSS_URL_FOTO;
		
		public Funcionario()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Empresa", DbType="Char(3)")]
		public string Empresa
		{
			get
			{
				return this._Empresa;
			}
			set
			{
				if ((this._Empresa != value))
				{
					this._Empresa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MATRICULA", DbType="Char(10)")]
		public string MATRICULA
		{
			get
			{
				return this._MATRICULA;
			}
			set
			{
				if ((this._MATRICULA != value))
				{
					this._MATRICULA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NomeLogin", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string NomeLogin
		{
			get
			{
				return this._NomeLogin;
			}
			set
			{
				if ((this._NomeLogin != value))
				{
					this._NomeLogin = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(60)")]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this._Nome = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nascimento", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> Nascimento
		{
			get
			{
				return this._Nascimento;
			}
			set
			{
				if ((this._Nascimento != value))
				{
					this._Nascimento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Departamento", DbType="VarChar(40)")]
		public string Departamento
		{
			get
			{
				return this._Departamento;
			}
			set
			{
				if ((this._Departamento != value))
				{
					this._Departamento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NomeDiretoria", DbType="VarChar(40)")]
		public string NomeDiretoria
		{
			get
			{
				return this._NomeDiretoria;
			}
			set
			{
				if ((this._NomeDiretoria != value))
				{
					this._NomeDiretoria = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NomeGerencia", DbType="VarChar(40)")]
		public string NomeGerencia
		{
			get
			{
				return this._NomeGerencia;
			}
			set
			{
				if ((this._NomeGerencia != value))
				{
					this._NomeGerencia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogradouroComercial", DbType="VarChar(61)")]
		public string LogradouroComercial
		{
			get
			{
				return this._LogradouroComercial;
			}
			set
			{
				if ((this._LogradouroComercial != value))
				{
					this._LogradouroComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CidadeComercial", DbType="VarChar(30)")]
		public string CidadeComercial
		{
			get
			{
				return this._CidadeComercial;
			}
			set
			{
				if ((this._CidadeComercial != value))
				{
					this._CidadeComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UFComercial", DbType="VarChar(3)")]
		public string UFComercial
		{
			get
			{
				return this._UFComercial;
			}
			set
			{
				if ((this._UFComercial != value))
				{
					this._UFComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CEPComercial", DbType="Char(9)")]
		public string CEPComercial
		{
			get
			{
				return this._CEPComercial;
			}
			set
			{
				if ((this._CEPComercial != value))
				{
					this._CEPComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TelefoneCelular", DbType="VarChar(20)")]
		public string TelefoneCelular
		{
			get
			{
				return this._TelefoneCelular;
			}
			set
			{
				if ((this._TelefoneCelular != value))
				{
					this._TelefoneCelular = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TelefoneComercial", DbType="VarChar(20)")]
		public string TelefoneComercial
		{
			get
			{
				return this._TelefoneComercial;
			}
			set
			{
				if ((this._TelefoneComercial != value))
				{
					this._TelefoneComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unidade", DbType="VarChar(40)")]
		public string Unidade
		{
			get
			{
				return this._Unidade;
			}
			set
			{
				if ((this._Unidade != value))
				{
					this._Unidade = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NivelHierarquico", DbType="Char(3)")]
		public string NivelHierarquico
		{
			get
			{
				return this._NivelHierarquico;
			}
			set
			{
				if ((this._NivelHierarquico != value))
				{
					this._NivelHierarquico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Predio", DbType="VarChar(8)")]
		public string Predio
		{
			get
			{
				return this._Predio;
			}
			set
			{
				if ((this._Predio != value))
				{
					this._Predio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoriaFuncionario", DbType="Char(3)")]
		public string CategoriaFuncionario
		{
			get
			{
				return this._CategoriaFuncionario;
			}
			set
			{
				if ((this._CategoriaFuncionario != value))
				{
					this._CategoriaFuncionario = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cidade", DbType="VarChar(34)")]
		public string Cidade
		{
			get
			{
				return this._Cidade;
			}
			set
			{
				if ((this._Cidade != value))
				{
					this._Cidade = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Banco", DbType="Char(3)")]
		public string Banco
		{
			get
			{
				return this._Banco;
			}
			set
			{
				if ((this._Banco != value))
				{
					this._Banco = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NomeBanco", DbType="VarChar(30)")]
		public string NomeBanco
		{
			get
			{
				return this._NomeBanco;
			}
			set
			{
				if ((this._NomeBanco != value))
				{
					this._NomeBanco = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cargo", DbType="Int")]
		public System.Nullable<int> Cargo
		{
			get
			{
				return this._Cargo;
			}
			set
			{
				if ((this._Cargo != value))
				{
					this._Cargo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EnderecoComercial", DbType="Char(9)")]
		public string EnderecoComercial
		{
			get
			{
				return this._EnderecoComercial;
			}
			set
			{
				if ((this._EnderecoComercial != value))
				{
					this._EnderecoComercial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="VarChar(100)")]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this._EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DescricaoCargo", DbType="VarChar(30)")]
		public string DescricaoCargo
		{
			get
			{
				return this._DescricaoCargo;
			}
			set
			{
				if ((this._DescricaoCargo != value))
				{
					this._DescricaoCargo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sexo", DbType="Char(1)")]
		public System.Nullable<char> Sexo
		{
			get
			{
				return this._Sexo;
			}
			set
			{
				if ((this._Sexo != value))
				{
					this._Sexo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOME_FONETICO", DbType="VarChar(255)")]
		public string NOME_FONETICO
		{
			get
			{
				return this._NOME_FONETICO;
			}
			set
			{
				if ((this._NOME_FONETICO != value))
				{
					this._NOME_FONETICO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WSS_ID", DbType="VarChar(10)")]
		public string WSS_ID
		{
			get
			{
				return this._WSS_ID;
			}
			set
			{
				if ((this._WSS_ID != value))
				{
					this._WSS_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WSS_APELIDO", DbType="VarChar(100)")]
		public string WSS_APELIDO
		{
			get
			{
				return this._WSS_APELIDO;
			}
			set
			{
				if ((this._WSS_APELIDO != value))
				{
					this._WSS_APELIDO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WSS_URL_FOTO", DbType="VarChar(255)")]
		public string WSS_URL_FOTO
		{
			get
			{
				return this._WSS_URL_FOTO;
			}
			set
			{
				if ((this._WSS_URL_FOTO != value))
				{
					this._WSS_URL_FOTO = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
