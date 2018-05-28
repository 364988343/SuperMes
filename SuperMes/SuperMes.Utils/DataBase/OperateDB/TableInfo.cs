using System;

namespace SuperMesServer.DataBase.OperateDB
{
	/// <summary>
	/// TableInfo 的摘要说明。
	/// </summary>
	public  class TableInfo
	{
		public TableInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static string GetQueryFieldFile(System.Data.DataTable table)
		{
		   int columnCount = table.Columns.Count;
			string QueryField = "";
			for (int i = 0 ;i < columnCount; i++)
			{
				if("".Equals(QueryField))
				{
					QueryField = table.Columns[i].ColumnName;
				}
				else
				{
					QueryField += ","+table.Columns[i].ColumnName;
				}
               
			}
			return QueryField;
		}
	}
}
