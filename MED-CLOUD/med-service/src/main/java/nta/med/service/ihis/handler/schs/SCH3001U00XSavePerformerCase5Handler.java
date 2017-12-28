package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch3101;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase5Request;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH3001U00XSavePerformerCase5Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase5Request,  SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch3101Repository sch3101Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase5Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SchsModelProto.SCH3001U00XSavePerformerCase5Info> listItem = request.getItemCase5List();
    	if (!CollectionUtils.isEmpty(listItem)) {
			for (SchsModelProto.SCH3001U00XSavePerformerCase5Info item : listItem) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch3101 Sch3101 = new Sch3101();
					Sch3101.setSysDate(new Date());
					Sch3101.setSysId(item.getUserId());
					Sch3101.setUpdDate(new Date());
					Sch3101.setUpdId(item.getUserId());
					Sch3101.setHospCode(hospCode);
					Sch3101.setJundalTable(item.getJundalTable());
					Sch3101.setJundalPart(item.getJundalPart());
					Sch3101.setGumsaja(item.getGumsaja());
					Sch3101.setReserDate(DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
					Sch3101.setStartTime(item.getStartTime());
					Sch3101.setEndTime(item.getEndTime());
					Sch3101.setInwon(CommonUtils.parseDouble(item.getInwon()));
					Sch3101.setAddInwon(CommonUtils.parseDouble(item.getAddInwon()));
					sch3101Repository.save(Sch3101);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3101Repository.updateXSavePerformerCase5(item.getUserId(), new Date(), item.getEndTime(), CommonUtils.parseDouble(item.getInwon()), CommonUtils.parseDouble(item.getAddInwon()),
							hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD), item.getStartTime());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3101Repository.deleteXSavePerformerCase5(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD), item.getStartTime());
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}
