package nta.med.core.glossary;

public enum DataRowState {
	DETACHED("Detached"), UNCHANGED("Unchanged"), ADDED("Added"), DELETED("Deleted"), MODIFIED("Modified");
	private String value;

	DataRowState(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
