package nta.med.core.glossary;

/**
 * @author dainguyen.
 */
public enum CacheKey {
	OrderBizComboPattern("%s_%s_%s_%s_%s"),
	OCS1003P01MakeInputGubunTabPattern("%s_%s_%s"),
	ComboGwaPattern("%s_%s_%s"),
	ComboHospCodeLanguagePattern("%s_%s");

    private String value;

    CacheKey(String value) {
        this.value = value;
    }

    @Override
    public String toString(){
        return value;
    }
}
