package nta.med.ext.phr.service;

import java.math.BigInteger;
import java.util.List;

import nta.med.ext.phr.model.AccountClinicKcckModel;
import nta.med.ext.phr.model.PhrAccountModel;
import nta.med.ext.phr.model.SocialAccountModel;
import nta.med.ext.support.proto.PatientServiceProto;

public interface PhrAccountService {
	public List<PhrAccountModel> findAll();
	
	public PhrAccountModel findById(Long id);
	
	public PhrAccountModel addAccount(PhrAccountModel accountModel, String udid, boolean isAaddAccountClinic) throws Exception;

	public void syncAccountToOtherSystem(PatientServiceProto.UserEvent userEvent);
	
	public Integer addAccountClinic(PhrAccountModel accountModel);

	public PhrAccountModel verifyAccount(Long accountId, Long profileId) throws Exception;
	public boolean verifyAccount(Long accountId) throws Exception;
	
	public PhrAccountModel login(PhrAccountModel accountModel) throws Exception;
	

	public Boolean processLogout(String token, Long accountId);

	public PhrAccountModel processForgotPassword(String email) throws Exception;
	
	public PhrAccountModel updateInformation(String token, PhrAccountModel accountModel, Long userId)
			throws Exception;
	

	public PhrAccountModel changeStandardBackground(PhrAccountModel accountModel, Long accountId)
			throws Exception;

	public PhrAccountModel changeBabyBackground(
			PhrAccountModel accountModel, Long accountId) throws Exception;

	public PhrAccountModel getAccount(String token);
	
	public List<AccountClinicKcckModel> verifyAccountFromKcck(PhrAccountModel accountModel) throws Exception;

	public PhrAccountModel registerUseFacebook(SocialAccountModel socialAccountModel, String udid) throws Exception;
	
	public PhrAccountModel loginUseFacebook(SocialAccountModel socialAccountModel) throws Exception;

	public PhrAccountModel changeStatusAgreement(Long accountId);

	public PhrAccountModel generateToken(String patientCode, String hospCode) throws Exception;
	
	public PhrAccountModel findByEmail(String email);
	
	public Integer updatePatientCodeByProfileIdHopsCode(Long profileId, String hospCode, String patientCode) throws Exception;

	PhrAccountModel changePassword(String token, PhrAccountModel accountModel, Long userId);
	
	public PhrAccountModel forgotPasswordMbs(PhrAccountModel accountModel)
			throws Exception;
	
}
