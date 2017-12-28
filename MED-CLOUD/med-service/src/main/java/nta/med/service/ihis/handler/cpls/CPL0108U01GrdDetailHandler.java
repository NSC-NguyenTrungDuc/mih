package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdDetailListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01GrdDetailRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01GrdDetailResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0108U01GrdDetailHandler extends ScreenHandler<CplsServiceProto.CPL0108U01GrdDetailRequest, CplsServiceProto.CPL0108U01GrdDetailResponse> {                     
	
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, CPL0108U01GrdDetailRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public CPL0108U01GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0108U01GrdDetailRequest request)
			throws Exception {                                                                   
  	   	CplsServiceProto.CPL0108U01GrdDetailResponse.Builder response = CplsServiceProto.CPL0108U01GrdDetailResponse.newBuilder();
		String hospCode = StringUtils.isEmpty(request.getHospCode()) ?  getHospitalCode(vertx, sessionId) : request.getHospCode();
		List<CPL0108U00InitGrdDetailListItemInfo> listGrdDetail = cpl0109Repository.getListCPL0108U00GrdDetail(hospCode,
				request.getCodeType(), getLanguage(vertx, sessionId), null, null);
		if(!CollectionUtils.isEmpty(listGrdDetail)){
			for(CPL0108U00InitGrdDetailListItemInfo item : listGrdDetail){
				CplsModelProto.CPL0108U01GrdDetailInfo.Builder info = CplsModelProto.CPL0108U01GrdDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetailItem(info);
			}
		}
		return response.build();
	}
}