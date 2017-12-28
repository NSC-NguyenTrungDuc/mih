package nta.med.core.glossary;

/**
 * @author dainguyen.
 */
public enum Language {
    ENGLISH("en") {
        @Override
        public String fromDouble(Double value) {
            return value == null ? null : value.toString();
        }
    }, JAPANESE("ja") {
        @Override
        public String fromDouble(Double value) {
            return value == null ? null : value.toString();
        }
    }, VIETNAMESE("vi") {
        @Override
        public String fromDouble(Double value) {
            return value == null ? null : value.toString().replace(CommonEnum.DOT.getValue(), CommonEnum.COMMA.getValue());
        }
    };

    private String value;

    Language(String value) {
        this.value = value;
    }

    public abstract String fromDouble(Double value);
    
    @Override
    public String toString(){
		return value;
	}

    public static Language newInstance(String val){
        switch (val.toLowerCase()){
            case "en": return ENGLISH;
            case "vi": return VIETNAMESE;
            case "ja": return JAPANESE;
            default: return JAPANESE;
        }
    }
}
