package nta.med.core.glossary;

public enum ScreenTable {
	CPL0101U00("CPL0101_CPL0109_CPL0104_CPL0106"), BAS0310U00("BAS0310_OCS0103"), OCS0103U00("OCS0103_CHT0110_INV0110_CHT0115"),
	MASTER_SANG("CHT0110"), MASTER_SUSIK("CHT0115"), MASTER_COM("OCS0132_BAS0310_OCS0103_INV0110"), MASTER_GD("OCS0109_OCS0110_OCS0103"),
	CHT0110U00("CHT0110");
	
    private String value;

    ScreenTable(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }

}
