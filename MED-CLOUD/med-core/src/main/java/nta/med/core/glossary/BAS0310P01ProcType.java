package nta.med.core.glossary;

public enum BAS0310P01ProcType {
	MASTER_SANG("PR_ADM_UPDATE_MASTER_SANG"),
	MASTER_SUSIK("PR_ADM_UPDATE_MASTER_SUSIK"),
	MASTER_COM("PR_ADM_UPDATE_MASTER_COM"),
	MASTER_SAKURA("PR_ADM_UPDATE_MASTER_SAKURA"),
	MASTER_GD("PR_ADM_UPDATE_MASTER_GD");
	private String value;

	BAS0310P01ProcType(String value) {
        this.value = value;
    }
	
	public static BAS0310P01ProcType get(String value){
		for(BAS0310P01ProcType type : BAS0310P01ProcType.values()){
			if(type.value.equals(value)) return type;
		}
		return null;
	}
	
	public String getValue(){
		return value;
	}
}
