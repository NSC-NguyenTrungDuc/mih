package nta.phr.service;

import nta.mss.model.ChangePassModel;
import nta.mss.model.UpdateInformationModel;
import nta.mss.model.UserModel;
import nta.phr.model.PhrAccountClinicModel;
import nta.phr.model.PhrLoginModel;
import nta.phr.model.ProfileStandard;
import nta.phr.model.SocialAccountModel;

public interface IPhrApiService {
	public String getFullUrl(String apiName);
	// Login
	public PhrLoginModel login(PhrLoginModel model);
	public SocialAccountModel loginFaceBook(SocialAccountModel model);

	public boolean registerAccount(UserModel user);
	public boolean verifyAccount(String email);
	public boolean registerAccountFacebook(UserModel user);
	public boolean bookingInsertDataAccountclinic(PhrAccountClinicModel model, String token);
	// Update information
	public boolean updateInformation(UpdateInformationModel inforModel, String token);

	// Change password
	public boolean changePassword(ChangePassModel userChangePassModel);

	//Get list patient by from profileId from phrAPI
	public ProfileStandard getListPatientByprofileId(Long profileId, String token);
	
	public String getPhrDeviceToken(String patientCode, String hospCode , String token);
	
	public String getAllConnectionFromPeer();

}
