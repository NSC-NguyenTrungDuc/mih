package nta.med.service.ihis.handler.drug;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.drg.Drg0120;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.service.ihis.proto.DrugModelProto.DRG0120U00GrdDrg0120ItemInfo;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DRG0120U00SaveLayoutHandler extends ScreenHandler<DrugServiceProto.DRG0120U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(DRG0120U00SaveLayoutHandler.class);                                    
	
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository; 
	@Resource
    private Bas0001Repository bas0001Repository;
	
	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, DrugServiceProto.DRG0120U00SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	                                                                                                                
	@Override
	//@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0120U00SaveLayoutRequest request) throws Exception {
		
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			for(DRG0120U00GrdDrg0120ItemInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insertDrg0120(item, request.getUserId(), language, hospitalCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateDrg0120(item, request.getUserId(), hospitalCode, language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(deleteDrg0120(item, request.getUserId(), hospitalCode, language));
				}
			}
		}
		return response.build();
	}
	
	public boolean insertDrg0120(DRG0120U00GrdDrg0120ItemInfo item, String userId, String language, String hospitalCode){
		Drg0120 drg0120 = new Drg0120();
		drg0120.setSysDate(new Date());
		drg0120.setSysId(userId);
		drg0120.setBogyongCode(item.getBogyongCode());
		drg0120.setBogyongName(item.getBogyongName());
		drg0120.setPattern(item.getPattern());
		drg0120.setBogyongGubun(item.getBogyongGubun());
		drg0120.setDrgGrp(item.getDrgGrp());
		drg0120.setBogyongName2(item.getBogyongName2());
		drg0120.setBogyongGubunDefault(item.getBogyongGubunDefault());
		drg0120.setPrtGubun(item.getPrtGubun());
		drg0120.setBunryu1(item.getBunryu1());
		drg0120.setBogyongCodeFull(item.getBogyongCodeFull());
		drg0120.setSpBogyongYn(item.getSpBogyongYn());
		drg0120.setBlockGubun(item.getBlockGubun());
		drg0120.setBanghyang(item.getBanghyang());
		drg0120.setChiryoGubun(item.getChiryoGubun());
		drg0120.setDonbogYn(item.getDonbogYn());
		drg0120.setBogyongJoFlag(item.getBogyongJoFlag());
		drg0120.setBogyongJuFlag(item.getBogyongJuFlag());
		drg0120.setBogyongSeokFlag(item.getBogyongSeokFlag());
		drg0120.setBogyongTime1Flag(item.getBogyongTime1Flag());
		drg0120.setBogyongTime2Flag(item.getBogyongTime2Flag());
		drg0120.setBogyongTime3Flag(item.getBogyongTime3Flag());
		drg0120.setBogyongTime4Flag(item.getBogyongTime4Flag());
		drg0120.setBogyongTime5Flag(item.getBogyongTime5Flag());
		drg0120.setBogyongTime6Flag(item.getBogyongTime6Flag());
		drg0120.setBogyongTime7Flag(item.getBogyongTime7Flag());
		drg0120.setLanguage(language);
		drg0120.setHospCode(hospitalCode);
		
		drg0120Repository.save(drg0120);
		return true;
	}
	
	public boolean updateDrg0120(DRG0120U00GrdDrg0120ItemInfo item, String userId, String hospitalCode, String language){
		if(drg0120Repository.updateDrg0120(new Date(), item.getBogyongName(), item.getPattern(), item.getBogyongGubun()
				, item.getDrgGrp(), item.getBogyongName2(), item.getBogyongGubunDefault(), item.getPrtGubun()
				, item.getBunryu1(), item.getBogyongCodeFull(), item.getSpBogyongYn(), item.getBlockGubun()
				, item.getBanghyang(), item.getChiryoGubun(), item.getDonbogYn(), userId
				, item.getBogyongJoFlag(), item.getBogyongJuFlag(), item.getBogyongSeokFlag()
				, item.getBogyongTime1Flag(), item.getBogyongTime2Flag(), item.getBogyongTime3Flag()
				, item.getBogyongTime4Flag(), item.getBogyongTime5Flag(), item.getBogyongTime6Flag()
				, item.getBogyongTime7Flag(), item.getBogyongCode(), hospitalCode, language) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean deleteDrg0120(DRG0120U00GrdDrg0120ItemInfo item, String userId, String hospitalCode, String language){
		if(drg0120Repository.deleteDrg0120(item.getBogyongCode(), hospitalCode, language) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	@Override
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrugServiceProto.DRG0120U00SaveLayoutRequest request, UpdateResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
}