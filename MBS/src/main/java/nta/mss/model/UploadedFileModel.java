package nta.mss.model;

import java.io.Serializable;

import org.springframework.web.multipart.MultipartFile;

/**
* The Class UploadedFileModel.
* 
* @author Dev-DuyenNT
* @CrtDate Jul 29, 2014
*/
public class UploadedFileModel implements Serializable {
	private static final long serialVersionUID = 1L;
	
	private MultipartFile file;
	//add for be015
	private String applyDate;
	private Boolean overwriteSchedule;
	
	public MultipartFile getFile() {
		return file;
	}

	public void setFile(MultipartFile file) {
		this.file = file;
	}

	public String getApplyDate() {
		return applyDate;
	}

	public void setApplyDate(String applyDate) {
		this.applyDate = applyDate;
	}

	public Boolean getOverwriteSchedule() {
		return overwriteSchedule;
	}

	public void setOverwriteSchedule(Boolean overwriteSchedule) {
		this.overwriteSchedule = overwriteSchedule;
	}	
}
