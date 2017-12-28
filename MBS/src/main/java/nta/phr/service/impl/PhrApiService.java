package nta.phr.service.impl;

import java.lang.reflect.Type;
import java.math.BigInteger;

import javax.ws.rs.core.MultivaluedMap;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.codehaus.jackson.map.ObjectMapper;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.reflect.TypeToken;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.core.util.MultivaluedMapImpl;

import nta.helper.ClientHelper;
import nta.helper.Message;
import nta.kcck.model.MessageResponse;
import nta.mss.controller.HospitalController;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.model.ChangePassModel;
import nta.mss.model.UpdateInformationModel;
import nta.mss.model.UserModel;
import nta.phr.model.PhrAccountClinicModel;
import nta.phr.model.PhrLoginModel;
import nta.phr.model.PhrRegisterModel;
import nta.phr.model.ProfileModel;
import nta.phr.model.ProfileStandard;
import nta.phr.model.SocialAccountModel;
import nta.phr.service.IPhrApiService;

@Service
@Transactional
public class PhrApiService implements IPhrApiService {

	private static final Logger LOG = LogManager.getLogger(HospitalController.class);

	@Override
	public String getFullUrl(String apiName) {
		String severUrl = null;
		String severPort = null;
		try {
			severUrl = MssConfiguration.getInstance().getApiPhrSeverUrl();
			severPort = MssConfiguration.getInstance().getApiPhrSeverPort();
		} catch (Exception e) {
			e.printStackTrace();
		}
		if (!Strings.isEmpty(severPort)) {
			return severUrl + ":" + severPort + "/" + apiName;
		} else {
			return severUrl + "/" + apiName;
		}

	}

