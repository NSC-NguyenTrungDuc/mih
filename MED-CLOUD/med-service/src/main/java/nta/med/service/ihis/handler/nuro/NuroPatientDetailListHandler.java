package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientDetailInfo;
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

@Service
@Scope("prototype")
public class NuroPatientDetailListHandler extends ScreenHandler<NuroServiceProto.NuroPatientDetailListRequest, NuroServiceProto.NuroPatientDetailListResponse> {
	private static final Log logger = LogFactory.getLog(NuroPatientDetailListHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroPatientDetailListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getComingDate()) && DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroPatientDetailListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientDetailListRequest request) throws Exception {
		List<NuroPatientDetailInfo> listNuroPatientDetailItemInfo = out1001Repository.getNuroPatientDetailListItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId),
				request.getPatientCode(),request.getComingDate());
		NuroServiceProto.NuroPatientDetailListResponse.Builder response = NuroServiceProto.NuroPatientDetailListResponse.newBuilder();
		if(listNuroPatientDetailItemInfo != null && !listNuroPatientDetailItemInfo.isEmpty()){
			for(NuroPatientDetailInfo item : listNuroPatientDetailItemInfo){
				NuroModelProto.NuroPatientDetailListItemInfo.Builder patientDefailInfo = NuroModelProto.NuroPatientDetailListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getDepartmentCode()))
				{
					patientDefailInfo.setDepartmentCode(item.getDepartmentCode());
				}
				if(!StringUtils.isEmpty(item.getDepartmentName()))
				{
					patientDefailInfo.setDepartmentName(item.getDepartmentName());
				}
				
				if(!StringUtils.isEmpty(item.getDoctorCode()))
				{
					patientDefailInfo.setDoctorCode(item.getDoctorCode());
				}
				
				if(!StringUtils.isEmpty(item.getDoctorName()))
				{
					patientDefailInfo.setDoctorName(item.getDoctorName());
				}
				if(!StringUtils.isEmpty(item.getExamStatus()))
				{
					patientDefailInfo.setExamStatus(item.getExamStatus());
				}
				
				if(!StringUtils.isEmpty(item.getReceptionNo()))
				{
					patientDefailInfo.setReceptionNo(item.getReceptionNo().toString());
				}
				
				if(!StringUtils.isEmpty(item.getInsurCode()))
				{
					patientDefailInfo.setInsurCode(item.getInsurCode());
				}
				
				if(!StringUtils.isEmpty(item.getInsurName()))
				{
					patientDefailInfo.setInsurName(item.getInsurName());
				}
				if(!StringUtils.isEmpty(item.getPatientCode()))
				{
					patientDefailInfo.setPatientCode(item.getPatientCode());
				}
				if(!StringUtils.isEmpty(item.getComingDate()))
				{
					patientDefailInfo.setComingDate(item.getComingDate().toString());
				}
				if(!StringUtils.isEmpty(item.getPkout1001()))
				{
					patientDefailInfo.setPkout1001(item.getPkout1001().toString());
				}
				if(!StringUtils.isEmpty(item.getReceptionTime()))
				{
					patientDefailInfo.setReceptionTime(item.getReceptionTime());
				}
				if(!StringUtils.isEmpty(item.getComingStatus()))
				{
					patientDefailInfo.setComingStatus(item.getComingStatus());
				}
				if(!StringUtils.isEmpty(item.getSunnabStatus()))
				{
					patientDefailInfo.setSunnabStatus(item.getSunnabStatus());
				}
				if(!StringUtils.isEmpty(item.getFkinp1001()))
				{
					patientDefailInfo.setFkinp1001(item.getFkinp1001().toString());
				}
				
				if(!StringUtils.isEmpty(item.getReceptionType()))
				{
					patientDefailInfo.setReceptionType(item.getReceptionType());
				}
				
				if(!StringUtils.isEmpty(item.getInpTransStatus()))
				{
					patientDefailInfo.setInpTransStatus(item.getInpTransStatus());
				}
				
				if(!StringUtils.isEmpty(item.getBigo()))
				{
					patientDefailInfo.setBigo(item.getBigo());
				}
				
				if(!StringUtils.isEmpty(item.getInsurCode1()))
				{
					patientDefailInfo.setInsurCode1(item.getInsurCode1());
				}
				
				if(!StringUtils.isEmpty(item.getFkinp1001()))
				{
					patientDefailInfo.setFkinp1001(item.getFkinp1001().toString());
				}
				
				if(!StringUtils.isEmpty(item.getInsurCode2()))
				{
					patientDefailInfo.setInsurCode2(item.getInsurCode2());
				}
				
				if(!StringUtils.isEmpty(item.getInsurCode3()))
				{
					patientDefailInfo.setInsurCode3(item.getInsurCode3());
				}
				
				if(!StringUtils.isEmpty(item.getInsurCode4()))
				{
					patientDefailInfo.setInsurCode4(item.getInsurCode4());;
				}
				
				if(!StringUtils.isEmpty(item.getPriority1()))
				{
					patientDefailInfo.setPriority1(item.getPriority1());
				}
				
				if(!StringUtils.isEmpty(item.getPriority2()))
				{
					patientDefailInfo.setPriority2(item.getPriority2());
				}
				
				if(!StringUtils.isEmpty(item.getPriority3()))
				{
					patientDefailInfo.setPriority3(item.getPriority3());
				}
				
				if(!StringUtils.isEmpty(item.getPriority4()))
				{
					patientDefailInfo.setPriority4(item.getPriority4());
				}
				
				if(!StringUtils.isEmpty(item.getSujinNo()))
				{
					patientDefailInfo.setSujinNo(item.getSujinNo());
				}
				
				if(!StringUtils.isEmpty(item.getWonyoiOrderStatus()))
				{
					patientDefailInfo.setWonyoiOrderStatus(item.getWonyoiOrderStatus());
				}
				
				if(!StringUtils.isEmpty(item.getReserStatus()))
				{
					patientDefailInfo.setReserStatus(item.getReserStatus());
				}
				
				if(!StringUtils.isEmpty(item.getButton()))
				{
					patientDefailInfo.setButton(item.getButton());
				}
				
				if(!StringUtils.isEmpty(item.getCheckComing()))
				{
					patientDefailInfo.setCheckComing(item.getCheckComing());
				}
				
				if(!StringUtils.isEmpty(item.getArriveTime()))
				{
					patientDefailInfo.setArriveTime(item.getArriveTime());
				}
				
				if(!StringUtils.isEmpty(item.getGroupKey()))
				{
					patientDefailInfo.setGroupKey(item.getGroupKey());
				}
				
				if(!StringUtils.isEmpty(item.getContKey()))
				{
					patientDefailInfo.setContKey(item.getContKey().toString());
				}
				
				response.addPatientDetailListItem(patientDefailInfo);
			}
		}
		return response.build();
	}

}
