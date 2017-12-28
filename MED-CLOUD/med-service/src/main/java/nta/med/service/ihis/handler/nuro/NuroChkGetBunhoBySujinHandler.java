package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroChkGetBunhoBySujinInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroChkGetBunhoBySujinHandler extends ScreenHandler<NuroServiceProto.NuroChkGetBunhoBySujinRequest, NuroServiceProto.NuroChkGetBunhoBySujinResponse> {
	private static final Log LOG = LogFactory.getLog(NuroChkGetBunhoBySujinHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroChkGetBunhoBySujinResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroChkGetBunhoBySujinRequest request) throws Exception {
		NuroServiceProto.NuroChkGetBunhoBySujinResponse.Builder response = NuroServiceProto.NuroChkGetBunhoBySujinResponse.newBuilder();
		NuroChkGetBunhoBySujinInfo info	 = out1001Repository.getNuroChkGetBunhoBySujinInfo(getHospitalCode(vertx, sessionId), request.getNaewonDate(), request.getSujinNo());
    	if(info != null ){
    		NuroModelProto.NuroChkGetBunhoBySujinInfo.Builder itemBuilder = NuroModelProto.NuroChkGetBunhoBySujinInfo.newBuilder();
    		BeanUtils.copyProperties(info, itemBuilder, getLanguage(vertx, sessionId));
    		response.setItemInfo(itemBuilder);
    	}
		return response.build();
	}

}