	@Override
	public PhrLoginModel login(PhrLoginModel model) {
		PhrLoginModel phrLoginModel = new PhrLoginModel();

		try {
			MessageResponse<PhrLoginModel> messageResponse = new MessageResponse<PhrLoginModel>();
			Type confType = new TypeToken<PhrLoginModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrLogin());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("LOGIN: [REQUEST URL = ] " + url);
			LOG.info("LOGIN: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("PHR-API login:" + response.getStatus());
				LOG.warn("PHR-API :" + response.getEntity(String.class));
				return phrLoginModel;
			}
			ObjectMapper mapper = new ObjectMapper();
			String output = response.getEntity(String.class);
			System.out.println(output);

			Type confType2 = new TypeToken<MessageResponse<PhrLoginModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			phrLoginModel = messageResponse.getContent();

		} catch (Exception e) {
			e.printStackTrace();
		}
		return phrLoginModel;
	}

	@Override
	public SocialAccountModel loginFaceBook(SocialAccountModel model) {
		SocialAccountModel accountModel = new SocialAccountModel();
		try {

			Type confType = new TypeToken<SocialAccountModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrLoginFacebook());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("LOGIN: [REQUEST URL = ] " + url);
			LOG.info("LOGIN: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("PHR-API login:" + response.getStatus());
				LOG.warn("PHR-API :" + response.getEntity(String.class));
				return accountModel;
			}

			String output = response.getEntity(String.class);

			Type confType2 = new TypeToken<MessageResponse<SocialAccountModel>>() {
			}.getType();
			MessageResponse<SocialAccountModel> messageResponse = gson.fromJson(output, confType2);
			accountModel = messageResponse.getContent();

		} catch (Exception e) {
			e.printStackTrace();
		}
		return accountModel;
	}

	@Override
	public boolean registerAccountFacebook(UserModel user) {
		if (user != null) {
			SocialAccountModel socialAccountModel = new SocialAccountModel();
			socialAccountModel.setEmail(user.getEmail());
			socialAccountModel.setName(user.getName());
			socialAccountModel.setFacebook_id(new BigInteger(user.getLoginId()));
			socialAccountModel.setAccess_token(user.getToken());
			socialAccountModel.setHosp_code(user.getHospitalCode());
			socialAccountModel.setPhone(user.getPhoneNumber());

			if (user.getSex() == "1") {
				socialAccountModel.setGender("M");
			} else {
				socialAccountModel.setGender("F");
			}
			socialAccountModel.setBirthday(user.getDob());

			try {

				Gson gson = new Gson();

				String json = gson.toJson(socialAccountModel);
				Client client = Client.create(ClientHelper.configureClient());
				String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrRegisterFB());
				WebResource webResource = client.resource(url);

				ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);

				if (response.getStatus() != 200) {
					LOG.warn("Info Status:" + response.getStatus());
					LOG.warn("Info:" + response.getEntity(String.class));
					return false;
				}
				String output = response.getEntity(String.class);

				Type confType = new TypeToken<MessageResponse<SocialAccountModel>>() {
				}.getType();
				MessageResponse<SocialAccountModel> messageResponse = gson.fromJson(output, confType);
				socialAccountModel = messageResponse.getContent();
				if (socialAccountModel != null
						|| messageResponse.getMessage().equals(Message.FACEBOOK_ID_IN_USED.getValue())) {
					return true;
				}
			} catch (Exception e) {

				return false;
			}
		}
		return false;
	}

	@Override
	public boolean registerAccount(UserModel user) {

		if (user != null) {

			PhrRegisterModel phrRegisterModel = new PhrRegisterModel();

			phrRegisterModel.setEmail(user.getEmail());
			phrRegisterModel.setPassword(user.getPassword());

			ProfileModel phrProfileModel = new ProfileModel();
			phrProfileModel.setFullName(user.getName());
			phrProfileModel.setFullNameKana(user.getNameFurigana());
			// phrProfileModel.setBabyFlg(new BigDecimal(0));
			phrProfileModel.setAddress(user.getAddress());
			phrProfileModel.setFamilyMemberType("PERSONAL");
			// phrProfileModel.setActive_profile_flg(new BigDecimal(1));
			// phrProfileModel.setNumberPhone(user.getPhoneNumber());
			if (user.getSex() == "1") {
				phrProfileModel.setGender("M");
			} else {
				phrProfileModel.setGender("F");
			}
			phrProfileModel.setBirthday(user.getDob());
			// phrProfileModel.setAccountId(phrRegisterModel.getId());
			phrProfileModel.setPhone(user.getPhoneNumber());
			phrRegisterModel.setHosp_code(user.getHospitalCode());
			phrRegisterModel.setHosp_name(user.getHospitalName());
			phrRegisterModel.setProfile(phrProfileModel);

			try {
				MessageResponse<PhrRegisterModel> messageResponse = new MessageResponse<PhrRegisterModel>();
				Type confType = new TypeToken<MessageResponse<PhrRegisterModel>>() {
				}.getType();
				Gson gson = new Gson();
				// String json = gson.toJson(phrRegisterModel,confType);
				String json = gson.toJson(phrRegisterModel);
				Client client = Client.create(ClientHelper.configureClient());
				String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrRegister());

				WebResource webResource = client.resource(url);

				ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);

				if (response.getStatus() != 200) {
					LOG.warn("Info Status:" + response.getStatus());
					LOG.warn("Info:" + response.getEntity(String.class));
					return false;
				}
				ObjectMapper mapper = new ObjectMapper();
				String output = response.getEntity(String.class);
				messageResponse = gson.fromJson(output, confType);
				Type confType2 = new TypeToken<MessageResponse<PhrRegisterModel>>() {
				}.getType();
				messageResponse = gson.fromJson(output, confType2);
				phrRegisterModel = messageResponse.getContent();
				if (phrRegisterModel != null
						|| messageResponse.getMessage().equals(Message.MESSAGE_DUPLICATE_EMAIL.getValue())) {
					return true;
				}
			} catch (Exception e) {
				System.out.println(e.getMessage());
				return false;
			}
		}
		return false;
	}

	@Override
	public boolean verifyAccount(String email) {
		try {
			MessageResponse messageResponse = new MessageResponse();
			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrVerify());
			WebResource webResource = client.resource(url + "/" + email);

			ClientResponse response = webResource.type("application/json").get(ClientResponse.class);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return false;
			}
			String output = response.getEntity(String.class);
			Gson gson = new Gson();
			Type confType = new TypeToken<MessageResponse>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType);
			output = messageResponse.getMessage();
			if (output.equals("Success")
					|| messageResponse.getMessage().equals(Message.MESSAGE_ACCOUNT_ALREADY_ACTIVE.getValue())) {
				return true;
			}

			// Gson gson = new Gson();
			// messageResponse = gson.fromJson(output));
		} catch (Exception e) {

			e.printStackTrace();
			return false;
		}
		return false;
	}

	@Override
	public boolean updateInformation(UpdateInformationModel infoUserModel, String token) {
		if (infoUserModel != null) {
			try {
				MessageResponse messageResponse = new MessageResponse();
				Gson gson = new Gson();
				String json = gson.toJson(infoUserModel);
				Client client = Client.create(ClientHelper.configureClient());

				String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrUpdateInformation());
				WebResource webResource = client.resource(url);
				ClientResponse response = webResource.type("application/json").header("token", token)
						.put(ClientResponse.class, json);

				if (response.getStatus() != 200) {
					LOG.warn("Info Status:" + response.getStatus());
					LOG.warn("Info:" + response.getEntity(String.class));
					return false;
				}

				String output = response.getEntity(String.class);
				Type confType = new TypeToken<MessageResponse<PhrRegisterModel>>() {
				}.getType();
				messageResponse = gson.fromJson(output, confType);
				System.out.println(output);

				return true;

			} catch (Exception e) {
				System.out.println(e.getMessage());
				return false;
			}
		}
		return false;
	}

	@Override
	public boolean changePassword(ChangePassModel userChangePassModel) {
		if (userChangePassModel != null) {
			try {
				MessageResponse messageResponse = new MessageResponse();
				Gson gson = new Gson();
				String json = gson.toJson(userChangePassModel);
				Client client = Client.create(ClientHelper.configureClient());

				String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrChangePass());
				WebResource webResource = client.resource(url);
				ClientResponse response = webResource.type("application/json").put(ClientResponse.class, json);
				if (response.getStatus() != 200) {
					LOG.warn("Info Status:" + response.getStatus());
					LOG.warn("Info:" + response.getEntity(String.class));
					return false;
				}
				String output = response.getEntity(String.class);
				Type confType = new TypeToken<MessageResponse<PhrRegisterModel>>() {
				}.getType();
				messageResponse = gson.fromJson(output, confType);
				System.out.println(output);
				output = messageResponse.getMessage();
				LOG.info("[FE][PHR]Update information complete");
				return true;

			} catch (Exception e) {
				System.out.println(e.getMessage());
				return false;
			}
		}
		return false;

	}

	@Override
	public boolean bookingInsertDataAccountclinic(PhrAccountClinicModel model, String token) {
		// TODO Auto-generated method stub
		try {
			MessageResponse messageResponse = new MessageResponse();
			GsonBuilder builder = new GsonBuilder();
			builder.serializeNulls();
			Gson gson = builder.create();
			String json = gson.toJson(model);
			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrAddAccountClinic());
			WebResource webResource = client.resource(url);
			ClientResponse response = webResource.type("application/json").header("token", token)
					.post(ClientResponse.class, json);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return false;
			}
			String output = response.getEntity(String.class);
			System.out.println(output);
			Type confType = new TypeToken<MessageResponse<PhrAccountClinicModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType);
			output = messageResponse.getMessage();
			LOG.info("[FE][PHR]Booking Accout clinic complete");
			if (output.equals("Success")) {
				return true;
			}
		} catch (Exception e) {
			System.out.println(e.getMessage());
			LOG.info("[FE][PHR]Booking Accout clinic failed");
			return false;
		}
		return false;
	}

	@Override
	public ProfileStandard getListPatientByprofileId(Long profileId, String token) {
		// TODO Auto-generated method stub
		ProfileStandard profileStandard = new ProfileStandard();
		try {
			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrFindPatientByProfileId());
			WebResource webResource = client.resource(url + "/" + profileId);

			ClientResponse response = webResource.type("application/json").header("token", token).get(ClientResponse.class);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return null;
			}
			String output = response.getEntity(String.class);
			Gson gson = new Gson();
			Type confType = new TypeToken<MessageResponse<ProfileStandard>>() {
			}.getType();
			MessageResponse<ProfileStandard> messageResponse = gson.fromJson(output, confType);
			profileStandard = messageResponse.getContent();
			LOG.info("Get profile success");
			return profileStandard;
			// Gson gson = new Gson();
			// messageResponse = gson.fromJson(output));
		} catch (Exception e) {

			e.printStackTrace();
			return null;
		}
	}

	@Override
	public String getPhrDeviceToken(String patientCode, String hospCode , String token) {
		// TODO Auto-generated method stub
		String tokenDevice = null;
		try{
			Client client = Client.create(ClientHelper.configureClient());
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiPhrGetTokenDevice());
			WebResource webResource = client.resource(url);
			MultivaluedMap<String, String> queryParams  = new MultivaluedMapImpl();
			queryParams.add("patient_code", patientCode);
			queryParams.add("hosp_code", hospCode);
			ClientResponse response = webResource.queryParams(queryParams).type("application/json").get(ClientResponse.class);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return null;
			}
			String output = response.getEntity(String.class);
			Gson gson = new Gson();
			Type confType = new TypeToken<MessageResponse<String>>() {
			}.getType();
			MessageResponse<String> messageResponse = gson.fromJson(output, confType);
			tokenDevice = messageResponse.getContent();
			LOG.info("Get token device successfully");
			return tokenDevice;
			
		}catch(Exception e)
		{
		e.printStackTrace();
		return null;
		}
	}

	@Override
	public String getAllConnectionFromPeer() {
		try{
			String url = MssConfiguration.getInstance().getLstpeeridUrl();
			Client client = Client.create(ClientHelper.configureClient());
			client.setConnectTimeout(5000);
			WebResource webResource = client.resource(url);
			ClientResponse response = webResource.get(ClientResponse.class);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return "";
			}
			String output = response.getEntity(String.class);
			return output;
		}
		catch(Exception e)
		{
		e.printStackTrace();
		return "";
		}
		
	}
	
	
}