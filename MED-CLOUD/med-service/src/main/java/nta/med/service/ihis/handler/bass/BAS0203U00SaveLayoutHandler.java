package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0203;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0203Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0203U00GrdBAS0203Info;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class BAS0203U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0203U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00SaveLayoutHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0203Repository bas0203Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0203U00SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0203U00SaveLayoutRequest request) throws Exception {
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
  	   	Integer result = null;
		String hospCode = request.getHospCode();
		String userId = request.getUserId();
		for(BAS0203U00GrdBAS0203Info info : request.getGrdBas0203ItemList()){
			Date jyDate = DateUtil.toDate(info.getJyDate(), DateUtil.PATTERN_YYMMDD);
			Double fromMonth = CommonUtils.parseDouble(info.getFromMonth());
			Double toMonth = CommonUtils.parseDouble(info.getToMonth());
			Double oldToMonth = CommonUtils.parseDouble(info.getOldToMonth());
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				String getY = bas0203Repository.getYFromBas0203(hospCode, info.getSymyaGubun(), info.getBunCode(), info.getSgCode(), jyDate, 
						info.getYoilGubun(), fromMonth, oldToMonth, info.getFromTime(), info.getToTime());
				if(!StringUtils.isEmpty(getY) && "Y".equalsIgnoreCase(getY)){
					if(!StringUtils.isEmpty(info.getSymyaGubun())){
						response.setMsg(info.getSymyaGubun());
					}
					response.setResult(result != null && result > 0);
					throw new ExecutionException(response.build());
				}
				result = insertBas0203(info, hospCode, userId);
			}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				result = bas0203Repository.updateBas0203(hospCode, info.getSymyaGubun(), info.getBunCode(), info.getSgCode(), info.getFromTime(), jyDate, 
						info.getYoilGubun(), fromMonth, oldToMonth, info.getOldToTime(), userId, new Date(), info.getToTime(), toMonth);
			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				result = bas0203Repository.deleteBas0203(hospCode, info.getSymyaGubun(), info.getBunCode(), info.getSgCode(), 
						info.getFromTime(), jyDate, info.getYoilGubun(), fromMonth, toMonth, info.getToTime());
			}
		}
		response.setResult(result != null && result > 0);
		return response.build();
  				                                                                                   
	}
	private Integer insertBas0203(BAS0203U00GrdBAS0203Info info, String hospCode, String userId){
		Bas0203 bas0203 = new Bas0203();
		Date jyDate = DateUtil.toDate(info.getJyDate(), DateUtil.PATTERN_YYMMDD);
		Double fromMonth = CommonUtils.parseDouble(info.getFromMonth()); 
		Double toMonth = CommonUtils.parseDouble(info.getToMonth());
		
		bas0203.setSysDate(new Date());
		bas0203.setSysId(userId);
		bas0203.setUpdDate(new Date());
		bas0203.setUpdId(userId);
		bas0203.setHospCode(hospCode);
		bas0203.setJyDate(jyDate);
		bas0203.setSymyaGubun(info.getSymyaGubun());
		bas0203.setBunCode(info.getBunCode());
		bas0203.setSgCode(info.getSgCode());
		bas0203.setFromTime(info.getFromTime());
		bas0203.setToTime(info.getToTime());
		bas0203.setYoilGubun(info.getYoilGubun());
		bas0203.setFromMonth(fromMonth);
		bas0203.setToMonth(toMonth);
		bas0203Repository.save(bas0203);
		return 1;
	}
}