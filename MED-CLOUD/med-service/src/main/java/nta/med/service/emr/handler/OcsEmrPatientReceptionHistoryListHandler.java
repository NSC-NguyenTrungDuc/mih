package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsEmrPatientReceptionHistoryListHandler extends ScreenHandler<EmrServiceProto.OcsEmrPatientReceptionHistoryListRequest, EmrServiceProto.OcsEmrPatientReceptionHistoryListResponse> {
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;    

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OcsEmrPatientReceptionHistoryListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OcsEmrPatientReceptionHistoryListRequest request) throws Exception {
		EmrServiceProto.OcsEmrPatientReceptionHistoryListResponse.Builder response = EmrServiceProto.OcsEmrPatientReceptionHistoryListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo(getLanguage(vertx, sessionId), hospCode, request.getPatientCode());
		if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
			for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
				EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.Builder info = EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				List<OCS2015U03OrderGubunInfo> listGubun = ocs1003Repository.getOCS2015U03OrderGubunInfo(hospCode, request.getPatientCode(), item.getPkout1001());
				for (OCS2015U03OrderGubunInfo orderItem : listGubun) {
					EmrModelProto.OCS2015U03OrderGubunInfo.Builder orderInfo = EmrModelProto.OCS2015U03OrderGubunInfo.newBuilder();
					BeanUtils.copyProperties(orderItem, orderInfo, getLanguage(vertx, sessionId));
					info.addOrderGubun(orderInfo);
				}
				
				response.addPatientReceptionHistoryListItem(info);
			}
		}
		return response.build();
	}
}