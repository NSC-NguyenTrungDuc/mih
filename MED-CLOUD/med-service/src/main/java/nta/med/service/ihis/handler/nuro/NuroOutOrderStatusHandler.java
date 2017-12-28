package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroOutOrderStatus;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

/**
* @author dainguyen.
*/
@Service
@Scope("prototype")
public class NuroOutOrderStatusHandler extends ScreenHandler<NuroServiceProto.NuroOutOrderStatusRequest, NuroServiceProto.NuroOutOrderStatusResponse> {
	private static final Log logger = LogFactory.getLog(NuroOutOrderStatusHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroOutOrderStatusRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getCommingDate()) && DateUtil.toDate(request.getCommingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
    
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOutOrderStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOutOrderStatusRequest request) throws Exception {
		List<NuroOutOrderStatus> listNuroOutOrderStatus = out1001Repository.getNuroOutOrderStatusInfo(getHospitalCode(vertx, sessionId), request.getPatientCode() + "%", 
				request.getCommingDate(),request.getDeparmentCode(),getLanguage(vertx, sessionId));
        NuroServiceProto.NuroOutOrderStatusResponse.Builder response = NuroServiceProto.NuroOutOrderStatusResponse.newBuilder();

        if (listNuroOutOrderStatus != null && !listNuroOutOrderStatus.isEmpty()) {
            for (NuroOutOrderStatus obj : listNuroOutOrderStatus) {
                NuroModelProto.NuroOutOrderStatusInfo.Builder nuroOutOrderStatusInfo = NuroModelProto.NuroOutOrderStatusInfo.newBuilder();
                if (obj.getPkOut1001() != null) {
                	nuroOutOrderStatusInfo.setPkOut1001(obj.getPkOut1001().toString());
                }
                if(!StringUtils.isEmpty(obj.getPatientCode())) {
                	nuroOutOrderStatusInfo.setPatientCode(obj.getPatientCode());
                }
                if(!StringUtils.isEmpty(obj.getPatientName())) {
                nuroOutOrderStatusInfo.setPatientName(obj.getPatientName());
                }
                if(!StringUtils.isEmpty(obj.getReceptionTime())) {
                nuroOutOrderStatusInfo.setReceptionTime(obj.getReceptionTime());
                }
                if (obj.getComingStatusDate() != null) {
                nuroOutOrderStatusInfo.setComingStatusDate(obj.getComingStatusDate().toString());
                }
                if(!StringUtils.isEmpty(obj.getReserYn())) {
                nuroOutOrderStatusInfo.setReserYn(obj.getReserYn());
                }
                if(!StringUtils.isEmpty(obj.getDeptCode())) {
                nuroOutOrderStatusInfo.setDeptCode(obj.getDeptCode());
                }
                if(!StringUtils.isEmpty(obj.getDoctorCode())) {
                nuroOutOrderStatusInfo.setDoctorCode(obj.getDoctorCode());
                }
                if(!StringUtils.isEmpty(obj.getDeptName())) {
                nuroOutOrderStatusInfo.setDeptName(obj.getDeptName());
                }
                if(!StringUtils.isEmpty(obj.getDoctorName())) {
                nuroOutOrderStatusInfo.setDoctorName(obj.getDoctorName());
                }
                if(!StringUtils.isEmpty(obj.getReceptionType())) {
                nuroOutOrderStatusInfo.setReceptionType(obj.getReceptionType());
                }
                if(!StringUtils.isEmpty(obj.getCompleteExamination())) {
                nuroOutOrderStatusInfo.setCompleteExamination(obj.getCompleteExamination());
                }
                if (obj.getNumberOfItemsReq() != null) {
                nuroOutOrderStatusInfo.setNumberOfItemsReq(obj.getNumberOfItemsReq().toString());
                }
                if(!StringUtils.isEmpty(obj.getActingPer())) {
                nuroOutOrderStatusInfo.setActingPer(obj.getActingPer().toString());
                }
                if(!StringUtils.isEmpty(obj.getAllEndYn())) {
                nuroOutOrderStatusInfo.setAllEndYn(obj.getAllEndYn());
                }
                if(!StringUtils.isEmpty(obj.getActingTime())) {
                nuroOutOrderStatusInfo.setActingTime(obj.getActingTime());
                }
                if(!StringUtils.isEmpty(obj.getDataEndYn())) {
                nuroOutOrderStatusInfo.setDataSendYn(obj.getDataEndYn());
                }
                response.addOutOrderStatusListItem(nuroOutOrderStatusInfo);
            }
        }
		return response.build();
	}
}
