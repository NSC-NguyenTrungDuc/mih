package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out0101;
import nta.med.core.glossary.MaxSequence;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101PhrInsertRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class OUT0101PhrInsertHandler extends ScreenHandler<NuroServiceProto.OUT0101PhrInsertRequest,SystemServiceProto.UpdateResponse > {                     
	private static final Log LOGGER = LogFactory.getLog(OUT0101PhrInsertHandler.class);  
	
	 @Resource                                                                                                       
	 private CommonRepository commonRepository;     
	 @Resource
	 private Out0101Repository out0101Repository;
	                                                                                                                
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OUT0101PhrInsertRequest request)
			throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			String seqInc = commonRepository.getSeqInc("OUT0101_SEQ", getHospitalCode(vertx, sessionId));
            String nextSeq = commonRepository.getNextBunho("OUT0101_SEQ", seqInc, getHospitalCode(vertx, sessionId));
			if (!StringUtils.isEmpty(nextSeq)) {
				if((new BigDecimal(nextSeq).compareTo(MaxSequence.OUT0101_MAX_SEQUENCE.getValue())) == 1){
					response.setResult(false);
					throw new ExecutionException(response.build()); 
				}
			}
			
            if(!StringUtils.isEmpty(nextSeq)){
             String newBunho = StringUtils.leftPad(nextSeq, 9, "0");
             Out0101 out0101 = new Out0101();
             out0101.setHospCode(request.getHospCode());
             out0101.setBunho(newBunho);
             out0101.setUpdId(request.getUserName());
             out0101.setBunhoType("0");
             out0101.setSysDate(new Date());
             out0101.setSysId(request.getSysId());
             out0101Repository.save(out0101);
             response.setResult(true);
           }
            return response.build();
	}
}