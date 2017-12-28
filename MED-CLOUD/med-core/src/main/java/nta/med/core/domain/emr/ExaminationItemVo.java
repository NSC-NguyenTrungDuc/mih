package nta.med.core.domain.emr;

import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ExaminationItemVo {
    private String gwa;
    private String naewonDate;
    private String doctor;
    private String naewonKey;
    private List<ExaminationTagVo> tags;
    private List<ExaminationOrderVo> orders;

    public ExaminationItemVo() {
        tags = new ArrayList<>();
        orders = new ArrayList<>();
    }

    public ExaminationItemVo(String gwa, String naewonDate, String doctor, String naewonKey, List<ExaminationTagVo> tags, List<ExaminationOrderVo> orders) {
        this.gwa = gwa;
        this.naewonDate = naewonDate;
        this.doctor = doctor;
        this.naewonKey = naewonKey;
        this.tags = tags;
        this.orders = orders;
    }

    public String getGwa() {
        return gwa;
    }

    public void setGwa(String gwa) {
        this.gwa = gwa;
    }

    public String getNaewonDate() {
        return naewonDate;
    }

    public void setNaewonDate(String naewonDate) {
        this.naewonDate = naewonDate;
    }

    public String getDoctor() {
        return doctor;
    }

    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    public String getNaewonKey() {
        return naewonKey;
    }

    public void setNaewonKey(String naewonKey) {
        this.naewonKey = naewonKey;
    }

    public List<ExaminationTagVo> getTags() {
        return tags;
    }

    public void setTags(List<ExaminationTagVo> tags) {
        this.tags = tags;
    }

    public List<ExaminationOrderVo> getOrders() {
        return orders;
    }

    public void setOrders(List<ExaminationOrderVo> orders) {
        this.orders = orders;
    }
}
