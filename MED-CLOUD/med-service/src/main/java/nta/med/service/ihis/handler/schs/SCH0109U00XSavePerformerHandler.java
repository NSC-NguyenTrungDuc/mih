package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0109;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00XSavePerformerRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH0109U00XSavePerformerHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U00XSavePerformerRequest, SystemServiceProto.UpdateResponse> {
	
//	@Resource
//	private Sch0108Repository sch0108Repository;
	
	@Resource
	private Sch0109Repository sch0109Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0109U00XSavePerformerRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<SchsModelProto.SCH0109U00GrdDetailInfo> listGrdDetail = request.getGrdDetailListList();
    	for(SchsModelProto.SCH0109U00GrdDetailInfo itemGrd : listGrdDetail){
    		if(DataRowState.ADDED.getValue().equals(itemGrd.getDataRowState())){
    			Sch0109 sch0109 = new Sch0109();
    			sch0109.setSysDate(new Date());
    			sch0109.setSysId(request.getUserId());
    			sch0109.setUpdDate(new Date());
    			sch0109.setUpdId(request.getUserId());
    			sch0109.setHospCode(hospCode);
    			sch0109.setLanguage(language);
    			sch0109.setCodeType(itemGrd.getCodeType());
    			sch0109.setCode(itemGrd.getCode());
    			sch0109.setCodeName(itemGrd.getCodeName());
    			sch0109.setCode2(itemGrd.getCode2());
    			sch0109.setCodeName2(itemGrd.getCodeName2());
    			sch0109Repository.save(sch0109);
    		}else if(DataRowState.MODIFIED.getValue().equals(itemGrd.getDataRowState())){
    			sch0109Repository.updateSCH0109XSavePerformer(request.getUserId(), new Date(), itemGrd.getCodeName(), itemGrd.getCodeName2(), itemGrd.getCode2(),
    					hospCode, itemGrd.getCodeType(), itemGrd.getCode());
    		}else if(DataRowState.DELETED.getValue().equals(itemGrd.getDataRowState())){
    			sch0109Repository.deleteSCH0109XSavePerformer(hospCode, language, itemGrd.getCodeType(), itemGrd.getCode());
    		}
    	}
    	response.setResult(true);
    	return response.build();
	}
}
