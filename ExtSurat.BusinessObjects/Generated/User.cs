
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : MySql
Date Generated       : 12/12/2012 3:36:07 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace ExtSurat.BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'user' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(User))]	
	[XmlType("User")]
	public partial class User : esUser
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new User();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String userid)
		{
			var obj = new User();
			obj.Userid = userid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String userid, esSqlAccessType sqlAccessType)
		{
			var obj = new User();
			obj.Userid = userid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("UserCollection")]
	public partial class UserCollection : esUserCollection, IEnumerable<User>
	{
		public User FindByPrimaryKey(System.String userid)
		{
			return this.SingleOrDefault(e => e.Userid == userid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(User))]
		public class UserCollectionWCFPacket : esCollectionWCFPacket<UserCollection>
		{
			public static implicit operator UserCollection(UserCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator UserCollectionWCFPacket(UserCollection collection)
			{
				return new UserCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class UserQuery : esUserQuery
	{
		public UserQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "UserQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(UserQuery query)
		{
			return UserQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator UserQuery(string query)
		{
			return (UserQuery)UserQuery.SerializeHelper.FromXml(query, typeof(UserQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esUser : esEntity
	{
		public esUser()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String userid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userid);
			else
				return LoadByPrimaryKeyStoredProcedure(userid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String userid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userid);
			else
				return LoadByPrimaryKeyStoredProcedure(userid);
		}

		private bool LoadByPrimaryKeyDynamic(System.String userid)
		{
			UserQuery query = new UserQuery();
			query.Where(query.Userid == userid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String userid)
		{
			esParameters parms = new esParameters();
			parms.Add("Userid", userid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to user.userid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Userid
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Userid);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Userid, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Userid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.password
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Password
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Password);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Password, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Password);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.nama
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nama
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Nama);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Nama, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Nama);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.jabatan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Jabatan
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Jabatan);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Jabatan, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Jabatan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.divisi
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Divisi
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Divisi);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Divisi, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Divisi);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.lokasi
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Lokasi
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Lokasi);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Lokasi, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Lokasi);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.level
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Level
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Level);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Level, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Level);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.aktif
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Aktif
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.Aktif);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.Aktif, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.Aktif);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S0
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S0
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S0);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S0, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S0);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S1
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S1);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S1, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S2
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S2);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S2, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S3
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S3
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S3);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S3, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S3);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S4
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S4
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S4);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S4, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S4);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S5
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S5
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S5);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S5, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S5);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S6
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S6
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S6);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S6, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S6);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S7
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S7
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S7);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S7, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S7);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.S8
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S8
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.S8);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.S8, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.S8);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.L0
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String L0
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.L0);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.L0, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.L0);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.L1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String L1
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.L1);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.L1, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.L1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.L2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String L2
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.L2);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.L2, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.L2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to user.L3
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String L3
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.L3);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.L3, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.L3);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "Userid": this.str().Userid = (string)value; break;							
						case "Password": this.str().Password = (string)value; break;							
						case "Nama": this.str().Nama = (string)value; break;							
						case "Jabatan": this.str().Jabatan = (string)value; break;							
						case "Divisi": this.str().Divisi = (string)value; break;							
						case "Lokasi": this.str().Lokasi = (string)value; break;							
						case "Level": this.str().Level = (string)value; break;							
						case "Aktif": this.str().Aktif = (string)value; break;							
						case "S0": this.str().S0 = (string)value; break;							
						case "S1": this.str().S1 = (string)value; break;							
						case "S2": this.str().S2 = (string)value; break;							
						case "S3": this.str().S3 = (string)value; break;							
						case "S4": this.str().S4 = (string)value; break;							
						case "S5": this.str().S5 = (string)value; break;							
						case "S6": this.str().S6 = (string)value; break;							
						case "S7": this.str().S7 = (string)value; break;							
						case "S8": this.str().S8 = (string)value; break;							
						case "L0": this.str().L0 = (string)value; break;							
						case "L1": this.str().L1 = (string)value; break;							
						case "L2": this.str().L2 = (string)value; break;							
						case "L3": this.str().L3 = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esUser entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Userid
			{
				get
				{
					System.String data = entity.Userid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Userid = null;
					else entity.Userid = Convert.ToString(value);
				}
			}
				
			public System.String Password
			{
				get
				{
					System.String data = entity.Password;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Password = null;
					else entity.Password = Convert.ToString(value);
				}
			}
				
			public System.String Nama
			{
				get
				{
					System.String data = entity.Nama;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Nama = null;
					else entity.Nama = Convert.ToString(value);
				}
			}
				
			public System.String Jabatan
			{
				get
				{
					System.String data = entity.Jabatan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Jabatan = null;
					else entity.Jabatan = Convert.ToString(value);
				}
			}
				
			public System.String Divisi
			{
				get
				{
					System.String data = entity.Divisi;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Divisi = null;
					else entity.Divisi = Convert.ToString(value);
				}
			}
				
			public System.String Lokasi
			{
				get
				{
					System.String data = entity.Lokasi;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Lokasi = null;
					else entity.Lokasi = Convert.ToString(value);
				}
			}
				
			public System.String Level
			{
				get
				{
					System.String data = entity.Level;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Level = null;
					else entity.Level = Convert.ToString(value);
				}
			}
				
			public System.String Aktif
			{
				get
				{
					System.String data = entity.Aktif;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Aktif = null;
					else entity.Aktif = Convert.ToString(value);
				}
			}
				
			public System.String S0
			{
				get
				{
					System.String data = entity.S0;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S0 = null;
					else entity.S0 = Convert.ToString(value);
				}
			}
				
			public System.String S1
			{
				get
				{
					System.String data = entity.S1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S1 = null;
					else entity.S1 = Convert.ToString(value);
				}
			}
				
			public System.String S2
			{
				get
				{
					System.String data = entity.S2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S2 = null;
					else entity.S2 = Convert.ToString(value);
				}
			}
				
			public System.String S3
			{
				get
				{
					System.String data = entity.S3;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S3 = null;
					else entity.S3 = Convert.ToString(value);
				}
			}
				
			public System.String S4
			{
				get
				{
					System.String data = entity.S4;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S4 = null;
					else entity.S4 = Convert.ToString(value);
				}
			}
				
			public System.String S5
			{
				get
				{
					System.String data = entity.S5;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S5 = null;
					else entity.S5 = Convert.ToString(value);
				}
			}
				
			public System.String S6
			{
				get
				{
					System.String data = entity.S6;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S6 = null;
					else entity.S6 = Convert.ToString(value);
				}
			}
				
			public System.String S7
			{
				get
				{
					System.String data = entity.S7;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S7 = null;
					else entity.S7 = Convert.ToString(value);
				}
			}
				
			public System.String S8
			{
				get
				{
					System.String data = entity.S8;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S8 = null;
					else entity.S8 = Convert.ToString(value);
				}
			}
				
			public System.String L0
			{
				get
				{
					System.String data = entity.L0;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.L0 = null;
					else entity.L0 = Convert.ToString(value);
				}
			}
				
			public System.String L1
			{
				get
				{
					System.String data = entity.L1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.L1 = null;
					else entity.L1 = Convert.ToString(value);
				}
			}
				
			public System.String L2
			{
				get
				{
					System.String data = entity.L2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.L2 = null;
					else entity.L2 = Convert.ToString(value);
				}
			}
				
			public System.String L3
			{
				get
				{
					System.String data = entity.L3;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.L3 = null;
					else entity.L3 = Convert.ToString(value);
				}
			}
			

			private esUser entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public UserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new UserQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(UserQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(UserQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private UserQuery query;		
	}



	[Serializable]
	abstract public partial class esUserCollection : esEntityCollection<User>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "UserCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public UserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new UserQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(UserQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new UserQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(UserQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((UserQuery)query);
		}

		#endregion
		
		private UserQuery query;
	}



	[Serializable]
	abstract public partial class esUserQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Userid": return this.Userid;
				case "Password": return this.Password;
				case "Nama": return this.Nama;
				case "Jabatan": return this.Jabatan;
				case "Divisi": return this.Divisi;
				case "Lokasi": return this.Lokasi;
				case "Level": return this.Level;
				case "Aktif": return this.Aktif;
				case "S0": return this.S0;
				case "S1": return this.S1;
				case "S2": return this.S2;
				case "S3": return this.S3;
				case "S4": return this.S4;
				case "S5": return this.S5;
				case "S6": return this.S6;
				case "S7": return this.S7;
				case "S8": return this.S8;
				case "L0": return this.L0;
				case "L1": return this.L1;
				case "L2": return this.L2;
				case "L3": return this.L3;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Userid
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Userid, esSystemType.String); }
		} 
		
		public esQueryItem Password
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Password, esSystemType.String); }
		} 
		
		public esQueryItem Nama
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Nama, esSystemType.String); }
		} 
		
		public esQueryItem Jabatan
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Jabatan, esSystemType.String); }
		} 
		
		public esQueryItem Divisi
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Divisi, esSystemType.String); }
		} 
		
		public esQueryItem Lokasi
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Lokasi, esSystemType.String); }
		} 
		
		public esQueryItem Level
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Level, esSystemType.String); }
		} 
		
		public esQueryItem Aktif
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.Aktif, esSystemType.String); }
		} 
		
		public esQueryItem S0
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S0, esSystemType.String); }
		} 
		
		public esQueryItem S1
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S1, esSystemType.String); }
		} 
		
		public esQueryItem S2
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S2, esSystemType.String); }
		} 
		
		public esQueryItem S3
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S3, esSystemType.String); }
		} 
		
		public esQueryItem S4
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S4, esSystemType.String); }
		} 
		
		public esQueryItem S5
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S5, esSystemType.String); }
		} 
		
		public esQueryItem S6
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S6, esSystemType.String); }
		} 
		
		public esQueryItem S7
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S7, esSystemType.String); }
		} 
		
		public esQueryItem S8
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.S8, esSystemType.String); }
		} 
		
		public esQueryItem L0
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.L0, esSystemType.String); }
		} 
		
		public esQueryItem L1
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.L1, esSystemType.String); }
		} 
		
		public esQueryItem L2
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.L2, esSystemType.String); }
		} 
		
		public esQueryItem L3
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.L3, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class User : esUser
	{

		
		
	}
	



	[Serializable]
	public partial class UserMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected UserMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(UserMetadata.ColumnNames.Userid, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Userid;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Password, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Password;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Nama, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Nama;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Jabatan, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Jabatan;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Divisi, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Divisi;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Lokasi, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Lokasi;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Level, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Level;
			c.HasDefault = true;
			c.Default = @"User";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.Aktif, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.Aktif;
			c.HasDefault = true;
			c.Default = @"Y";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S0, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S0;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;D;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S1, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S1;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"N;D;N;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S2, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S2;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"N;N;N;N;N";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S3, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S3;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;Y;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S4, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S4;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"N;D;N;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S5, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S5;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;Y;N;N;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S6, 14, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S6;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;Y;N;N;N";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S7, 15, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S7;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;Y;N;N;N";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.S8, 16, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.S8;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"N;D;N;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.L0, 17, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.L0;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;D;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.L1, 18, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.L1;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;D;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.L2, 19, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.L2;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;D;D;D";
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.L3, 20, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.L3;
			c.CharacterMaxLength = 9;
			c.HasDefault = true;
			c.Default = @"Y;D;D;D;D";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public UserMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Userid = "userid";
			 public const string Password = "password";
			 public const string Nama = "nama";
			 public const string Jabatan = "jabatan";
			 public const string Divisi = "divisi";
			 public const string Lokasi = "lokasi";
			 public const string Level = "level";
			 public const string Aktif = "aktif";
			 public const string S0 = "S0";
			 public const string S1 = "S1";
			 public const string S2 = "S2";
			 public const string S3 = "S3";
			 public const string S4 = "S4";
			 public const string S5 = "S5";
			 public const string S6 = "S6";
			 public const string S7 = "S7";
			 public const string S8 = "S8";
			 public const string L0 = "L0";
			 public const string L1 = "L1";
			 public const string L2 = "L2";
			 public const string L3 = "L3";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Userid = "Userid";
			 public const string Password = "Password";
			 public const string Nama = "Nama";
			 public const string Jabatan = "Jabatan";
			 public const string Divisi = "Divisi";
			 public const string Lokasi = "Lokasi";
			 public const string Level = "Level";
			 public const string Aktif = "Aktif";
			 public const string S0 = "S0";
			 public const string S1 = "S1";
			 public const string S2 = "S2";
			 public const string S3 = "S3";
			 public const string S4 = "S4";
			 public const string S5 = "S5";
			 public const string S6 = "S6";
			 public const string S7 = "S7";
			 public const string S8 = "S8";
			 public const string L0 = "L0";
			 public const string L1 = "L1";
			 public const string L2 = "L2";
			 public const string L3 = "L3";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(UserMetadata))
			{
				if(UserMetadata.mapDelegates == null)
				{
					UserMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (UserMetadata.meta == null)
				{
					UserMetadata.meta = new UserMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("Userid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Password", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nama", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Jabatan", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Divisi", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Lokasi", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Level", new esTypeMap("ENUM", "System.String"));
				meta.AddTypeMap("Aktif", new esTypeMap("ENUM", "System.String"));
				meta.AddTypeMap("S0", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S1", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S2", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S3", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S4", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S5", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S6", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S7", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("S8", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("L0", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("L1", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("L2", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("L3", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				meta.Source = "user";
				meta.Destination = "user";
				
				meta.spInsert = "proc_userInsert";				
				meta.spUpdate = "proc_userUpdate";		
				meta.spDelete = "proc_userDelete";
				meta.spLoadAll = "proc_userLoadAll";
				meta.spLoadByPrimaryKey = "proc_userLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private UserMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
