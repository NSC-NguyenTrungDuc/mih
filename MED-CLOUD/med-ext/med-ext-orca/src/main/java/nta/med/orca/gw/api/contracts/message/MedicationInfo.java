package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class MedicationInfo {

    private String medicationCode;
    private String medicationName;
    private String medicationNumber;
    private String medicationGenericFlg;

    @JacksonXmlProperty(localName = "Medication_Code")
    public String getMedicationCode() {
        return medicationCode;
    }

    public void setMedicationCode(String medicationCode) {
        this.medicationCode = medicationCode;
    }

    @JacksonXmlProperty(localName = "Medication_Name")
    public String getMedicationName() {
        return medicationName;
    }

    public void setMedicationName(String medicationName) {
        this.medicationName = medicationName;
    }

    @JacksonXmlProperty(localName = "Medication_Number")
    public String getMedicationNumber() {
        return medicationNumber;
    }

    public void setMedicationNumber(String medicationNumber) {
        this.medicationNumber = medicationNumber;
    }

    @JacksonXmlProperty(localName = "Medication_Generic_Flg")
    public String getMedicationGenericFlg() {
        return medicationGenericFlg;
    }

    public void setMedicationGenericFlg(String medicationGenericFlg) {
        this.medicationGenericFlg = medicationGenericFlg;
    }
}
