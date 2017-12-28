package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdMasterListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00GrdMasterRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00GrdMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL0108U00GrdMasterHandler extends ScreenHandler<CplsServiceProto.CPL0108U00GrdMasterRequest, CplsServiceProto.CPL0108U00GrdMasterResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0108U00GrdMasterHandler.class);
	@Resource
	private Cpl0108Repository  cpl0108Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0108U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0108U00GrdMasterRequest request)
					throws Exception {
		CplsServiceProto.CPL0108U00GrdMasterResponse.Builder response = CplsServiceProto.CPL0108U00GrdMasterResponse.newBuilder();
		List<CPL0108U00InitGrdMasterListItemInfo> listResult = cpl0108Repository.getListCPL0108U00GrdMaster(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeTypeName());
		 if(listResult != null && !listResult.isEmpty()){
	    	 for(CPL0108U00InitGrdMasterListItemInfo item : listResult){
	    		 CplsModelProto.CPL0108U00InitGrdMasterListItemInfo.Builder info = CplsModelProto.CPL0108U00InitGrdMasterListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCodeType())) {
	    				info.setCodeType(item.getCodeType());
	    			}
	    			if (!StringUtils.isEmpty(item.getCodeTypeName())) {
	    				info.setCodeTypeName(item.getCodeTypeName());
	    			}
	    			response.addGrdMaster(info);
	    	 }
		 }
		return response.build();
	}
}
