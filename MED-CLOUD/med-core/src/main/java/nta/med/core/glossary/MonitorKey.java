package nta.med.core.glossary;

public enum MonitorKey {
	CONNECTION("[MEDSER]CONNECTION"), 
	REG_PATIENT("[MEDAPP]REG_PATIENT"), 
	REG_ORDER("[MEDAPP]REG_ORDER"), 
	LOGIN_SUCCESS("[MEDAPP]LOGIN_SUCCESS"), 
	REG_RESERVATION("[MEDAPP]REG_RESERVATION"),
	REG_RECEPTION("[MEDAPP]REG_RECEPTION"),
	REG_USER("[MEDAPP]REG_USER"),
	COMPRESS_TOTAL_MESSAGE("[MEDSER]COMPRESS_TOTAL_MESSAGE"),
	COMPRESS_TOTAL_MESSAGE_COMPRESSED("[MEDSER]COMPRESS_TOTAL_MESSAGE_COMPRESSED"),
	COMPRESS_TOTAL_BYTES_BEFORE_COMPRESS("[MEDSER]COMPRESS_TOTAL_BYTES_BEFORE_COMPRESS"),
	COMPRESS_TOTAL_BYTES_REDUCE_AFTER_COMPRESSED("[MEDSER]COMPRESS_TOTAL_BYTES_REDUCE_AFTER_COMPRESSED");
	
	String value;
	
	private MonitorKey(String value){
		this.value = value;
	}
	
	public String getValue(){
		return value;
	}
}

