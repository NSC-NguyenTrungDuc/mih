package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch3100;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3100Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase4Request;
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
public class SCH3001U00XSavePerformerCase4Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase4Request,  SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch3100Repository sch3100Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase4Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SchsModelProto.SCH3001U00XSavePerformerCase4Info> listItem = request.getItemCase4List();
    	if (!CollectionUtils.isEmpty(listItem)) {
			for (SchsModelProto.SCH3001U00XSavePerformerCase4Info item : listItem) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch3100 sch3100 = new Sch3100();
					sch3100.setSysDate(new Date());
					sch3100.setSysId(item.getUserId());
					sch3100.setUpdDate(new Date());
					sch3100.setUpdId(item.getUserId());
					sch3100.setHospCode(hospCode);
					sch3100.setJundalTable(item.getJundalTable());
					sch3100.setJundalPart(item.getJundalPart());
					sch3100.setGumsaja(item.getGumsaja());
					sch3100.setReserYn(item.getReserYn());
					sch3100.setReserDate(DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
					sch3100Repository.save(sch3100);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3100Repository.updateXSavePerformerCase4(item.getUserId(), new Date(), item.getReserYn(),
							hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3100Repository.deleteXSavePerformerCase4(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}
