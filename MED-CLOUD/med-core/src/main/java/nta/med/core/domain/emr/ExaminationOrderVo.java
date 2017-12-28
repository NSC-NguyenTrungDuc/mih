package nta.med.core.domain.emr;

/**
 * @author dainguyen.
 */
public class ExaminationOrderVo {
    private String content;
    private String gubunBass;
    private String hangmogCode;
    private String inputTab;
    private String hangmogName;
    private String inputGubunName;
    private String orderGubunName;

    public ExaminationOrderVo() {
    }

    public ExaminationOrderVo(String content, String gubunBass, String hangmogCode, String inputTab, String hangmogName, String inputGubunName, String orderGubunName) {
        this.content = content;
        this.gubunBass = gubunBass;
        this.hangmogCode = hangmogCode;
        this.inputTab = inputTab;
        this.hangmogName = hangmogName;
        this.inputGubunName = inputGubunName;
        this.orderGubunName = orderGubunName;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public String getGubunBass() {
        return gubunBass;
    }

    public void setGubunBass(String gubunBass) {
        this.gubunBass = gubunBass;
    }

    public String getHangmogCode() {
        return hangmogCode;
    }

    public void setHangmogCode(String hangmogCode) {
        this.hangmogCode = hangmogCode;
    }

    public String getInputTab() {
        return inputTab;
    }

    public void setInputTab(String inputTab) {
        this.inputTab = inputTab;
    }

    public String getHangmogName() {
        return hangmogName;
    }

    public void setHangmogName(String hangmogName) {
        this.hangmogName = hangmogName;
    }

    public String getInputGubunName() {
        return inputGubunName;
    }

    public void setInputGubunName(String inputGubunName) {
        this.inputGubunName = inputGubunName;
    }

    public String getOrderGubunName() {
        return orderGubunName;
    }

    public void setOrderGubunName(String orderGubunName) {
        this.orderGubunName = orderGubunName;
    }
}
