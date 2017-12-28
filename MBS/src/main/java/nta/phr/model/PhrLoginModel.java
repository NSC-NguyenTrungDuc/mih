package nta.phr.model;

import java.math.BigDecimal;

public class PhrLoginModel {
	
	private Long id;
	private String baby_background_url;
	private String email;
	private String password;
	private String new_password;
	private String standard_background_url;
	private BigDecimal status;
	private int type;
	private BigDecimal login_type;
	private ProfileModel profile;
	private Long baby_profile_id;
	private Long standard_profile_id;
	private String token;
	private String gender;
	private BigDecimal baby_sync_flg;
	private String baby_udid;
	private BigDecimal standard_sync_flg;
	private String standard_udid;
	private Long master_profile_id;
	private String udid;

	public PhrLoginModel() {}

	public PhrLoginModel(Long id, String baby_background_url, String email, String password, String new_password,
			String standard_background_url, BigDecimal status, int type, BigDecimal login_type, ProfileModel profile,
			Long baby_profile_id, Long standard_profile_id, String token, String gender, BigDecimal baby_sync_flg,
			String baby_udid, BigDecimal standard_sync_flg, String standard_udid, Long master_profile_id, String udid) {
		super();
		this.id = id;
		this.baby_background_url = baby_background_url;
		this.email = email;
		this.password = password;
		this.new_password = new_password;
		this.standard_background_url = standard_background_url;
		this.status = status;
		this.type = type;
		this.login_type = login_type;
		this.profile = profile;
		this.baby_profile_id = baby_profile_id;
		this.standard_profile_id = standard_profile_id;
		this.token = token;
		this.gender = gender;
		this.baby_sync_flg = baby_sync_flg;
		this.baby_udid = baby_udid;
		this.standard_sync_flg = standard_sync_flg;
		this.standard_udid = standard_udid;
		this.master_profile_id = master_profile_id;
		this.udid = udid;
	}

	@Override
	public String toString() {
		return "PhrLoginModel [email=" + email + ", password=" + password + "]";
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getBaby_background_url() {
		return baby_background_url;
	}

	public void setBaby_background_url(String baby_background_url) {
		this.baby_background_url = baby_background_url;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getNew_password() {
		return new_password;
	}

	public void setNew_password(String new_password) {
		this.new_password = new_password;
	}

	public String getStandard_background_url() {
		return standard_background_url;
	}

	public void setStandard_background_url(String standard_background_url) {
		this.standard_background_url = standard_background_url;
	}

	public BigDecimal getStatus() {
		return status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public BigDecimal getLogin_type() {
		return login_type;
	}

	public void setLogin_type(BigDecimal login_type) {
		this.login_type = login_type;
	}

	public ProfileModel getProfile() {
		return profile;
	}

	public void setProfile(ProfileModel profile) {
		this.profile = profile;
	}

	public Long getBaby_profile_id() {
		return baby_profile_id;
	}

	public void setBaby_profile_id(Long baby_profile_id) {
		this.baby_profile_id = baby_profile_id;
	}

	public Long getStandard_profile_id() {
		return standard_profile_id;
	}

	public void setStandard_profile_id(Long standard_profile_id) {
		this.standard_profile_id = standard_profile_id;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public BigDecimal getBaby_sync_flg() {
		return baby_sync_flg;
	}

	public void setBaby_sync_flg(BigDecimal baby_sync_flg) {
		this.baby_sync_flg = baby_sync_flg;
	}

	public String getBaby_udid() {
		return baby_udid;
	}

	public void setBaby_udid(String baby_udid) {
		this.baby_udid = baby_udid;
	}

	public BigDecimal getStandard_sync_flg() {
		return standard_sync_flg;
	}

	public void setStandard_sync_flg(BigDecimal standard_sync_flg) {
		this.standard_sync_flg = standard_sync_flg;
	}

	public String getStandard_udid() {
		return standard_udid;
	}

	public void setStandard_udid(String standard_udid) {
		this.standard_udid = standard_udid;
	}

	public Long getMaster_profile_id() {
		return master_profile_id;
	}

	public void setMaster_profile_id(Long master_profile_id) {
		this.master_profile_id = master_profile_id;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}
	
}
