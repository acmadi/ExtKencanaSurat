
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
	/// Encapsulates the 'suratkeluar' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Suratkeluar))]	
	[XmlType("Suratkeluar")]
	public partial class Suratkeluar : esSuratkeluar
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Suratkeluar();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 keluarid)
		{
			var obj = new Suratkeluar();
			obj.Keluarid = keluarid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 keluarid, esSqlAccessType sqlAccessType)
		{
			var obj = new Suratkeluar();
			obj.Keluarid = keluarid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("SuratkeluarCollection")]
	public partial class SuratkeluarCollection : esSuratkeluarCollection, IEnumerable<Suratkeluar>
	{
		public Suratkeluar FindByPrimaryKey(System.Int32 keluarid)
		{
			return this.SingleOrDefault(e => e.Keluarid == keluarid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Suratkeluar))]
		public class SuratkeluarCollectionWCFPacket : esCollectionWCFPacket<SuratkeluarCollection>
		{
			public static implicit operator SuratkeluarCollection(SuratkeluarCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SuratkeluarCollectionWCFPacket(SuratkeluarCollection collection)
			{
				return new SuratkeluarCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SuratkeluarQuery : esSuratkeluarQuery
	{
		public SuratkeluarQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SuratkeluarQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SuratkeluarQuery query)
		{
			return SuratkeluarQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SuratkeluarQuery(string query)
		{
			return (SuratkeluarQuery)SuratkeluarQuery.SerializeHelper.FromXml(query, typeof(SuratkeluarQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSuratkeluar : esEntity
	{
		public esSuratkeluar()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 keluarid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(keluarid);
			else
				return LoadByPrimaryKeyStoredProcedure(keluarid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 keluarid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(keluarid);
			else
				return LoadByPrimaryKeyStoredProcedure(keluarid);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 keluarid)
		{
			SuratkeluarQuery query = new SuratkeluarQuery();
			query.Where(query.Keluarid == keluarid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 keluarid)
		{
			esParameters parms = new esParameters();
			parms.Add("Keluarid", keluarid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to suratkeluar.keluarid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Keluarid
		{
			get
			{
				return base.GetSystemInt32(SuratkeluarMetadata.ColumnNames.Keluarid);
			}
			
			set
			{
				if(base.SetSystemInt32(SuratkeluarMetadata.ColumnNames.Keluarid, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Keluarid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.userid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Userid
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Userid);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Userid, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Userid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.nomorid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomorid
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Nomorid);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Nomorid, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Nomorid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.kepada
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Kepada
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Kepada);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Kepada, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Kepada);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.nomor
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomor
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Nomor);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Nomor, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Nomor);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.judul
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Judul
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Judul);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Judul, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Judul);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.tanggal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Tanggal
		{
			get
			{
				return base.GetSystemDateTime(SuratkeluarMetadata.ColumnNames.Tanggal);
			}
			
			set
			{
				if(base.SetSystemDateTime(SuratkeluarMetadata.ColumnNames.Tanggal, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Tanggal);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.berkas
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Berkas
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Berkas);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Berkas, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Berkas);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.keterangan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Keterangan
		{
			get
			{
				return base.GetSystemString(SuratkeluarMetadata.ColumnNames.Keterangan);
			}
			
			set
			{
				if(base.SetSystemString(SuratkeluarMetadata.ColumnNames.Keterangan, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Keterangan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratkeluar.lastedited
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Lastedited
		{
			get
			{
				return base.GetSystemDateTime(SuratkeluarMetadata.ColumnNames.Lastedited);
			}
			
			set
			{
				if(base.SetSystemDateTime(SuratkeluarMetadata.ColumnNames.Lastedited, value))
				{
					OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Lastedited);
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
						case "Keluarid": this.str().Keluarid = (string)value; break;							
						case "Userid": this.str().Userid = (string)value; break;							
						case "Nomorid": this.str().Nomorid = (string)value; break;							
						case "Kepada": this.str().Kepada = (string)value; break;							
						case "Nomor": this.str().Nomor = (string)value; break;							
						case "Judul": this.str().Judul = (string)value; break;							
						case "Tanggal": this.str().Tanggal = (string)value; break;							
						case "Berkas": this.str().Berkas = (string)value; break;							
						case "Keterangan": this.str().Keterangan = (string)value; break;							
						case "Lastedited": this.str().Lastedited = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Keluarid":
						
							if (value == null || value is System.Int32)
								this.Keluarid = (System.Int32?)value;
								OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Keluarid);
							break;
						
						case "Tanggal":
						
							if (value == null || value is System.DateTime)
								this.Tanggal = (System.DateTime?)value;
								OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Tanggal);
							break;
						
						case "Lastedited":
						
							if (value == null || value is System.DateTime)
								this.Lastedited = (System.DateTime?)value;
								OnPropertyChanged(SuratkeluarMetadata.PropertyNames.Lastedited);
							break;
					

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
			public esStrings(esSuratkeluar entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Keluarid
			{
				get
				{
					System.Int32? data = entity.Keluarid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Keluarid = null;
					else entity.Keluarid = Convert.ToInt32(value);
				}
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
				
			public System.String Nomorid
			{
				get
				{
					System.String data = entity.Nomorid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Nomorid = null;
					else entity.Nomorid = Convert.ToString(value);
				}
			}
				
			public System.String Kepada
			{
				get
				{
					System.String data = entity.Kepada;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Kepada = null;
					else entity.Kepada = Convert.ToString(value);
				}
			}
				
			public System.String Nomor
			{
				get
				{
					System.String data = entity.Nomor;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Nomor = null;
					else entity.Nomor = Convert.ToString(value);
				}
			}
				
			public System.String Judul
			{
				get
				{
					System.String data = entity.Judul;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Judul = null;
					else entity.Judul = Convert.ToString(value);
				}
			}
				
			public System.String Tanggal
			{
				get
				{
					System.DateTime? data = entity.Tanggal;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Tanggal = null;
					else entity.Tanggal = Convert.ToDateTime(value);
				}
			}
				
			public System.String Berkas
			{
				get
				{
					System.String data = entity.Berkas;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Berkas = null;
					else entity.Berkas = Convert.ToString(value);
				}
			}
				
			public System.String Keterangan
			{
				get
				{
					System.String data = entity.Keterangan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Keterangan = null;
					else entity.Keterangan = Convert.ToString(value);
				}
			}
				
			public System.String Lastedited
			{
				get
				{
					System.DateTime? data = entity.Lastedited;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Lastedited = null;
					else entity.Lastedited = Convert.ToDateTime(value);
				}
			}
			

			private esSuratkeluar entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SuratkeluarMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SuratkeluarQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SuratkeluarQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SuratkeluarQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SuratkeluarQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SuratkeluarQuery query;		
	}



	[Serializable]
	abstract public partial class esSuratkeluarCollection : esEntityCollection<Suratkeluar>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SuratkeluarMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SuratkeluarCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SuratkeluarQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SuratkeluarQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SuratkeluarQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SuratkeluarQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SuratkeluarQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SuratkeluarQuery)query);
		}

		#endregion
		
		private SuratkeluarQuery query;
	}



	[Serializable]
	abstract public partial class esSuratkeluarQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SuratkeluarMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Keluarid": return this.Keluarid;
				case "Userid": return this.Userid;
				case "Nomorid": return this.Nomorid;
				case "Kepada": return this.Kepada;
				case "Nomor": return this.Nomor;
				case "Judul": return this.Judul;
				case "Tanggal": return this.Tanggal;
				case "Berkas": return this.Berkas;
				case "Keterangan": return this.Keterangan;
				case "Lastedited": return this.Lastedited;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Keluarid
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Keluarid, esSystemType.Int32); }
		} 
		
		public esQueryItem Userid
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Userid, esSystemType.String); }
		} 
		
		public esQueryItem Nomorid
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Nomorid, esSystemType.String); }
		} 
		
		public esQueryItem Kepada
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Kepada, esSystemType.String); }
		} 
		
		public esQueryItem Nomor
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Nomor, esSystemType.String); }
		} 
		
		public esQueryItem Judul
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Judul, esSystemType.String); }
		} 
		
		public esQueryItem Tanggal
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Tanggal, esSystemType.DateTime); }
		} 
		
		public esQueryItem Berkas
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Berkas, esSystemType.String); }
		} 
		
		public esQueryItem Keterangan
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Keterangan, esSystemType.String); }
		} 
		
		public esQueryItem Lastedited
		{
			get { return new esQueryItem(this, SuratkeluarMetadata.ColumnNames.Lastedited, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}


	
	public partial class Suratkeluar : esSuratkeluar
	{

		
		
	}
	



	[Serializable]
	public partial class SuratkeluarMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SuratkeluarMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Keluarid, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Keluarid;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Userid, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Userid;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Nomorid, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Nomorid;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Kepada, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Kepada;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Nomor, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Nomor;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Judul, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Judul;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Tanggal, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Tanggal;
			c.HasDefault = true;
			c.Default = @"0000-00-00";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Berkas, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Berkas;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Keterangan, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Keterangan;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratkeluarMetadata.ColumnNames.Lastedited, 9, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SuratkeluarMetadata.PropertyNames.Lastedited;
			c.HasDefault = true;
			c.Default = @"0000-00-00 00:00:00";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SuratkeluarMetadata Meta()
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
			 public const string Keluarid = "keluarid";
			 public const string Userid = "userid";
			 public const string Nomorid = "nomorid";
			 public const string Kepada = "kepada";
			 public const string Nomor = "nomor";
			 public const string Judul = "judul";
			 public const string Tanggal = "tanggal";
			 public const string Berkas = "berkas";
			 public const string Keterangan = "keterangan";
			 public const string Lastedited = "lastedited";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Keluarid = "Keluarid";
			 public const string Userid = "Userid";
			 public const string Nomorid = "Nomorid";
			 public const string Kepada = "Kepada";
			 public const string Nomor = "Nomor";
			 public const string Judul = "Judul";
			 public const string Tanggal = "Tanggal";
			 public const string Berkas = "Berkas";
			 public const string Keterangan = "Keterangan";
			 public const string Lastedited = "Lastedited";
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
			lock (typeof(SuratkeluarMetadata))
			{
				if(SuratkeluarMetadata.mapDelegates == null)
				{
					SuratkeluarMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SuratkeluarMetadata.meta == null)
				{
					SuratkeluarMetadata.meta = new SuratkeluarMetadata();
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


				meta.AddTypeMap("Keluarid", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Userid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomorid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Kepada", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomor", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Judul", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Tanggal", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("Berkas", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Keterangan", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Lastedited", new esTypeMap("DATETIME", "System.DateTime"));			
				
				
				
				meta.Source = "suratkeluar";
				meta.Destination = "suratkeluar";
				
				meta.spInsert = "proc_suratkeluarInsert";				
				meta.spUpdate = "proc_suratkeluarUpdate";		
				meta.spDelete = "proc_suratkeluarDelete";
				meta.spLoadAll = "proc_suratkeluarLoadAll";
				meta.spLoadByPrimaryKey = "proc_suratkeluarLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SuratkeluarMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
