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
	public partial class FriendDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserthygl_friend(hygl_friend instance);
    partial void Updatehygl_friend(hygl_friend instance);
    partial void Deletehygl_friend(hygl_friend instance);
    #endregion
		
		public FriendDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FriendDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FriendDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FriendDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FriendDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<hygl_friend> hygl_friend
		{
			get
			{
				return this.GetTable<hygl_friend>();
			}
		}
	}
	
	[Table(Name="dbo.hygl_friend")]
	public partial class hygl_friend : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _hygx_id;
		
		private int _hy1_id;
		
		private int _hy2_id;
		
		private string _hy_time;
		
		private System.Nullable<int> _group_id;
		
		private string _hy_bz;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onhygx_idChanging(int value);
    partial void Onhygx_idChanged();
    partial void Onhy1_idChanging(int value);
    partial void Onhy1_idChanged();
    partial void Onhy2_idChanging(int value);
    partial void Onhy2_idChanged();
    partial void Onhy_timeChanging(string value);
    partial void Onhy_timeChanged();
    partial void Ongroup_idChanging(System.Nullable<int> value);
    partial void Ongroup_idChanged();
    partial void Onhy_bzChanging(string value);
    partial void Onhy_bzChanged();
    #endregion
		
		public hygl_friend()
		{
			OnCreated();
		}
		
		[Column(Storage="_hygx_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int hygx_id
		{
			get
			{
				return this._hygx_id;
			}
			set
			{
				if ((this._hygx_id != value))
				{
					this.Onhygx_idChanging(value);
					this.SendPropertyChanging();
					this._hygx_id = value;
					this.SendPropertyChanged("hygx_id");
					this.Onhygx_idChanged();
				}
			}
		}
		
		[Column(Storage="_hy1_id", DbType="Int NOT NULL")]
		public int hy1_id
		{
			get
			{
				return this._hy1_id;
			}
			set
			{
				if ((this._hy1_id != value))
				{
					this.Onhy1_idChanging(value);
					this.SendPropertyChanging();
					this._hy1_id = value;
					this.SendPropertyChanged("hy1_id");
					this.Onhy1_idChanged();
				}
			}
		}
		
		[Column(Storage="_hy2_id", DbType="Int NOT NULL")]
		public int hy2_id
		{
			get
			{
				return this._hy2_id;
			}
			set
			{
				if ((this._hy2_id != value))
				{
					this.Onhy2_idChanging(value);
					this.SendPropertyChanging();
					this._hy2_id = value;
					this.SendPropertyChanged("hy2_id");
					this.Onhy2_idChanged();
				}
			}
		}
		
		[Column(Storage="_hy_time", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string hy_time
		{
			get
			{
				return this._hy_time;
			}
			set
			{
				if ((this._hy_time != value))
				{
					this.Onhy_timeChanging(value);
					this.SendPropertyChanging();
					this._hy_time = value;
					this.SendPropertyChanged("hy_time");
					this.Onhy_timeChanged();
				}
			}
		}
		
		[Column(Storage="_group_id", DbType="Int")]
		public System.Nullable<int> group_id
		{
			get
			{
				return this._group_id;
			}
			set
			{
				if ((this._group_id != value))
				{
					this.Ongroup_idChanging(value);
					this.SendPropertyChanging();
					this._group_id = value;
					this.SendPropertyChanged("group_id");
					this.Ongroup_idChanged();
				}
			}
		}
		
		[Column(Storage="_hy_bz", DbType="VarChar(50)")]
		public string hy_bz
		{
			get
			{
				return this._hy_bz;
			}
			set
			{
				if ((this._hy_bz != value))
				{
					this.Onhy_bzChanging(value);
					this.SendPropertyChanging();
					this._hy_bz = value;
					this.SendPropertyChanged("hy_bz");
					this.Onhy_bzChanged();
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
