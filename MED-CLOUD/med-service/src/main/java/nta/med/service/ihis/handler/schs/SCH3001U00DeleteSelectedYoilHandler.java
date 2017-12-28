package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00DeleteSelectedYoilRequest;
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
public class SCH3001U00DeleteSelectedYoilHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00DeleteSelectedYoilRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00DeleteSelectedYoilRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	List<CommonModelProto.DataStringListItemInfo> lstSelectedYoil = request.getSelectedYoilList();
    	List<String> listYoilGubun = new ArrayList<String>();
    	if (!CollectionUtils.isEmpty(lstSelectedYoil)) {
			for (CommonModelProto.DataStringListItemInfo item : lstSelectedYoil) {
				listYoilGubun.add(item.getDataValue());
			}
    	}
    	Date jukyongDate = DateUtil.toDate(request.getJukyongDate(), DateUtil.PATTERN_YYMMDD);
    	sch3000Repository.deleteSelectedYoil(getHospitalCode(vertx, sessionId), jukyongDate, request.getJundalTable(),
    			request.getJundalPart(), listYoilGubun, request.getGumsaja());
		response.setResult(true);
    	return response.build();
	}
}
