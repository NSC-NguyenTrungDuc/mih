package nta.med.service.ihis.handler.nuro;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.res.Res0102;
import nta.med.core.domain.res.Res0103;
import nta.med.core.domain.res.Res0104;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00UpdateRES0102Info;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class NuroRES0102U00SaveScheduleHandler extends ScreenHandler<NuroServiceProto.NuroRES0102U00SaveScheduleRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES0102U00SaveScheduleHandler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00SaveScheduleRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00SaveScheduleRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response = updateData(request, request.getHospCode(), vertx, sessionId);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
    }
	
	public SystemServiceProto.UpdateResponse.Builder updateData(NuroServiceProto.NuroRES0102U00SaveScheduleRequest request, String hospCode, Vertx vertx, String sessionId){
		List<String> departments = new ArrayList<>();
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			List<NuroModelProto.NuroRES0102U00GrdRES0102Info> lstNuroRES0102U00GrdRES0102Info = request.getGridRes0102SaveItemList();
			for(NuroModelProto.NuroRES0102U00GrdRES0102Info itemNuroRES0102U00GrdRES0102Info : lstNuroRES0102U00GrdRES0102Info){
				Calendar cal = Calendar.getInstance();
				cal.setTime(DateUtil.toDate(itemNuroRES0102U00GrdRES0102Info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				cal.add(Calendar.DATE, -1);
				departments.add(itemNuroRES0102U00GrdRES0102Info.getGwa());
				if(DataRowState.ADDED.getValue().equals(itemNuroRES0102U00GrdRES0102Info.getDataRowState())){
					String strNuroRES0102U00CheckDoctor1 = res0102Repository.getNuroRES0102U00CheckDoctor1(hospCode,
							itemNuroRES0102U00GrdRES0102Info.getDoctor(),
							itemNuroRES0102U00GrdRES0102Info.getStartDate(),
							itemNuroRES0102U00GrdRES0102Info.getGwa(),
							"N");
					if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor1)) {
						response.setMsg("MSG025_MSG");
						response.setResult(false);
						return response;
					}
					updateRes0102(itemNuroRES0102U00GrdRES0102Info.getDoctor(), cal.getTime(), hospCode);
					deleteRES0102(itemNuroRES0102U00GrdRES0102Info, hospCode);
					insertRES0102(request.getUserId(), itemNuroRES0102U00GrdRES0102Info, hospCode);

				}else if(DataRowState.MODIFIED.getValue().equals(itemNuroRES0102U00GrdRES0102Info.getDataRowState())){
					NuroRES0102U00UpdateRES0102Info nuroRES0102U00UpdateRES0102Info = new NuroRES0102U00UpdateRES0102Info();
					BeanUtils.copyProperties(itemNuroRES0102U00GrdRES0102Info, nuroRES0102U00UpdateRES0102Info, getLanguage(vertx,sessionId ));
					nuroRES0102U00UpdateRES0102Info.setUserId(request.getUserId());
					res0102Repository.updateNuroRES0102U00UpdateRES0102Info(hospCode, nuroRES0102U00UpdateRES0102Info);

				} else if (DataRowState.DELETED.getValue().equals(itemNuroRES0102U00GrdRES0102Info.getDataRowState())){
					res0102Repository.updateRES0102Request3(hospCode, itemNuroRES0102U00GrdRES0102Info.getDoctor(), cal.getTime());
					res0102Repository.deleteRES0102Req2(hospCode, itemNuroRES0102U00GrdRES0102Info.getDoctor(), itemNuroRES0102U00GrdRES0102Info.getStartDate());
					
				}
			}
			
			List<NuroModelProto.NuroRES0102U00GrdRES0103Info> lstNuroRES0102U00GrdRES0103Info = request.getGridRes0103SaveItemList();
			for(NuroModelProto.NuroRES0102U00GrdRES0103Info itemNuroRES0102U00GrdRES0103Info : lstNuroRES0102U00GrdRES0103Info){
				if (DataRowState.ADDED.getValue().equals(itemNuroRES0102U00GrdRES0103Info.getDataRowState())) {
					String strNuroRES0102U00CheckDoctor2 = res0103Repository.getNuroRES0102U00CheckDoctor2(hospCode, itemNuroRES0102U00GrdRES0103Info.getDoctor(), itemNuroRES0102U00GrdRES0103Info.getJinryoPreDate());
					if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor2)) {
						response.setMsg("MSG026_MSG");
						response.setResult(false);
						return response;
					}
					insertRES0103(request.getUserId(), itemNuroRES0102U00GrdRES0103Info, hospCode);
				} else if (DataRowState.MODIFIED.getValue().equals(itemNuroRES0102U00GrdRES0103Info.getDataRowState())) {
					res0103Repository.updateRES0103Request1(request.getUserId(), new Date(), itemNuroRES0102U00GrdRES0103Info.getAmStartHhmm(), itemNuroRES0102U00GrdRES0103Info.getAmEndHhmm(),
							itemNuroRES0102U00GrdRES0103Info.getPmStartHhmm(), itemNuroRES0102U00GrdRES0103Info.getPmEndHhmm(), itemNuroRES0102U00GrdRES0103Info.getRemark(),
							itemNuroRES0102U00GrdRES0103Info.getAmGwaRoom(), itemNuroRES0102U00GrdRES0103Info.getPmGwaRoom(), hospCode,
							itemNuroRES0102U00GrdRES0103Info.getDoctor(), DateUtil.toDate(itemNuroRES0102U00GrdRES0103Info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
				} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(itemNuroRES0102U00GrdRES0103Info.getDataRowState())) {
					res0103Repository.deleteRES0104Request1(hospCode, itemNuroRES0102U00GrdRES0103Info.getDoctor(), itemNuroRES0102U00GrdRES0103Info.getJinryoPreDate());
				}
			}
			
			List<NuroModelProto.NuroRES0102U00GrdRES0103ResInfo> lstNuroRES0102U00GrdRES0103RInfo = request.getGridRes0103RSaveItemList();
			for(NuroModelProto.NuroRES0102U00GrdRES0103ResInfo itemNuroRES0102U00GrdRES0103RInfo : lstNuroRES0102U00GrdRES0103RInfo){
				if(DataRowState.ADDED.getValue().equals(itemNuroRES0102U00GrdRES0103RInfo.getDataRowState())){
					String strNuroRES0102U00CheckDoctor2 = res0103Repository.getNuroRES0102U00CheckDoctor2(hospCode, itemNuroRES0102U00GrdRES0103RInfo.getDoctor(), itemNuroRES0102U00GrdRES0103RInfo.getJinryoPreDate());
					if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor2)) {
						response.setMsg("MSG026_MSG");
						response.setResult(false);
						return response;
					}
					
					insertRES0103R(request.getUserId(), itemNuroRES0102U00GrdRES0103RInfo, hospCode);
				}else if(DataRowState.MODIFIED.getValue().equals(itemNuroRES0102U00GrdRES0103RInfo.getDataRowState())){
					 res0103Repository.updateRES0103Request2(request.getUserId(), new Date(), itemNuroRES0102U00GrdRES0103RInfo.getRemark(),
							 itemNuroRES0102U00GrdRES0103RInfo.getResAmStartHhmm(), itemNuroRES0102U00GrdRES0103RInfo.getResAmEndHhmm(),
							 itemNuroRES0102U00GrdRES0103RInfo.getResPmStartHhmm(), itemNuroRES0102U00GrdRES0103RInfo.getResPmEndHhmm(),
							 hospCode, itemNuroRES0102U00GrdRES0103RInfo.getDoctor(), DateUtil.toDate(itemNuroRES0102U00GrdRES0103RInfo.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
				}else if(DataRowState.DELETED.getValue().equalsIgnoreCase(itemNuroRES0102U00GrdRES0103RInfo.getDataRowState())){
					res0103Repository.deleteRES0104Request2(hospCode, itemNuroRES0102U00GrdRES0103RInfo.getDoctor(), itemNuroRES0102U00GrdRES0103RInfo.getJinryoPreDate());
				}
			}
			
			List<NuroModelProto.NuroRES0102U00GridDoctorInfo> lstNuroRES0102U00GridDoctorInfo = request.getGridDoctorSaveItemList();
			for(NuroModelProto.NuroRES0102U00GridDoctorInfo itemNuroRES0102U00GridDoctorInfo : lstNuroRES0102U00GridDoctorInfo){
				if(DataRowState.ADDED.getValue().equals(itemNuroRES0102U00GridDoctorInfo.getDataRowState())){
					String strNuroRES0102U00CheckDoctor3 = res0104Repository.getNuroRES0102U00CheckDoctor3(hospCode, itemNuroRES0102U00GridDoctorInfo.getDoctor(), itemNuroRES0102U00GridDoctorInfo.getStartDate());
					if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor3)) {
						response.setMsg("MSG027_MSG");
						response.setResult(false);
						return response;
					}
					insertRES0104(request.getUserId(), itemNuroRES0102U00GridDoctorInfo, hospCode);
				}else if(DataRowState.MODIFIED.getValue().equals(itemNuroRES0102U00GridDoctorInfo.getDataRowState())){
					res0104Repository.updateRES0104(request.getUserId(), new Date(), itemNuroRES0102U00GridDoctorInfo.getEndDate(), itemNuroRES0102U00GridDoctorInfo.getSayu(), hospCode, itemNuroRES0102U00GridDoctorInfo.getDoctor(), itemNuroRES0102U00GridDoctorInfo.getStartDate());
				}else if(DataRowState.DELETED.getValue().equalsIgnoreCase(itemNuroRES0102U00GridDoctorInfo.getDataRowState())){
					res0104Repository.deleteRES0104(hospCode, itemNuroRES0102U00GridDoctorInfo.getDoctor(), itemNuroRES0102U00GridDoctorInfo.getStartDate());
				}
			}

		response.setResult(true);


		NuroModelProto.Doctor.Builder doctor = NuroModelProto.Doctor.newBuilder().setDoctorCode("").setDoctorName("").setDoctorId("").setDepartmentId("");
		List<NuroModelProto.Department> departmentList = new ArrayList<>();
		for (String department : departments) {
			NuroModelProto.Department.Builder departmentItem = NuroModelProto.Department.newBuilder();
			departmentItem.setDepartmentCode(department).setDepartmentId(department).setDepartmentName(department);
			departmentList.add(departmentItem.build());

		}
		NuroServiceProto.HospitalEvent.Builder message = NuroServiceProto.HospitalEvent.newBuilder().addAllDepts(departmentList).setDoctor(doctor).setHospCode(hospCode);
		publish(vertx, message.build());


		return response;
	}
	
	private void updateRes0102(String doctor, Date startDate, String hospCode){
		res0102Repository.updateRES0102Request1(hospCode, doctor, startDate);
	}
	
	private void deleteRES0102(NuroModelProto.NuroRES0102U00GrdRES0102Info info, String hospCode){
		res0102Repository.deleteRES0102(hospCode, info.getDoctor(), info.getStartDate()) ;
	}
	
	private void insertRES0102(String userId, NuroModelProto.NuroRES0102U00GrdRES0102Info request, String hospCode){
			Res0102 res0102 = new Res0102(); 
			res0102.setSysDate(new Date());
			if(!StringUtils.isEmpty(userId)) {
				res0102.setSysId(userId);	
				res0102.setUpdId(userId);
			}
			res0102.setUpdDate(new Date());
			if(!StringUtils.isEmpty(request.getDoctor())) {
				res0102.setDoctor(request.getDoctor());
			}
			res0102.setHospCode(hospCode);
			if(!StringUtils.isEmpty(request.getGwa())) {
				res0102.setGwa(request.getGwa());
			}
			if(!StringUtils.isEmpty(request.getStartDate())) {
				res0102.setStartDate(DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(request.getEndDate())) {
				res0102.setEndDate(DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(request.getAvgTime())) {
				res0102.setAvgTime(CommonUtils.parseDouble(request.getAvgTime()));
			}
			if(!StringUtils.isEmpty(request.getJinryoBreakYn())) {
				res0102.setJinryoBreakYn(request.getJinryoBreakYn());
			}
			//
			if(!StringUtils.isEmpty(request.getAmStartHhmm1())) {
				res0102.setAmStartHhmm1(request.getAmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm2())) {
				res0102.setAmStartHhmm2(request.getAmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm3())) {
				res0102.setAmStartHhmm3(request.getAmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm4())) {
				res0102.setAmStartHhmm4(request.getAmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm5())) {
				res0102.setAmStartHhmm5(request.getAmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm6())) {
				res0102.setAmStartHhmm6(request.getAmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm7())) {
				res0102.setAmStartHhmm7(request.getAmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getAmEndHhmm1())) {
				res0102.setAmEndHhmm1(request.getAmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm2())) {
				res0102.setAmEndHhmm2(request.getAmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm3())) {
				res0102.setAmEndHhmm3(request.getAmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm4())) {
				res0102.setAmEndHhmm4(request.getAmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm5())) {
				res0102.setAmEndHhmm5(request.getAmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm6())) {
				res0102.setAmEndHhmm6(request.getAmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm7())) {
				res0102.setAmEndHhmm7(request.getAmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmStartHhmm1())) {
				res0102.setPmStartHhmm1(request.getPmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm2())) {
				res0102.setPmStartHhmm2(request.getPmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm3())) {
				res0102.setPmStartHhmm3(request.getPmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm4())) {
				res0102.setPmStartHhmm4(request.getPmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm5())) {
				res0102.setPmStartHhmm5(request.getPmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm6())) {
				res0102.setPmStartHhmm6(request.getPmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm7())) {
				res0102.setPmStartHhmm7(request.getPmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmEndHhmm1())) {
				res0102.setPmEndHhmm1(request.getPmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm2())) {
				res0102.setPmEndHhmm2(request.getPmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm3())) {
				res0102.setPmEndHhmm3(request.getPmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm4())) {
				res0102.setPmEndHhmm4(request.getPmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm5())) {
				res0102.setPmEndHhmm5(request.getPmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm6())) {
				res0102.setPmEndHhmm6(request.getPmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm7())) {
				res0102.setPmEndHhmm7(request.getPmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getAmGwaRoom1())) {
				res0102.setAmGwaRoom1(request.getAmGwaRoom1());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom2())) {
				res0102.setAmGwaRoom2(request.getAmGwaRoom2());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom3())) {
				res0102.setAmGwaRoom3(request.getAmGwaRoom3());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom4())) {
				res0102.setAmGwaRoom4(request.getAmGwaRoom4());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom5())) {
				res0102.setAmGwaRoom5(request.getAmGwaRoom5());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom6())) {
				res0102.setAmGwaRoom6(request.getAmGwaRoom6());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom7())) {
				res0102.setAmGwaRoom7(request.getAmGwaRoom7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmGwaRoom1())) {
				res0102.setPmGwaRoom1(request.getPmGwaRoom1());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom2())) {
				res0102.setPmGwaRoom2(request.getPmGwaRoom2());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom3())) {
				res0102.setPmGwaRoom3(request.getPmGwaRoom3());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom4())) {
				res0102.setPmGwaRoom4(request.getPmGwaRoom4());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom5())) {
				res0102.setPmGwaRoom5(request.getPmGwaRoom5());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom6())) {
				res0102.setPmGwaRoom6(request.getPmGwaRoom6());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom7())) {
				res0102.setPmGwaRoom7(request.getPmGwaRoom7());
			}
			//
			if(!StringUtils.isEmpty(request.getResAmStartHhmm1())) {
				res0102.setResAmStartHhmm1(request.getResAmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm2())) {
				res0102.setResAmStartHhmm2(request.getResAmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm3())) {
				res0102.setResAmStartHhmm3(request.getResAmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm4())) {
				res0102.setResAmStartHhmm4(request.getResAmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm5())) {
				res0102.setResAmStartHhmm5(request.getResAmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm6())) {
				res0102.setResAmStartHhmm6(request.getResAmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm7())) {
				res0102.setResAmStartHhmm7(request.getResAmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResAmEndHhmm1())) {
				res0102.setResAmEndHhmm1(request.getResAmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm2())) {
				res0102.setResAmEndHhmm2(request.getResAmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm3())) {
				res0102.setResAmEndHhmm3(request.getResAmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm4())) {
				res0102.setResAmEndHhmm4(request.getResAmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm5())) {
				res0102.setResAmEndHhmm5(request.getResAmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm6())) {
				res0102.setResAmEndHhmm6(request.getResAmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm7())) {
				res0102.setResAmEndHhmm7(request.getResAmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResPmStartHhmm1())) {
				res0102.setResPmStartHhmm1(request.getResPmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm2())) {
				res0102.setResPmStartHhmm2(request.getResPmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm3())) {
				res0102.setResPmStartHhmm3(request.getResPmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm4())) {
				res0102.setResPmStartHhmm4(request.getResPmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm5())) {
				res0102.setResPmStartHhmm5(request.getResPmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm6())) {
				res0102.setResPmStartHhmm6(request.getResPmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm7())) {
				res0102.setResPmStartHhmm7(request.getResPmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResPmEndHhmm1())) {
				res0102.setResPmEndHhmm1(request.getResPmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm2())) {
				res0102.setResPmEndHhmm2(request.getResPmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm3())) {
				res0102.setResPmEndHhmm3(request.getResPmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm4())) {
				res0102.setResPmEndHhmm4(request.getResPmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm5())) {
				res0102.setResPmEndHhmm5(request.getResPmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm6())) {
				res0102.setResPmEndHhmm6(request.getResPmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm7())) {
				res0102.setResPmEndHhmm7(request.getResPmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getDocResLimit())) {
				res0102.setDocResLimit(CommonUtils.parseDouble(request.getDocResLimit()));
			}
			if(!StringUtils.isEmpty(request.getEtcResLimit())) {
				res0102.setEtcResLimit(CommonUtils.parseDouble(request.getEtcResLimit()));
			}
			if(!StringUtils.isEmpty(request.getOutHospResLimit())){
				res0102.setOutHospResLimit(CommonUtils.parseInteger(request.getOutHospResLimit()));
			}
			
			res0102Repository.save(res0102);
	}
	
	private void insertRES0103(String userId, NuroModelProto.NuroRES0102U00GrdRES0103Info request, String hospCode){
		Res0103 res0103 = new Res0103(); 
		res0103.setSysDate(new Date());
		res0103.setSysId(userId);
		res0103.setUpdDate(new Date());
		res0103.setUpdId(userId);
		res0103.setDoctor(request.getDoctor());
		res0103.setJinryoPreDate(DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
		res0103.setAmStartHhmm(request.getAmStartHhmm());
		res0103.setAmEndHhmm(request.getAmEndHhmm());
		res0103.setPmStartHhmm(request.getPmStartHhmm());
		res0103.setPmEndHhmm(request.getPmEndHhmm());
		res0103.setRemark(request.getRemark());
		res0103.setAmGwaRoom(request.getAmGwaRoom());
		res0103.setPmGwaRoom(request.getPmGwaRoom());
		res0103.setHospCode(hospCode);
        
		res0103Repository.save(res0103);
	}
	
	private void insertRES0103R(String userId, NuroModelProto.NuroRES0102U00GrdRES0103ResInfo request, String hospCode){
		Res0103 res0103 = new Res0103(); 
		res0103.setSysDate(new Date());
		res0103.setSysId(userId);
		res0103.setUpdDate(new Date());
		res0103.setUpdId(userId);
		res0103.setDoctor(request.getDoctor());
		res0103.setJinryoPreDate(DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
		res0103.setResAmStartHhmm(request.getResAmStartHhmm());
		res0103.setResAmEndHhmm(request.getResAmEndHhmm());
		res0103.setResPmStartHhmm(request.getResPmStartHhmm());
		res0103.setResPmEndHhmm(request.getResPmEndHhmm());
		res0103.setRemark(request.getRemark());
		res0103.setHospCode(hospCode);
        
		res0103Repository.save(res0103);
	}
	
	private void insertRES0104(String userId, NuroModelProto.NuroRES0102U00GridDoctorInfo request, String hospCode){
		Res0104 res0104 = new Res0104(); 
		res0104.setSysDate(new Date());
		res0104.setSysId(userId);
		res0104.setUpdDate(new Date());
        res0104.setUpdId(userId);
        res0104.setDoctor(request.getDoctor());
        res0104.setStartDate(DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
        res0104.setEndDate(DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD));
        res0104.setEndYn("N");
        res0104.setSayu(request.getSayu());
        res0104.setHospCode(hospCode);
        
		res0104Repository.save(res0104);
	}
}
