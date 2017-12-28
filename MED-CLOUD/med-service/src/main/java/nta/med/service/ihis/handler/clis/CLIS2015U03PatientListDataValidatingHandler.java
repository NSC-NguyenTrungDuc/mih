package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out0101;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03PatientListDataValidatingRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03PatientListDataValidatingResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CLIS2015U03PatientListDataValidatingHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03PatientListDataValidatingRequest, ClisServiceProto.CLIS2015U03PatientListDataValidatingResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03PatientListDataValidatingHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;   
	@Resource
	private ClisProtocolPatientRepository clisProtocolPatientRepository;

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U03PatientListDataValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U03PatientListDataValidatingRequest request)
			throws Exception {
		ClisServiceProto.CLIS2015U03PatientListDataValidatingResponse.Builder response = ClisServiceProto.CLIS2015U03PatientListDataValidatingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<Out0101> listOut0101 = out0101Repository.getByBunho(hospCode, request.getBunho());
		if(CollectionUtils.isEmpty(listOut0101)){
			response.setErrMsg("1");
			throw new ExecutionException(response.build());
		}else{
			if(!StringUtils.isEmpty(listOut0101.get(0).getBunho())){
				response.setBunho(listOut0101.get(0).getBunho());
			}
			if(!StringUtils.isEmpty(listOut0101.get(0).getSuname())){
				response.setSuname(listOut0101.get(0).getSuname());
			}
			if(!StringUtils.isEmpty(listOut0101.get(0).getSuname2())){
				response.setSuname2(listOut0101.get(0).getSuname2());
			}
			Integer protpcolId = CommonUtils.parseInteger(request.getProtocolId());
			List<String> listResult = clisProtocolPatientRepository.getYByBunhoAndClisProtocolId(hospCode, request.getBunho(), protpcolId);
			if(CollectionUtils.isEmpty(listResult)){
				response.setErrMsg("2");
				throw new ExecutionException(response.build());
			}
		}
		return response.build();
	}                                                                                                                 
}