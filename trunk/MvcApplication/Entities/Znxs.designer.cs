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
	public partial class ZnxsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertyjgl_znx(yjgl_znx instance);
    partial void Updateyjgl_znx(yjgl_znx instance);
    partial void Deleteyjgl_znx(yjgl_znx instance);
    #endregion
		
		public ZnxsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ZnxsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZnxsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZnxsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ZnxsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<yjgl_znx> yjgl_znx
		{
			get
			{
				return this.GetTable<yjgl_znx>();
			}
		}
	}
	
	[Table(Name="dbo.yjgl_znx")]
	public partial class yjgl_znx : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _znx_id;
		
		private int _fs_user_id;
		
		private int _js_user_id;
		
		private string _znx_topic;
		
		private string _znx_nr;
		
		private string _znx_fssj;
		
		private string _znx_isread;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onznx_idChanging(int value);
    partial void Onznx_idChanged();
    partial void Onfs_user_idChanging(int value);
    partial void Onfs_user_idChanged();
    partial void Onjs_user_idChanging(int value);
    partial void Onjs_user_idChanged();
    partial void Onznx_topicChanging(string value);
    partial void Onznx_topicChanged();
    partial void Onznx_nrChanging(string value);
    partial void Onznx_nrChanged();
    partial void Onznx_fssjChanging(string value);
    partial void Onznx_fssjChanged();
    partial void Onznx_isreadChanging(string value);
    partial void Onznx_isreadChanged();
    #endregion
		
		public yjgl_znx()
		{
			OnCreated();
		}
		
		[Column(Storage="_znx_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int znx_id
		{
			get
			{
				return this._znx_id;
			}
			set
			{
				if ((this._znx_id != value))
				{
					this.Onznx_idChanging(value);
					this.SendPropertyChanging();
					this._znx_id = value;
					this.SendPropertyChanged("znx_id");
					this.Onznx_idChanged();
				}
			}
		}
		
		[Column(Storage="_fs_user_id", DbType="Int NOT NULL")]
		public int fs_user_id
		{
			get
			{
				return this._fs_user_id;
			}
			set
			{
				if ((this._fs_user_id != value))
				{
					this.Onfs_user_idChanging(value);
					this.SendPropertyChanging();
					this._fs_user_id = value;
					this.SendPropertyChanged("fs_user_id");
					this.Onfs_user_idChanged();
				}
			}
		}
		
		[Column(Storage="_js_user_id", DbType="Int NOT NULL")]
		public int js_user_id
		{
			get
			{
				return this._js_user_id;
			}
			set
			{
				if ((this._js_user_id != value))
				{
					this.Onjs_user_idChanging(value);
					this.SendPropertyChanging();
					this._js_user_id = value;
					this.SendPropertyChanged("js_user_id");
					this.Onjs_user_idChanged();
				}
			}
		}
		
		[Column(Storage="_znx_topic", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string znx_topic
		{
			get
			{
				return this._znx_topic;
			}
			set
			{
				if ((this._znx_topic != value))
				{
					this.Onznx_topicChanging(value);
					this.SendPropertyChanging();
					this._znx_topic = value;
					this.SendPropertyChanged("znx_topic");
					this.Onznx_topicChanged();
				}
			}
		}
		
		[Column(Storage="_znx_nr", DbType="VarChar(5000) NOT NULL", CanBeNull=false)]
		public string znx_nr
		{
			get
			{
				return this._znx_nr;
			}
			set
			{
				if ((this._znx_nr != value))
				{
					this.Onznx_nrChanging(value);
					this.SendPropertyChanging();
					this._znx_nr = value;
					this.SendPropertyChanged("znx_nr");
					this.Onznx_nrChanged();
				}
			}
		}
		
		[Column(Storage="_znx_fssj", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string znx_fssj
		{
			get
			{
				return this._znx_fssj;
			}
			set
			{
				if ((this._znx_fssj != value))
				{
					this.Onznx_fssjChanging(value);
					this.SendPropertyChanging();
					this._znx_fssj = value;
					this.SendPropertyChanged("znx_fssj");
					this.Onznx_fssjChanged();
				}
			}
		}
		
		[Column(Storage="_znx_isread", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string znx_isread
		{
			get
			{
				return this._znx_isread;
			}
			set
			{
				if ((this._znx_isread != value))
				{
					this.Onznx_isreadChanging(value);
					this.SendPropertyChanging();
					this._znx_isread = value;
					this.SendPropertyChanged("znx_isread");
					this.Onznx_isreadChanged();
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
