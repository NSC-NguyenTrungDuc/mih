package nta.med.ext.registration.glosarry;

public enum GmtAndVpn {
    ENGLAND("EN") {
        @Override
        public Integer toGMT() {
            return 10;
        }
        
        @Override
        public String getVpn() {
            return "N";
        }
    }, JAPAN("JP") {
        @Override
        public Integer toGMT() {
            return 9;
        }
        
        @Override
        public String getVpn() {
            return "Y";
        }
    }, VIETNAM("VN") {
        @Override
        public Integer toGMT() {
            return 7;
        }
        
        @Override
        public String getVpn() {
            return "N";
        }
    };

    private String value;

    GmtAndVpn(String value) {
        this.value = value;
    }

    public abstract Integer toGMT();
    public abstract String getVpn();
    
    @Override
    public String toString(){
		return value;
	}

    public static GmtAndVpn newInstance(String val){
        switch (val.toLowerCase()){
            case "en": return ENGLAND;
            case "vn": return VIETNAM;
            case "jp": return JAPAN;
            default: return JAPAN;
        }
    }
}
