package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.model.ihis.cpls.CPL0108U01GrdMasterItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01GrdMasterRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01GrdMasterResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0108U01GrdMasterHandler extends ScreenHandler<CplsServiceProto.CPL0108U01GrdMasterRequest, CplsServiceProto.CPL0108U01GrdMasterResponse> {                     
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override                
	@Transactional(readOnly = true)
	@Route(global = true)
	public CPL0108U01GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0108U01GrdMasterRequest request)
			throws Exception  {                                                                   
  	   	CplsServiceProto.CPL0108U01GrdMasterResponse.Builder response = CplsServiceProto.CPL0108U01GrdMasterResponse.newBuilder();
		String hospCode = StringUtils.isEmpty(request.getHospCode()) ?  getHospitalCode(vertx, sessionId) : request.getHospCode();
		List<CPL0108U01GrdMasterItemInfo> listGrdMaster = cpl0108Repository.getCPL0108U01grdMasterItemInfo(hospCode, getLanguage(vertx, sessionId),
				request.getCodeType(), request.getCodeTypeName());
		if(!CollectionUtils.isEmpty(listGrdMaster)){
			for(CPL0108U01GrdMasterItemInfo item : listGrdMaster){
				CplsModelProto.CPL0108U01GrdMasterItemInfo.Builder info = CplsModelProto.CPL0108U01GrdMasterItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMstItem(info);
			}
		}
		return response.build();
	}   
}

