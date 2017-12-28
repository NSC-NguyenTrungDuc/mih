package nta.med.core.glossary;

import java.util.Arrays;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
public enum ScreenMater {
    OCS0103U00(Arrays.asList("OCS0103","CHT0110","INV0110","CHT0115")),
    BAS0310U00(Arrays.asList("BAS0310", "OCS0103")),
    CPL0101U00(Arrays.asList("CPL0101" ,"CPL0106","CPL0109","CPL0104")),
	CHT0110U00(Arrays.asList("CHT0110"));
    private List<String> tables;


    ScreenMater(List<String> tables) {
        this.tables = tables;
    }

    public List<String> getTables() {
        return tables;
    }

    public void setTables(List<String> tables) {
        this.tables = tables;
    }
}
