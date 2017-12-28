package nta.med.ext.registration.glosarry;

public enum ClinicScale {
	ONE("1") {
        @Override
        public String getScale(String clinicType) {
        	switch (clinicType){
            	case "1": return "Dưới 3 nhân viên";
            	case "2": return "Dưới 7 nhân viên";
            	default: return "";
        	}
        }
    }, TWO("2") {
        @Override
        public String getScale(String clinicType) {
        	switch (clinicType){
        		case "1": return "Từ 3 đến 10 nhân viên";
        		case "2": return "Từ 8 đến 15 nhân viên";
        		default: return "";
        	}
        }
    }, THREE("3") {
        @Override
        public String getScale(String clinicType) {
        	switch (clinicType){
        		case "1": return "Trên 10 nhân viên";
        		case "2": return "Trên 15 nhân viên";
        		default: return "";
    	}
        }
    },OTHER("OTHER") {
    	@Override
        public String getScale(String clinicType) {
        	return "";
    	}	
    };

    private String value;

    ClinicScale(String value) {
        this.value = value;
    }

    public abstract String getScale(String clinicType);
    
    @Override
    public String toString(){
		return value;
	}

    public static ClinicScale newInstance(String scale){
        switch (scale){
            case "1": return ONE;
            case "2": return TWO;
            case "3": return THREE;
            default: return OTHER;
        }
    }
}
