package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase6Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH3001U00XSavePerformerCase6Handler 
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase6Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase6Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SchsModelProto.SCH3001U00XSavePerformerCase6Info> listItem = request.getItemCase6List();
    	if (!CollectionUtils.isEmpty(listItem)) {
			for (SchsModelProto.SCH3001U00XSavePerformerCase6Info item : listItem) {
				if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.updateXSavePerformerCase6(item.getUserId(), new Date(), DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD), 
							hospCode, DateUtil.toDate(item.getOldJukyongDate(), DateUtil.PATTERN_YYMMDD), item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.deleteXSavePerformerCase6(hospCode, DateUtil.toDate(item.getOldJukyongDate(), DateUtil.PATTERN_YYMMDD), item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}

}
