package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NUR2016U02ActingDateAndSendYnInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02NuroPatientListRequest;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02NuroPatientListResponse;

@Service
@Scope("prototype")
public class NUR2016U02NuroPatientListHandler extends ScreenHandler<NuroServiceProto.NUR2016U02NuroPatientListRequest, NuroServiceProto.NUR2016U02NuroPatientListResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NUR2016U02NuroPatientListHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2016U02NuroPatientListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016U02NuroPatientListRequest request) throws Exception {
		NuroServiceProto.NUR2016U02NuroPatientListResponse.Builder response = NuroServiceProto.NUR2016U02NuroPatientListResponse.newBuilder();
		List<NuroPatientInfo> patients = out1001Repository.getNuroPatientListInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getComingDate(),
                request.getDepartmentCode(), request.getDoctorCode(), request.getPatientCode(),
                request.getReceptionType(), request.getExamStatus(), request.getComingStatus(),request.getCurrentSystemId(), false);
		if(!CollectionUtils.isEmpty(patients)){
			List<String> bunhos = new ArrayList<String>();
			for(NuroPatientInfo item : patients){
				bunhos.add(item.getPatientCode());
			}
			
			List<NUR2016U02ActingDateAndSendYnInfo> actingDateAndSendYns = out1001Repository.getNUR2016U02ActingDateAndSendYn(getHospitalCode(vertx, sessionId), bunhos);
			for(NuroPatientInfo item : patients){
				NuroModelProto.NUR2016U02NuroPatientListItemInfo.Builder info = NuroModelProto.NUR2016U02NuroPatientListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 if(item.getReceptionCode() != null) {
					 info.setReceptionCode(String.format("%.0f", item.getReceptionCode()));
	             }
				 if(item.getOutResKey() != null) {
					 info.setOutResKey(String.format("%.0f", item.getOutResKey()));
	            }
				if(item.getLastComingDate() != null) {
					info.setLastComingDate(item.getLastComingDate().toString());
	            }
				if(!StringUtils.isEmpty(item.getTrialYn())) {
					info.setTrialYn(CommonEnum.O.getValue());
                }
                else{
                	info.setTrialYn(CommonEnum.MINUS_SIGN.getValue());
                }
				
				if(!CollectionUtils.isEmpty(actingDateAndSendYns)){
					for(NUR2016U02ActingDateAndSendYnInfo actingDateAndSendYn : actingDateAndSendYns){
						if(actingDateAndSendYn.getBunho().equalsIgnoreCase(item.getPatientCode())
								&& actingDateAndSendYn.getGwa().equalsIgnoreCase(item.getDepartmentCode())
								&& actingDateAndSendYn.getDoctor().equals(item.getDoctorCode())
								&&  item.getComingDate().compareTo(actingDateAndSendYn.getNaewonDate()) == 0){
							if(!StringUtils.isEmpty(actingDateAndSendYn.getIfDataSendYn()) && !"N".equals(actingDateAndSendYn.getIfDataSendYn())){
								info.setIfDataSentYn(CommonEnum.O.getValue());
							}else{
								info.setIfDataSentYn(CommonEnum.MINUS_SIGN.getValue());	
							}
							
							if(actingDateAndSendYn.getActingDate() == null){
								info.setActingDate(CommonEnum.ICON2_MULTI_LANGUAGE.getValue());
								break;
							}else if(actingDateAndSendYn.getActingDate() != null){
								info.setActingDate(CommonEnum.ICON3_MULTI_LANGUAGE.getValue());
							}
						}
					}
				}
				
				info.setIfDataSentYn(StringUtils.isEmpty(info.getIfDataSentYn()) ? CommonEnum.MINUS_SIGN.getValue() : info.getIfDataSentYn());
				info.setActingDate(StringUtils.isEmpty(info.getActingDate()) ? CommonEnum.ICON1_MULTI_LANGUAGE.getValue() : info.getActingDate());
				response.addPatientListItem(info);
			}
		}
		
		return response.build();
	}

}
