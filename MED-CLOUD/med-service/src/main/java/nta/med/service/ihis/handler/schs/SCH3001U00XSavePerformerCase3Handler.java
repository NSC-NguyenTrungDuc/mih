package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0002;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0002Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase3Request;
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
public class SCH3001U00XSavePerformerCase3Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase3Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Resource
	private Sch0002Repository sch0002Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase3Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SchsModelProto.SCH3001U00XSavePerformerCase3Info> listItem = request.getItemCase3List();
    	if (!CollectionUtils.isEmpty(listItem)) {
			for (SchsModelProto.SCH3001U00XSavePerformerCase3Info item : listItem) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					sch0201Repository.updateXSavePerformerCase3(item.getJundalTable(), item.getJundalPart(),
							hospCode, item.getHangmogCode(), item.getGumsaja());
					
					Sch0002 sch0002 = new Sch0002();
					sch0002.setSysDate(new Date());
					sch0002.setSysId(item.getUserId());
					sch0002.setUpdDate(new Date());
					sch0002.setUpdId(item.getUserId());
					sch0002.setHospCode(hospCode);
					sch0002.setJundalTable(item.getJundalTable());
					sch0002.setJundalPart(item.getJundalPart());
					if(!StringUtils.isEmpty(item.getGumsaja())){
						sch0002.setGumsaja(item.getGumsaja());
					}else{
						sch0002.setGumsaja("%");
					}
					sch0002.setHangmogCode(item.getHangmogCode());
					sch0002.setHangmogName(item.getHangmogName());
					Double gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
					sch0002.setGumsaTime(gumsaTime);
					
					sch0002Repository.save(sch0002);
					
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					Double gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
					sch0002Repository.updateXSavePerformerCase3(item.getUserId(), new Date(), item.getHangmogName(),
							gumsaTime, hospCode, item.getJundalTable(), item.getJundalPart(), item.getHangmogCode());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch0002Repository.deleteXSavePerformerCase3(hospCode, item.getJundalTable(), item.getJundalPart(), item.getHangmogCode());
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}
