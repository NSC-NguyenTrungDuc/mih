package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0891Repository;
import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdIDListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdResultListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02RESULTMAPInitializeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02RESULTMAPInitializeResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U02RESULTMAPInitializeHandler extends ScreenHandler<CplsServiceProto.CPL3020U02RESULTMAPInitializeRequest, CplsServiceProto.CPL3020U02RESULTMAPInitializeResponse> {
	@Resource
	private Cpl0891Repository cpl0891Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U02RESULTMAPInitializeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02RESULTMAPInitializeRequest request) throws Exception {
        CplsServiceProto.CPL3020U02RESULTMAPInitializeResponse.Builder response = CplsServiceProto.CPL3020U02RESULTMAPInitializeResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        List<CPL3020U02RESULTMAPGrdIDListItemInfo> listCPL3020U02RESULTMAPGrdIDListItemInfo = cpl0891Repository.getCPL3020U02RESULTMAPGrdIDListItemInfo(hospCode, request.getJangbiCodeGrdIDList(), 
        		request.getSpecimenSerGrdIDList(), request.getFromDateGrdIDList(), request.getToDateGrdIDList(), request.getAllYnGrdIDList());
        if(!CollectionUtils.isEmpty(listCPL3020U02RESULTMAPGrdIDListItemInfo)) {
        	for(CPL3020U02RESULTMAPGrdIDListItemInfo item : listCPL3020U02RESULTMAPGrdIDListItemInfo) {
        		CplsModelProto.CPL3020U02RESULTMAPGrdIDListItemInfo.Builder info = CplsModelProto.CPL3020U02RESULTMAPGrdIDListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdIDList(info);
        	}
        }
            
        List<CPL3020U02RESULTMAPGrdResultListItemInfo> listCPL3020U02RESULTMAPGrdResultListItemInfo = cpl0891Repository.getCPL3020U02RESULTMAPGrdResultListItemInfo(hospCode, request.getJangbiCodeGrdResultList(),
        		request.getResultDateGrdResultList(), request.getSampleIdGrdResultList());
        if(!CollectionUtils.isEmpty(listCPL3020U02RESULTMAPGrdResultListItemInfo)) {
        	for(CPL3020U02RESULTMAPGrdResultListItemInfo item : listCPL3020U02RESULTMAPGrdResultListItemInfo) {
        		CplsModelProto.CPL3020U02RESULTMAPGrdResultListItemInfo.Builder info = CplsModelProto.CPL3020U02RESULTMAPGrdResultListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdResultList(info);
        	}
        }    
        return response.build();
	}
}
