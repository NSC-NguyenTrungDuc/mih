package nta.phr.model;


import java.math.BigDecimal;

/**
 * The persistent class for the PHR_ACCOUNT database table.
 */
// @JsonSerialize(include=JsonSerialize.Inclusion.NON_NULL)
public class PhrAccountModel {


    private String token;
    private Long master_profile_id;


    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public Long getMaster_profile_id() {
        return master_profile_id;
    }

    public void setMaster_profile_id(Long master_profile_id) {
        this.master_profile_id = master_profile_id;
    }
}