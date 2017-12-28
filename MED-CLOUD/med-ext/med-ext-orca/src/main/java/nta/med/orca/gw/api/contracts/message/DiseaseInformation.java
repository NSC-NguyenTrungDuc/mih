package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiseaseInformation {

    private String diseaseInOut;
    private String diseaseCode;
    private String diseaseName;
    private String diseaseSuspectedFlag;
    private String diseaseStartDate;
    private String diseaseEndDate;
    private String diseaseOutCome;
    private String diseaseSupplement;
    private String diseaseScode1;
    private String diseaseScode2;
    private String diseaseScode3;
    private String diseaseSname;
    private String diseaseCategory;
    private List<DiseaseSingle> diseaseSingles;

    @JacksonXmlProperty(localName = "Disease_InOut")
    public String getDiseaseInOut() {
        return diseaseInOut;
    }

    public void setDiseaseInOut(String diseaseInOut) {
        this.diseaseInOut = diseaseInOut;
    }

    @JacksonXmlProperty(localName = "Disease_Code")
    public String getDiseaseCode() {
        return diseaseCode;
    }

    public void setDiseaseCode(String diseaseCode) {
        this.diseaseCode = diseaseCode;
    }

    @JacksonXmlProperty(localName = "Disease_Name")
    public String getDiseaseName() {
        return diseaseName;
    }

    public void setDiseaseName(String diseaseName) {
        this.diseaseName = diseaseName;
    }

    @JacksonXmlProperty(localName = "Disease_SuspectedFlag")
    public String getDiseaseSuspectedFlag() {
        return diseaseSuspectedFlag;
    }

    public void setDiseaseSuspectedFlag(String diseaseSuspectedFlag) {
        this.diseaseSuspectedFlag = diseaseSuspectedFlag;
    }

    @JacksonXmlProperty(localName = "Disease_StartDate")
    public String getDiseaseStartDate() {
        return diseaseStartDate;
    }

    public void setDiseaseStartDate(String diseaseStartDate) {
        this.diseaseStartDate = diseaseStartDate;
    }

    @JacksonXmlProperty(localName = "Disease_EndDate")
    public String getDiseaseEndDate() {
        return diseaseEndDate;
    }

    public void setDiseaseEndDate(String diseaseEndDate) {
        this.diseaseEndDate = diseaseEndDate;
    }

    @JacksonXmlProperty(localName = "Disease_OutCome")
    public String getDiseaseOutCome() {
        return diseaseOutCome;
    }

    public void setDiseaseOutCome(String diseaseOutCome) {
        this.diseaseOutCome = diseaseOutCome;
    }

    @JacksonXmlProperty(localName = "Disease_Supplement")
    public String getDiseaseSupplement() {
        return diseaseSupplement;
    }

    public void setDiseaseSupplement(String diseaseSupplement) {
        this.diseaseSupplement = diseaseSupplement;
    }

    @JacksonXmlProperty(localName = "Disease_Scode1")
    public String getDiseaseScode1() {
        return diseaseScode1;
    }

    public void setDiseaseScode1(String diseaseScode1) {
        this.diseaseScode1 = diseaseScode1;
    }

    @JacksonXmlProperty(localName = "Disease_Scode2")
    public String getDiseaseScode2() {
        return diseaseScode2;
    }

    public void setDiseaseScode2(String diseaseScode2) {
        this.diseaseScode2 = diseaseScode2;
    }

    @JacksonXmlProperty(localName = "Disease_Scode3")
    public String getDiseaseScode3() {
        return diseaseScode3;
    }

    public void setDiseaseScode3(String diseaseScode3) {
        this.diseaseScode3 = diseaseScode3;
    }

    @JacksonXmlProperty(localName = "Disease_Sname")
    public String getDiseaseSname() {
        return diseaseSname;
    }

    public void setDiseaseSname(String diseaseSname) {
        this.diseaseSname = diseaseSname;
    }

    @JacksonXmlProperty(localName = "Disease_Category")
    public String getDiseaseCategory() {
        return diseaseCategory;
    }

    public void setDiseaseCategory(String diseaseCategory) {
        this.diseaseCategory = diseaseCategory;
    }

    @JacksonXmlProperty(localName = "Disease_Single")
    public List<DiseaseSingle> getDiseaseSingles() {
        return diseaseSingles;
    }

    public void setDiseaseSingles(List<DiseaseSingle> diseaseSingles) {
        this.diseaseSingles = diseaseSingles;
    }
}
