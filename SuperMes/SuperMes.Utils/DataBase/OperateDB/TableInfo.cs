using System;

namespace SuperMesServer.DataBase.OperateDB
{
	/// <summary>
	/// TableInfo ��ժҪ˵����
	/// </summary>
	public  class TableInfo
	{
		public TableInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
