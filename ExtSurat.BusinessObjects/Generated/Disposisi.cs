
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : MySql
Date Generated       : 15/01/2013 17:00:33
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
	/// Encapsulates the 'disposisi' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Disposisi))]	
	[XmlType("Disposisi")]
	public partial class Disposisi : esDisposisi
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Disposisi();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 disposisiid)
		{
			var obj = new Disposisi();
			obj.Disposisiid = disposisiid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 disposisiid, esSqlAccessType sqlAccessType)
		{
			var obj = new Disposisi();
			obj.Disposisiid = disposisiid;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("DisposisiCollection")]
	public partial class DisposisiCollection : esDisposisiCollection, IEnumerable<Disposisi>
	{
		public Disposisi FindByPrimaryKey(System.Int32 disposisiid)
		{
			return this.SingleOrDefault(e => e.Disposisiid == disposisiid);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Disposisi))]
		public class DisposisiCollectionWCFPacket : esCollectionWCFPacket<DisposisiCollection>
		{
			public static implicit operator DisposisiCollection(DisposisiCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator DisposisiCollectionWCFPacket(DisposisiCollection collection)
			{
				return new DisposisiCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class DisposisiQuery : esDisposisiQuery
	{
		public DisposisiQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "DisposisiQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(DisposisiQuery query)
		{
			return DisposisiQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator DisposisiQuery(string query)
		{
			return (DisposisiQuery)DisposisiQuery.SerializeHelper.FromXml(query, typeof(DisposisiQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esDisposisi : esEntity
	{
		public esDisposisi()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 disposisiid)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(disposisiid);
			else
				return LoadByPrimaryKeyStoredProcedure(disposisiid);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 disposisiid)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(disposisiid);
			else
				return LoadByPrimaryKeyStoredProcedure(disposisiid);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 disposisiid)
		{
			DisposisiQuery query = new DisposisiQuery();
			query.Where(query.Disposisiid == disposisiid);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 disposisiid)
		{
			esParameters parms = new esParameters();
			parms.Add("Disposisiid", disposisiid);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to disposisi.disposisiid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Disposisiid
		{
			get
			{
				return base.GetSystemInt32(DisposisiMetadata.ColumnNames.Disposisiid);
			}
			
			set
			{
				if(base.SetSystemInt32(DisposisiMetadata.ColumnNames.Disposisiid, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Disposisiid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.agendanomor
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Agendanomor
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Agendanomor);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Agendanomor, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Agendanomor);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.nomorsurat
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Nomorsurat
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Nomorsurat);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Nomorsurat, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Nomorsurat);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.tanggal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Tanggal
		{
			get
			{
				return base.GetSystemDateTime(DisposisiMetadata.ColumnNames.Tanggal);
			}
			
			set
			{
				if(base.SetSystemDateTime(DisposisiMetadata.ColumnNames.Tanggal, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Tanggal);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.sifatsuratid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.SByte? Sifatsuratid
		{
			get
			{
				return base.GetSystemSByte(DisposisiMetadata.ColumnNames.Sifatsuratid);
			}
			
			set
			{
				if(base.SetSystemSByte(DisposisiMetadata.ColumnNames.Sifatsuratid, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Sifatsuratid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.perihal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Perihal
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Perihal);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Perihal, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Perihal);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.asalsurat
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Asalsurat
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Asalsurat);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Asalsurat, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Asalsurat);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.diteruskanke
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Diteruskanke
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Diteruskanke);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Diteruskanke, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Diteruskanke);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.catatan
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Catatan
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Catatan);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Catatan, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Catatan);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.lastedit
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? Lastedit
		{
			get
			{
				return base.GetSystemDateTime(DisposisiMetadata.ColumnNames.Lastedit);
			}
			
			set
			{
				if(base.SetSystemDateTime(DisposisiMetadata.ColumnNames.Lastedit, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Lastedit);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.userid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Userid
		{
			get
			{
				return base.GetSystemString(DisposisiMetadata.ColumnNames.Userid);
			}
			
			set
			{
				if(base.SetSystemString(DisposisiMetadata.ColumnNames.Userid, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Userid);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.biasa
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? Biasa
		{
			get
			{
				return base.GetSystemBoolean(DisposisiMetadata.ColumnNames.Biasa);
			}
			
			set
			{
				if(base.SetSystemBoolean(DisposisiMetadata.ColumnNames.Biasa, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Biasa);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.segera
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? Segera
		{
			get
			{
				return base.GetSystemBoolean(DisposisiMetadata.ColumnNames.Segera);
			}
			
			set
			{
				if(base.SetSystemBoolean(DisposisiMetadata.ColumnNames.Segera, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Segera);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.penting
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? Penting
		{
			get
			{
				return base.GetSystemBoolean(DisposisiMetadata.ColumnNames.Penting);
			}
			
			set
			{
				if(base.SetSystemBoolean(DisposisiMetadata.ColumnNames.Penting, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Penting);
				}
			}
		}		
		
		/// <summary>
		/// Maps to disposisi.rahasia
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? Rahasia
		{
			get
			{
				return base.GetSystemBoolean(DisposisiMetadata.ColumnNames.Rahasia);
			}
			
			set
			{
				if(base.SetSystemBoolean(DisposisiMetadata.ColumnNames.Rahasia, value))
				{
					OnPropertyChanged(DisposisiMetadata.PropertyNames.Rahasia);
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
						case "Disposisiid": this.str().Disposisiid = (string)value; break;							
						case "Agendanomor": this.str().Agendanomor = (string)value; break;							
						case "Nomorsurat": this.str().Nomorsurat = (string)value; break;							
						case "Tanggal": this.str().Tanggal = (string)value; break;							
						case "Sifatsuratid": this.str().Sifatsuratid = (string)value; break;							
						case "Perihal": this.str().Perihal = (string)value; break;							
						case "Asalsurat": this.str().Asalsurat = (string)value; break;							
						case "Diteruskanke": this.str().Diteruskanke = (string)value; break;							
						case "Catatan": this.str().Catatan = (string)value; break;							
						case "Lastedit": this.str().Lastedit = (string)value; break;							
						case "Userid": this.str().Userid = (string)value; break;							
						case "Biasa": this.str().Biasa = (string)value; break;							
						case "Segera": this.str().Segera = (string)value; break;							
						case "Penting": this.str().Penting = (string)value; break;							
						case "Rahasia": this.str().Rahasia = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Disposisiid":
						
							if (value == null || value is System.Int32)
								this.Disposisiid = (System.Int32?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Disposisiid);
							break;
						
						case "Tanggal":
						
							if (value == null || value is System.DateTime)
								this.Tanggal = (System.DateTime?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Tanggal);
							break;
						
						case "Sifatsuratid":
						
							if (value == null || value is System.SByte)
								this.Sifatsuratid = (System.SByte?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Sifatsuratid);
							break;
						
						case "Lastedit":
						
							if (value == null || value is System.DateTime)
								this.Lastedit = (System.DateTime?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Lastedit);
							break;
						
						case "Biasa":
						
							if (value == null || value is System.Boolean)
								this.Biasa = (System.Boolean?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Biasa);
							break;
						
						case "Segera":
						
							if (value == null || value is System.Boolean)
								this.Segera = (System.Boolean?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Segera);
							break;
						
						case "Penting":
						
							if (value == null || value is System.Boolean)
								this.Penting = (System.Boolean?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Penting);
							break;
						
						case "Rahasia":
						
							if (value == null || value is System.Boolean)
								this.Rahasia = (System.Boolean?)value;
								OnPropertyChanged(DisposisiMetadata.PropertyNames.Rahasia);
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
			public esStrings(esDisposisi entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Disposisiid
			{
				get
				{
					System.Int32? data = entity.Disposisiid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Disposisiid = null;
					else entity.Disposisiid = Convert.ToInt32(value);
				}
			}
				
			public System.String Agendanomor
			{
				get
				{
					System.String data = entity.Agendanomor;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Agendanomor = null;
					else entity.Agendanomor = Convert.ToString(value);
				}
			}
				
			public System.String Nomorsurat
			{
				get
				{
					System.String data = entity.Nomorsurat;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Nomorsurat = null;
					else entity.Nomorsurat = Convert.ToString(value);
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
				
			public System.String Perihal
			{
				get
				{
					System.String data = entity.Perihal;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Perihal = null;
					else entity.Perihal = Convert.ToString(value);
				}
			}
				
			public System.String Asalsurat
			{
				get
				{
					System.String data = entity.Asalsurat;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Asalsurat = null;
					else entity.Asalsurat = Convert.ToString(value);
				}
			}
				
			public System.String Diteruskanke
			{
				get
				{
					System.String data = entity.Diteruskanke;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Diteruskanke = null;
					else entity.Diteruskanke = Convert.ToString(value);
				}
			}
				
			public System.String Catatan
			{
				get
				{
					System.String data = entity.Catatan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Catatan = null;
					else entity.Catatan = Convert.ToString(value);
				}
			}
				
			public System.String Lastedit
			{
				get
				{
					System.DateTime? data = entity.Lastedit;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Lastedit = null;
					else entity.Lastedit = Convert.ToDateTime(value);
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
				
			public System.String Biasa
			{
				get
				{
					System.Boolean? data = entity.Biasa;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Biasa = null;
					else entity.Biasa = Convert.ToBoolean(value);
				}
			}
				
			public System.String Segera
			{
				get
				{
					System.Boolean? data = entity.Segera;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Segera = null;
					else entity.Segera = Convert.ToBoolean(value);
				}
			}
				
			public System.String Penting
			{
				get
				{
					System.Boolean? data = entity.Penting;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Penting = null;
					else entity.Penting = Convert.ToBoolean(value);
				}
			}
				
			public System.String Rahasia
			{
				get
				{
					System.Boolean? data = entity.Rahasia;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Rahasia = null;
					else entity.Rahasia = Convert.ToBoolean(value);
				}
			}
			

			private esDisposisi entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return DisposisiMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public DisposisiQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DisposisiQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(DisposisiQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(DisposisiQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private DisposisiQuery query;		
	}



	[Serializable]
	abstract public partial class esDisposisiCollection : esEntityCollection<Disposisi>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return DisposisiMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "DisposisiCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public DisposisiQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DisposisiQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(DisposisiQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new DisposisiQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(DisposisiQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((DisposisiQuery)query);
		}

		#endregion
		
		private DisposisiQuery query;
	}



	[Serializable]
	abstract public partial class esDisposisiQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return DisposisiMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Disposisiid": return this.Disposisiid;
				case "Agendanomor": return this.Agendanomor;
				case "Nomorsurat": return this.Nomorsurat;
				case "Tanggal": return this.Tanggal;
				case "Sifatsuratid": return this.Sifatsuratid;
				case "Perihal": return this.Perihal;
				case "Asalsurat": return this.Asalsurat;
				case "Diteruskanke": return this.Diteruskanke;
				case "Catatan": return this.Catatan;
				case "Lastedit": return this.Lastedit;
				case "Userid": return this.Userid;
				case "Biasa": return this.Biasa;
				case "Segera": return this.Segera;
				case "Penting": return this.Penting;
				case "Rahasia": return this.Rahasia;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Disposisiid
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Disposisiid, esSystemType.Int32); }
		} 
		
		public esQueryItem Agendanomor
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Agendanomor, esSystemType.String); }
		} 
		
		public esQueryItem Nomorsurat
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Nomorsurat, esSystemType.String); }
		} 
		
		public esQueryItem Tanggal
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Tanggal, esSystemType.DateTime); }
		} 
		
		public esQueryItem Sifatsuratid
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Sifatsuratid, esSystemType.SByte); }
		} 
		
		public esQueryItem Perihal
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Perihal, esSystemType.String); }
		} 
		
		public esQueryItem Asalsurat
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Asalsurat, esSystemType.String); }
		} 
		
		public esQueryItem Diteruskanke
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Diteruskanke, esSystemType.String); }
		} 
		
		public esQueryItem Catatan
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Catatan, esSystemType.String); }
		} 
		
		public esQueryItem Lastedit
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Lastedit, esSystemType.DateTime); }
		} 
		
		public esQueryItem Userid
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Userid, esSystemType.String); }
		} 
		
		public esQueryItem Biasa
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Biasa, esSystemType.Boolean); }
		} 
		
		public esQueryItem Segera
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Segera, esSystemType.Boolean); }
		} 
		
		public esQueryItem Penting
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Penting, esSystemType.Boolean); }
		} 
		
		public esQueryItem Rahasia
		{
			get { return new esQueryItem(this, DisposisiMetadata.ColumnNames.Rahasia, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}


	
	public partial class Disposisi : esDisposisi
	{

		
		
	}
	



	[Serializable]
	public partial class DisposisiMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected DisposisiMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Disposisiid, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = DisposisiMetadata.PropertyNames.Disposisiid;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Agendanomor, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Agendanomor;
			c.CharacterMaxLength = 512;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Nomorsurat, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Nomorsurat;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Tanggal, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = DisposisiMetadata.PropertyNames.Tanggal;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Sifatsuratid, 4, typeof(System.SByte), esSystemType.SByte);
			c.PropertyName = DisposisiMetadata.PropertyNames.Sifatsuratid;
			c.NumericPrecision = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Perihal, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Perihal;
			c.CharacterMaxLength = 512;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Asalsurat, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Asalsurat;
			c.CharacterMaxLength = 512;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Diteruskanke, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Diteruskanke;
			c.CharacterMaxLength = 512;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Catatan, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Catatan;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Lastedit, 9, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = DisposisiMetadata.PropertyNames.Lastedit;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Userid, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = DisposisiMetadata.PropertyNames.Userid;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Biasa, 11, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = DisposisiMetadata.PropertyNames.Biasa;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"b'0'";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Segera, 12, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = DisposisiMetadata.PropertyNames.Segera;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"b'0'";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Penting, 13, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = DisposisiMetadata.PropertyNames.Penting;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"b'0'";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DisposisiMetadata.ColumnNames.Rahasia, 14, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = DisposisiMetadata.PropertyNames.Rahasia;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"b'0'";
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public DisposisiMetadata Meta()
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
			 public const string Disposisiid = "disposisiid";
			 public const string Agendanomor = "agendanomor";
			 public const string Nomorsurat = "nomorsurat";
			 public const string Tanggal = "tanggal";
			 public const string Sifatsuratid = "sifatsuratid";
			 public const string Perihal = "perihal";
			 public const string Asalsurat = "asalsurat";
			 public const string Diteruskanke = "diteruskanke";
			 public const string Catatan = "catatan";
			 public const string Lastedit = "lastedit";
			 public const string Userid = "userid";
			 public const string Biasa = "biasa";
			 public const string Segera = "segera";
			 public const string Penting = "penting";
			 public const string Rahasia = "rahasia";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Disposisiid = "Disposisiid";
			 public const string Agendanomor = "Agendanomor";
			 public const string Nomorsurat = "Nomorsurat";
			 public const string Tanggal = "Tanggal";
			 public const string Sifatsuratid = "Sifatsuratid";
			 public const string Perihal = "Perihal";
			 public const string Asalsurat = "Asalsurat";
			 public const string Diteruskanke = "Diteruskanke";
			 public const string Catatan = "Catatan";
			 public const string Lastedit = "Lastedit";
			 public const string Userid = "Userid";
			 public const string Biasa = "Biasa";
			 public const string Segera = "Segera";
			 public const string Penting = "Penting";
			 public const string Rahasia = "Rahasia";
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
			lock (typeof(DisposisiMetadata))
			{
				if(DisposisiMetadata.mapDelegates == null)
				{
					DisposisiMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (DisposisiMetadata.meta == null)
				{
					DisposisiMetadata.meta = new DisposisiMetadata();
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


				meta.AddTypeMap("Disposisiid", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Agendanomor", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Nomorsurat", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Tanggal", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("Sifatsuratid", new esTypeMap("TINYINT", "System.SByte"));
				meta.AddTypeMap("Perihal", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Asalsurat", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Diteruskanke", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Catatan", new esTypeMap("TEXT", "System.String"));
				meta.AddTypeMap("Lastedit", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("Userid", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Biasa", new esTypeMap("BIT", "System.Boolean"));
				meta.AddTypeMap("Segera", new esTypeMap("BIT", "System.Boolean"));
				meta.AddTypeMap("Penting", new esTypeMap("BIT", "System.Boolean"));
				meta.AddTypeMap("Rahasia", new esTypeMap("BIT", "System.Boolean"));			
				
				
				
				meta.Source = "disposisi";
				meta.Destination = "disposisi";
				
				meta.spInsert = "proc_disposisiInsert";				
				meta.spUpdate = "proc_disposisiUpdate";		
				meta.spDelete = "proc_disposisiDelete";
				meta.spLoadAll = "proc_disposisiLoadAll";
				meta.spLoadByPrimaryKey = "proc_disposisiLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private DisposisiMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
