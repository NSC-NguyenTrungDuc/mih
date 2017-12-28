package nta.med.service.ihis.handler.nuro;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

/**
* @author dainguyen.
*/
@Service
@Scope("prototype")
public class NuroPatientReceptionHistoryListHandler extends ScreenHandler<NuroServiceProto.NuroPatientReceptionHistoryListRequest, NuroServiceProto.NuroPatientReceptionHistoryListResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroPatientReceptionHistoryListHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroPatientReceptionHistoryListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientReceptionHistoryListRequest request) throws Exception {
		List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode());
		NuroServiceProto.NuroPatientReceptionHistoryListResponse.Builder response = NuroServiceProto.NuroPatientReceptionHistoryListResponse.newBuilder();
		if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
			for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
				NuroModelProto.NuroPatientReceptionHistoryListItemInfo.Builder nuroPatientReceptionHistoryInfo = NuroModelProto.NuroPatientReceptionHistoryListItemInfo.newBuilder();
				
				if(item.getComingDate()!= null){
					nuroPatientReceptionHistoryInfo.setComingDate(item.getComingDate().toString());
				}
				if(item.getExamDate()!= null){
					nuroPatientReceptionHistoryInfo.setExamDate(item.getExamDate().toString());
				}
				if(item.getExamTime()!= null){
					nuroPatientReceptionHistoryInfo.setExamTime(item.getExamTime());
				}
				if(item.getDepartmentCode()!= null){
					nuroPatientReceptionHistoryInfo.setDepartmentCode(item.getDepartmentCode());
				}
				if(item.getDoctor()!= null){
					nuroPatientReceptionHistoryInfo.setDoctor(item.getDoctor());
				}
				if(item.getInsurType()!= null){
					nuroPatientReceptionHistoryInfo.setInsurType(item.getInsurType());
				}
				if(item.getSunnabStatus()!= null){
					nuroPatientReceptionHistoryInfo.setSunnabStatus(item.getSunnabStatus());
				}
				if(item.getComingStatus()!= null){
					nuroPatientReceptionHistoryInfo.setComingStatus(item.getComingStatus());
				}
				if(item.getPatientCode()!= null){
					nuroPatientReceptionHistoryInfo.setPatientCode(item.getPatientCode());
				}
				if(item.getReceptionTime()!= null){
					nuroPatientReceptionHistoryInfo.setReceptionTime(item.getReceptionTime());
				}
				if(item.getDepartmentName()!= null){
					nuroPatientReceptionHistoryInfo.setDepartmentName(item.getDepartmentName());
				}
				if(item.getSujinNo()!= null){
					nuroPatientReceptionHistoryInfo.setSujinNo(item.getSujinNo());
				}
				if(item.getDokuStatus()!= null){
					nuroPatientReceptionHistoryInfo.setDokuStatus(item.getDokuStatus());
				}
				if(item.getContKey()!= null){
					nuroPatientReceptionHistoryInfo.setContKey(item.getContKey());
				}
				
				if(item.getSysId() != null){
					nuroPatientReceptionHistoryInfo.setSysId(item.getSysId());
				}
				
				response.addPatientReceptionHistoryListItem(nuroPatientReceptionHistoryInfo);
			}
		}
		return response.build();
	}

}
