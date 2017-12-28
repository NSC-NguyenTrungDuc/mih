package nta.med.service.ihis.handler.nuro;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.PatientDetailInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class PatientInfoHandler
		extends ScreenHandler<NuroServiceProto.PatientInfoRequest, NuroServiceProto.PatientInfoResponse> {
	private static final Log LOGGER = LogFactory.getLog(PatientInfoHandler.class);

	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                   
	
	@Override
	@Transactional(readOnly = true)
    @Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.PatientInfoRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("kcck PatientInfoHandler preHandle not found hosp code");
		}
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.PatientInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.PatientInfoRequest request) throws Exception {
		NuroServiceProto.PatientInfoResponse.Builder response = NuroServiceProto.PatientInfoResponse.newBuilder();
		
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageIndex(), request.getPageSize());
  	   	List<PatientDetailInfo> listPatient = out0101Repository.getPatientDetailResultInfo(getHospitalCode(vertx, sessionId), request.getDiseaseName(), request.getFromLastestGoHospital(), request.getToLastestGoHospital(),
				request.getFromPatientAge(), request.getToPatientAge(), request.getPatientSex(), request.getStatusOfDisease(), request.getPatientContact(),
				request.getPageSize(), startNum, request.getOrderField(), request.getOrderValue());

		BigInteger totalRecord = out0101Repository.getTotalRecord(getHospitalCode(vertx, sessionId), request.getDiseaseName(), request.getFromLastestGoHospital(), request.getToLastestGoHospital(),
				request.getFromPatientAge(), request.getToPatientAge(), request.getPatientSex(), request.getStatusOfDisease(), request.getPatientContact());
		if (!CollectionUtils.isEmpty(listPatient)) {
			for (PatientDetailInfo item : listPatient) {
				NuroModelProto.PatientDetailInfo.Builder info = NuroModelProto.PatientDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getPatientAge() != null){
					info.setPatientAge(item.getPatientAge().intValue());
				}
				response.addPatientDetailInfo(info);
			}
		}
		response.setTotalRecords(totalRecord == null ? 0 : totalRecord.longValue());
		return response.build();
	}
}
