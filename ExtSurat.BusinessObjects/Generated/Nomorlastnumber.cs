
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : MySql
Date Generated       : 15/01/2013 10:01:23
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
	/// Encapsulates the 'nomorlastnumber' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Nomorlastnumber))]	
	[XmlType("Nomorlastnumber")]
	public partial class Nomorlastnumber : esNomorlastnumber
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Nomorlastnumber();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String format, System.String tahun)
		{
			var obj = new Nomorlastnumber();
			obj.Format = format;
			obj.Tahun = tahun;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String format, System.String tahun, esSqlAccessType sqlAccessType)
		{
			var obj = new Nomorlastnumber();
			obj.Format = format;
			obj.Tahun = tahun;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("NomorlastnumberCollection")]
	public partial class NomorlastnumberCollection : esNomorlastnumberCollection, IEnumerable<Nomorlastnumber>
	{
		public Nomorlastnumber FindByPrimaryKey(System.String format, System.String tahun)
		{
			return this.SingleOrDefault(e => e.Format == format && e.Tahun == tahun);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Nomorlastnumber))]
		public class NomorlastnumberCollectionWCFPacket : esCollectionWCFPacket<NomorlastnumberCollection>
		{
			public static implicit operator NomorlastnumberCollection(NomorlastnumberCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator NomorlastnumberCollectionWCFPacket(NomorlastnumberCollection collection)
			{
				return new NomorlastnumberCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class NomorlastnumberQuery : esNomorlastnumberQuery
	{
		public NomorlastnumberQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "NomorlastnumberQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(NomorlastnumberQuery query)
		{
			return NomorlastnumberQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator NomorlastnumberQuery(string query)
		{
			return (NomorlastnumberQuery)NomorlastnumberQuery.SerializeHelper.FromXml(query, typeof(NomorlastnumberQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esNomorlastnumber : esEntity
	{
		public esNomorlastnumber()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String format, System.String tahun)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(format, tahun);
			else
				return LoadByPrimaryKeyStoredProcedure(format, tahun);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String format, System.String tahun)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(format, tahun);
			else
				return LoadByPrimaryKeyStoredProcedure(format, tahun);
		}

		private bool LoadByPrimaryKeyDynamic(System.String format, System.String tahun)
		{
			NomorlastnumberQuery query = new NomorlastnumberQuery();
			query.Where(query.Format == format, query.Tahun == tahun);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String format, System.String tahun)
		{
			esParameters parms = new esParameters();
			parms.Add("Format", format);			parms.Add("Tahun", tahun);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to nomorlastnumber.format
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Format
		{
			get
			{
				return base.GetSystemString(NomorlastnumberMetadata.ColumnNames.Format);
			}
			
			set
			{
				if(base.SetSystemString(NomorlastnumberMetadata.ColumnNames.Format, value))
				{
					OnPropertyChanged(NomorlastnumberMetadata.PropertyNames.Format);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomorlastnumber.tahun
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Tahun
		{
			get
			{
				return base.GetSystemString(NomorlastnumberMetadata.ColumnNames.Tahun);
			}
			
			set
			{
				if(base.SetSystemString(NomorlastnumberMetadata.ColumnNames.Tahun, value))
				{
					OnPropertyChanged(NomorlastnumberMetadata.PropertyNames.Tahun);
				}
			}
		}		
		
		/// <summary>
		/// Maps to nomorlastnumber.lastnumber
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Lastnumber
		{
			get
			{
				return base.GetSystemInt32(NomorlastnumberMetadata.ColumnNames.Lastnumber);
			}
			
			set
			{
				if(base.SetSystemInt32(NomorlastnumberMetadata.ColumnNames.Lastnumber, value))
				{
					OnPropertyChanged(NomorlastnumberMetadata.PropertyNames.Lastnumber);
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
						case "Format": this.str().Format = (string)value; break;							
						case "Tahun": this.str().Tahun = (string)value; break;							
						case "Lastnumber": this.str().Lastnumber = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Lastnumber":
						
							if (value == null || value is System.Int32)
								this.Lastnumber = (System.Int32?)value;
								OnPropertyChanged(NomorlastnumberMetadata.PropertyNames.Lastnumber);
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
			public esStrings(esNomorlastnumber entity)
			{
				this.entity = entity;
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
				
			public System.String Lastnumber
			{
				get
				{
					System.Int32? data = entity.Lastnumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Lastnumber = null;
					else entity.Lastnumber = Convert.ToInt32(value);
				}
			}
			

			private esNomorlastnumber entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return NomorlastnumberMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public NomorlastnumberQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NomorlastnumberQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NomorlastnumberQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(NomorlastnumberQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private NomorlastnumberQuery query;		
	}



	[Serializable]
	abstract public partial class esNomorlastnumberCollection : esEntityCollection<Nomorlastnumber>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return NomorlastnumberMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "NomorlastnumberCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public NomorlastnumberQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NomorlastnumberQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NomorlastnumberQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new NomorlastnumberQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(NomorlastnumberQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((NomorlastnumberQuery)query);
		}

		#endregion
		
		private NomorlastnumberQuery query;
	}



	[Serializable]
	abstract public partial class esNomorlastnumberQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return NomorlastnumberMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Format": return this.Format;
				case "Tahun": return this.Tahun;
				case "Lastnumber": return this.Lastnumber;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Format
		{
			get { return new esQueryItem(this, NomorlastnumberMetadata.ColumnNames.Format, esSystemType.String); }
		} 
		
		public esQueryItem Tahun
		{
			get { return new esQueryItem(this, NomorlastnumberMetadata.ColumnNames.Tahun, esSystemType.String); }
		} 
		
		public esQueryItem Lastnumber
		{
			get { return new esQueryItem(this, NomorlastnumberMetadata.ColumnNames.Lastnumber, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Nomorlastnumber : esNomorlastnumber
	{

		
		
	}
	



	[Serializable]
	public partial class NomorlastnumberMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected NomorlastnumberMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(NomorlastnumberMetadata.ColumnNames.Format, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorlastnumberMetadata.PropertyNames.Format;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 255;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorlastnumberMetadata.ColumnNames.Tahun, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = NomorlastnumberMetadata.PropertyNames.Tahun;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NomorlastnumberMetadata.ColumnNames.Lastnumber, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = NomorlastnumberMetadata.PropertyNames.Lastnumber;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public NomorlastnumberMetadata Meta()
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
			 public const string Format = "format";
			 public const string Tahun = "tahun";
			 public const string Lastnumber = "lastnumber";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Format = "Format";
			 public const string Tahun = "Tahun";
			 public const string Lastnumber = "Lastnumber";
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
			lock (typeof(NomorlastnumberMetadata))
			{
				if(NomorlastnumberMetadata.mapDelegates == null)
				{
					NomorlastnumberMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NomorlastnumberMetadata.meta == null)
				{
					NomorlastnumberMetadata.meta = new NomorlastnumberMetadata();
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


				meta.AddTypeMap("Format", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Tahun", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Lastnumber", new esTypeMap("INT", "System.Int32"));			
				
				
				
				meta.Source = "nomorlastnumber";
				meta.Destination = "nomorlastnumber";
				
				meta.spInsert = "proc_nomorlastnumberInsert";				
				meta.spUpdate = "proc_nomorlastnumberUpdate";		
				meta.spDelete = "proc_nomorlastnumberDelete";
				meta.spLoadAll = "proc_nomorlastnumberLoadAll";
				meta.spLoadByPrimaryKey = "proc_nomorlastnumberLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private NomorlastnumberMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
