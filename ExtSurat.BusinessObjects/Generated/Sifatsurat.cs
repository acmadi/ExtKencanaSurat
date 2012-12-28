
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : MySql
Date Generated       : 28/12/2012 15:29:58
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
	/// Encapsulates the 'sifatsurat' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Sifatsurat))]	
	[XmlType("Sifatsurat")]
	public partial class Sifatsurat : esSifatsurat
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Sifatsurat();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.SByte sifatsuratid)
		{
			var obj = new Sifatsurat();
			obj.Sifatsuratid = sifatsuratid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.SByte sifatsuratid, esSqlAccessType sqlAccessType)
		{
			var obj = new Sifatsurat();
			obj.Sifatsuratid = sifatsuratid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("SifatsuratCollection")]
	public partial class SifatsuratCollection : esSifatsuratCollection, IEnumerable<Sifatsurat>
	{
		public Sifatsurat FindByPrimaryKey(System.SByte sifatsuratid)
		{
			return this.SingleOrDefault(e => e.Sifatsuratid == sifatsuratid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Sifatsurat))]
		public class SifatsuratCollectionWCFPacket : esCollectionWCFPacket<SifatsuratCollection>
		{
			public static implicit operator SifatsuratCollection(SifatsuratCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SifatsuratCollectionWCFPacket(SifatsuratCollection collection)
			{
				return new SifatsuratCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SifatsuratQuery : esSifatsuratQuery
	{
		public SifatsuratQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SifatsuratQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SifatsuratQuery query)
		{
			return SifatsuratQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SifatsuratQuery(string query)
		{
			return (SifatsuratQuery)SifatsuratQuery.SerializeHelper.FromXml(query, typeof(SifatsuratQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSifatsurat : esEntity
	{
		public esSifatsurat()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.SByte sifatsuratid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(sifatsuratid);
			else
				return LoadByPrimaryKeyStoredProcedure(sifatsuratid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.SByte sifatsuratid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(sifatsuratid);
			else
				return LoadByPrimaryKeyStoredProcedure(sifatsuratid);
		}

		private bool LoadByPrimaryKeyDynamic(System.SByte sifatsuratid)
		{
			SifatsuratQuery query = new SifatsuratQuery();
			query.Where(query.Sifatsuratid == sifatsuratid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.SByte sifatsuratid)
		{
			esParameters parms = new esParameters();
			parms.Add("Sifatsuratid", sifatsuratid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to sifatsurat.sifatsuratid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.SByte? Sifatsuratid
		{
			get
			{
				return base.GetSystemSByte(SifatsuratMetadata.ColumnNames.Sifatsuratid);
			}
			
			set
			{
				if(base.SetSystemSByte(SifatsuratMetadata.ColumnNames.Sifatsuratid, value))
				{
					OnPropertyChanged(SifatsuratMetadata.PropertyNames.Sifatsuratid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to sifatsurat.sifat
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Sifat
		{
			get
			{
				return base.GetSystemString(SifatsuratMetadata.ColumnNames.Sifat);
			}
			
			set
			{
				if(base.SetSystemString(SifatsuratMetadata.ColumnNames.Sifat, value))
				{
					OnPropertyChanged(SifatsuratMetadata.PropertyNames.Sifat);
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
						case "Sifatsuratid": this.str().Sifatsuratid = (string)value; break;							
						case "Sifat": this.str().Sifat = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Sifatsuratid":
						
							if (value == null || value is System.SByte)
								this.Sifatsuratid = (System.SByte?)value;
								OnPropertyChanged(SifatsuratMetadata.PropertyNames.Sifatsuratid);
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
			public esStrings(esSifatsurat entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Sifatsuratid
			{
				get
				{
					System.SByte? data = entity.Sifatsuratid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Sifatsuratid = null;
					else entity.Sifatsuratid = Convert.ToSByte(value);
				}
			}
				
			public System.String Sifat
			{
				get
				{
					System.String data = entity.Sifat;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Sifat = null;
					else entity.Sifat = Convert.ToString(value);
				}
			}
			

			private esSifatsurat entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SifatsuratMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SifatsuratQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SifatsuratQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SifatsuratQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SifatsuratQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SifatsuratQuery query;		
	}



	[Serializable]
	abstract public partial class esSifatsuratCollection : esEntityCollection<Sifatsurat>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SifatsuratMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SifatsuratCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SifatsuratQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SifatsuratQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SifatsuratQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SifatsuratQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SifatsuratQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SifatsuratQuery)query);
		}

		#endregion
		
		private SifatsuratQuery query;
	}



	[Serializable]
	abstract public partial class esSifatsuratQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SifatsuratMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Sifatsuratid": return this.Sifatsuratid;
				case "Sifat": return this.Sifat;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Sifatsuratid
		{
			get { return new esQueryItem(this, SifatsuratMetadata.ColumnNames.Sifatsuratid, esSystemType.SByte); }
		} 
		
		public esQueryItem Sifat
		{
			get { return new esQueryItem(this, SifatsuratMetadata.ColumnNames.Sifat, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Sifatsurat : esSifatsurat
	{

		
		
	}
	



	[Serializable]
	public partial class SifatsuratMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SifatsuratMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SifatsuratMetadata.ColumnNames.Sifatsuratid, 0, typeof(System.SByte), esSystemType.SByte);
			c.PropertyName = SifatsuratMetadata.PropertyNames.Sifatsuratid;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SifatsuratMetadata.ColumnNames.Sifat, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = SifatsuratMetadata.PropertyNames.Sifat;
			c.CharacterMaxLength = 64;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SifatsuratMetadata Meta()
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
			 public const string Sifatsuratid = "sifatsuratid";
			 public const string Sifat = "sifat";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Sifatsuratid = "Sifatsuratid";
			 public const string Sifat = "Sifat";
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
			lock (typeof(SifatsuratMetadata))
			{
				if(SifatsuratMetadata.mapDelegates == null)
				{
					SifatsuratMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SifatsuratMetadata.meta == null)
				{
					SifatsuratMetadata.meta = new SifatsuratMetadata();
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


				meta.AddTypeMap("Sifatsuratid", new esTypeMap("TINYINT", "System.SByte"));
				meta.AddTypeMap("Sifat", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				meta.Source = "sifatsurat";
				meta.Destination = "sifatsurat";
				
				meta.spInsert = "proc_sifatsuratInsert";				
				meta.spUpdate = "proc_sifatsuratUpdate";		
				meta.spDelete = "proc_sifatsuratDelete";
				meta.spLoadAll = "proc_sifatsuratLoadAll";
				meta.spLoadByPrimaryKey = "proc_sifatsuratLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SifatsuratMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
