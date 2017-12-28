package nta.med.orca.gw.service.order.impl;

import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;

import nta.med.common.glossary.Lifecyclet;
import nta.med.ext.support.proto.OrderServiceProto;
import nta.med.ext.support.service.order.OrderRpcService;
import nta.med.orca.gw.api.command.MedicalModCommand;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.api.contracts.service.MedicalModRequest;
import nta.med.orca.gw.api.contracts.service.MedicalModResponse;
import nta.med.orca.gw.service.order.OrderAdministrator;
import nta.med.orca.gw.service.patient.impl.PatientAdministratorImpl;
import nta.med.orca.gw.service.system.SystemAdministrator;

@Component("orderAdministrator")
public class OrderAdministratorImpl extends Lifecyclet implements OrderAdministrator, OrderRpcService.Service {

	private static final Log LOGGER = LogFactory.getLog(OrderAdministratorImpl.class);
	
	@Resource
	private OrderRpcService orderRpcService;
	
    @Resource
    private SystemAdministrator systemAdministrator;
	
    @Resource
    private MedicalModCommand medicalModCommand;
	
	public OrderAdministratorImpl(){
		
	}
	
	@Override
	public boolean updatePaidOrder(String hospCode, String receptionDate, List<String> refIdList) {
		OrderServiceProto.UpdatePaidOrderRequest.Builder request = OrderServiceProto.UpdatePaidOrderRequest.newBuilder();
		request.setHospCode(hospCode);
		request.setReceptionDate(receptionDate);
		request.addAllReceptRefId(refIdList);
		
		OrderServiceProto.UpdatePaidOrderResponse response = orderRpcService.updatePaidOrder(request.build());
		return response == null ? false : response.getResult();
	}

	@Override
	protected void doStart() throws Exception {
		
	}

	@Override
	protected long doStop(long timeout, TimeUnit timeUnit) throws Exception {
		return timeout;
	}

	@Override
	public OrderServiceProto.OrderTranferResponse orderTranfer(OrderServiceProto.OrderTranferRequest request) throws Exception {
		OrderServiceProto.OrderTranferResponse.Builder response = OrderServiceProto.OrderTranferResponse.newBuilder();
		response.setId(request.getId());
		response.setHospCode(request.getHospCode());
		response.setResult(true);
		
		MedicalModRequest medicalModRequest = new MedicalModRequest();
		medicalModRequest.copyFromProto(request);
		
		OrcaEnvInfo orcaEnvInfo = getOrcaInfo(request.getHospCode());
		medicalModRequest.setOrcaEnvInfo(orcaEnvInfo);
		
		MedicalModResponse rp = null;
		try {
			rp = medicalModCommand.execute(medicalModRequest);
		} catch (Exception e) {
			LOGGER.warn("FAIL TO CALL ORCA API: ", e);
			rp = null;
		}
		
		if(rp == null){
			LOGGER.info("CALL ORCA API To Transfer Order - RESPONSE = NULL");
			response.setResult(false);
			return response.build();
		}
		
		LOGGER.info("CALL ORCA API To Transfer Order, Api_Result = " + rp.getApiResult() + ", Message " + rp.getApiResultMessage());
		if(rp.getMedicalMessageInformation() != null)
			LOGGER.info("CALL ORCA API To Transfer Order, Medical_Result = " + rp.getMedicalMessageInformation().getMedicalResult() + ", Message " + rp.getMedicalMessageInformation().getMedicalResultMessage());
		if(rp.getDiseaseMessageInformation() != null)
			LOGGER.info("CALL ORCA API To Transfer Order, Disease_Result = " + rp.getDiseaseMessageInformation().getDiseaseResult() + ", Message " + rp.getDiseaseMessageInformation().getDiseaseResultMessage());
		
		if(rp.getApiResult() != null){
			response.setApiResult(rp.getApiResult());
		}
		
		if(rp.getApiResultMessage() != null){
			response.setApiResultMessage(rp.getApiResultMessage());
		}
		
		if(rp.getMedicalUid() != null){
			response.setMedicalUid(rp.getMedicalUid());
		}
		
		if(rp.getMedicalMessageInformation() != null){
			if(rp.getMedicalMessageInformation().getMedicalResult() != null){
				response.setMedicalResult(rp.getMedicalMessageInformation().getMedicalResult());
			}
			
			if(rp.getMedicalMessageInformation().getMedicalResultMessage() != null){
				response.setMedicalResultMessage(rp.getMedicalMessageInformation().getMedicalResultMessage());
			}
		}
		
		if(rp.getDiseaseMessageInformation() != null){
			if(rp.getDiseaseMessageInformation().getDiseaseResult() != null){
				response.setDiseaseResult(rp.getDiseaseMessageInformation().getDiseaseResult());
			}
			
			if(rp.getDiseaseMessageInformation().getDiseaseResultMessage() != null){
				response.setDiseaseResultMessage(rp.getDiseaseMessageInformation().getDiseaseResultMessage());
			}
		}
		
		response.setResult(true);
		return response.build();
	}

	private OrcaEnvInfo getOrcaInfo(String gigwanCode) throws Exception {
        return systemAdministrator.findOrcaInfoByGigwanCode(gigwanCode);
    }
}
