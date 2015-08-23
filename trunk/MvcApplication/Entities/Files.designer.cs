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
	public partial class FilesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertwjgl_files(wjgl_files instance);
    partial void Updatewjgl_files(wjgl_files instance);
    partial void Deletewjgl_files(wjgl_files instance);
    #endregion
		
		public FilesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zsgl_solutionConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FilesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<wjgl_files> wjgl_files
		{
			get
			{
				return this.GetTable<wjgl_files>();
			}
		}
	}
	
	[Table(Name="dbo.wjgl_files")]
	public partial class wjgl_files : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _file_id;
		
		private int _user_id;
		
		private string _file_name;
		
		private string _file_bz;
		
		private string _file_path;
		
		private string _file_scsj;
		
		private string _floder_name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onfile_idChanging(string value);
    partial void Onfile_idChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onfile_nameChanging(string value);
    partial void Onfile_nameChanged();
    partial void Onfile_bzChanging(string value);
    partial void Onfile_bzChanged();
    partial void Onfile_pathChanging(string value);
    partial void Onfile_pathChanged();
    partial void Onfile_scsjChanging(string value);
    partial void Onfile_scsjChanged();
    partial void Onfloder_nameChanging(string value);
    partial void Onfloder_nameChanged();
    #endregion
		
		public wjgl_files()
		{
			OnCreated();
		}
		
		[Column(Storage="_file_id", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[Column(Storage="_file_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string file_name
		{
			get
			{
				return this._file_name;
			}
			set
			{
				if ((this._file_name != value))
				{
					this.Onfile_nameChanging(value);
					this.SendPropertyChanging();
					this._file_name = value;
					this.SendPropertyChanged("file_name");
					this.Onfile_nameChanged();
				}
			}
		}
		
		[Column(Storage="_file_bz", DbType="VarChar(200)")]
		public string file_bz
		{
			get
			{
				return this._file_bz;
			}
			set
			{
				if ((this._file_bz != value))
				{
					this.Onfile_bzChanging(value);
					this.SendPropertyChanging();
					this._file_bz = value;
					this.SendPropertyChanged("file_bz");
					this.Onfile_bzChanged();
				}
			}
		}
		
		[Column(Storage="_file_path", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string file_path
		{
			get
			{
				return this._file_path;
			}
			set
			{
				if ((this._file_path != value))
				{
					this.Onfile_pathChanging(value);
					this.SendPropertyChanging();
					this._file_path = value;
					this.SendPropertyChanged("file_path");
					this.Onfile_pathChanged();
				}
			}
		}
		
		[Column(Storage="_file_scsj", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string file_scsj
		{
			get
			{
				return this._file_scsj;
			}
			set
			{
				if ((this._file_scsj != value))
				{
					this.Onfile_scsjChanging(value);
					this.SendPropertyChanging();
					this._file_scsj = value;
					this.SendPropertyChanged("file_scsj");
					this.Onfile_scsjChanged();
				}
			}
		}
		
		[Column(Storage="_floder_name", DbType="VarChar(50)")]
		public string floder_name
		{
			get
			{
				return this._floder_name;
			}
			set
			{
				if ((this._floder_name != value))
				{
					this.Onfloder_nameChanging(value);
					this.SendPropertyChanging();
					this._floder_name = value;
					this.SendPropertyChanged("floder_name");
					this.Onfloder_nameChanged();
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
