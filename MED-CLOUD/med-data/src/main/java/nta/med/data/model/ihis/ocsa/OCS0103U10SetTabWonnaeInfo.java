package nta.med.data.model.ihis.ocsa;

import java.math.BigDecimal;
import java.math.BigInteger;

/**
 * @author DEV-TiepNM
 */
public class OCS0103U10SetTabWonnaeInfo {

    private String filter4;
    private BigDecimal cnt4;
    private String kijunCode4;

    private String filter7;
    private BigDecimal cnt7;
    private String kijunCode7;

    private String filter8;
    private BigDecimal cnt8;
    private String kijunCode8;


    private String filter9;
    private BigDecimal cnt9;
    private String kijunCode9;


    public OCS0103U10SetTabWonnaeInfo(String filter4, BigDecimal cnt4, String kijunCode4, String filter7, BigDecimal cnt7, String kijunCode7, String filter8, BigDecimal cnt8, String kijunCode8, String filter9, BigDecimal cnt9, String kijunCode9) {
        this.filter4 = filter4;
        this.cnt4 = cnt4;
        this.kijunCode4 = kijunCode4;
        this.filter7 = filter7;
        this.cnt7 = cnt7;
        this.kijunCode7 = kijunCode7;
        this.filter8 = filter8;
        this.cnt8 = cnt8;
        this.kijunCode8 = kijunCode8;
        this.filter9 = filter9;
        this.cnt9 = cnt9;
        this.kijunCode9 = kijunCode9;
    }

    public String getFilter4() {
        return filter4;
    }

    public void setFilter4(String filter4) {
        this.filter4 = filter4;
    }

    public BigDecimal getCnt4() {
        return cnt4;
    }

    public void setCnt4(BigDecimal cnt4) {
        this.cnt4 = cnt4;
    }

    public String getKijunCode4() {
        return kijunCode4;
    }

    public void setKijunCode4(String kijunCode4) {
        this.kijunCode4 = kijunCode4;
    }

    public String getFilter7() {
        return filter7;
    }

    public void setFilter7(String filter7) {
        this.filter7 = filter7;
    }

    public BigDecimal getCnt7() {
        return cnt7;
    }

    public void setCnt7(BigDecimal cnt7) {
        this.cnt7 = cnt7;
    }

    public String getKijunCode7() {
        return kijunCode7;
    }

    public void setKijunCode7(String kijunCode7) {
        this.kijunCode7 = kijunCode7;
    }

    public String getFilter8() {
        return filter8;
    }

    public void setFilter8(String filter8) {
        this.filter8 = filter8;
    }

    public BigDecimal getCnt8() {
        return cnt8;
    }

    public void setCnt8(BigDecimal cnt8) {
        this.cnt8 = cnt8;
    }

    public String getKijunCode8() {
        return kijunCode8;
    }

    public void setKijunCode8(String kijunCode8) {
        this.kijunCode8 = kijunCode8;
    }

    public String getFilter9() {
        return filter9;
    }

    public void setFilter9(String filter9) {
        this.filter9 = filter9;
    }

    public BigDecimal getCnt9() {
        return cnt9;
    }

    public void setCnt9(BigDecimal cnt9) {
        this.cnt9 = cnt9;
    }

    public String getKijunCode9() {
        return kijunCode9;
    }

    public void setKijunCode9(String kijunCode9) {
        this.kijunCode9 = kijunCode9;
    }
}
