
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
	/// Encapsulates the 'perusahaan' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Perusahaan))]	
	[XmlType("Perusahaan")]
	public partial class Perusahaan : esPerusahaan
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Perusahaan();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 kode)
		{
			var obj = new Perusahaan();
			obj.Kode = kode;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 kode, esSqlAccessType sqlAccessType)
		{
			var obj = new Perusahaan();
			obj.Kode = kode;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("PerusahaanCollection")]
	public partial class PerusahaanCollection : esPerusahaanCollection, IEnumerable<Perusahaan>
	{
		public Perusahaan FindByPrimaryKey(System.Int32 kode)
		{
			return this.SingleOrDefault(e => e.Kode == kode);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Perusahaan))]
		public class PerusahaanCollectionWCFPacket : esCollectionWCFPacket<PerusahaanCollection>
		{
			public static implicit operator PerusahaanCollection(PerusahaanCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator PerusahaanCollectionWCFPacket(PerusahaanCollection collection)
			{
				return new PerusahaanCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class PerusahaanQuery : esPerusahaanQuery
	{
		public PerusahaanQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "PerusahaanQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(PerusahaanQuery query)
		{
			return PerusahaanQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator PerusahaanQuery(string query)
		{
			return (PerusahaanQuery)PerusahaanQuery.SerializeHelper.FromXml(query, typeof(PerusahaanQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esPerusahaan : esEntity
	{
		public esPerusahaan()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 kode)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(kode);
			else
				return LoadByPrimaryKeyStoredProcedure(kode);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 kode)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(kode);
			else
				return LoadByPrimaryKeyStoredProcedure(kode);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 kode)
		{
			PerusahaanQuery query = new PerusahaanQuery();
			query.Where(query.Kode == kode);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 kode)
		{
			esParameters parms = new esParameters();
			parms.Add("Kode", kode);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to perusahaan.kode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Kode
		{
			get
			{
				return base.GetSystemInt32(PerusahaanMetadata.ColumnNames.Kode);
			}
			
			set
			{
				if(base.SetSystemInt32(PerusahaanMetadata.ColumnNames.Kode, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Kode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.nama
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nama
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Nama);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Nama, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Nama);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.slogan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Slogan
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Slogan);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Slogan, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Slogan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.alamat
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Alamat
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Alamat);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Alamat, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Alamat);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.kota
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Kota
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Kota);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Kota, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Kota);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.telepon
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Telepon
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Telepon);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Telepon, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Telepon);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.fax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Fax
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Fax);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Fax, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Fax);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.email
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Email
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Email);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Email, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Email);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.logo
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Logo
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Logo);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Logo, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Logo);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.format
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Format
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Format);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Format, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Format);
				}
			}
		}		
		
		/// <summary>
		/// Maps to perusahaan.size
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Size
		{
			get
			{
				return base.GetSystemString(PerusahaanMetadata.ColumnNames.Size);
			}
			
			set
			{
				if(base.SetSystemString(PerusahaanMetadata.ColumnNames.Size, value))
				{
					OnPropertyChanged(PerusahaanMetadata.PropertyNames.Size);
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
						case "Kode": this.str().Kode = (string)value; break;							
						case "Nama": this.str().Nama = (string)value; break;							
						case "Slogan": this.str().Slogan = (string)value; break;							
						case "Alamat": this.str().Alamat = (string)value; break;							
						case "Kota": this.str().Kota = (string)value; break;							
						case "Telepon": this.str().Telepon = (string)value; break;							
						case "Fax": this.str().Fax = (string)value; break;							
						case "Email": this.str().Email = (string)value; break;							
						case "Logo": this.str().Logo = (string)value; break;							
						case "Format": this.str().Format = (string)value; break;							
						case "Size": this.str().Size = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Kode":
						
							if (value == null || value is System.Int32)
								this.Kode = (System.Int32?)value;
								OnPropertyChanged(PerusahaanMetadata.PropertyNames.Kode);
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
			public esStrings(esPerusahaan entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Kode
			{
				get
				{
					System.Int32? data = entity.Kode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Kode = null;
					else entity.Kode = Convert.ToInt32(value);
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
				
			public System.String Slogan
			{
				get
				{
					System.String data = entity.Slogan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Slogan = null;
					else entity.Slogan = Convert.ToString(value);
				}
			}
				
			public System.String Alamat
			{
				get
				{
					System.String data = entity.Alamat;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Alamat = null;
					else entity.Alamat = Convert.ToString(value);
				}
			}
				
			public System.String Kota
			{
				get
				{
					System.String data = entity.Kota;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Kota = null;
					else entity.Kota = Convert.ToString(value);
				}
			}
				
			public System.String Telepon
			{
				get
				{
					System.String data = entity.Telepon;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Telepon = null;
					else entity.Telepon = Convert.ToString(value);
				}
			}
				
			public System.String Fax
			{
				get
				{
					System.String data = entity.Fax;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Fax = null;
					else entity.Fax = Convert.ToString(value);
				}
			}
				
			public System.String Email
			{
				get
				{
					System.String data = entity.Email;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Email = null;
					else entity.Email = Convert.ToString(value);
				}
			}
				
			public System.String Logo
			{
				get
				{
					System.String data = entity.Logo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Logo = null;
					else entity.Logo = Convert.ToString(value);
				}
			}
				
			public System.String Format
			{
				get
				{
					System.String data = entity.Format;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Format = null;
					else entity.Format = Convert.ToString(value);
				}
			}
				
			public System.String Size
			{
				get
				{
					System.String data = entity.Size;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Size = null;
					else entity.Size = Convert.ToString(value);
				}
			}
			

			private esPerusahaan entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return PerusahaanMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public PerusahaanQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PerusahaanQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PerusahaanQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(PerusahaanQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private PerusahaanQuery query;		
	}



	[Serializable]
	abstract public partial class esPerusahaanCollection : esEntityCollection<Perusahaan>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return PerusahaanMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "PerusahaanCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public PerusahaanQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PerusahaanQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PerusahaanQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new PerusahaanQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(PerusahaanQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((PerusahaanQuery)query);
		}

		#endregion
		
		private PerusahaanQuery query;
	}



	[Serializable]
	abstract public partial class esPerusahaanQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return PerusahaanMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Kode": return this.Kode;
				case "Nama": return this.Nama;
				case "Slogan": return this.Slogan;
				case "Alamat": return this.Alamat;
				case "Kota": return this.Kota;
				case "Telepon": return this.Telepon;
				case "Fax": return this.Fax;
				case "Email": return this.Email;
				case "Logo": return this.Logo;
				case "Format": return this.Format;
				case "Size": return this.Size;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Kode
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Kode, esSystemType.Int32); }
		} 
		
		public esQueryItem Nama
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Nama, esSystemType.String); }
		} 
		
		public esQueryItem Slogan
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Slogan, esSystemType.String); }
		} 
		
		public esQueryItem Alamat
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Alamat, esSystemType.String); }
		} 
		
		public esQueryItem Kota
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Kota, esSystemType.String); }
		} 
		
		public esQueryItem Telepon
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Telepon, esSystemType.String); }
		} 
		
		public esQueryItem Fax
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Fax, esSystemType.String); }
		} 
		
		public esQueryItem Email
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Email, esSystemType.String); }
		} 
		
		public esQueryItem Logo
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Logo, esSystemType.String); }
		} 
		
		public esQueryItem Format
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Format, esSystemType.String); }
		} 
		
		public esQueryItem Size
		{
			get { return new esQueryItem(this, PerusahaanMetadata.ColumnNames.Size, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Perusahaan : esPerusahaan
	{

		
		
	}
	



	[Serializable]
	public partial class PerusahaanMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected PerusahaanMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Kode, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Kode;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Nama, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Nama;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Slogan, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Slogan;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Alamat, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Alamat;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Kota, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Kota;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Telepon, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Telepon;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Fax, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Fax;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Email, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Email;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Logo, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Logo;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Format, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Format;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PerusahaanMetadata.ColumnNames.Size, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = PerusahaanMetadata.PropertyNames.Size;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public PerusahaanMetadata Meta()
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
			 public const string Kode = "kode";
			 public const string Nama = "nama";
			 public const string Slogan = "slogan";
			 public const string Alamat = "alamat";
			 public const string Kota = "kota";
			 public const string Telepon = "telepon";
			 public const string Fax = "fax";
			 public const string Email = "email";
			 public const string Logo = "logo";
			 public const string Format = "format";
			 public const string Size = "size";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Kode = "Kode";
			 public const string Nama = "Nama";
			 public const string Slogan = "Slogan";
			 public const string Alamat = "Alamat";
			 public const string Kota = "Kota";
			 public const string Telepon = "Telepon";
			 public const string Fax = "Fax";
			 public const string Email = "Email";
			 public const string Logo = "Logo";
			 public const string Format = "Format";
			 public const string Size = "Size";
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
			lock (typeof(PerusahaanMetadata))
			{
				if(PerusahaanMetadata.mapDelegates == null)
				{
					PerusahaanMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (PerusahaanMetadata.meta == null)
				{
					PerusahaanMetadata.meta = new PerusahaanMetadata();
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


				meta.AddTypeMap("Kode", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Nama", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Slogan", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Alamat", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Kota", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Telepon", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Fax", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Email", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Logo", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Format", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Size", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				meta.Source = "perusahaan";
				meta.Destination = "perusahaan";
				
				meta.spInsert = "proc_perusahaanInsert";				
				meta.spUpdate = "proc_perusahaanUpdate";		
				meta.spDelete = "proc_perusahaanDelete";
				meta.spLoadAll = "proc_perusahaanLoadAll";
				meta.spLoadByPrimaryKey = "proc_perusahaanLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private PerusahaanMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
