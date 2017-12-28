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
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.model.ihis.inps.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse;

@Service
@Scope("prototype")
public class INPBATCHTRANSgrdInpListQueryStartingrbnMiTransHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransRequest, InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse>{
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INPBATCHTRANSgrdInpListQueryStartingrbnMiTransRequest request) throws Exception {
		
		InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse.Builder response = InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransResponse.newBuilder();
		List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> list = inp1002Repository.getINPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getFromDate(), request.getQueryDate(), request.getHoDong1());
		
		if(CollectionUtils.isEmpty(list)){
			return response.build();
		}
		
		for (INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo item : list) {
			InpsModelProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.Builder info = InpsModelProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
