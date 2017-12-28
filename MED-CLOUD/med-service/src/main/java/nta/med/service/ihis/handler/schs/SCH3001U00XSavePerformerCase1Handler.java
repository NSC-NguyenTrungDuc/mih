package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase1Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH3001U00XSavePerformerCase1Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase1Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch0001Repository sch0001Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase1Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SchsModelProto.SCH3001U00XSavePerformerCase1Info> listItem = request.getItemCase1List();
    	if (!CollectionUtils.isEmpty(listItem)) {
			for (SchsModelProto.SCH3001U00XSavePerformerCase1Info item : listItem) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch0001 sch0001 = new Sch0001();
					sch0001.setSysDate(new Date());
					sch0001.setSysId(item.getUserId());
					sch0001.setUpdDate(new Date());
					sch0001.setUpdId(item.getUserId());
					sch0001.setHospCode(hospCode);
					sch0001.setJundalTable(item.getJundalTable());
					sch0001.setJundalPart(item.getJundalPart());
					if(!StringUtils.isEmpty(item.getGumsaja())){
						sch0001.setGumsaja(item.getGumsaja());
					}else{
						sch0001.setGumsaja("%");
					}
					sch0001.setJundalPartName(item.getJundalPartName());
					if(!StringUtils.isEmpty(item.getGwaGubun())){
						sch0001.setGwaGubun(item.getGwaGubun());
					}else{
						sch0001.setGwaGubun("%");
					}
					Double gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
					sch0001.setGumsaTime(gumsaTime);
					
					sch0001Repository.save(sch0001);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					Double gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
					sch0001Repository.updateSCH0001XSavePerformerCase1(item.getUserId(), new Date(), 
							item.getJundalPartName(), item.getGwaGubun(), gumsaTime, hospCode,
							item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch0001Repository.deleteSCH0001XSavePerformerCase1(hospCode,
							item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}
