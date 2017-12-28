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
import nta.med.data.dao.medi.ifs.Ifs3014Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSangTransRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSangTransResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSSangTransHandler extends ScreenHandler<InpsServiceProto.INPORDERTRANSSangTransRequest, InpsServiceProto.INPORDERTRANSSangTransResponse>{
	@Resource
	private Ifs3014Repository ifs3014Repository;

	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSSangTransResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSangTransRequest request) throws Exception {
		InpsServiceProto.INPORDERTRANSSangTransResponse.Builder response = InpsServiceProto.INPORDERTRANSSangTransResponse.newBuilder();
		List<Double> pkifs3014s = ifs3014Repository.getINPORDERTRANSSangTrans(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkINP3010()), request.getTransGubun());
		if (!CollectionUtils.isEmpty(pkifs3014s)) {
			CommonModelProto.DataStringListItemInfo .Builder info = CommonModelProto.DataStringListItemInfo .newBuilder();
			for (Double item : pkifs3014s) {
				info.setDataValue(CommonUtils.parseString(item));
				response.addPkifs3014List(info);
			}
		}
		return response.build();
	}

}
