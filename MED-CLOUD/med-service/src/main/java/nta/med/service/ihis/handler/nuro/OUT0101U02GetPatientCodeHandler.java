package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.MaxSequence;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02GetPatientCodeRequest;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02GetPatientCodeResponse;

@Service
@Scope("prototype")
@Transactional
public class OUT0101U02GetPatientCodeHandler
		extends ScreenHandler<OUT0101U02GetPatientCodeRequest, OUT0101U02GetPatientCodeResponse> {
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Route(global = false)
	public OUT0101U02GetPatientCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUT0101U02GetPatientCodeRequest request) throws Exception {
		
		NuroServiceProto.OUT0101U02GetPatientCodeResponse.Builder response = NuroServiceProto.OUT0101U02GetPatientCodeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String autoGen = bas0001Repository.checkAutoGenHospital(hospCode, language);
		response.setResult(true);
		response.setAutoBunhoFlg(autoGen);
		
		if ("Y".equals(request.getGetPatientCodeYn()) && autoGen.equals("1")) {
			List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
			boolean useOrcaCloud = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
			String nextSeq = "";
			String seqInc = commonRepository.getSeqInc("OUT0101_SEQ", hospCode);
			//nextSeq = useOrcaCloud ? "*" : commonRepository.getNextBunho("OUT0101_SEQ", seqInc, hospCode);
			if(useOrcaCloud) {
				nextSeq = "*";
			} else {
				nextSeq = commonRepository.getNextBunho("OUT0101_SEQ", seqInc, hospCode);
				if (!StringUtils.isEmpty(nextSeq)) {
					if((new BigDecimal(nextSeq).compareTo(MaxSequence.OUT0101_MAX_SEQUENCE.getValue())) == 1){
						response.setResult(false);
						throw new ExecutionException(response.build()); 
					}
				}
			}
			
			if (!StringUtils.isEmpty(nextSeq)) {
				response.setResult(true);
				response.setPatientCode(nextSeq);
			}
		}
		
		return response.build();
	}
}