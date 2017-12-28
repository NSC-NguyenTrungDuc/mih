package nta.med.service.ihis.handler.bass;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0271;
import nta.med.core.domain.bas.Bas0272;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0271Repository;
import nta.med.data.dao.medi.bas.Bas0272Repository;
import nta.med.service.ihis.proto.*;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00ExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class BAS0270U00ExecuteHandler extends ScreenHandler<BassServiceProto.BAS0270U00ExecuteRequest, SystemServiceProto.UpdateResponse> {                             

	private static final Log LOG = LogFactory.getLog(BAS0270U00ExecuteHandler.class);                                        
                                                                
	@Resource                                                                                                       
	private Bas0271Repository bas0271Repository;                                                                    
	
	@Resource                                                                                                       
	private Bas0272Repository bas0272Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00ExecuteRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override               
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0270U00ExecuteRequest request)
					throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String userId = request.getUserId();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		List<String> departments = new ArrayList<>();
		if(!CollectionUtils.isEmpty(request.getGrdBAS0271InfoList())) {
			for (BassModelProto.BAS0270U00GrdBAS0271Info item : request.getGrdBAS0271InfoList()) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					List<String> listText = bas0271Repository.checkDoctorExistInBas0271(hospCode, item.getSabun(), item.getDoctor());
					if(!CollectionUtils.isEmpty(listText)) {
						response.setMsg(item.getDoctor());
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertBas0271(hospCode, userId, item, hospCode, language);
				} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					String commonDoctorYn = "N";
					if(!StringUtils.isEmpty(item.getCommonDoctorYn())){
						commonDoctorYn = item.getCommonDoctorYn();
					}
					Integer rs = bas0271Repository.updateBas0271(hospCode, userId, new Date(), 
							StringUtils.isEmpty(item.getDoctorName()) ? null : item.getDoctorName(), StringUtils.isEmpty(item.getDoctorGrade()) ? null : item.getDoctorGrade(),
							StringUtils.isEmpty(item.getReserYn()) ? null : item.getReserYn(), DateUtil.toDate(item.getEndDate(),DateUtil.PATTERN_YYMMDD), 
							StringUtils.isEmpty(item.getLicenseBunho()) ? null : item.getLicenseBunho(), StringUtils.isEmpty(item.getSabun()) ? null : item.getSabun(),
							StringUtils.isEmpty(item.getOcsStatus()) ? null : item.getOcsStatus(), StringUtils.isEmpty(item.getJubsuYn()) ? null : item.getJubsuYn(),
							StringUtils.isEmpty(item.getDoctorSign()) ? null : item.getDoctorSign(), StringUtils.isEmpty(item.getCpDoctorYn()) ? null : item.getCpDoctorYn(),
							StringUtils.isEmpty(item.getDoctorName2()) ? null : item.getDoctorName2(),
							StringUtils.isEmpty(item.getMayakLicense()) ? null : item.getMayakLicense(),
							StringUtils.isEmpty(item.getTonggyeDoctor()) ? null : item.getTonggyeDoctor(), commonDoctorYn, StringUtils.isEmpty(item.getDoctorColor()) ? null : item.getDoctorColor(),
							StringUtils.isEmpty(item.getDoctor()) ? null : item.getDoctor(), item.getStartDate());
					if(rs <= 0) {
						LOG.info("updateBas0271 FALSE");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					LOG.info("updateBas0271 SUCCESSFUL");
				} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					String txt = bas0272Repository.checkExistBySabun(hospCode, item.getSabun());
					if(!StringUtils.isEmpty(txt)) {
						response.setResult(false);
						response.setMsg(item.getSabun());
						throw new ExecutionException(response.build());
					}
					Integer rs = bas0271Repository.deleteBas0271(hospCode, item.getDoctor(), item.getStartDate());
					if(rs <= 0) {
						LOG.info("deleteBas0271 FALSE");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					LOG.info("deleteBas0271 SUCCESSFUL");
				}
			}
		}
		if(!CollectionUtils.isEmpty(request.getGrdBAS0272InfoList())) {
			for (BassModelProto.BAS0270U00GrdBAS0272Info item : request.getGrdBAS0272InfoList()) {
				departments.add(item.getDoctorGwa());
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					String txt = bas0272Repository.checkExistBySabunAndDoctorGwa(hospCode, item.getSabun(), item.getDoctorGwa());
					if(!StringUtils.isEmpty(txt)) {
						response.setMsg(item.getSabun() + " " + item.getDoctorGwa());
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertBas0272(hospCode, userId, item, hospCode);
				} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					Integer rs = bas0272Repository.updateBas0272(hospCode, userId, new Date(), 
					DateUtil.toDate(item.getEndDate(),DateUtil.PATTERN_YYMMDD), StringUtils.isEmpty(item.getMainGwaYn()) ? null : item.getMainGwaYn(),
					StringUtils.isEmpty(item.getSabun()) ? null : item.getSabun(), StringUtils.isEmpty(item.getDoctorGwa()) ? null : item.getDoctorGwa(), item.getStartDate(), item.getOutDiscussYn(), item.getReserOutYn());
					if(rs <= 0) {
						LOG.info("updateBas0271 FALSE");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					LOG.info("updateBas0271 SUCCESSFULL");
				} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					Integer rs = bas0272Repository.deleteBas0272Bas(hospCode, item.getSabun(), item.getDoctorGwa(), item.getStartDate());
					if(rs <= 0) {
						LOG.info("deleteBas0271 FALSE");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					LOG.info("deleteBas0271 SUCCESSFULL");
				}
			}
		}
		response.setResult(true);
		LOG.info("BAS0270U00ExecuteHandler departments: "+ departments);


		NuroModelProto.Doctor.Builder doctor = NuroModelProto.Doctor.newBuilder().setDoctorCode("").setDoctorName("").setDoctorId("").setDepartmentId("");
		List<NuroModelProto.Department> departmentList = new ArrayList<>();
		for (String department : departments) {
			NuroModelProto.Department.Builder departmentItem = NuroModelProto.Department.newBuilder();
			departmentItem.setDepartmentCode(department).setDepartmentId(department).setDepartmentName(department);
			departmentList.add(departmentItem.build());

		}
		NuroServiceProto.HospitalEvent.Builder message = NuroServiceProto.HospitalEvent.newBuilder().addAllDepts(departmentList).setDoctor(doctor).setHospCode(hospCode);
		publish(vertx, message.build());
	//
		return response.build();
	}
	
	private void insertBas0271(String hospCode, String userId, BassModelProto.BAS0270U00GrdBAS0271Info info, String hospitalCode, String language) {
		Bas0271 bas0271 = new Bas0271();
		bas0271.setSysDate(new Date());
		bas0271.setSysId(userId);
		bas0271.setUpdDate(new Date());
		bas0271.setUpdId(userId);
		bas0271.setHospCode(hospCode);
		bas0271.setDoctor(StringUtils.isEmpty(info.getDoctor()) ? null : info.getDoctor());
		bas0271.setDoctorName(StringUtils.isEmpty(info.getDoctorName()) ? null : info.getDoctorName());
		bas0271.setDoctorGrade(StringUtils.isEmpty(info.getDoctorGrade()) ? null : info.getDoctorGrade());
		bas0271.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
		bas0271.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
		bas0271.setReserYn(StringUtils.isEmpty(info.getReserYn()) ? null : info.getReserYn());
		bas0271.setLicenseBunho(StringUtils.isEmpty(info.getLicenseBunho()) ? null : info.getLicenseBunho());
		bas0271.setSabun(StringUtils.isEmpty(info.getSabun()) ? null : info.getSabun());
		bas0271.setDoctorSign(StringUtils.isEmpty(info.getDoctorSign()) ? null : info.getDoctorSign());
		bas0271.setCpDoctorYn(StringUtils.isEmpty(info.getCpDoctorYn()) ? null : info.getCpDoctorYn());
		bas0271.setDoctorName2(StringUtils.isEmpty(info.getDoctorName2()) ? null : info.getDoctorName2());
		bas0271.setMayakLicense(StringUtils.isEmpty(info.getMayakLicense()) ? null : info.getMayakLicense());		
		bas0271.setTonggyeDoctor(StringUtils.isEmpty(info.getTonggyeDoctor()) ? null : info.getTonggyeDoctor());	
		bas0271.setCommonDoctorYn(StringUtils.isEmpty(info.getCommonDoctorYn()) ? null : info.getCommonDoctorYn());
		bas0271.setDoctorColor(StringUtils.isEmpty(info.getDoctorColor()) ? null : info.getDoctorColor());
		bas0271.setJubsuYn(StringUtils.isEmpty(info.getJubsuYn()) ? null : info.getJubsuYn());
		bas0271.setOcsStatus(StringUtils.isEmpty(info.getOcsStatus()) ? null : info.getOcsStatus());
		bas0271Repository.save(bas0271);
	}
	
	private void insertBas0272(String hospCode, String userId, BassModelProto.BAS0270U00GrdBAS0272Info info, String hospitalCode) {
		Bas0272 bas0272 = new Bas0272();
		bas0272.setSysDate(new Date());
		bas0272.setSysId(userId);
		bas0272.setUpdDate(new Date());
		bas0272.setUpdId(userId);
		bas0272.setHospCode(hospCode);
		bas0272.setSabun(StringUtils.isEmpty(info.getSabun()) ? null : info.getSabun());
		bas0272.setDoctor(StringUtils.isEmpty(info.getDoctor()) ? null : info.getDoctor());
		bas0272.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
		bas0272.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
		bas0272.setDoctorGwa(StringUtils.isEmpty(info.getDoctorGwa()) ? null : info.getDoctorGwa());
		bas0272.setMainGwaYn(StringUtils.isEmpty(info.getMainGwaYn()) ? null : info.getMainGwaYn());
		bas0272.setOutDiscussYn(info.getOutDiscussYn());
		bas0272.setReserOutYn(info.getReserOutYn());
		bas0272Repository.save(bas0272);
	}
}                                                                                                                 
