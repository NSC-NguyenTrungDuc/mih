package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayChkNameCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayChkNamesRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayChkNamesResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL2010U00LayChkNamesHandler extends ScreenHandler <CplsServiceProto.CPL2010U00LayChkNamesRequest, CplsServiceProto.CPL2010U00LayChkNamesResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00LayChkNamesResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00LayChkNamesRequest request) throws Exception {
        CplsServiceProto.CPL2010U00LayChkNamesResponse.Builder response = CplsServiceProto.CPL2010U00LayChkNamesResponse.newBuilder();
    	List<CplsCPL2010U00LayChkNameCPL2010ListItemInfo> listLayChkName=cpl2010Repository.getCplsCPL2010U00LayChkNameListItemInfo(getHospitalCode(vertx, sessionId), 
				request.getBunho(), request.getReserDate());
		 if(listLayChkName != null && !listLayChkName.isEmpty()){
			 for(CplsCPL2010U00LayChkNameCPL2010ListItemInfo item: listLayChkName){
				 CplsModelProto.CPL2010U00LayChkNameListItemInfo.Builder info= CplsModelProto.CPL2010U00LayChkNameListItemInfo.newBuilder();
				    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addLayChkNamesList(info);
			 }
		 }
		 return response.build();
	}
}
