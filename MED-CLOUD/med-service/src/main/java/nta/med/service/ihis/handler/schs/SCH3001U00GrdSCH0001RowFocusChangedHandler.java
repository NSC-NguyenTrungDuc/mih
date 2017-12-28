package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0002Repository;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.data.dao.medi.sch.Sch3100Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdJukyongDateInfo;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0002Info;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3100Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdSCH0001RowFocusChangedHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedRequest, SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedResponse> {
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Resource
	private Sch3100Repository sch3100Repository;
	
	@Resource
	private Sch0002Repository sch0002Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdSCH0001RowFocusChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SCH3001U00GrdSCH0001RowFocusChangedRequest request)
			throws Exception {
        SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedResponse.Builder response = SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	List<SCH3001U00GrdJukyongDateInfo> listSCH3001U00GrdJukyongDateInfo = sch3000Repository.getSCH3001U00GrdJukyongDateInfo(hospCode, request.getJundalTable(), request.getJundalPart(), request.getGumsaja());
    	if(listSCH3001U00GrdJukyongDateInfo != null && !listSCH3001U00GrdJukyongDateInfo.isEmpty()){
			for(SCH3001U00GrdJukyongDateInfo item : listSCH3001U00GrdJukyongDateInfo){
				SchsModelProto.SCH3001U00GrdJukyongDateInfo.Builder info = SchsModelProto.SCH3001U00GrdJukyongDateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addJukyongDateInfo(info);
			}
		}
    	
    	List<SCH3001U00GrdSCH0002Info> listSCH3001U00GrdSCH0002Info = sch0002Repository.getSCH3001U00GrdSCH0002Info(hospCode, request.getJundalTable(),request.getJundalPart());
    	if(listSCH3001U00GrdSCH0002Info != null && !listSCH3001U00GrdSCH0002Info.isEmpty()){
			for(SCH3001U00GrdSCH0002Info item : listSCH3001U00GrdSCH0002Info){
				SchsModelProto.SCH3001U00GrdSCH0002Info.Builder info = SchsModelProto.SCH3001U00GrdSCH0002Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdSch0002Info(info);
			}
		}
    	
    	List<SCH3001U00GrdSCH3100Info> listSCH3001U00GrdSCH3100Info = sch3100Repository.getSCH3001U00GrdSCH3100Info(hospCode, request.getJundalTable(), request.getJundalPart(), request.getGumsaja());
    	if(listSCH3001U00GrdSCH3100Info != null && !listSCH3001U00GrdSCH3100Info.isEmpty()){
			for(SCH3001U00GrdSCH3100Info item : listSCH3001U00GrdSCH3100Info){
				SchsModelProto.SCH3001U00GrdSCH3100Info.Builder info = SchsModelProto.SCH3001U00GrdSCH3100Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdSch3100Info(info);
			}
		}
    	
    	return response.build();
	}
}
