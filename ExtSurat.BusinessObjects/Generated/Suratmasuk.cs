
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
	/// Encapsulates the 'suratmasuk' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Suratmasuk))]	
	[XmlType("Suratmasuk")]
	public partial class Suratmasuk : esSuratmasuk
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Suratmasuk();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 masukid)
		{
			var obj = new Suratmasuk();
			obj.Masukid = masukid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 masukid, esSqlAccessType sqlAccessType)
		{
			var obj = new Suratmasuk();
			obj.Masukid = masukid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("SuratmasukCollection")]
	public partial class SuratmasukCollection : esSuratmasukCollection, IEnumerable<Suratmasuk>
	{
		public Suratmasuk FindByPrimaryKey(System.Int32 masukid)
		{
			return this.SingleOrDefault(e => e.Masukid == masukid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Suratmasuk))]
		public class SuratmasukCollectionWCFPacket : esCollectionWCFPacket<SuratmasukCollection>
		{
			public static implicit operator SuratmasukCollection(SuratmasukCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SuratmasukCollectionWCFPacket(SuratmasukCollection collection)
			{
				return new SuratmasukCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SuratmasukQuery : esSuratmasukQuery
	{
		public SuratmasukQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SuratmasukQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SuratmasukQuery query)
		{
			return SuratmasukQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SuratmasukQuery(string query)
		{
			return (SuratmasukQuery)SuratmasukQuery.SerializeHelper.FromXml(query, typeof(SuratmasukQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSuratmasuk : esEntity
	{
		public esSuratmasuk()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 masukid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(masukid);
			else
				return LoadByPrimaryKeyStoredProcedure(masukid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 masukid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(masukid);
			else
				return LoadByPrimaryKeyStoredProcedure(masukid);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 masukid)
		{
			SuratmasukQuery query = new SuratmasukQuery();
			query.Where(query.Masukid == masukid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 masukid)
		{
			esParameters parms = new esParameters();
			parms.Add("Masukid", masukid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to suratmasuk.masukid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Masukid
		{
			get
			{
				return base.GetSystemInt32(SuratmasukMetadata.ColumnNames.Masukid);
			}
			
			set
			{
				if(base.SetSystemInt32(SuratmasukMetadata.ColumnNames.Masukid, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Masukid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.userid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Userid
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Userid);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Userid, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Userid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.nomorid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomorid
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Nomorid);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Nomorid, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Nomorid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.nomor
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomor
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Nomor);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Nomor, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Nomor);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.noasal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Noasal
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Noasal);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Noasal, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Noasal);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.judul
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Judul
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Judul);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Judul, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Judul);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.tanggal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Tanggal
		{
			get
			{
				return base.GetSystemDateTime(SuratmasukMetadata.ColumnNames.Tanggal);
			}
			
			set
			{
				if(base.SetSystemDateTime(SuratmasukMetadata.ColumnNames.Tanggal, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Tanggal);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.dari
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Dari
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Dari);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Dari, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Dari);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.berkas
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Berkas
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Berkas);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Berkas, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Berkas);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.keterangan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Keterangan
		{
			get
			{
				return base.GetSystemString(SuratmasukMetadata.ColumnNames.Keterangan);
			}
			
			set
			{
				if(base.SetSystemString(SuratmasukMetadata.ColumnNames.Keterangan, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Keterangan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to suratmasuk.lastedited
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Lastedited
		{
			get
			{
				return base.GetSystemDateTime(SuratmasukMetadata.ColumnNames.Lastedited);
			}
			
			set
			{
				if(base.SetSystemDateTime(SuratmasukMetadata.ColumnNames.Lastedited, value))
				{
					OnPropertyChanged(SuratmasukMetadata.PropertyNames.Lastedited);
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
						case "Masukid": this.str().Masukid = (string)value; break;							
						case "Userid": this.str().Userid = (string)value; break;							
						case "Nomorid": this.str().Nomorid = (string)value; break;							
						case "Nomor": this.str().Nomor = (string)value; break;							
						case "Noasal": this.str().Noasal = (string)value; break;							
						case "Judul": this.str().Judul = (string)value; break;							
						case "Tanggal": this.str().Tanggal = (string)value; break;							
						case "Dari": this.str().Dari = (string)value; break;							
						case "Berkas": this.str().Berkas = (string)value; break;							
						case "Keterangan": this.str().Keterangan = (string)value; break;							
						case "Lastedited": this.str().Lastedited = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Masukid":
						
							if (value == null || value is System.Int32)
								this.Masukid = (System.Int32?)value;
								OnPropertyChanged(SuratmasukMetadata.PropertyNames.Masukid);
							break;
						
						case "Tanggal":
						
							if (value == null || value is System.DateTime)
								this.Tanggal = (System.DateTime?)value;
								OnPropertyChanged(SuratmasukMetadata.PropertyNames.Tanggal);
							break;
						
						case "Lastedited":
						
							if (value == null || value is System.DateTime)
								this.Lastedited = (System.DateTime?)value;
								OnPropertyChanged(SuratmasukMetadata.PropertyNames.Lastedited);
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
			public esStrings(esSuratmasuk entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Masukid
			{
				get
				{
					System.Int32? data = entity.Masukid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Masukid = null;
					else entity.Masukid = Convert.ToInt32(value);
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
				
			public System.String Noasal
			{
				get
				{
					System.String data = entity.Noasal;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Noasal = null;
					else entity.Noasal = Convert.ToString(value);
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
				
			public System.String Dari
			{
				get
				{
					System.String data = entity.Dari;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Dari = null;
					else entity.Dari = Convert.ToString(value);
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
			

			private esSuratmasuk entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SuratmasukMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SuratmasukQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SuratmasukQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SuratmasukQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SuratmasukQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SuratmasukQuery query;		
	}



	[Serializable]
	abstract public partial class esSuratmasukCollection : esEntityCollection<Suratmasuk>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SuratmasukMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SuratmasukCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SuratmasukQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SuratmasukQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SuratmasukQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SuratmasukQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SuratmasukQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SuratmasukQuery)query);
		}

		#endregion
		
		private SuratmasukQuery query;
	}



	[Serializable]
	abstract public partial class esSuratmasukQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SuratmasukMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Masukid": return this.Masukid;
				case "Userid": return this.Userid;
				case "Nomorid": return this.Nomorid;
				case "Nomor": return this.Nomor;
				case "Noasal": return this.Noasal;
				case "Judul": return this.Judul;
				case "Tanggal": return this.Tanggal;
				case "Dari": return this.Dari;
				case "Berkas": return this.Berkas;
				case "Keterangan": return this.Keterangan;
				case "Lastedited": return this.Lastedited;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Masukid
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Masukid, esSystemType.Int32); }
		} 
		
		public esQueryItem Userid
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Userid, esSystemType.String); }
		} 
		
		public esQueryItem Nomorid
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Nomorid, esSystemType.String); }
		} 
		
		public esQueryItem Nomor
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Nomor, esSystemType.String); }
		} 
		
		public esQueryItem Noasal
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Noasal, esSystemType.String); }
		} 
		
		public esQueryItem Judul
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Judul, esSystemType.String); }
		} 
		
		public esQueryItem Tanggal
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Tanggal, esSystemType.DateTime); }
		} 
		
		public esQueryItem Dari
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Dari, esSystemType.String); }
		} 
		
		public esQueryItem Berkas
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Berkas, esSystemType.String); }
		} 
		
		public esQueryItem Keterangan
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Keterangan, esSystemType.String); }
		} 
		
		public esQueryItem Lastedited
		{
			get { return new esQueryItem(this, SuratmasukMetadata.ColumnNames.Lastedited, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}


	
	public partial class Suratmasuk : esSuratmasuk
	{

		
		
	}
	



	[Serializable]
	public partial class SuratmasukMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SuratmasukMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Masukid, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Masukid;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Userid, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Userid;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Nomorid, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Nomorid;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Nomor, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Nomor;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Noasal, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Noasal;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Judul, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Judul;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Tanggal, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Tanggal;
			c.HasDefault = true;
			c.Default = @"0000-00-00";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Dari, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Dari;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Berkas, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Berkas;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Keterangan, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Keterangan;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SuratmasukMetadata.ColumnNames.Lastedited, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SuratmasukMetadata.PropertyNames.Lastedited;
			c.HasDefault = true;
			c.Default = @"0000-00-00 00:00:00";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SuratmasukMetadata Meta()
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
			 public const string Masukid = "masukid";
			 public const string Userid = "userid";
			 public const string Nomorid = "nomorid";
			 public const string Nomor = "nomor";
			 public const string Noasal = "noasal";
			 public const string Judul = "judul";
			 public const string Tanggal = "tanggal";
			 public const string Dari = "dari";
			 public const string Berkas = "berkas";
			 public const string Keterangan = "keterangan";
			 public const string Lastedited = "lastedited";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Masukid = "Masukid";
			 public const string Userid = "Userid";
			 public const string Nomorid = "Nomorid";
			 public const string Nomor = "Nomor";
			 public const string Noasal = "Noasal";
			 public const string Judul = "Judul";
			 public const string Tanggal = "Tanggal";
			 public const string Dari = "Dari";
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
			lock (typeof(SuratmasukMetadata))
			{
				if(SuratmasukMetadata.mapDelegates == null)
				{
					SuratmasukMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SuratmasukMetadata.meta == null)
				{
					SuratmasukMetadata.meta = new SuratmasukMetadata();
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


				meta.AddTypeMap("Masukid", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Userid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomorid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomor", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Noasal", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Judul", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Tanggal", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("Dari", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Berkas", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Keterangan", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Lastedited", new esTypeMap("DATETIME", "System.DateTime"));			
				
				
				
				meta.Source = "suratmasuk";
				meta.Destination = "suratmasuk";
				
				meta.spInsert = "proc_suratmasukInsert";				
				meta.spUpdate = "proc_suratmasukUpdate";		
				meta.spDelete = "proc_suratmasukDelete";
				meta.spLoadAll = "proc_suratmasukLoadAll";
				meta.spLoadByPrimaryKey = "proc_suratmasukLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SuratmasukMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
