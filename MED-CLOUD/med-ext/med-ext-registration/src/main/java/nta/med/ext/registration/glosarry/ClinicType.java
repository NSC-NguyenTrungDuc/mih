package nta.med.ext.registration.glosarry;

public enum ClinicType {
	ONE("1") {
        @Override
        public String getTypeName() {
            return "Phòng khám chuyên khoa";
        }
    }, TWO("2") {
        @Override
        public String getTypeName() {
            return "Phòng khám đa khoa";
        }
    }, OTHER("OTHER") {
        @Override
        public String getTypeName() {
            return "";
        }
    };

    private String value;

    ClinicType(String value) {
        this.value = value;
    }

    public abstract String getTypeName();
    
    @Override
    public String toString(){
		return value;
	}

    public static ClinicType newInstance(String val){
        switch (val.toLowerCase()){
            case "1": return ONE;
            case "2": return TWO;
            default: return OTHER;
        }
    }
}
