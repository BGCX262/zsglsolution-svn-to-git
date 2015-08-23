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
	public partial class FsyhDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertyhgl_fsyh(yhgl_fsyh instance);
    partial void Updateyhgl_fsyh(yhgl_fsyh instance);
    partial void Deleteyhgl_fsyh(yhgl_fsyh instance);
    #endregion
		
		public FsyhDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FsyhDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<yhgl_fsyh> yhgl_fsyh
		{
			get
			{
				return this.GetTable<yhgl_fsyh>();
			}
		}
	}
	
	[Table(Name="dbo.yhgl_fsyh")]
	public partial class yhgl_fsyh : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _fsyh_id;
		
		private int _user_id;
		
		private string _fsyh_name;
		
		private string _fsyh_bz;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onfsyh_idChanging(int value);
    partial void Onfsyh_idChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onfsyh_nameChanging(string value);
    partial void Onfsyh_nameChanged();
    partial void Onfsyh_bzChanging(string value);
    partial void Onfsyh_bzChanged();
    #endregion
		
		public yhgl_fsyh()
		{
			OnCreated();
		}
		
		[Column(Storage="_fsyh_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[Column(Storage="_fsyh_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string fsyh_name
		{
			get
			{
				return this._fsyh_name;
			}
			set
			{
				if ((this._fsyh_name != value))
				{
					this.Onfsyh_nameChanging(value);
					this.SendPropertyChanging();
					this._fsyh_name = value;
					this.SendPropertyChanged("fsyh_name");
					this.Onfsyh_nameChanged();
				}
			}
		}
		
		[Column(Storage="_fsyh_bz", DbType="VarChar(50)")]
		public string fsyh_bz
		{
			get
			{
				return this._fsyh_bz;
			}
			set
			{
				if ((this._fsyh_bz != value))
				{
					this.Onfsyh_bzChanging(value);
					this.SendPropertyChanging();
					this._fsyh_bz = value;
					this.SendPropertyChanged("fsyh_bz");
					this.Onfsyh_bzChanged();
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
