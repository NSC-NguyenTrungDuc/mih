package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckUsingOrcaRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckUsingOrcaResponse;

@Service
@Scope("prototype")
public class RES1001U00CheckUsingOrcaHandler extends ScreenHandler<NuroServiceProto.RES1001U00CheckUsingOrcaRequest, NuroServiceProto.RES1001U00CheckUsingOrcaResponse>{
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U00CheckUsingOrcaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U00CheckUsingOrcaRequest request) throws Exception {
		
		NuroServiceProto.RES1001U00CheckUsingOrcaResponse.Builder response = NuroServiceProto.RES1001U00CheckUsingOrcaResponse.newBuilder();
		List<Bas0102> checkAccTypes = bas0102Repository.findByHospCodeAndCodeType(request.getHospCodeLink(), AccountingConfig.ACCT_TYPE.getValue());
		if(!CollectionUtils.isEmpty(checkAccTypes)){
			if(AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(checkAccTypes.get(0).getCode())){
				response.setAccType(checkAccTypes.get(0).getCode());
				List<Bas0102> orcaInfos = bas0102Repository.findByHospCodeAndCodeType(request.getHospCodeLink(), AccountingConfig.ACCT_ORCA.getValue());
				if(!CollectionUtils.isEmpty(orcaInfos)){
					for(Bas0102 orcaInfo : orcaInfos)
			        {
			    		if(orcaInfo.getCode().equals(AccountingConfig.ORCA_IP.getValue()))
			            {
			    			response.setOrcaIp(orcaInfo.getCodeName());
			            }
			            else if(orcaInfo.getCode().equals(AccountingConfig.ORCA_USER.getValue()))
			            {
			            	response.setOrcaUser(orcaInfo.getCodeName());
			            }
			            else if(orcaInfo.getCode().equals(AccountingConfig.ORCA_PWD.getValue()))
			            {
			            	response.setOrcaPassword(orcaInfo.getCodeName());
			            }
			        }
				}
			}else{
				if(!StringUtils.isEmpty(checkAccTypes.get(0).getCode())){
					response.setAccType(checkAccTypes.get(0).getCode());
				}
			}
		}
		return response.build();
	}

}
