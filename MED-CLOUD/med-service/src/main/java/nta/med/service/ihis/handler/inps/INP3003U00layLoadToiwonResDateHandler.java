package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP3003U00layLoadToiwonResDateInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00layLoadToiwonResDateRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00layLoadToiwonResDateResponse;

@Service
@Scope("prototype")
public class INP3003U00layLoadToiwonResDateHandler extends ScreenHandler<InpsServiceProto.INP3003U00layLoadToiwonResDateRequest, InpsServiceProto.INP3003U00layLoadToiwonResDateResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP3003U00layLoadToiwonResDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00layLoadToiwonResDateRequest request) throws Exception {
		InpsServiceProto.INP3003U00layLoadToiwonResDateResponse.Builder response = InpsServiceProto.INP3003U00layLoadToiwonResDateResponse.newBuilder();
		List<INP3003U00layLoadToiwonResDateInfo> toiwonRes = inp1001Repository.getINP3003U00layLoadToiwonResDateInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkinp1001()));
		if(!CollectionUtils.isEmpty(toiwonRes)){
			for(INP3003U00layLoadToiwonResDateInfo item : toiwonRes){
				InpsModelProto.INP3003U00layLoadToiwonResDateInfo.Builder info = InpsModelProto.INP3003U00layLoadToiwonResDateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
