package nta.med.core.caching.model.medi.drgs;

import java.io.Serializable;
import java.math.BigInteger;

public class InformationSchemaColumn  implements Serializable{
	
	private static final long serialVersionUID = 1L;
	
	private String tableSchema;
	private String tableName;
	private String columnName;
	private String dataType;
	private BigInteger characterMaximunLength;
	
	
	public InformationSchemaColumn(String tableSchema, String tableName,
			String columnName, String dataType,
			BigInteger characterMaximunLength) {
		super();
		this.tableSchema = tableSchema;
		this.tableName = tableName;
		this.columnName = columnName;
		this.dataType = dataType;
		this.characterMaximunLength = characterMaximunLength;
	}
	
	public String getTableSchema() {
		return tableSchema;
	}
	public void setTableSchema(String tableSchema) {
		this.tableSchema = tableSchema;
	}
	public String getTableName() {
		return tableName;
	}
	public void setTableName(String tableName) {
		this.tableName = tableName;
	}
	public String getColumnName() {
		return columnName;
	}
	public void setColumnName(String columnName) {
		this.columnName = columnName;
	}
	public String getDataType() {
		return dataType;
	}
	public void setDataType(String dataType) {
		this.dataType = dataType;
	}
	public BigInteger getCharacterMaximunLength() {
		return characterMaximunLength;
	}
	public void setCharacterMaximunLength(BigInteger characterMaximunLength) {
		this.characterMaximunLength = characterMaximunLength;
	}
	@Override
	public String toString() {
		return "InfomationSchemaColumn [tableSchema="
				+ tableSchema + ", tableName=" + tableName + ", columnName="
				+ columnName + ", dataType=" + dataType
				+ ", characterMaximunLength=" + characterMaximunLength + "]";
	}
	
}
