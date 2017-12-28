package nta.med.service.ihis.handler.nuri;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur7001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.data.model.phr.SyncBloodPressureInfo;
import nta.med.data.model.phr.SyncHeartRateInfo;
import nta.med.data.model.phr.SyncHeightInfo;
import nta.med.data.model.phr.SyncRespirationRateInfo;
import nta.med.data.model.phr.SyncTemperatureInfo;
import nta.med.data.model.phr.SyncWeightInfo;
import nta.med.service.ihis.proto.NuriModelProto.NuriNUR7001U00MeasurePhysicalConditionListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class NuriNUR7001U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NuriNUR7001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NuriNUR7001U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Nur7001Repository nur7001Repository;                                                                    
	   
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR7001U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
		Integer result=null;
		String hospCode = getHospitalCode(vertx, sessionId);
		for(NuriNUR7001U00MeasurePhysicalConditionListItemInfo  info : request.getListInfoList()){
			 if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				 insertNUR7001(info, request.getUserId(), hospCode);
				 result =1;
			 }else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				  result = nur7001Repository.updateNUR7001(hospCode, request.getUserId(), new Date(), info.getBunho(),
							DateUtil.toDate(info.getMeasureDate(), DateUtil.PATTERN_YYMMDD), CommonUtils.parseDouble(info.getSeq()),
							CommonUtils.parseDouble(info.getHeight()),
							CommonUtils.parseDouble(info.getWeight()),
							CommonUtils.parseDouble(info.getBpFrom()),
							CommonUtils.parseDouble(info.getBpTo()),
							CommonUtils.parseDouble(info.getBodyHeat()),
							StringUtils.isEmpty(info.getPulse()) ? null : new BigDecimal(info.getPulse()),
							CommonUtils.parseDouble(info.getSpo2()),info.getMeasureTime(),
							CommonUtils.parseDouble(info.getBreath()));
			 }else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				 result = nur7001Repository.updateValidStatusNUR7001(
						 hospCode, request.getUserId(), new Date(), info.getBunho(),
							DateUtil.toDate(info.getMeasureDate(), DateUtil.PATTERN_YYMMDD), CommonUtils.parseDouble(info.getSeq()));
			 }
		}
		// event sync vitals
    	if(!CollectionUtils.isEmpty(request.getListInfoList())){
    		String patientCode = request.getListInfoList().get(0).getBunho();
    		LOGGER.info("Sync vitals throw PATIENT_EVENT!!! hospCode=" + hospCode + ", patientCode=" + patientCode);
    		NuroServiceProto.PatientEvent.Builder builder = NuroServiceProto.PatientEvent.newBuilder()
					.setHospCode(hospCode).setPatientCode(patientCode);
    		List<SyncHeightInfo> patientHeights = nur7001Repository.getPatientHeightByPatient(hospCode, patientCode);
    		for (SyncHeightInfo info : patientHeights) {
    			NuroModelProto.SyncHeight.Builder item = NuroModelProto.SyncHeight.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setHeight(info.getHeight().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientHeightInfo(item);
			}
    		
    		List<SyncWeightInfo> patientWeights = nur7001Repository.getPatientWeightByPatient(hospCode, patientCode);
    		for (SyncWeightInfo info : patientWeights) {
    			NuroModelProto.SyncWeight.Builder item = NuroModelProto.SyncWeight.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setWeight(info.getWeight().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientWeightInfo(item);
			}
    		
    		List<SyncTemperatureInfo> patientTemperatures = nur7001Repository.getPatientTemperatureByPatient(hospCode, patientCode);
    		for (SyncTemperatureInfo info : patientTemperatures) {
    			NuroModelProto.SyncTemperature.Builder item = NuroModelProto.SyncTemperature.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setTemperature(info.getTemperature().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientTemperatureInfo(item);
			}
    		
    		List<SyncHeartRateInfo> patientHeartRates = nur7001Repository.getPatientHeartRateByPatient(hospCode, patientCode);
    		for (SyncHeartRateInfo info : patientHeartRates) {
    			NuroModelProto.SyncHeartRate.Builder item = NuroModelProto.SyncHeartRate.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setHeartRate(info.getHeartRate().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientHeartRateInfo(item);
			}
    		
    		List<SyncRespirationRateInfo> patientRespirationRates = nur7001Repository.getPatientRespirationRateByPatient(hospCode, patientCode);
    		for (SyncRespirationRateInfo info : patientRespirationRates) {
    			NuroModelProto.SyncRespirationRate.Builder item = NuroModelProto.SyncRespirationRate.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setRespirationRate(info.getRespirationRate().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientRespirationRateInfo(item);
			}
    		
    		List<SyncBloodPressureInfo> patientBloodPressures = nur7001Repository.getPatientBloodPressureByPatient(hospCode, patientCode);
    		for (SyncBloodPressureInfo info : patientBloodPressures) {
    			NuroModelProto.SyncBloodPressure.Builder item = NuroModelProto.SyncBloodPressure.newBuilder();
    			BeanUtils.copyProperties(info, item, getLanguage(vertx, sessionId));
    			item.setSyncId(info.getSyncId().longValue());
    			item.setLowBloodPressure(info.getLowBloodPressure().toString());
    			item.setHighBloodPressure(info.getHighBloodPressure().toString());
    			if(!org.springframework.util.StringUtils.isEmpty(info.getVald()) && !YesNo.YES.getValue().equalsIgnoreCase(info.getVald())){
    				item.setIsDelete(true);
    			}
    			builder.addPatientBloodPressureInfo(item);
			}
			LOGGER.info("Sync vitals Publish!!!");
			publish(vertx, builder.build());
    	}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private void insertNUR7001(NuriNUR7001U00MeasurePhysicalConditionListItemInfo request,String userId, String hospCode) {
			Double pkSeq = CommonUtils.parseDouble(nur7001Repository.getNuriNUR7001U00GetMaxSeqInNUR7001(hospCode, request.getBunho(), request.getMeasureDate()));
    		if(pkSeq == null || pkSeq.equals(new Double(0))){
    			pkSeq = new  Double(1);
    		}
			Nur7001 nur7001 = new Nur7001();
			nur7001.setSysDate(new Date());
			nur7001.setSysId(userId);
			nur7001.setUpdId(userId);
			nur7001.setHospCode(hospCode);
			nur7001.setUpdDate(new Date());
			nur7001.setBunho(request.getBunho());
			nur7001.setMeasureDate(DateUtil.toDate(request.getMeasureDate(), DateUtil.PATTERN_YYMMDD));
			nur7001.setSeq(pkSeq);
			nur7001.setVald("Y");
			nur7001.setHeight(CommonUtils.parseDouble(request.getHeight()));
			nur7001.setWeight(CommonUtils.parseDouble(request.getWeight()));
			nur7001.setBpFrom(CommonUtils.parseDouble(request.getBpFrom()));
			nur7001.setBpTo(CommonUtils.parseDouble(request.getBpTo()));
			nur7001.setBodyHeat(CommonUtils.parseDouble(request.getBodyHeat()));
			nur7001.setPulse(StringUtils.isEmpty(request.getPulse()) ? null : new BigDecimal(request.getPulse()));
			nur7001.setSpo2(CommonUtils.parseDouble(request.getSpo2()));
			nur7001.setMeasureTime(request.getMeasureTime());
			nur7001.setBreath(CommonUtils.parseDouble(request.getBreath()));
			nur7001Repository.save(nur7001);
	}
	
}