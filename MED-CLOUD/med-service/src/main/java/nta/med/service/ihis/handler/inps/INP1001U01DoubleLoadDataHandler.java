package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01DoubleLoadDataInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleLoadDataRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01DoubleLoadDataHandler extends ScreenHandler<InpsServiceProto.INP1001U01DoubleLoadDataRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01DoubleLoadDataRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		 List<INP1001U01DoubleLoadDataInfo> list = inp1001Repository.getINP1001U01DoubleLoadDataInfo(getHospitalCode(vertx, sessionId), request.getBunho(), "2");
		 if (!CollectionUtils.isEmpty(list)) {
			 for (INP1001U01DoubleLoadDataInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCheckY());
				info.setCodeName(CommonUtils.parseString(item.getPkinp1001()));
				response.addComboItem(info);
			}
		 }
		return response.build();
	}

}
