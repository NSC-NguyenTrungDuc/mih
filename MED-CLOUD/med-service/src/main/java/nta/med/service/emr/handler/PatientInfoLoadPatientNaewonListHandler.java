package nta.med.service.emr.handler;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.system.LoadPatientBaseInfo;
import nta.med.data.model.ihis.system.LoadPatientNaewonListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PatientInfoLoadPatientNaewonListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PatientInfoLoadPatientNaewonListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class PatientInfoLoadPatientNaewonListHandler extends ScreenHandler<SystemServiceProto.PatientInfoLoadPatientNaewonListRequest, SystemServiceProto.PatientInfoLoadPatientNaewonListResponse> {
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource                                                                                                       
	private Out1001Repository  out1001Repository; 
	
	@Override
	public PatientInfoLoadPatientNaewonListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PatientInfoLoadPatientNaewonListRequest request)
			throws Exception {
		SystemServiceProto.PatientInfoLoadPatientNaewonListResponse.Builder response = SystemServiceProto.PatientInfoLoadPatientNaewonListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		LoadPatientBaseInfo loadPatientinfo = out0101Repository.callPrOcsLoadBunhoInfo(hospCode, naewonDate, request.getBunho());
		if(loadPatientinfo != null && !loadPatientinfo.isEmptyPatient()){
			SystemModelProto.LoadPatientBaseInfo.Builder loadPatientBuilder = SystemModelProto.LoadPatientBaseInfo.newBuilder();
			BeanUtils.copyProperties(loadPatientinfo, loadPatientBuilder, getLanguage(vertx, sessionId));
			response.addPatientBaseItem(loadPatientBuilder);
		}
		
		List<LoadPatientNaewonListInfo> listResult = out1001Repository.getLoadPatientNaewonListItem(hospCode, getLanguage(vertx, sessionId),
				request.getApproveDoctor(),request.getDoctorModeYn(),request.getIoGubun(),request.getPkKeyOut(),request.getBunho(),
				request.getNaewonDate(),request.getGwa(),request.getDoctor(),request.getJaewonFlag(),request.getPkKeyInp(),request.getIsEnableIpwonReser());
		if(!CollectionUtils.isEmpty(listResult)){
			for(LoadPatientNaewonListInfo item : listResult){
				CommonModelProto.LoadPatientNaewonListInfo.Builder info = CommonModelProto.LoadPatientNaewonListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getJubsuNo() != null){
					info.setJubsuNo(String.format("%.0f", item.getJubsuNo()));
				}
				if(item.getPkKey() != null){
					info.setPkKey(String.format("%.0f", item.getPkKey()));
				}
				response.addPatientNaewonItem(info);
			}
		}
		return response.build();
	}

}
