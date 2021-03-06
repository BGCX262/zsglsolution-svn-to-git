﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4961
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication.Entities
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="zsgl_solution")]
	public partial class ZyhGxFilesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertgxgl_zyhgx(gxgl_zyhgx instance);
    partial void Updategxgl_zyhgx(gxgl_zyhgx instance);
    partial void Deletegxgl_zyhgx(gxgl_zyhgx instance);
    #endregion
		
		public ZyhGxFilesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ZyhGxFilesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZyhGxFilesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZyhGxFilesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZyhGxFilesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<gxgl_zyhgx> gxgl_zyhgx
		{
			get
			{
				return this.GetTable<gxgl_zyhgx>();
			}
		}
	}
	
	[Table(Name="dbo.gxgl_zyhgx")]
	public partial class gxgl_zyhgx : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _gx_id;
		
		private string _file_id;
		
		private int _user_id;
		
		private string _gx_sj;
		
		private int _gx_ly;
		
		private string _gx_isread;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ongx_idChanging(int value);
    partial void Ongx_idChanged();
    partial void Onfile_idChanging(string value);
    partial void Onfile_idChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Ongx_sjChanging(string value);
    partial void Ongx_sjChanged();
    partial void Ongx_lyChanging(int value);
    partial void Ongx_lyChanged();
    partial void Ongx_isreadChanging(string value);
    partial void Ongx_isreadChanged();
    #endregion
		
		public gxgl_zyhgx()
		{
			OnCreated();
		}
		
		[Column(Storage="_gx_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int gx_id
		{
			get
			{
				return this._gx_id;
			}
			set
			{
				if ((this._gx_id != value))
				{
					this.Ongx_idChanging(value);
					this.SendPropertyChanging();
					this._gx_id = value;
					this.SendPropertyChanged("gx_id");
					this.Ongx_idChanged();
				}
			}
		}
		
		[Column(Storage="_file_id", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string file_id
		{
			get
			{
				return this._file_id;
			}
			set
			{
				if ((this._file_id != value))
				{
					this.Onfile_idChanging(value);
					this.SendPropertyChanging();
					this._file_id = value;
					this.SendPropertyChanged("file_id");
					this.Onfile_idChanged();
				}
			}
		}
		
		[Column(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[Column(Storage="_gx_sj", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string gx_sj
		{
			get
			{
				return this._gx_sj;
			}
			set
			{
				if ((this._gx_sj != value))
				{
					this.Ongx_sjChanging(value);
					this.SendPropertyChanging();
					this._gx_sj = value;
					this.SendPropertyChanged("gx_sj");
					this.Ongx_sjChanged();
				}
			}
		}
		
		[Column(Storage="_gx_ly", DbType="Int NOT NULL")]
		public int gx_ly
		{
			get
			{
				return this._gx_ly;
			}
			set
			{
				if ((this._gx_ly != value))
				{
					this.Ongx_lyChanging(value);
					this.SendPropertyChanging();
					this._gx_ly = value;
					this.SendPropertyChanged("gx_ly");
					this.Ongx_lyChanged();
				}
			}
		}
		
		[Column(Storage="_gx_isread", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string gx_isread
		{
			get
			{
				return this._gx_isread;
			}
			set
			{
				if ((this._gx_isread != value))
				{
					this.Ongx_isreadChanging(value);
					this.SendPropertyChanging();
					this._gx_isread = value;
					this.SendPropertyChanged("gx_isread");
					this.Ongx_isreadChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
