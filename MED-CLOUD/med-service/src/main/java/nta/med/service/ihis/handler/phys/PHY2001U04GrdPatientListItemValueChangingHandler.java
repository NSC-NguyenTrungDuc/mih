package nta.med.service.ihis.handler.phys;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class PHY2001U04GrdPatientListItemValueChangingHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingRequest, PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingResponse>{                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;  
	@Resource
	private Ocs1003Repository ocs1003Repository;
	                                                                                                                
	@Override                                                                                                       
	public PHY2001U04GrdPatientListItemValueChangingResponse handle(
			Vertx vertx, String clientId, String sessionId, long contextId,
			PHY2001U04GrdPatientListItemValueChangingRequest request)
			throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingResponse.Builder response = PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
  	   	Integer updateResult = null;
  	   	String result = null;
		String resultMsg = null;
		String getPreviousValue = request.getPreviousValue();
		String getChangeValue = request.getChangedValue();
		Double fkOut1001 = CommonUtils.parseDouble(request.getFkout1001());
		if("20".equalsIgnoreCase(getPreviousValue) || "21".equalsIgnoreCase(getPreviousValue) || "22".equalsIgnoreCase(getPreviousValue)){
			if(request.getCbxSinryouryou()){
				Date iOrderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
				 ComboListItemInfo info =  ocs1003Repository.callPrRehAddRehasinryouryou(hospCode, language,
						 iOrderDate, request.getBunho(), fkOut1001, request.getDoctor(), getPreviousValue,
						request.getInputId(), request.getInputTab(), "D");
				 if(info !=null && !"1".equalsIgnoreCase(info.getCode())){
					 result =  info.getCode();
					 response.setResultMsg(info.getCodeName());
					 throw new ExecutionException(response.build());
				 }
			}
		}
		
		if("20".equalsIgnoreCase(getChangeValue) || "21".equalsIgnoreCase(getChangeValue) || "22".equalsIgnoreCase(getChangeValue)){
			if(request.getCbxSinryouryou()){
				Date iOrderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
				 ComboListItemInfo info =  ocs1003Repository.callPrRehAddRehasinryouryou(hospCode, language,
						 iOrderDate, request.getBunho(), fkOut1001, request.getDoctor(), getChangeValue,
						request.getInputId(), request.getInputTab(), "I");
				 if(info !=null && !"1".equalsIgnoreCase(info.getCode())){
					 result =  info.getCode();
					 resultMsg = info.getCodeName();
					 throw new ExecutionException(response.build());
				 }
			}
		}
		Double pkout1001 = CommonUtils.parseDouble(request.getFkout1001());
		updateResult = out1001Repository.updatePhyWherePkout1001(hospCode, request.getUserId(), 
		request.getNaewonYn(), request.getArriveTime(), request.getJubsuGubun(), pkout1001);
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		if(!StringUtils.isEmpty(resultMsg)){
			response.setResultMsg(resultMsg);
		}
		if(updateResult == null){
			response.setSuccess(false);
		}else{
			response.setSuccess(true);
		}
		return response.build();
	}

}