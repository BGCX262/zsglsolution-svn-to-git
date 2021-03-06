﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4959
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
	public partial class FsyhGxFilesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertgxgl_fsyhgxb(gxgl_fsyhgxb instance);
    partial void Updategxgl_fsyhgxb(gxgl_fsyhgxb instance);
    partial void Deletegxgl_fsyhgxb(gxgl_fsyhgxb instance);
    #endregion
		
		public FsyhGxFilesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhGxFilesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhGxFilesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhGxFilesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhGxFilesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<gxgl_fsyhgxb> gxgl_fsyhgxb
		{
			get
			{
				return this.GetTable<gxgl_fsyhgxb>();
			}
		}
	}
	
	[Table(Name="dbo.gxgl_fsyhgxb")]
	public partial class gxgl_fsyhgxb : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _fsyhgx_id;
		
		private string _file_id;
		
		private int _fsyh_id;
		
		private string _fsyhgx_sj;
		
		private int _fsyhgx_ly;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onfsyhgx_idChanging(int value);
    partial void Onfsyhgx_idChanged();
    partial void Onfile_idChanging(string value);
    partial void Onfile_idChanged();
    partial void Onfsyh_idChanging(int value);
    partial void Onfsyh_idChanged();
    partial void Onfsyhgx_sjChanging(string value);
    partial void Onfsyhgx_sjChanged();
    partial void Onfsyhgx_lyChanging(int value);
    partial void Onfsyhgx_lyChanged();
    #endregion
		
		public gxgl_fsyhgxb()
		{
			OnCreated();
		}
		
		[Column(Storage="_fsyhgx_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int fsyhgx_id
		{
			get
			{
				return this._fsyhgx_id;
			}
			set
			{
				if ((this._fsyhgx_id != value))
				{
					this.Onfsyhgx_idChanging(value);
					this.SendPropertyChanging();
					this._fsyhgx_id = value;
					this.SendPropertyChanged("fsyhgx_id");
					this.Onfsyhgx_idChanged();
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
		
		[Column(Storage="_fsyh_id", DbType="Int NOT NULL")]
		public int fsyh_id
		{
			get
			{
				return this._fsyh_id;
			}
			set
			{
				if ((this._fsyh_id != value))
				{
					this.Onfsyh_idChanging(value);
					this.SendPropertyChanging();
					this._fsyh_id = value;
					this.SendPropertyChanged("fsyh_id");
					this.Onfsyh_idChanged();
				}
			}
		}
		
		[Column(Storage="_fsyhgx_sj", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string fsyhgx_sj
		{
			get
			{
				return this._fsyhgx_sj;
			}
			set
			{
				if ((this._fsyhgx_sj != value))
				{
					this.Onfsyhgx_sjChanging(value);
					this.SendPropertyChanging();
					this._fsyhgx_sj = value;
					this.SendPropertyChanged("fsyhgx_sj");
					this.Onfsyhgx_sjChanged();
				}
			}
		}
		
		[Column(Storage="_fsyhgx_ly", DbType="Int NOT NULL")]
		public int fsyhgx_ly
		{
			get
			{
				return this._fsyhgx_ly;
			}
			set
			{
				if ((this._fsyhgx_ly != value))
				{
					this.Onfsyhgx_lyChanging(value);
					this.SendPropertyChanging();
					this._fsyhgx_ly = value;
					this.SendPropertyChanged("fsyhgx_ly");
					this.Onfsyhgx_lyChanged();
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
