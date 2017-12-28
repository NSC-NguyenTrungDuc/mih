package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.collections.CollectionUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import nta.mss.entity.UserChild;
import nta.mss.model.UserChildModel;
import nta.mss.repository.UserChildRepository;
import nta.mss.service.IUserChildService;

// TODO: Auto-generated Javadoc
/**
 * The Class UserChildService.
 */
@Service
public class UserChildService implements IUserChildService {
	
	/** The mapper. */
	private Mapper mapper;
	
	/** The user child repository. */
	private UserChildRepository userChildRepository;
	
	/**
	 * Instantiates a new user child service.
	 */
	public UserChildService() {

	}
	
	/**
	 * Instantiates a new user child service.
	 *
	 * @param mapper the mapper
	 * @param userChildRepository the user child repository
	 */
	@Autowired
	public UserChildService(Mapper mapper,
			UserChildRepository userChildRepository) {
		this.mapper = mapper;
		this.userChildRepository = userChildRepository;
	}
	
	/**
	 * Find user child by active flg.
	 *
	 * @param activeFlg the active flg
	 * @return the list
	 */
	public List<UserChildModel> findUserChildByActiveFlg(Integer userId, Integer activeFlg) throws Exception {
		List<UserChildModel> lstUChildModel = new ArrayList<UserChildModel>();
		List<UserChild> lstChild = this.userChildRepository.findChildByActiveFlg(userId, activeFlg);
		if (CollectionUtils.isNotEmpty(lstChild)) {
			for (UserChild userChild : lstChild) {
				lstUChildModel.add(userChild.toModel(mapper));
			}
		}
		return lstUChildModel;
	}
	
	/*public List<UserChildModel> findUserChildByUserId(Integer userId, String token) {
		List<UserChildModel> lstUChildModel = new ArrayList<UserChildModel>();
		
		PhrApiService phrApiService = new PhrApiService();
		PhrUserChildInfoModel phrUserChildInfoModel = new PhrUserChildInfoModel();
		phrUserChildInfoModel.setId(new Long(userId));
		MessageResponse<List<PhrUserChildInfoModel>> phrAccountInfoModelRes1 = phrApiService.findUserChildsByAccountId(phrUserChildInfoModel, token);
		List<PhrUserChildInfoModel> ls = phrAccountInfoModelRes1.getContent();
		if(ls != null && ls.size() > 0) {
			for (PhrUserChildInfoModel p : ls) {
				UserChildModel userChildModel = new UserChildModel();
				userChildModel.setChildId(new Integer(p.getId().intValue()));
				userChildModel.setChildName(p.getFullname());
				userChildModel.setChildNameFurigana(p.getFullname_kana());
				userChildModel.setDob(p.getBirth_day());
				if("M".equalsIgnoreCase(p.getSex()))
					userChildModel.setSex("1");
				if("F".equalsIgnoreCase(p.getSex()))
					userChildModel.setSex("0");
				lstUChildModel.add(userChildModel);
			}
		}
		
		return lstUChildModel;
	}*/
	
	
//	public UserChildModel findByPatientId(Integer patientId){
//		if (childId == null) {
//			return null;
//		}
//		List<UserChild>  lstChild = this.userChildRepository.findUserChildByPatientId(patientId);
//		
//		return null;
//		
//	}
	

	@Override
	public UserChildModel findById(Integer childId) throws Exception {
		if (childId == null) {
			return null;
		}
		UserChild userChild = this.userChildRepository.findOne(childId);
		if (userChild != null) {
			return userChild.toModel(mapper);
		}
		return null;
	}
	
	/*@Override
	public UserChildModel findById(Integer childId, String token) throws Exception {
		if (childId == null) {
			return null;
		}
		
		PhrApiService phrApiService = new PhrApiService();
		PhrUserChildInfoModel phrUserChildInfoModel = new PhrUserChildInfoModel();
		phrUserChildInfoModel.setId(new Long(childId));
		MessageResponse<PhrUserChildInfoModel> phrAccountInfoModelRes = phrApiService.findUserChildById(phrUserChildInfoModel, token);
		PhrUserChildInfoModel phrUserChildInfoModelRes = phrAccountInfoModelRes.getContent();
		if(phrUserChildInfoModelRes != null) {
			UserChildModel userChildModel = new UserChildModel();
			userChildModel.setChildId(new Integer(phrUserChildInfoModelRes.getId().intValue()));
			userChildModel.setChildName(phrUserChildInfoModelRes.getFullname());
			userChildModel.setChildNameFurigana(phrUserChildInfoModelRes.getFullname_kana());
			userChildModel.setDob(phrUserChildInfoModelRes.getBirth_day());
			if("M".equalsIgnoreCase(phrUserChildInfoModelRes.getSex()))
				userChildModel.setSex("1");
			if("F".equalsIgnoreCase(phrUserChildInfoModelRes.getSex()))
				userChildModel.setSex("0");
			
			return userChildModel;
		}
		
		return null;
	}*/
	
	/**
	 * Save.
	 *
	 * @param userChildModel the user child model
	 * @throws Exception the exception
	 */
	public void save(UserChildModel userChildModel) throws Exception {
		String dob = userChildModel.getDob().replace("/", "");
		userChildModel.setDob(dob);
		this.userChildRepository.save(userChildModel.toEntity(mapper));
	}
	
	@Override
	public UserChild getUserChildByPatientId(Integer patientId){
		List<UserChild> userChilds = userChildRepository.findUserChildByPatientId(patientId);
		if(!CollectionUtils.isEmpty(userChilds)){
			return userChilds.get(0);
		}
		
		return null;
	}
}
