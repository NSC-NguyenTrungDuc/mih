package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class RelationSurveyModel {

    private boolean hasMore;

    private List<PatientSurveyModel> relate_list;
    @JsonProperty("has_more")
    public boolean isHasMore() {
        return hasMore;
    }

    public void setHasMore(boolean hasMore) {
        this.hasMore = hasMore;
    }
    @JsonProperty("relate_list")
    public List<PatientSurveyModel> getRelate_list() {
        return relate_list;
    }

    public void setRelate_list(List<PatientSurveyModel> relate_list) {
        this.relate_list = relate_list;
    }
}
