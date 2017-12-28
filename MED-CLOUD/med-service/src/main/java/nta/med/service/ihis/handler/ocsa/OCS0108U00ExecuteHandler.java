package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0108;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0108U00grdOCS0108ItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00ExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCS0108U00ExecuteHandler extends ScreenHandler<OcsaServiceProto.OCS0108U00ExecuteRequest, SystemServiceProto.UpdateResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0108U00ExecuteHandler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                     
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0108U00ExecuteRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0108U00ExecuteRequest request)
			throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
		String hospCode = request.getHospCode();
		for(OCS0108U00grdOCS0108ItemInfo info : request.getItemInfoList()){
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
					Ocs0108 ocs0108= new Ocs0108();
					ocs0108.setSysDate(new Date());
					ocs0108.setSysId(request.getUserId());
					ocs0108.setHangmogCode(info.getHangmogCode());
					ocs0108.setOrdDanui(info.getOrdDanui());
					ocs0108.setSeq(CommonUtils.parseDouble(info.getSeq()));
					ocs0108.setChangeQty1(CommonUtils.parseDouble(info.getChangeQty1()));
					ocs0108.setChangeQty2(CommonUtils.parseDouble(info.getChangeQty2()));
					ocs0108.setHospCode(hospCode);
					if (!StringUtils.isEmpty(info.getHangmogStartDate()) && DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD) != null) {
						ocs0108.setHangmogStartDate(DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD));    
			        }
					ocs0108Repository.save(ocs0108);
		    	} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
		    		ocs0108Repository.updateOCS0108U00Execute(hospCode,
		    				request.getUserId(), CommonUtils.parseDouble(info.getSeq()), CommonUtils.parseDouble(info.getChangeQty1()),
		    				CommonUtils.parseDouble(info.getChangeQty2()),info.getHangmogCode(),
		    				DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD), info.getOrdDanui());
		    	} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
		    		ocs0108Repository.deleteOCS0108U00Execute(hospCode, info.getHangmogCode(),
		    				DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD), info.getOrdDanui());
		    	}
			}	
		response.setResult(true);
		return response.build();
	}                                                                                                                                                   
}