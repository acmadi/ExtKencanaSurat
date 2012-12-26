
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
	/// Encapsulates the 'nomor' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Nomor))]	
	[XmlType("Nomor")]
	public partial class Nomor : esNomor
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Nomor();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 nomorid)
		{
			var obj = new Nomor();
			obj.Nomorid = nomorid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 nomorid, esSqlAccessType sqlAccessType)
		{
			var obj = new Nomor();
			obj.Nomorid = nomorid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("NomorCollection")]
	public partial class NomorCollection : esNomorCollection, IEnumerable<Nomor>
	{
		public Nomor FindByPrimaryKey(System.Int32 nomorid)
		{
			return this.SingleOrDefault(e => e.Nomorid == nomorid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Nomor))]
		public class NomorCollectionWCFPacket : esCollectionWCFPacket<NomorCollection>
		{
			public static implicit operator NomorCollection(NomorCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator NomorCollectionWCFPacket(NomorCollection collection)
			{
				return new NomorCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class NomorQuery : esNomorQuery
	{
		public NomorQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "NomorQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(NomorQuery query)
		{
			return NomorQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator NomorQuery(string query)
		{
			return (NomorQuery)NomorQuery.SerializeHelper.FromXml(query, typeof(NomorQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esNomor : esEntity
	{
		public esNomor()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 nomorid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(nomorid);
			else
				return LoadByPrimaryKeyStoredProcedure(nomorid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 nomorid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(nomorid);
			else
				return LoadByPrimaryKeyStoredProcedure(nomorid);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 nomorid)
		{
			NomorQuery query = new NomorQuery();
			query.Where(query.Nomorid == nomorid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 nomorid)
		{
			esParameters parms = new esParameters();
			parms.Add("Nomorid", nomorid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to nomor.nomorid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Nomorid
		{
			get
			{
				return base.GetSystemInt32(NomorMetadata.ColumnNames.Nomorid);
			}
			
			set
			{
				if(base.SetSystemInt32(NomorMetadata.ColumnNames.Nomorid, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Nomorid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.userid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Userid
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Userid);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Userid, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Userid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.format
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Format
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Format);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Format, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Format);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.batas
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Batas
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Batas);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Batas, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Batas);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.nomor
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomor
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Nomor);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Nomor, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Nomor);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.organisasi
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Organisasi
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Organisasi);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Organisasi, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Organisasi);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.bagian
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Bagian
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Bagian);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Bagian, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Bagian);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.subagian
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Subagian
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Subagian);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Subagian, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Subagian);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.bulan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Bulan
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Bulan);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Bulan, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Bulan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.tahun
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Tahun
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Tahun);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Tahun, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Tahun);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.prefix
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Prefix
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Prefix);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Prefix, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Prefix);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.jenis
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Jenis
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Jenis);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Jenis, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Jenis);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.reset
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Reset
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Reset);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Reset, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Reset);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomor.Keterangan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Keterangan
		{
			get
			{
				return base.GetSystemString(NomorMetadata.ColumnNames.Keterangan);
			}
			
			set
			{
				if(base.SetSystemString(NomorMetadata.ColumnNames.Keterangan, value))
				{
					OnPropertyChanged(NomorMetadata.PropertyNames.Keterangan);
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
						case "Nomorid": this.str().Nomorid = (string)value; break;							
						case "Userid": this.str().Userid = (string)value; break;							
						case "Format": this.str().Format = (string)value; break;							
						case "Batas": this.str().Batas = (string)value; break;							
						case "Nomor": this.str().Nomor = (string)value; break;							
						case "Organisasi": this.str().Organisasi = (string)value; break;							
						case "Bagian": this.str().Bagian = (string)value; break;							
						case "Subagian": this.str().Subagian = (string)value; break;							
						case "Bulan": this.str().Bulan = (string)value; break;							
						case "Tahun": this.str().Tahun = (string)value; break;							
						case "Prefix": this.str().Prefix = (string)value; break;							
						case "Jenis": this.str().Jenis = (string)value; break;							
						case "Reset": this.str().Reset = (string)value; break;							
						case "Keterangan": this.str().Keterangan = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Nomorid":
						
							if (value == null || value is System.Int32)
								this.Nomorid = (System.Int32?)value;
								OnPropertyChanged(NomorMetadata.PropertyNames.Nomorid);
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
			public esStrings(esNomor entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Nomorid
			{
				get
				{
					System.Int32? data = entity.Nomorid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Nomorid = null;
					else entity.Nomorid = Convert.ToInt32(value);
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
				
			public System.String Batas
			{
				get
				{
					System.String data = entity.Batas;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Batas = null;
					else entity.Batas = Convert.ToString(value);
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
				
			public System.String Organisasi
			{
				get
				{
					System.String data = entity.Organisasi;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Organisasi = null;
					else entity.Organisasi = Convert.ToString(value);
				}
			}
				
			public System.String Bagian
			{
				get
				{
					System.String data = entity.Bagian;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Bagian = null;
					else entity.Bagian = Convert.ToString(value);
				}
			}
				
			public System.String Subagian
			{
				get
				{
					System.String data = entity.Subagian;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Subagian = null;
					else entity.Subagian = Convert.ToString(value);
				}
			}
				
			public System.String Bulan
			{
				get
				{
					System.String data = entity.Bulan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Bulan = null;
					else entity.Bulan = Convert.ToString(value);
				}
			}
				
			public System.String Tahun
			{
				get
				{
					System.String data = entity.Tahun;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Tahun = null;
					else entity.Tahun = Convert.ToString(value);
				}
			}
				
			public System.String Prefix
			{
				get
				{
					System.String data = entity.Prefix;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Prefix = null;
					else entity.Prefix = Convert.ToString(value);
				}
			}
				
			public System.String Jenis
			{
				get
				{
					System.String data = entity.Jenis;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Jenis = null;
					else entity.Jenis = Convert.ToString(value);
				}
			}
				
			public System.String Reset
			{
				get
				{
					System.String data = entity.Reset;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Reset = null;
					else entity.Reset = Convert.ToString(value);
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
			

			private esNomor entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return NomorMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public NomorQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NomorQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NomorQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(NomorQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private NomorQuery query;		
	}



	[Serializable]
	abstract public partial class esNomorCollection : esEntityCollection<Nomor>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return NomorMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "NomorCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public NomorQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NomorQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NomorQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new NomorQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(NomorQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((NomorQuery)query);
		}

		#endregion
		
		private NomorQuery query;
	}



	[Serializable]
	abstract public partial class esNomorQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return NomorMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Nomorid": return this.Nomorid;
				case "Userid": return this.Userid;
				case "Format": return this.Format;
				case "Batas": return this.Batas;
				case "Nomor": return this.Nomor;
				case "Organisasi": return this.Organisasi;
				case "Bagian": return this.Bagian;
				case "Subagian": return this.Subagian;
				case "Bulan": return this.Bulan;
				case "Tahun": return this.Tahun;
				case "Prefix": return this.Prefix;
				case "Jenis": return this.Jenis;
				case "Reset": return this.Reset;
				case "Keterangan": return this.Keterangan;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Nomorid
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Nomorid, esSystemType.Int32); }
		} 
		
		public esQueryItem Userid
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Userid, esSystemType.String); }
		} 
		
		public esQueryItem Format
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Format, esSystemType.String); }
		} 
		
		public esQueryItem Batas
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Batas, esSystemType.String); }
		} 
		
		public esQueryItem Nomor
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Nomor, esSystemType.String); }
		} 
		
		public esQueryItem Organisasi
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Organisasi, esSystemType.String); }
		} 
		
		public esQueryItem Bagian
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Bagian, esSystemType.String); }
		} 
		
		public esQueryItem Subagian
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Subagian, esSystemType.String); }
		} 
		
		public esQueryItem Bulan
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Bulan, esSystemType.String); }
		} 
		
		public esQueryItem Tahun
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Tahun, esSystemType.String); }
		} 
		
		public esQueryItem Prefix
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Prefix, esSystemType.String); }
		} 
		
		public esQueryItem Jenis
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Jenis, esSystemType.String); }
		} 
		
		public esQueryItem Reset
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Reset, esSystemType.String); }
		} 
		
		public esQueryItem Keterangan
		{
			get { return new esQueryItem(this, NomorMetadata.ColumnNames.Keterangan, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Nomor : esNomor
	{

		
		
	}
	



	[Serializable]
	public partial class NomorMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected NomorMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(NomorMetadata.ColumnNames.Nomorid, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = NomorMetadata.PropertyNames.Nomorid;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Userid, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Userid;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Format, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Format;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Batas, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Batas;
			c.CharacterMaxLength = 1;
			c.HasDefault = true;
			c.Default = @"/";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Nomor, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Nomor;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Organisasi, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Organisasi;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Bagian, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Bagian;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Subagian, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Subagian;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Bulan, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Bulan;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-,N";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Tahun, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Tahun;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-,N";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Prefix, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Prefix;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"-,-";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Jenis, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Jenis;
			c.HasDefault = true;
			c.Default = @"suratkeluar";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Reset, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Reset;
			c.HasDefault = true;
			c.Default = @"tahun";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorMetadata.ColumnNames.Keterangan, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorMetadata.PropertyNames.Keterangan;
			c.CharacterMaxLength = 255;
			c.HasDefault = true;
			c.Default = @"-";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public NomorMetadata Meta()
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
			 public const string Nomorid = "nomorid";
			 public const string Userid = "userid";
			 public const string Format = "format";
			 public const string Batas = "batas";
			 public const string Nomor = "nomor";
			 public const string Organisasi = "organisasi";
			 public const string Bagian = "bagian";
			 public const string Subagian = "subagian";
			 public const string Bulan = "bulan";
			 public const string Tahun = "tahun";
			 public const string Prefix = "prefix";
			 public const string Jenis = "jenis";
			 public const string Reset = "reset";
			 public const string Keterangan = "Keterangan";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Nomorid = "Nomorid";
			 public const string Userid = "Userid";
			 public const string Format = "Format";
			 public const string Batas = "Batas";
			 public const string Nomor = "Nomor";
			 public const string Organisasi = "Organisasi";
			 public const string Bagian = "Bagian";
			 public const string Subagian = "Subagian";
			 public const string Bulan = "Bulan";
			 public const string Tahun = "Tahun";
			 public const string Prefix = "Prefix";
			 public const string Jenis = "Jenis";
			 public const string Reset = "Reset";
			 public const string Keterangan = "Keterangan";
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
			lock (typeof(NomorMetadata))
			{
				if(NomorMetadata.mapDelegates == null)
				{
					NomorMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NomorMetadata.meta == null)
				{
					NomorMetadata.meta = new NomorMetadata();
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


				meta.AddTypeMap("Nomorid", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Userid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Format", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Batas", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomor", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Organisasi", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Bagian", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Subagian", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Bulan", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Tahun", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Prefix", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Jenis", new esTypeMap("ENUM", "System.String"));
				meta.AddTypeMap("Reset", new esTypeMap("ENUM", "System.String"));
				meta.AddTypeMap("Keterangan", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				meta.Source = "nomor";
				meta.Destination = "nomor";
				
				meta.spInsert = "proc_nomorInsert";				
				meta.spUpdate = "proc_nomorUpdate";		
				meta.spDelete = "proc_nomorDelete";
				meta.spLoadAll = "proc_nomorLoadAll";
				meta.spLoadByPrimaryKey = "proc_nomorLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private NomorMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
