package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

/**
* @author dainguyen.
*/
@Service
@Scope("prototype")
public class NuroPatientListHandler extends ScreenHandler<NuroServiceProto.NuroPatientListRequest, NuroServiceProto.NuroPatientListResponse> {
	private static final Log logger = LogFactory.getLog(NuroPatientListHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
        return true;
    }

    @Override
	public boolean isValid(NuroServiceProto.NuroPatientListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getComingDate()) && DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
    @Route(global = false)
	public NuroServiceProto.NuroPatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientListRequest request) throws Exception {
		NuroServiceProto.NuroPatientListResponse.Builder response= NuroServiceProto.NuroPatientListResponse.newBuilder();
		List<NuroPatientInfo> listNuroPatientInfo = out1001Repository.getNuroPatientListInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getComingDate(),
                request.getDepartmentCode(), request.getDoctorCode(), request.getPatientCode(),
                request.getReceptionType(), request.getExamStatus(), request.getComingStatus(),request.getCurrentSystemId(), false);
		
		if(CollectionUtils.isEmpty(listNuroPatientInfo)){
			// Case change language of hospital in BAS0001 but not change in BAS0102
			listNuroPatientInfo = out1001Repository.getNuroPatientListInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getComingDate(),
	                request.getDepartmentCode(), request.getDoctorCode(), request.getPatientCode(),
	                request.getReceptionType(), request.getExamStatus(), request.getComingStatus(),request.getCurrentSystemId(), true);
		}
		
        if (listNuroPatientInfo != null && !listNuroPatientInfo.isEmpty()) {
            for (NuroPatientInfo item : listNuroPatientInfo) {
                NuroModelProto.NuroPatientListItemInfo.Builder patientInfo = NuroModelProto.NuroPatientListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(item.getDepartmentCode())) {
                	patientInfo.setDepartmentCode(item.getDepartmentCode());
            	}
                if(!StringUtils.isEmpty(item.getDepartmentName())) {
            		patientInfo.setDepartmentName(item.getDepartmentName());
            	}
            	if(!StringUtils.isEmpty(item.getPatientCode())) {
            		patientInfo.setPatientCode(item.getPatientCode());
            	}
                if(!StringUtils.isEmpty(item.getPatientName())) {
                	patientInfo.setPatientName(item.getPatientName());
                }
                if(!StringUtils.isEmpty(item.getPatientName2())) {
                	patientInfo.setPatientName2(item.getPatientName2());
                }
                if(item.getComingDate() != null) {
                	patientInfo.setComingDate(item.getComingDate().toString());
                }
                patientInfo.setDoctorCode(item.getDoctorCode());
                if(!StringUtils.isEmpty(item.getDoctorName())) {
                	patientInfo.setDoctorName(item.getDoctorName());
                }
                if(!StringUtils.isEmpty(item.getComingType())) {
                	patientInfo.setComingType(item.getComingType());
                }
                if(item.getReceptionCode() != null) {
                	patientInfo.setReceptionCode(String.format("%.0f", item.getReceptionCode()));
                }
                if(item.getBirth() != null) {
                	patientInfo.setBirth(item.getBirth().toString());
                }
                if(item.getAgeSex() != null) {
                	patientInfo.setAgeSex(item.getAgeSex().toString());
                }
                if(item.getOutResKey() != null) {
                	patientInfo.setOutResKey(String.format("%.0f", item.getOutResKey()));
                }
                if(!StringUtils.isEmpty(item.getReceptionTime())) {
                	patientInfo.setReceptionTime(item.getReceptionTime());
                }
                if(!StringUtils.isEmpty(item.getOrderEndYn())) {
                	patientInfo.setOrderEndYn(item.getOrderEndYn());
                }
                if(!StringUtils.isEmpty(item.getHoldYn())) {
                	patientInfo.setHoldYn(item.getHoldYn());
                }
                if(!StringUtils.isEmpty(item.getResultYn())) {
                	patientInfo.setResultYn(item.getResultYn());
                }
                if(!StringUtils.isEmpty(item.getReserYn())) {
                	patientInfo.setReserYn(item.getReserYn());
                }
                if(!StringUtils.isEmpty(item.getIpwonYn())) {
                	patientInfo.setIpwonYn(item.getIpwonYn());
                }
                if(!StringUtils.isEmpty(item.getSunabYn())) {
                	patientInfo.setSunabYn(item.getSunabYn());
                }
                if(!StringUtils.isEmpty(item.getComingStatus())) {
                	patientInfo.setComingStatus(item.getComingStatus());
                }
                if(!StringUtils.isEmpty(item.getReceptionType())) {
                	patientInfo.setReceptionType(item.getReceptionType());
                }
                if(!StringUtils.isEmpty(item.getReceptionTypeName())) {
                	patientInfo.setReceptionTypeName(item.getReceptionTypeName());
                }
                if(!StringUtils.isEmpty(item.getRemark())) {
                	patientInfo.setRemark(item.getRemark());
                }
                if(!StringUtils.isEmpty(item.getArriveTime())) {
                	patientInfo.setArriveTime(item.getArriveTime());
                }
                if(!StringUtils.isEmpty(item.getType())) {
                	patientInfo.setType(item.getType());
                }
                if(item.getLastComingDate() != null) {
                	patientInfo.setLastComingDate(item.getLastComingDate().toString());
                }
                if(!StringUtils.isEmpty(item.getOcsComment())) {
                	patientInfo.setOcsComment(item.getOcsComment());
                }
                if(!StringUtils.isEmpty(item.getChojae())) {
                	patientInfo.setChojae(item.getChojae());
                }
                if(!StringUtils.isEmpty(item.getGroupKey())) {
                	patientInfo.setGroupKey(item.getGroupKey());
                }
                if(!StringUtils.isEmpty(item.getPatientType())) {
                	patientInfo.setPatientType(item.getPatientType());
                }
                if(!StringUtils.isEmpty(item.getCareStatus())) {
                    patientInfo.setCareStatus(item.getCareStatus());
                }
                if(!StringUtils.isEmpty(item.getPercentage())) {
                    patientInfo.setPercentage(item.getPercentage());
                }
                if(!StringUtils.isEmpty(item.getExamStatus())) {
                    patientInfo.setExamStatus(item.getExamStatus());
                }
                if(!StringUtils.isEmpty(item.getTrialYn())) {
                    patientInfo.setTrialYn("Y");
                }
                else
                {
                    patientInfo.setTrialYn("N");
                }
                if(!StringUtils.isEmpty(item.getSysIdOut1001())) {
                	patientInfo.setSysId(item.getSysIdOut1001());
                }
                response.addPatientListItem(patientInfo);
            }
        }
		return response.build();
	}
}
