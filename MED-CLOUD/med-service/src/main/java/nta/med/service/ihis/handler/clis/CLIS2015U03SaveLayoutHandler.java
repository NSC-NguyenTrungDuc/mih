package nta.med.service.ihis.handler.clis;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.clis.ClisProtocolPatient;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U03PatientListInfo;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class CLIS2015U03SaveLayoutHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private ClisProtocolPatientRepository clisProtocolPatientRepository;                                                                    

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U03SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String sysId = request.getUserId();
		List<CLIS2015U03PatientListInfo> listPatient = request.getPatientListItemList();
		Integer result = null;
		if(!CollectionUtils.isEmpty(listPatient)){
			for(CLIS2015U03PatientListInfo item : listPatient){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					insertClisProtocolPatient(item, hospCode, sysId);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					Integer clisProtocolId = CommonUtils.parseInteger(item.getClisProtocolId());
					result = clisProtocolPatientRepository.updateClisProtocolPatient(sysId, new Date(), clisProtocolId, item.getBunho());
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertClisProtocolPatient(item, hospCode, sysId);
				} else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					Integer clisProtocolId = CommonUtils.parseInteger(item.getClisProtocolId());
					result = clisProtocolPatientRepository.updateClisProtocolPatient(sysId, new Date(), clisProtocolId, item.getBunho());
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		response.setResult(true);
		return response.build();
	}  
	public void insertClisProtocolPatient(CLIS2015U03PatientListInfo item, String hospCode, String sysId){
		ClisProtocolPatient clisProtocolPatient = new ClisProtocolPatient();
		Integer clisProtocolId = CommonUtils.parseInteger(item.getClisProtocolId());
		Date date = new Date();
		clisProtocolPatient.setClisProtocolId(clisProtocolId);
		clisProtocolPatient.setBunho(item.getBunho());
		clisProtocolPatient.setHospCode(hospCode);
		clisProtocolPatient.setSysId(sysId);
		clisProtocolPatient.setCreated(new Timestamp(date.getTime()));
		clisProtocolPatient.setActiveFlg(new BigDecimal("1"));
		clisProtocolPatientRepository.save(clisProtocolPatient);
	}
}