package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * @author DEV-TiepNM
 */
public class AccountPicture {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("account_id")
	private Long accountId;

	@JsonProperty("picture_profile_url")
	private String pictureProfileUrl;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Long getAccountId() {
		return accountId;
	}

	public void setAccountId(Long accountId) {
		this.accountId = accountId;
	}

	public String getPictureProfileUrl() {
		return pictureProfileUrl;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.pictureProfileUrl = pictureProfileUrl;
	}
}
