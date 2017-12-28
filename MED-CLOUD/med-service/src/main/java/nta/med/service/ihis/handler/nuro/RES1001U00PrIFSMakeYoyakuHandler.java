package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs1002Repository;
import nta.med.data.model.ihis.nuro.RES1001U00PrIFSMakeYoyakuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class RES1001U00PrIFSMakeYoyakuHandler extends ScreenHandler<NuroServiceProto.RES1001U00PrIFSMakeYoyakuRequest, NuroServiceProto.RES1001U00PrIFSMakeYoyakuResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(RES1001U00PrIFSMakeYoyakuHandler.class);                                    
	@Resource                                                                                                       
	private Ifs1002Repository ifs1002Repository;                                                                    

	@Override
	public NuroServiceProto.RES1001U00PrIFSMakeYoyakuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00PrIFSMakeYoyakuRequest request) throws Exception {
		NuroServiceProto.RES1001U00PrIFSMakeYoyakuResponse.Builder response = NuroServiceProto.RES1001U00PrIFSMakeYoyakuResponse.newBuilder();
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		RES1001U00PrIFSMakeYoyakuInfo info = ifs1002Repository.callRES1001U00PrIFSMakeYoyaku(getHospitalCode(vertx, sessionId), pkout1001, request.getProcGubun(), request.getYoyakuGubun(), 
				request.getIoGubun(), request.getUserId(), request.getBunho(), request.getGwa(), request.getDoctor(), request.getNaewonDate(), request.getJubsuTime());
		if(info != null){
			if (info.getPkifs1002() != null) {
				response.setPkifs1002(String.format("%.0f",info.getPkifs1002()));
			}
			if(!StringUtils.isEmpty(info.getErrMsg())){
				response.setErrMsg(info.getErrMsg());
				if(!"O".equalsIgnoreCase(info.getErrMsg())){
					throw new ExecutionException(response.build());
				}
			}
		}
		return response.build();
	}                                                                                                                 
}